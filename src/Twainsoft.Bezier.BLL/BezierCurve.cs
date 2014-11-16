using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Twainsoft.Bezier.BLL
{ 
    public class BezierCurve
    {
        private List<ControlPoint> ControlPoints { get; set; }
        private BezierPoint[] BezierPoints { get; set; }
        private int Count { get; set; }
        private bool ConnectPoints { get; set; }

        public BezierCurve()
        {
            ControlPoints = new List<ControlPoint>();

            Count = 1000;
        }

        public ControlPoint AddControlPoint(Point point)
        {
            var controlPoint = new ControlPoint(ControlPoints.Count + 1, point);

            ControlPoints.Add(controlPoint);

            CalculateCurve();

            return controlPoint;
        }

        public void CalculateCurve()
        {
            if (ControlPoints.Count == 0)
            {
                BezierPoints = null;
                return;
            }

            var n = ControlPoints.Count - 1;

            var controlPointArray = ControlPoints.ToArray();

            BezierPoints = new BezierPoint[Count];
            BezierPoints[0] = controlPointArray[0];

            var calcs = 1;
            for (var t = 1 / (decimal)Count; t <= ((decimal)Count - 1) / Count; t += 1 / (decimal)Count)
            {
                var result = new BezierPoint();

                for (var i = 0; i <= n; i++)
                {
                    result += (CalculateBinomial(n, i) * Math.Pow((double)t, i) * Math.Pow(1 - (double)t, n - i)) * controlPointArray[i];
                }

                BezierPoints[calcs++] = result;
            }

            BezierPoints[Count - 1] = controlPointArray[n];
        }

        private void DrawControlsPoints(Graphics graphics)
        {
            ControlPoint previousControlPoint = null;
            foreach (var controlPoint in ControlPoints)
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
            DrawControlsPoints(graphics);

            if (BezierPoints != null)
            {
                BezierPoint previousBezierPoint = null;
                foreach (var bezierPoint in BezierPoints)
                {
                    graphics.DrawRectangle(Pens.Black, (float)bezierPoint.X, (float)bezierPoint.Y, 1, 1);

                    if (ConnectPoints)
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
            ControlPoints.Clear();
            BezierPoints = null;
        }

        public ControlPoint CheckMousePosition(MouseEventArgs e)
        {
            foreach (var controlPoint in ControlPoints)
            {
                if (controlPoint.IsMouseHover(e))
                {
                    Cursor.Current = Cursors.Hand;
                    
                    return controlPoint;
                }

                Cursor.Current = Cursors.Default;
            }

            return null;
        }

        public void RemoveControlPoint(ControlPoint controlPoint)
        {
            ControlPoints.Remove(controlPoint);

            var number = 1;
            foreach (var item in ControlPoints)
            {
                item.Number = number;
                number++;
            }

            CalculateCurve();
        }

        public void SetTCount(int t)
        {
            Count = t;

            CalculateCurve();
        }

        public void SetConnectPoints(bool connectPoints)
        {
            ConnectPoints = connectPoints;
        }
    }
}