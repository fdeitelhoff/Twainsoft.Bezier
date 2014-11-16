using System;
using System.Drawing;
using System.Windows.Forms;

namespace Twainsoft.Bezier.BLL
{
    public class ControlPoint : BezierPoint
    {
        public int Number { get; set; }
        private Rectangle MoveRectangle { get; set; }
        public bool IsSelected { get; set; }
        public bool IsMoving { get; set; }
        public bool IsHovering { get; set; }

        public ControlPoint(int number, Point point) : base(point)
        {
            Number = number;

            CreateMoveRectangle();
        }

        private void CreateMoveRectangle()
        {
            MoveRectangle = new Rectangle((int)X - 4, (int)Y - 4, 10, 10);
        }

        public void Draw(Graphics graphics)
        {
            if (IsSelected)
                graphics.DrawRectangle(Pens.Red, MoveRectangle);

            if (IsHovering)
            {
                graphics.DrawRectangle(Pens.Red, MoveRectangle);
                DrawControlPoint(graphics, Pens.Red, Brushes.Red);
            }
            else
            {
                DrawControlPoint(graphics, Pens.Black, Brushes.Black);
            }

            if (IsMoving)
            {
                graphics.DrawRectangle(Pens.LightBlue, MoveRectangle);

                DrawControlPoint(graphics, Pens.LightBlue, Brushes.Gray);
            }
        }

        private void DrawControlPoint(Graphics graphics, Pen pen, Brush brush)
        {
            graphics.DrawRectangle(pen, (float)X, (float)Y, 2, 2);
            graphics.FillRectangle(brush, (float)X, (float)Y, 2, 2);
            graphics.DrawString(string.Format("[{0}]", Number), new Font("Arial", 8), brush, new PointF((float)X + 2, (float)Y + 2));
        }

        internal bool IsMouseHover(MouseEventArgs e)
        {
            return MoveRectangle.Contains(e.Location);
        }

        public void SetNewPosition(Point newLocation)
        {
            X = newLocation.X;
            Y = newLocation.Y;

            CreateMoveRectangle();

            OnPropertyChanged("X");
        }

        public override string ToString()
        {
            return string.Format("{0}. ControlPoint (X={1}, Y={2})", new object[] { Number, X, Y });
        }
    }
}