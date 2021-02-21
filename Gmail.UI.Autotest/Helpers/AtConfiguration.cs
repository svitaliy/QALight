using System.Configuration;
using System.IO;
using System.Reflection;

namespace Gmail.UI.Autotests.Helpers
{
    public sealed class AtConfiguration
    {
        public static string AppConfigFile = "App.config";
        public static string GetConfiguration(string settingName)
        {
            var configFile = AppConfigFile;

            var configMap = new ExeConfigurationFileMap();
            configMap.ExeConfigFilename = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                                          .CodeBase.Replace("file:///", string.Empty)), configFile);
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
           
            var result = config.AppSettings.Settings[settingName].Value;

            return result;
        }
    }
}