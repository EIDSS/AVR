namespace EIDSS.Reports.BaseControls.Filters
{
	partial class ThaiZonesSingleFilter
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThaiZonesSingleFilter));
			this.SuspendLayout();
			// 
			// lblLookupName
			// 
			resources.ApplyResources(this.lblLookupName, "lblLookupName");
			bv.common.Resources.BvResourceManagerChanger.GetResourceManager(typeof(ThaiZonesSingleFilter), out resources);
			// Form Is Localizable: True
			// 
			// ThaiZonesSingleFilter
			// 
			this.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("ThaiZonesSingleFilter.Appearance.Font")));
			this.Appearance.Options.UseFont = true;
			resources.ApplyResources(this, "$this");
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.Name = "ThaiZonesSingleFilter";
			this.ResumeLayout(false);

		}

		#endregion
	}
}
