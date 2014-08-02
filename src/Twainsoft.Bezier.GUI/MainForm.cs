#region Namespaces

using System;
using System.Windows.Forms;

#endregion

namespace Twainsoft.Bezier.GUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();

            this.ucDrawArea.MouseMoved += new UcDrawArea.MouseMovedEventHandler(ucDrawArea_MouseMoved);
            this.lbControlPoints.DataSource = this.ucDrawArea.ControlsPoints;
        }

        void ucDrawArea_MouseMoved(object sender, MouseMovedEventArgs e)
        {
            this.tsslMousePosition.Text = String.Format("Aktuelle Position: X={0}, Y={1}", e.Location.X, e.Location.Y);

            this.tsslControlPointCount.Text = String.Format("Anzahl Kontrollpunkte: {0}", this.ucDrawArea.ControlsPoints.Count);
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            this.ucDrawArea.Clear();
        }

        private void tsbRealtimeCalculation_Click(object sender, EventArgs e)
        {
            this.tsbRealtimeCalculation.Checked = !this.tsbRealtimeCalculation.Checked;

            this.ucDrawArea.SetRealtimeCalculation(this.tsbRealtimeCalculation.Checked);
        }

        private void tstbCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int result = 0;
                Int32.TryParse(this.tstbCount.Text, out result);

                if (result != 0)
                    this.ucDrawArea.SetTCount(result);
                else
                    MessageBox.Show(this, "Der Wert für die Laufvariable t für c(t) muss größer 0 sein!", "Falsche Eingabe",
                        MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void tsbConnectPoints_Click(object sender, EventArgs e)
        {
            this.tsbConnectPoints.Checked = !this.tsbConnectPoints.Checked;

            this.ucDrawArea.SetConnectPoints(this.tsbConnectPoints.Checked);

            this.ucDrawArea.Invalidate();
        }
    }
}