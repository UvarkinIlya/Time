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
        Clock clock1, clock2, clock3;
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
            if (clock1.Inside(e.X, e.Y))
            {
                clock1.MouseWheel(e.Delta);
                //Thread.Sleep(1000);
                Invalidate();
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            if (flag) return;
            clock1.Draw(g);
            clock2.Draw(g);
            flag = true;
        }

        public Form1()
        {
            InitializeComponent();
            clock1 = new Clock(200, 200, 200, 1000);
            clock2 = new Clock(400, 400, 200, 60000);
        }
    }
}
