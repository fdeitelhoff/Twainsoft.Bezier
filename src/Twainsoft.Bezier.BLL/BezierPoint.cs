using System;
using System.ComponentModel;
using System.Drawing;

namespace Twainsoft.Bezier.BLL
{
    public class BezierPoint : INotifyPropertyChanged
    {
        public double X { get; set; }
        public double Y { get; set; }

        public BezierPoint()
        {
            X = 0;
            Y = 0;
        }

        public BezierPoint(double x, double y) : this()
        {
            X = x;
            Y = y;
        }

        public BezierPoint(Point point) : this(point.X, point.Y) { }

        public static BezierPoint operator *(double value, BezierPoint bezierPoint)
        {
            return new BezierPoint(value * bezierPoint.X, value * bezierPoint.Y);
        }

        public static BezierPoint operator *(BezierPoint bezierPoint, double value)
        {
            return new BezierPoint(value * bezierPoint.X, value * bezierPoint.Y);
        }

        public static BezierPoint operator +(BezierPoint bezierPointLeft, BezierPoint bezierPointRight)
        {
            return new BezierPoint(bezierPointLeft.X + bezierPointRight.X, bezierPointLeft.Y + bezierPointRight.Y);
        }

        public override string ToString()
        {
            return String.Format("BezierPoint (X={0}, Y={1})", new object[] { X, Y });
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}