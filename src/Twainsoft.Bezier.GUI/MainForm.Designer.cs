namespace Twainsoft.Bezier.GUI
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tsslMousePosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslControlPointCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.ucDrawArea = new Twainsoft.Bezier.GUI.UcDrawArea();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tsbRealtimeCalculation = new System.Windows.Forms.ToolStripButton();
            this.tslTCount = new System.Windows.Forms.ToolStripLabel();
            this.tstbCount = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lbControlPoints = new System.Windows.Forms.ListBox();
            this.tsbConnectPoints = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.BottomToolStripPanel
            // 
            this.toolStripContainer.BottomToolStripPanel.Controls.Add(this.ssMain);
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.AutoScroll = true;
            this.toolStripContainer.ContentPanel.Controls.Add(this.ucDrawArea);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(495, 360);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.LeftToolStripPanelVisible = false;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.RightToolStripPanelVisible = false;
            this.toolStripContainer.Size = new System.Drawing.Size(495, 407);
            this.toolStripContainer.TabIndex = 2;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.tsMain);
            // 
            // ssMain
            // 
            this.ssMain.Dock = System.Windows.Forms.DockStyle.None;
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMousePosition,
            this.tsslControlPointCount});
            this.ssMain.Location = new System.Drawing.Point(0, 0);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(495, 22);
            this.ssMain.SizingGrip = false;
            this.ssMain.TabIndex = 0;
            // 
            // tsslMousePosition
            // 
            this.tsslMousePosition.Name = "tsslMousePosition";
            this.tsslMousePosition.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslControlPointCount
            // 
            this.tsslControlPointCount.Name = "tsslControlPointCount";
            this.tsslControlPointCount.Size = new System.Drawing.Size(0, 17);
            // 
            // ucDrawArea
            // 
            this.ucDrawArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDrawArea.HoveredControlPoint = null;
            this.ucDrawArea.Location = new System.Drawing.Point(0, 0);
            this.ucDrawArea.Name = "ucDrawArea";
            this.ucDrawArea.Size = new System.Drawing.Size(495, 360);
            this.ucDrawArea.TabIndex = 0;
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.None;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClear,
            this.tsbRealtimeCalculation,
            this.tsbConnectPoints,
            this.tslTCount,
            this.tstbCount});
            this.tsMain.Location = new System.Drawing.Point(3, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(466, 25);
            this.tsMain.TabIndex = 0;
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(80, 22);
            this.tsbClear.Text = "Alles löschen";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // tsbRealtimeCalculation
            // 
            this.tsbRealtimeCalculation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRealtimeCalculation.Image = ((System.Drawing.Image)(resources.GetObject("tsbRealtimeCalculation.Image")));
            this.tsbRealtimeCalculation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRealtimeCalculation.Name = "tsbRealtimeCalculation";
            this.tsbRealtimeCalculation.Size = new System.Drawing.Size(116, 22);
            this.tsbRealtimeCalculation.Text = "Echtzeitberechnung";
            this.tsbRealtimeCalculation.Click += new System.EventHandler(this.tsbRealtimeCalculation_Click);
            // 
            // tslTCount
            // 
            this.tslTCount.Name = "tslTCount";
            this.tslTCount.Size = new System.Drawing.Size(71, 22);
            this.tslTCount.Text = "Anzahl für t:";
            // 
            // tstbCount
            // 
            this.tstbCount.Name = "tstbCount";
            this.tstbCount.Size = new System.Drawing.Size(50, 25);
            this.tstbCount.Text = "1000";
            this.tstbCount.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tstbCount.ToolTipText = "Die maximale Größe der Laufvariable t für c(t).";
            this.tstbCount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstbCount_KeyDown);
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lbControlPoints);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.toolStripContainer);
            this.splitContainer.Size = new System.Drawing.Size(661, 407);
            this.splitContainer.SplitterDistance = 162;
            this.splitContainer.TabIndex = 3;
            // 
            // lbControlPoints
            // 
            this.lbControlPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbControlPoints.FormattingEnabled = true;
            this.lbControlPoints.Location = new System.Drawing.Point(0, 0);
            this.lbControlPoints.Name = "lbControlPoints";
            this.lbControlPoints.Size = new System.Drawing.Size(162, 407);
            this.lbControlPoints.TabIndex = 0;
            // 
            // tsbConnectPoints
            // 
            this.tsbConnectPoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConnectPoints.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnectPoints.Image")));
            this.tsbConnectPoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnectPoints.Name = "tsbConnectPoints";
            this.tsbConnectPoints.Size = new System.Drawing.Size(104, 22);
            this.tsbConnectPoints.Text = "Punkte verbinden";
            this.tsbConnectPoints.Click += new System.EventHandler(this.tsbConnectPoints_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 407);
            this.Controls.Add(this.splitContainer);
            this.DoubleBuffered = true;
            this.Name = "FrmMain";
            this.Text = "Bezierkurve (Fabian Deitelhoff)";
            this.toolStripContainer.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UcDrawArea ucDrawArea;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ListBox lbControlPoints;
        private System.Windows.Forms.ToolStripButton tsbRealtimeCalculation;
        private System.Windows.Forms.ToolStripStatusLabel tsslMousePosition;
        private System.Windows.Forms.ToolStripStatusLabel tsslControlPointCount;
        private System.Windows.Forms.ToolStripTextBox tstbCount;
        private System.Windows.Forms.ToolStripLabel tslTCount;
        private System.Windows.Forms.ToolStripButton tsbConnectPoints;
    }
}