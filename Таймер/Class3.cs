using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Таймер
{
    class Button
    {
        bool state;
        int x, y, size;
        static Graphics Form;
        public Button(bool _state, int _x, int _y, int _size)
        {
            state = _state;
            x = _x; y = _y;
            size = _size;
        }

        public bool getState(){
            return state;
        }
        public void setState(bool _state)
        {
            state = _state;
        }

        public void Draw(Graphics g)
        {
            Form = g;
            if (state) {
                DrawStart(g);
            } else {
                DrawEnd(g);
            }
        }

        public void DrawStart(Graphics g)
        {
            Pen greenPen = new Pen(Color.Green, 3);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(SystemColors.Control);

            Point point1 = new Point(x - size / 2, y + 50);
            Point point2 = new Point(x - size / 2, y + size - 50);
            Point point3 = new Point(x - 50, y + size / 2);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3
             };

            g.FillRectangle(myBrush, x - size + 60, y, x, y + size);
            g.DrawPolygon(greenPen, curvePoints);
            g.FillPolygon(Brushes.Green, curvePoints);
        }

        public void DrawEnd(Graphics g)
        {
            Pen redPen = new Pen(Color.Red, 3);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(SystemColors.Control);

            int plus = (int)(0.4 * size);
            int plus2 = (int)(0.3 * size);
            Point point1 = new Point(x - size / 2, y + plus);
            Point point2 = new Point(x - size / 2, y + size - plus);
            Point point3 = new Point(x - plus2, y + size - plus);
            Point point4 = new Point(x - plus2, y + plus);
            Point[] curvePoints =
                     {
                 point1,
                 point2,
                 point3,
                 point4
        };

            g.FillRectangle(myBrush, x - size + 60, y, x, y + size);
            g.DrawPolygon(redPen, curvePoints);
            g.FillPolygon(Brushes.Red, curvePoints);
        }

        private bool isInside(int _x, int _y){
            int isInsideX = x - size / 2;
            return (_x > isInsideX && _x < isInsideX + size) && (_y > y && _y < y + size);
        }
        public void Click(int _x, int _y)
        {
            if(isInside(_x, _y)){
                state = !state;
                Draw(Form);
            }
        }
    }
}
