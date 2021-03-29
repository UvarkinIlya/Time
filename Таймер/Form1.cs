using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Таймер
{
    public partial class Form1 : Form
    {
        Boolean flag;
        Timer timer2;
        Timer timer3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            /*clock1.MouseWheel(e.Delta);

            if (clock1.Inside(e.X, e.Y)){
                Thread.Sleep(2000);
                clock1.MouseWheel(e.Delta);
            }
            if (clock2.Inside(e.X, e.Y))
            {
                Thread.Sleep(2000);
                clock2.MouseWheel(e.Delta);
            }
            if (clock3.Inside(e.X, e.Y))
            {
                clock3.MouseWheel(e.Delta);
            }*/
        }

        private void Form1_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            timer2.Inside(e.X, e.Y, e);
            timer3.Inside(e.X, e.Y, e);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (flag) return;
            timer2.Draw(g);
            timer3.Draw(g);
            flag = true;
        }

        public Form1()
        {
            InitializeComponent();
            timer2 = new Timer(200, 200, 200);
            timer3 = new Timer(200, 500, 150);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            timer2.InsideButton(e.X, e.Y);
            timer3.InsideButton(e.X, e.Y);
        }
    }
}
