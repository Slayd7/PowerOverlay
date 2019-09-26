namespace PowerOverlay
{
    partial class Form1
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
            this.pkgElem = new System.Windows.Forms.Integration.ElementHost();
            this.corElem = new System.Windows.Forms.Integration.ElementHost();
            this.gfxElem = new System.Windows.Forms.Integration.ElementHost();
            this.drmElem = new System.Windows.Forms.Integration.ElementHost();
            this.pkgGauge = new Gauge();
            this.corGauge = new Gauge();
            this.gfxGauge = new Gauge();
            this.drmGauge = new Gauge();

            this.pkgGraphElem = new System.Windows.Forms.Integration.ElementHost();
            this.corGraphElem = new System.Windows.Forms.Integration.ElementHost();
            this.gfxGraphElem = new System.Windows.Forms.Integration.ElementHost();
            this.drmGraphElem = new System.Windows.Forms.Integration.ElementHost();
            this.pkgGraph = new Graph();
            this.corGraph = new Graph();
            this.gfxGraph = new Graph();
            this.drmGraph = new Graph();

            this.SuspendLayout();

            int width = getFullScreensSize().Width;

            ///// Graphs /////

            int h = 20;

            this.pkgGraphElem.Location = new System.Drawing.Point(width - 620, h);
            this.pkgGraphElem.Name = "Package Power Graph";
            this.pkgGraphElem.Size = new System.Drawing.Size(300, 150);
            this.pkgGraphElem.TabIndex = 0;
            this.pkgGraphElem.Text = "Package Power Graph";
            this.pkgGraphElem.Child = this.pkgGraph;
            this.pkgGraph.DataContext = this.pg.pkgNotif;
            this.pg.pkgNotif.PropValChanged += this.pkgGraph.Plot;
            h += 150;

            this.corGraphElem.Location = new System.Drawing.Point(width - 620, h);
            this.corGraphElem.Name = "Core Power Graph";
            this.corGraphElem.Size = new System.Drawing.Size(300, 150);
            this.corGraphElem.TabIndex = 0;
            this.corGraphElem.Text = "Core Power Graph";
            this.corGraphElem.Child = this.corGraph;
            this.corGraph.DataContext = this.pg.corNotif;
            this.pg.corNotif.PropValChanged += this.corGraph.Plot;
            h += 150;

            this.gfxGraphElem.Location = new System.Drawing.Point(width - 620, h);
            this.gfxGraphElem.Name = "Graphics Power Graph";
            this.gfxGraphElem.Size = new System.Drawing.Size(300, 150);
            this.gfxGraphElem.TabIndex = 0;
            this.gfxGraphElem.Text = "Graphics Power Graph";
            this.gfxGraphElem.Child = this.gfxGraph;
            this.gfxGraph.DataContext = this.pg.gfxNotif;
            this.pg.gfxNotif.PropValChanged += this.gfxGraph.Plot;
            h += 150;

            this.drmGraphElem.Location = new System.Drawing.Point(width - 620, h);
            this.drmGraphElem.Name = "DRAM Power Graph";
            this.drmGraphElem.Size = new System.Drawing.Size(300, 150);
            this.drmGraphElem.TabIndex = 0;
            this.drmGraphElem.Text = "DRAM Power Graph";
            this.drmGraphElem.Child = this.drmGraph;
            this.drmGraph.DataContext = this.pg.drmNotif;
            this.pg.drmNotif.PropValChanged += this.drmGraph.Plot;
            h += 150;

            ////// Gauges //////

            h = 20;
            this.pkgElem.Location = new System.Drawing.Point(width - 320, h);
            this.pkgElem.Name = "Package Power";
            this.pkgElem.Size = new System.Drawing.Size(300, 150);
            this.pkgElem.TabIndex = 0;
            this.pkgElem.Text = "Package Power";
            this.pkgElem.Child = this.pkgGauge;
            this.pkgGauge.DataContext = this.pg.pkgNotif;
            h += 150;

            this.corElem.Location = new System.Drawing.Point(width - 320, h);
            this.corElem.Name = "Core Power";
            this.corElem.Size = new System.Drawing.Size(300, 150);
            this.corElem.TabIndex = 0;
            this.corElem.Text = "Core Power";
            this.corElem.Child = this.corGauge;
            this.corGauge.DataContext = this.pg.corNotif;
            h += 150;

            this.gfxElem.Location = new System.Drawing.Point(width - 320, h);
            this.gfxElem.Name = "Graphics Power";
            this.gfxElem.Size = new System.Drawing.Size(300, 150);
            this.gfxElem.TabIndex = 0;
            this.gfxElem.Text = "Graphics Power";
            this.gfxElem.Child = this.gfxGauge;
            this.gfxGauge.DataContext = this.pg.gfxNotif;
            h += 150;

            this.drmElem.Location = new System.Drawing.Point(width - 320, h);
            this.drmElem.Name = "DRAM Power";
            this.drmElem.Size = new System.Drawing.Size(300, 150);
            this.drmElem.TabIndex = 0;
            this.drmElem.Text = "DRAM Power";
            this.drmElem.Child = this.drmGauge;
            this.drmGauge.DataContext = this.pg.drmNotif;
            h += 150;

            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            //this.ClientSize = new System.Drawing.Size(1276, 757);

            this.Controls.Add(this.pkgElem);
            this.Controls.Add(this.corElem);
            this.Controls.Add(this.gfxElem);
            this.Controls.Add(this.drmElem);

            this.Controls.Add(this.pkgGraphElem);
            this.Controls.Add(this.corGraphElem);
            this.Controls.Add(this.gfxGraphElem);
            this.Controls.Add(this.drmGraphElem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Power Overlay";
            this.Text = " ";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost pkgElem;
        private System.Windows.Forms.Integration.ElementHost corElem;
        private System.Windows.Forms.Integration.ElementHost gfxElem;
        private System.Windows.Forms.Integration.ElementHost drmElem;
        private Gauge pkgGauge;
        private Gauge corGauge;
        private Gauge gfxGauge;
        private Gauge drmGauge;

        private System.Windows.Forms.Integration.ElementHost pkgGraphElem;
        private System.Windows.Forms.Integration.ElementHost corGraphElem;
        private System.Windows.Forms.Integration.ElementHost gfxGraphElem;
        private System.Windows.Forms.Integration.ElementHost drmGraphElem;
        private Graph pkgGraph;
        private Graph corGraph;
        private Graph gfxGraph;
        private Graph drmGraph;
    }
}

