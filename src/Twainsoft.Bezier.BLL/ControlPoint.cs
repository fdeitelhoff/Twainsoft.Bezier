#region Namespaces

using System;

#endregion

namespace Twainsoft.FHSWF.Math.Bezier
{
    public class ControlPoint : BezierPoint
    {
        public int Number { get; set; }
        public Rectangle MoveRectangle { get; private set; }
        public bool IsSelected { get; set; }
        public bool IsMoving { get; set; }
        public bool IsHovering { get; set; }

        public ControlPoint() { }

        public ControlPoint(int number, Point point) : base(point)
        {
            this.Number = number;

            this.CreateMoveRectangle();
        }

        private void CreateMoveRectangle()
        {
            this.MoveRectangle = new Rectangle((int)this.X - 4, (int)this.Y - 4, 10, 10);
        }

        public void Draw(Graphics graphics)
        {
            if (this.IsSelected)
                graphics.DrawRectangle(Pens.Red, this.MoveRectangle);

            if (this.IsHovering)
            {
                graphics.DrawRectangle(Pens.Red, this.MoveRectangle);
                this.DrawControlPoint(graphics, Pens.Red, Brushes.Red);
            }
            else
            {
                this.DrawControlPoint(graphics, Pens.Black, Brushes.Black);
            }

            if (this.IsMoving)
            {
                graphics.DrawRectangle(Pens.LightBlue, this.MoveRectangle);

                this.DrawControlPoint(graphics, Pens.LightBlue, Brushes.Gray);
            }
        }

        private void DrawControlPoint(Graphics graphics, Pen pen, Brush brush)
        {
            graphics.DrawRectangle(pen, (float)this.X, (float)this.Y, 2, 2);
            graphics.FillRectangle(brush, (float)this.X, (float)this.Y, 2, 2);
            graphics.DrawString(String.Format("[{0}]", this.Number), new Font("Arial", 8), brush, new PointF((float)this.X + 2, (float)this.Y + 2));
        }

        internal bool IsMouseHover(MouseEventArgs e)
        {
            return this.MoveRectangle.Contains(e.Location);
        }

        public void SetNewPosition(Point newLocation)
        {
            this.X = newLocation.X;
            this.Y = newLocation.Y;

            this.CreateMoveRectangle();

            this.OnPropertyChanged("X");
        }

        public override string ToString()
        {
            return String.Format("{0}. ControlPoint (X={1}, Y={2})", new object[] { this.Number, this.X, this.Y });
        }
    }
}