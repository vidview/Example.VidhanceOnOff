using System;
using Forms = System.Windows.Forms;
using Settings = Kean.Platform.Settings;

namespace Example.Simple
{
	public class Viewer : 
		Forms.UserControl
	{
		Imint.Vidview.Viewer vidview;

		public Viewer()
		{
			this.InitializeComponent();
		}

		void InitializeComponent()
		{
			this.vidview = new Imint.Vidview.Viewer();
			this.SuspendLayout();
			// 
			// viewer
			// 
			this.vidview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vidview.Location = new System.Drawing.Point(0, 0);
			this.vidview.Name = "viewer";
			this.vidview.SeparateProcess = false;
			this.vidview.Size = new System.Drawing.Size(800, 600);
			this.vidview.TabIndex = 0;
			// When the Vidview viewer is closed force shutdown of the full application.
			this.vidview.Closed += System.Windows.Forms.Application.Exit;
			// When the Vidview viewer is fully initialized open test://photo. In case of errors shut down the viewer and the application.
			this.vidview.Started += () => 
			{
				if (!(this.vidview.Media != null && this.vidview.Media.Open("test://photo")))
					this.vidview.Close();
			};

			this.Controls.Add(this.vidview);
			this.ResumeLayout(false);
		}
	}
}
