﻿namespace Example.VidhanceOnOff
{
	partial class Window
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
			this.viewer = new Example.VidhanceOnOff.Viewer();
			this.SuspendLayout();
			// 
			// viewer
			// 
			this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.viewer.Location = new System.Drawing.Point(3, 55);
			this.viewer.Name = "viewer";
			this.viewer.Size = new System.Drawing.Size(778, 504);
			this.viewer.TabIndex = 0;
			// 
			// Window
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(viewer);
			this.ClientSize = new System.Drawing.Size(784, 562);
			this.Name = "Window";
			this.Text = "Vidview Example Vidhance On/Off";
			this.ResumeLayout(false);

		}

		#endregion

		private Viewer viewer;
	}
}

