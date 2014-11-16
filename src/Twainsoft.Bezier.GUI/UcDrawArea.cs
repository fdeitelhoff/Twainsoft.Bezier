using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Twainsoft.Bezier.BLL;

namespace Twainsoft.Bezier.GUI
{
    public sealed partial class UcDrawArea : UserControl
    {
        private BezierCurve BezierCurve { get; set; }
        private ControlPoint SelectedControlPoint { get; set; }
        public ControlPoint HoveredControlPoint { get; set; }

        private bool IsRealtimeCalculation { get; set; }

        public BindingList<ControlPoint> ControlsPoints { get; private set; }

        public delegate void MouseMovedEventHandler(object sender, MouseMovedEventArgs e);
        public event MouseMovedEventHandler MouseMoved;

        public UcDrawArea()
        {
            InitializeComponent();

            BezierCurve = new BezierCurve();
            ControlsPoints = new BindingList<ControlPoint>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            BezierCurve.DrawCurve(e.Graphics);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                if (SelectedControlPoint == null)
                {
                    var controlPoint = BezierCurve.AddControlPoint(e.Location);

                    ControlsPoints.Add(controlPoint);

                    Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                var controlPoint = BezierCurve.CheckMousePosition(e);
                
                if (controlPoint != null)
                {
                    BezierCurve.RemoveControlPoint(controlPoint);

                    ControlsPoints.Remove(controlPoint);

                    Invalidate();
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            OnMouseMoved(e.Location);

            if (HoveredControlPoint != null)
            {
                HoveredControlPoint.IsHovering = false;
            }

            HoveredControlPoint = BezierCurve.CheckMousePosition(e);

            if (HoveredControlPoint != null)
                HoveredControlPoint.IsHovering = true;

            if (SelectedControlPoint != null && SelectedControlPoint.IsSelected)
            {
                SelectedControlPoint.SetNewPosition(e.Location);
                SelectedControlPoint.IsMoving = true;
            }

            if (IsRealtimeCalculation)
            {
                BezierCurve.CalculateCurve();
            }

            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            SelectedControlPoint = BezierCurve.CheckMousePosition(e);

            if (SelectedControlPoint != null)
            {
                SelectedControlPoint.IsSelected = true;
            }

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (SelectedControlPoint != null)
            {
                SelectedControlPoint.IsSelected = false;
                SelectedControlPoint.IsMoving = false;
                SelectedControlPoint.IsHovering = false;

                if (!IsRealtimeCalculation)
                    BezierCurve.CalculateCurve();

                Invalidate();
            }
        }

        internal void Clear()
        {
            BezierCurve.Clear();
            ControlsPoints.Clear();

            Invalidate();
        }

        private void OnMouseMoved(Point location)
        {
            if (MouseMoved != null)
            {
                MouseMoved(this, new MouseMovedEventArgs(location));
            }
        }

        internal void SetRealtimeCalculation(bool realtimeCalculation)
        {
            IsRealtimeCalculation = realtimeCalculation;
        }

        internal void SetTCount(int t)
        {
            BezierCurve.SetTCount(t);

            Invalidate();
        }

        internal void SetConnectPoints(bool connectPoints)
        {
            BezierCurve.SetConnectPoints(connectPoints);
        }
    }
}