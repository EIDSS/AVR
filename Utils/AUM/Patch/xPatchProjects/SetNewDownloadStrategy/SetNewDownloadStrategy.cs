using System.Text;
using AUM.Core;

namespace AUM.XPatch
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Xsl;
    using Core.Helper;


    public sealed class SetNewDownloadStrategy : BaseTask
    {
        private const string XPatchName = "Switching to Url Update Mechanism.";
        private const string DefaultUpdateEidssInfo = "https://update.eidss.info";
        private const string UpdateUrlNode = "updateurl";


        public override string GetName()
        {
            return XPatchName;
        }

        public override Guid GetID()
        {
            return new Guid("{DB59B5CF-647E-4833-8D9E-5F2387094A50}");
        }

        protected override bool ExecuteInternal()
        {
            try
            {
                return Run();
            }
            catch (Exception ex)
            {
                AddErrorString(GetFullError(ex));
            }
            return false;
        }

        private bool Run()
        {
            var aumPath = RegistryHelper.ReadFromRegistry("aumpath");
            BackupMainConfig(aumPath);

            var aumConfig = Path.Combine(aumPath, FileHelper.BVUpdaterConfigFileName);
            return UpdateConfigFile(aumConfig);
        }

        //public method for tests
        public bool UpdateConfigFile(string configFile)
        {
            AddInfoString("Updating aum config file");
            var tempAumConfig = Path.ChangeExtension(configFile, "temp");

            using (var xsltStream = GetManifestResourceStream("AUM.XPatch.UrlUpdateMode.xslt"))
            {
                using (var reader = XmlReader.Create(xsltStream))
                {
                    var transformer = LoadXslt(reader);
                    using (var xmlTextWriter = XmlWriter.Create(tempAumConfig, transformer.OutputSettings))
                    {
                        AddInfoString("Performing xsl transformation");
                        var args = PrepareXsltParams();
                        transformer.Transform(configFile, args, xmlTextWriter);
                    }
                }
            }
            AddInfoString("AUM config file is successfully updated");
            File.Copy(tempAumConfig, configFile, true);
            try
            {
                AddInfoString("AUM service stopping");
                ServiceHelper.AUMServiceChangeState(false, "", true);
                AddInfoString("AUM service is stopped");
                AddInfoString("AUM service starting");
                ServiceHelper.AUMServiceChangeState(true);
                AddInfoString("AUM service is started");
            }
            catch (Exception e)
            {
                //Consider this as unsignificant error here
                //patch is considered as successfull even if it is implossible to restart aum service
                AddInfoString("Error during AUM service restarting:{0}", e.Message);
            }
            return true;           
        }
        private static XslCompiledTransform LoadXslt(XmlReader reader)
        {
            var xslt = new XslCompiledTransform(true);
            xslt.Load(reader);
            return xslt;
        }

        private XsltArgumentList PrepareXsltParams()
        {
            var updateUrl = UpdateUrl;
            AddInfoString("Reading UpdateUrl from config: url = '{0}'", updateUrl);
            var args = new XsltArgumentList();
            args.AddParam(UpdateUrlNode, string.Empty, updateUrl);
            return args;
        }
        
        private string m_UpdateUrl = null;
        //public property for tests
        public string UpdateUrl
        {
            get
            {
                if (m_UpdateUrl!=null)
                    return m_UpdateUrl;
                var updateUrl = new ModuleConfigurationHelper(Assembly.GetExecutingAssembly().Location)[UpdateUrlNode];
                return !string.IsNullOrEmpty(updateUrl) ? updateUrl : DefaultUpdateEidssInfo;
            }
            set
            {
                m_UpdateUrl = value??String.Empty;
            }
        }

        private void BackupMainConfig(string aumPath)
        {
            AddInfoString("Trying to backup current main config");
            BackupHelper.BackupMainConfig(aumPath);
        }

        private static Stream GetManifestResourceStream(string resource)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
        }
    }
}