using System;
using Forms = System.Windows.Forms;
using Settings = Kean.Platform.Settings;
using Vidhance = Imint.Vidhance;
using Example.VidhanceOnOff.Extension;

namespace Example.VidhanceOnOff
{
	public class Viewer : 
		Forms.UserControl
	{
		Imint.Vidview.Viewer vidview;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.CheckBox StabilizeOnOff;
		private System.Windows.Forms.CheckBox ContrastOnOff;
		private System.Windows.Forms.CheckBox AlignOnOff;

		public Viewer()
		{
			this.InitializeComponent();
			this.vidview.Started += () =>
			{
				// We need to make sure each of the vidhance components are initialized before hooking the buttons up, 
				// or we'll get NREs if any dll or valid license for those components is missing.
				if (this.vidview.Vidhance.Stabilize != null)
				{
					Action<Vidhance.StabilizeMode> StabilizeModeChanged = mode => this.StabilizeOnOff.Invoke(() => StabilizeOnOff.Checked = mode == Vidhance.StabilizeMode.Auto);
					vidview.Vidhance.Stabilize.ModeChanged += StabilizeModeChanged;
					StabilizeModeChanged(vidview.Vidhance.Stabilize.Mode);
					this.StabilizeOnOff.CheckedChanged += (object sender, EventArgs e) =>
					{
						this.vidview.Vidhance.Stabilize.Mode = StabilizeOnOff.Checked ? Vidhance.StabilizeMode.Auto : Vidhance.StabilizeMode.Off;
					};
					this.StabilizeOnOff.Visible = true;
				}
				if (this.vidview.Vidhance.Contrast != null)
				{
					Action<Vidhance.ContrastMode> ContrastModeChanged = mode => this.ContrastOnOff.Invoke(() => ContrastOnOff.Checked = mode == Vidhance.ContrastMode.Luma);
					vidview.Vidhance.Contrast.ModeChanged += ContrastModeChanged;
					ContrastModeChanged(vidview.Vidhance.Contrast.Mode);
					this.ContrastOnOff.Visible = true;
					this.ContrastOnOff.CheckedChanged += (object sender, EventArgs e) =>
					{
						this.vidview.Vidhance.Contrast.Mode = ContrastOnOff.Checked ? Vidhance.ContrastMode.Luma : Vidhance.ContrastMode.Off;
					};
				}
				if (this.vidview.Vidhance.GeoAlign != null)
				{
					Action<Vidhance.GeoAlignMode> SkyUpModeChanged = mode => this.AlignOnOff.Invoke(() => AlignOnOff.Checked = mode == Vidhance.GeoAlignMode.SkyUp);
                    vidview.Vidhance.GeoAlign.ModeChanged += SkyUpModeChanged;
                    SkyUpModeChanged(vidview.Vidhance.GeoAlign.Mode);
					this.AlignOnOff.Visible = true;
					this.AlignOnOff.CheckedChanged += (object sender, EventArgs e) =>
					{
                        this.vidview.Vidhance.GeoAlign.Mode = AlignOnOff.Checked ? Vidhance.GeoAlignMode.SkyUp : Vidhance.GeoAlignMode.Off;
					};
				}
				// When the Vidview viewer is closed force shutdown of the full application.
				this.vidview.Closed += System.Windows.Forms.Application.Exit;
				// When the Vidview viewer is fully initialized open test://photo. In case of errors shut down the viewer and the application.
				if (!(this.vidview.Media != null && this.vidview.Media.Open("test://photo")))
					this.vidview.Close();
			};
		}

		void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
			this.vidview = new Imint.Vidview.Viewer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.StabilizeOnOff = new System.Windows.Forms.CheckBox();
			this.ContrastOnOff = new System.Windows.Forms.CheckBox();
			this.AlignOnOff = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.vidview, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.252669F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.74733F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 562);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.StabilizeOnOff);
			this.flowLayoutPanel1.Controls.Add(this.ContrastOnOff);
			this.flowLayoutPanel1.Controls.Add(this.AlignOnOff);
			this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(778, 46);
			this.flowLayoutPanel1.TabIndex = 1;
			// 
			// Stabilize
			// 
			this.StabilizeOnOff.Appearance = System.Windows.Forms.Appearance.Button;
			this.StabilizeOnOff.Image = ((System.Drawing.Image)(resources.GetObject("Stabilize.Image")));
			this.StabilizeOnOff.Location = new System.Drawing.Point(3, 3);
			this.StabilizeOnOff.Name = "Stabilize";
			this.StabilizeOnOff.Size = new System.Drawing.Size(38, 38);
			this.StabilizeOnOff.TabIndex = 0;
			this.StabilizeOnOff.UseVisualStyleBackColor = true;
			this.StabilizeOnOff.Visible = false;
			// 
			// Contrast
			// 
			this.ContrastOnOff.Appearance = System.Windows.Forms.Appearance.Button;
			this.ContrastOnOff.Image = ((System.Drawing.Image)(resources.GetObject("Contrast.Image")));
			this.ContrastOnOff.Location = new System.Drawing.Point(47, 3);
			this.ContrastOnOff.Name = "Contrast";
			this.ContrastOnOff.Size = new System.Drawing.Size(38, 38);
			this.ContrastOnOff.TabIndex = 1;
			this.ContrastOnOff.UseVisualStyleBackColor = true;
			this.ContrastOnOff.Visible = false;
			// 
			// SkyUp
			// 
			this.AlignOnOff.Appearance = System.Windows.Forms.Appearance.Button;
			this.AlignOnOff.Image = ((System.Drawing.Image)(resources.GetObject("SkyUp.Image")));
			this.AlignOnOff.Location = new System.Drawing.Point(91, 3);
			this.AlignOnOff.Name = "SkyUp";
			this.AlignOnOff.Size = new System.Drawing.Size(38, 38);
			this.AlignOnOff.TabIndex = 2;
			this.AlignOnOff.UseVisualStyleBackColor = true;
			this.AlignOnOff.Visible = false;
			// 
			// viewer
			// 
			this.vidview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vidview.Location = new System.Drawing.Point(0, 0);
			this.vidview.Name = "viewer";
			this.vidview.SeparateProcess = false;
			this.vidview.Size = new System.Drawing.Size(800, 600);
			this.vidview.TabIndex = 0;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.Controls.Add(this.tableLayoutPanel1);
			this.ResumeLayout(false);
		}

	}
}
