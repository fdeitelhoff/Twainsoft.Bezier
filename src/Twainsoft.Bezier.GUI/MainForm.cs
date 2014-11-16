using System;
using System.Windows.Forms;
using Twainsoft.Bezier.BLL;

namespace Twainsoft.Bezier.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            ucDrawArea.MouseMoved += ucDrawArea_MouseMoved;
            lbControlPoints.DataSource = ucDrawArea.ControlsPoints;
        }
        
        private void ucDrawArea_MouseMoved(object sender, MouseMovedEventArgs e)
        {
            tsslMousePosition.Text = String.Format("Current Position: X={0}, Y={1}", e.Location.X, e.Location.Y);

            tsslControlPointCount.Text = String.Format("Control Point Count: {0}", ucDrawArea.ControlsPoints.Count);
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            ucDrawArea.Clear();
        }

        private void tsbRealtimeCalculation_Click(object sender, EventArgs e)
        {
            tsbRealtimeCalculation.Checked = !tsbRealtimeCalculation.Checked;

            ucDrawArea.SetRealtimeCalculation(tsbRealtimeCalculation.Checked);
        }

        private void tstbCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var result = 0;
                Int32.TryParse(tstbCount.Text, out result);

                if (result != 0)
                {
                    ucDrawArea.SetTCount(result);
                }
                else
                {
                    MessageBox.Show(this, "The Value For The Control Variable t For c(t) Must Be Greater Than 0!",
                        "Wrong Input",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void tsbConnectPoints_Click(object sender, EventArgs e)
        {
            tsbConnectPoints.Checked = !tsbConnectPoints.Checked;

            ucDrawArea.SetConnectPoints(tsbConnectPoints.Checked);

            ucDrawArea.Invalidate();
        }
    }
}