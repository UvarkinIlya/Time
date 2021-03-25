using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Таймер
{
    class Clock
    {
        int seconds = 0;
        Pen ciclePen = new Pen(Color.Black, 3);
        const float fontSize = 24;
        int TabFontSize = (int)fontSize / 2;
        Font numberFont = new Font("Arial", fontSize);//fontSize = 12
        int x, y; //Координаты середины
        int radius, diameter;
        int PointTopLeftX, PointTopLeftY;
        int[] arrX = new int[60];//Координаты второй точки по X стрелки
        int[] arrY = new int[60];//Координаты второй точки по Y стрелки
        System.Windows.Forms.Timer Timer = new System.Windows.Forms.Timer();
        static Graphics Form;
        int interval;
        int prevDelta = 0;

        public Clock(int _x, int _y, int _diameter, int _interval)
        {
            x = _x; y = _y;
            diameter = _diameter;
            interval = _interval;
            radius = diameter / 2;
            PointTopLeftX = x - radius;
            PointTopLeftY = y - radius;
            SetXY();
            InitializationTimer();
        }

        internal void MouseWheel(int delta)
        {
            delta = (int)delta / 120;
            int dif = Math.Abs(delta - prevDelta);
            seconds = Math.Abs(seconds - dif) % 60;
            prevDelta = delta;
        }

        internal bool Inside(int pointX, int pointY)
        {
            return radius > Math.Sqrt(Math.Abs(x - pointX) * Math.Abs(x - pointX) +
                                      Math.Abs(y - pointY) + Math.Abs(y - pointY));
        }


        

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            seconds++;
            //Pen ciclePen = new Pen(Color.Black, 3);
            //Form.DrawLine(ciclePen, x, y, arrX[seconds % 12] /*+ radius - fontSize*/, arrY[seconds % 12]);
            Draw(Form);
        }

        private void InitializationTimer()
        {
            Timer.Tick += new EventHandler(TimerEventProcessor);
            Timer.Interval = interval;
            Timer.Start();
        }

        internal void Draw(Graphics g)
        {
            Form = g;
            g.FillEllipse(Brushes.White, PointTopLeftX, PointTopLeftY, diameter, diameter);
            g.DrawEllipse(ciclePen, PointTopLeftX, PointTopLeftY, diameter, diameter);

            g.DrawString("12", numberFont, Brushes.Black, x - fontSize, y - radius);
            g.DrawString(" 3", numberFont, Brushes.Black, x + radius - (fontSize + TabFontSize), y - fontSize + 4);
            g.DrawString(" 6", numberFont, Brushes.Black, x - fontSize, y + radius - (fontSize + TabFontSize));
            g.DrawString(" 9", numberFont, Brushes.Black, x - radius - (fontSize - TabFontSize), y - fontSize + 4);


            /*int _x = x + (int)(0.5 * (radius - fontSize));
            int _y = y + (int)(-root3 * (radius - fontSize));seconds % 12*/
            Form.DrawLine(ciclePen, x, y, arrX[seconds % 60] /*+ radius - fontSize*/, arrY[seconds % 60]);
        }

        private void SetXY(){
            for(int i = 0; i < 60; i++){
                arrX[i] = x + (int)(Math.Cos((Math.PI / 2) - i * Math.PI / 30) * (radius - fontSize));
                arrY[i] = y - (int)(Math.Sin((Math.PI / 2) - i * Math.PI / 30) * (radius - fontSize));
            }
        }
    }
}
