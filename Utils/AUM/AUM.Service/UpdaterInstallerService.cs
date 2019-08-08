using System.ComponentModel;
using System.Configuration.Install;

namespace AUM.Service
{
    [RunInstaller(true)]
    public partial class UpdaterInstallerService : Installer
    {
        public UpdaterInstallerService()
        {
            InitializeComponent();
        }
    }
}
