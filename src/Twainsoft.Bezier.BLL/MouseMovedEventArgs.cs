using System;
using System.Drawing;

namespace Twainsoft.Bezier.BLL
{
    public class MouseMovedEventArgs : EventArgs
    {
        public Point Location { get; set; }

        public MouseMovedEventArgs(Point point)
        {
            Location = point;
        }
    }
}