using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using bv.WinTests.utils;
using bv.common.Resources.TranslationTool;
using bv.winclient.Core;
using bv.winclient.Core.TranslationTool;

namespace bv.WinTests.TranslationUI
{
    public partial class ControlDesignerForm : BvForm
    {
        public ControlDesignerForm()
        {
            InitializeComponent();
            TranslationToolHelper.RootPath = PathUtils.GetMainBinFolderPath();
            var lb = new ControlDesignerProxy();
            lb.HostControl = simpleButton1;
            DesignControlManager.Create(this);
            
            //new ControlDesigner(labelControl1, DesignElement.All, labelControl1.Text);

            //new winclient.Core.TranslationTool.ControlDesigner(this.textEdit1, DesignElement.Moving | DesignElement.Sizing);
            //new winclient.Core.TranslationTool.ControlDesigner(this.simpleButton1, DesignElement.All, simpleButton1.Text);
            //new winclient.Core.TranslationTool.ControlDesigner(this.buttonEdit1, DesignElement.Moving | DesignElement.Sizing);

        }

        private void ControlDesignerForm_Click(object sender, EventArgs e)
        {

        }


    }
}