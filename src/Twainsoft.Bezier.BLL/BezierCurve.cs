using System.Collections.Generic;

namespace Twainsoft.FHSWF.Math.Bezier
{ 
    public class BezierCurve
    {
        private List<ControlPoint> ControlPoints { get; set; }
        private BezierPoint[] BezierPoints { get; set; }
        public int TCount { get; private set; }
        public bool ConnectPoints { get; set; }

        public BezierCurve()
        {
            this.ControlPoints = new List<ControlPoint>();

            this.TCount = 1000;
        }

        public ControlPoint AddControlPoint(Point point)
        {
            ControlPoint controlPoint = new ControlPoint(this.ControlPoints.Count + 1, point);

            this.ControlPoints.Add(controlPoint);

            this.CalculateCurve();

            return controlPoint;
        }

        public void CalculateCurve()
        {
            if (this.ControlPoints.Count == 0)
            {
                this.BezierPoints = null;
                return;
            }

            int n = this.ControlPoints.Count - 1;

            ControlPoint[] controlPointArray = this.ControlPoints.ToArray();

            this.BezierPoints = new BezierPoint[this.TCount];
            this.BezierPoints[0] = controlPointArray[0];

            int calcs = 1;
            for (decimal t = 1 / (decimal)this.TCount; t <= ((decimal)this.TCount - 1) / this.TCount; t += 1 / (decimal)this.TCount)
            {
                BezierPoint result = new BezierPoint();

                for (int i = 0; i <= n; i++)
                {
                    result += (this.CalculateBinomial(n, i) * System.Math.Pow((double)t, i) * System.Math.Pow(1 - (double)t, n - i)) * controlPointArray[i];
                }

                this.BezierPoints[calcs++] = result;
            }

            this.BezierPoints[this.TCount - 1] = controlPointArray[n];
        }

        private void DrawControlsPoints(Graphics graphics)
        {
            ControlPoint previousControlPoint = null;
            foreach (var controlPoint in this.ControlPoints)
            {
                controlPoint.Draw(graphics);

                if (previousControlPoint != null)
                {
                    graphics.DrawLine(Pens.Black, new Point((int)previousControlPoint.X, (int)previousControlPoint.Y),
                        new Point((int)controlPoint.X, (int)controlPoint.Y));
                }

                previousControlPoint = controlPoint;
            }
        }

        private int CalculateBinomial(int n, int k)
        {
            return (factorial(n) / (factorial(k) * factorial(n - k)));
        }

        private int factorial(int x)
        {
            return (x <= 1) ? 1 : x * factorial(x - 1);
        }

        public void DrawCurve(Graphics graphics)
        {
            this.DrawControlsPoints(graphics);

            if (this.BezierPoints != null)
            {
                BezierPoint previousBezierPoint = null;
                foreach (var bezierPoint in this.BezierPoints)
                {
                    graphics.DrawRectangle(Pens.Black, (float)bezierPoint.X, (float)bezierPoint.Y, 1, 1);

                    if (this.ConnectPoints)
                    {
                        if (previousBezierPoint != null)
                        {
                            graphics.DrawLine(Pens.Black, new Point((int)previousBezierPoint.X, (int)previousBezierPoint.Y),
                                new Point((int)bezierPoint.X, (int)bezierPoint.Y));
                        }

                        previousBezierPoint = bezierPoint;
                    }
                }
            }
        }

        public void Clear()
        {
            this.ControlPoints.Clear();
            this.BezierPoints = null;
        }

        public ControlPoint CheckMousePosition(MouseEventArgs e)
        {
            foreach (var controlPoint in this.ControlPoints)
            {
                if (controlPoint.IsMouseHover(e))
                {
                    Cursor.Current = Cursors.Hand;
                    
                    return controlPoint;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                }
            }

            return null;
        }

        public void RemoveControlPoint(ControlPoint controlPoint)
        {
            this.ControlPoints.Remove(controlPoint);

            int number = 1;
            foreach (var item in this.ControlPoints)
            {
                item.Number = number;
                number++;
            }

            this.CalculateCurve();
        }

        public void SetTCount(int t)
        {
            this.TCount = t;

            this.CalculateCurve();
        }

        public void SetConnectPoints(bool connectPoints)
        {
            this.ConnectPoints = connectPoints;
        }
    }
}