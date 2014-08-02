#region Namespaces

using System;

#endregion

namespace Twainsoft.FHSWF.Math.Bezier
{
    public class MouseMovedEventArgs : EventArgs
    {
        public Point Location { get; set; }

        public MouseMovedEventArgs() : base() { }

        public MouseMovedEventArgs(Point point) : this()
        {
            this.Location = point;
        }
    }
}