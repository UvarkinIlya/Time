using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Таймер
{
    class Timer
    {
        Clock clock1, clock2, clock3;
        Button button;
        const int SizeArrClock = 3;
        Clock[] arrClock = new Clock[SizeArrClock];
        const int second = 1000;
        const int tab = 50;
        System.Windows.Forms.Timer Time = new System.Windows.Forms.Timer();
        int interval = 200;
        static Graphics Form;
        bool globalFlag = true;

        public Timer(int start_x, int start_y, int diameter)
        {
            int Interval;
            for (int i = 0; i < SizeArrClock; i++)
            {
                Interval = second * 60 * i != 0 ? second * 60 * i : second;
                arrClock[i] = new Clock(start_x + i * (diameter + tab), start_y, diameter, Interval);
            }

            button = new Button(true, start_x + SizeArrClock * (diameter + tab), start_y - diameter / 2, diameter);
            InitializationTimer();
        }

        public void IntitArrClock()
        {
            arrClock[0] = clock1;
            arrClock[1] = clock2;
            arrClock[2] = clock3;
        }

        public void Draw(Graphics g)
        {
            Form = g;

            foreach (Clock clock in arrClock)
            {
                clock.Draw(g);
            }
            button.Draw(g);
        }

        public void Inside(int x, int y, System.Windows.Forms.MouseEventArgs e)
        {
            foreach (Clock clock in arrClock)
            {
                if (clock.Inside(x, y))
                {
                    clock.MouseWheel(e.Delta);
                }
            }
        }

        public void InsideButton(int x, int y)
        {
            bool flag = button.getState();
            button.Click(x, y);
            if (flag != button.getState()){
                if (flag){
                    stopClock();
                } else {
                    startClock();
                }
            }
        }

        private void startClock(){
            button.DrawStart(Form);
            foreach (Clock clock in arrClock)
            {
                clock.TimerStart();
            }
            //arrClock[0].setSeconds(55);
            button.setState(true);
            globalFlag = true;
        }

        private void stopClock(){
            button.DrawEnd(Form);
            foreach (Clock clock in arrClock)
            {
                clock.TimerStop();
            }
            button.setState(false);
            globalFlag = false;
        }

        private void InitializationTimer()
        {
            Time.Tick += new EventHandler(StopTimer);
            Time.Interval = interval;
            Time.Start();
        }

        private bool IsTimerEnd(){
            bool flag = true;

            foreach (Clock clock in arrClock)
            {
                if (clock.getSeconds() % 60 != 0)
                {
                    flag = false;
                }
            }

            return flag;
        }

        private void StopTimer(object sender, EventArgs e)
        {
            if (IsTimerEnd() && globalFlag){
                stopClock();
                globalFlag = false;
            }
        }
    }
}
