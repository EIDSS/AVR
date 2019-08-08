
namespace AUM.XPatch
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Xsl;
    using Core.Helper;


    public sealed class UpdateAvrLoggingConfig : BaseTask
    {
        private const string XPatchName = "AVR logging switching";


        public override string GetName()
        {
            return XPatchName;
        }

        public override Guid GetID()
        {
            return new Guid("{0D254C0E-B846-4DFB-86D1-AFC8A59E7EB4}");
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
            var avrServicePath = UpdHelper.AvrServicePath;
            if (string.IsNullOrEmpty(avrServicePath))
            {
                AddInfoString("Avr service is not installed on this computer. No need to update AVR service config file");
                return true;
            }
            BackupMainConfig(avrServicePath);

            var avrConfig = Path.Combine(avrServicePath, "eidss.avr.service.exe.config");
            return UpdateConfigFile(avrConfig);
        }

        //public method for tests
        public bool UpdateConfigFile(string configFile)
        {
            AddInfoString("Updating AVR config file");
            var tempAvrConfig = Path.ChangeExtension(configFile, "temp");

            using (var xsltStream = GetManifestResourceStream("AUM.XPatch.AvrLogging.xslt"))
            {
                using (var reader = XmlReader.Create(xsltStream))
                {
                    var transformer = LoadXslt(reader);
                    using (var xmlTextWriter = XmlWriter.Create(tempAvrConfig, transformer.OutputSettings))
                    {
                        AddInfoString("Performing xsl transformation");
                        transformer.Transform(configFile, null, xmlTextWriter);
                    }
                }
            }
            AddInfoString("AVR config file is successfully updated");
            File.Copy(tempAvrConfig, configFile, true);
            return true;
        }
        private static XslCompiledTransform LoadXslt(XmlReader reader)
        {
            var xslt = new XslCompiledTransform(true);
            xslt.Load(reader);
            return xslt;
        }

        private void BackupMainConfig(string aumPath)
        {
            AddInfoString("Trying to backup current avr service config");
            BackupHelper.BackupMainConfig(aumPath);
        }

        private static Stream GetManifestResourceStream(string resource)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
        }
    }
}

