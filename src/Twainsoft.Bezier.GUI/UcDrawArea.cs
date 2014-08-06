#region Namespaces

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#endregion

namespace Twainsoft.Bezier.GUI
{
    public partial class UcDrawArea : UserControl
    {
        public BezierCurve BezierCurve { get; private set; }
        private ControlPoint SelectedControlPoint { get; set; }
        public ControlPoint HoveredControlPoint { get; set; }

        public bool IsRealtimeCalculation { get; private set; }

        public BindingList<ControlPoint> ControlsPoints { get; private set; }

        public delegate void MouseMovedEventHandler(object sender, MouseMovedEventArgs e);
        public event MouseMovedEventHandler MouseMoved;

        public UcDrawArea()
        {
            InitializeComponent();

            this.BezierCurve = new BezierCurve();
            this.ControlsPoints = new BindingList<ControlPoint>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.BezierCurve.DrawCurve(e.Graphics);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                if (this.SelectedControlPoint == null)
                {
                    ControlPoint controlPoint = this.BezierCurve.AddControlPoint(e.Location);

                    this.ControlsPoints.Add(controlPoint);

                    this.Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ControlPoint controlPoint = this.BezierCurve.CheckMousePosition(e);
                
                if (controlPoint != null)
                {
                    this.BezierCurve.RemoveControlPoint(controlPoint);

                    this.ControlsPoints.Remove(controlPoint);

                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            this.OnMouseMoved(e.Location);

            if (this.HoveredControlPoint != null)
                this.HoveredControlPoint.IsHovering = false;

            this.HoveredControlPoint = this.BezierCurve.CheckMousePosition(e);

            if (this.HoveredControlPoint != null)
                this.HoveredControlPoint.IsHovering = true;

            if (this.SelectedControlPoint != null && this.SelectedControlPoint.IsSelected)
            {
                this.SelectedControlPoint.SetNewPosition(e.Location);
                this.SelectedControlPoint.IsMoving = true;
            }

            if (this.IsRealtimeCalculation)
                this.BezierCurve.CalculateCurve();

            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            this.SelectedControlPoint = this.BezierCurve.CheckMousePosition(e);

            if (this.SelectedControlPoint != null)
            {
                this.SelectedControlPoint.IsSelected = true;
            }

            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (this.SelectedControlPoint != null)
            {
                this.SelectedControlPoint.IsSelected = false;
                this.SelectedControlPoint.IsMoving = false;
                this.SelectedControlPoint.IsHovering = false;

                if (!this.IsRealtimeCalculation)
                    this.BezierCurve.CalculateCurve();

                this.Invalidate();
            }
        }

        internal void Clear()
        {
            this.BezierCurve.Clear();
            this.ControlsPoints.Clear();

            this.Invalidate();
        }

        protected virtual void OnMouseMoved(Point location)
        {
            if (this.MouseMoved != null)
                this.MouseMoved(this, new MouseMovedEventArgs(location));
        }

        internal void SetRealtimeCalculation(bool realtimeCalculation)
        {
            this.IsRealtimeCalculation = realtimeCalculation;
        }

        internal void SetTCount(int t)
        {
            this.BezierCurve.SetTCount(t);

            this.Invalidate();
        }

        internal void SetConnectPoints(bool connectPoints)
        {
            this.BezierCurve.SetConnectPoints(connectPoints);
        }
    }
}