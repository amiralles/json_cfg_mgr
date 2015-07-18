
namespace JsonConfigurationManager {
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Settings = System.Collections.Generic.Dictionary<string, string>;

    public class ConfigurationManager {
        static bool _isConfigured;
        static AppSettingsCollection _appSettings;
        static Dictionary<string, DbSetting> _connectionStrings;
        static object SyncRoot = new object();

        public static AppSettingsCollection AppSettings {
            get {
                if (_appSettings == null)
                    Init("DEV"); 

                return _appSettings;
            }
            set { _appSettings = value;}
        }

        public static Dictionary<string, DbSetting> ConnectionStrings {
            get {
                if (_connectionStrings == null)
                    Init("DEV");

                return _connectionStrings;
            }
            set { _connectionStrings = value; }
        }

        public static void Init(string env = "DEV", string path = "config.json") {
            lock (SyncRoot) {
                if (_isConfigured)//<= Nothing to do.
                    return;

                var assm   = Assembly.GetExecutingAssembly();
                var cfgdir = Path.GetDirectoryName(Path.GetFullPath(assm.Location));

                var cfgpath = Path.Combine(cfgdir, path);
                if (!File.Exists(cfgpath))
                    throw new Exception(string.Format(
                                "Configuration error. Couldn't find '{0}'.", cfgpath));

                var json   = File.ReadAllText(cfgpath);
                var config = JsonConvert.DeserializeObject<Config>(json);

                if (!config.Environments.ContainsKey(env))
                    throw new Exception(string.Format(
                                "Configuration error. Couldn't find env '{0}'.", env));

                AppSettings       = new AppSettingsCollection(config.Environments[env].AppSettings);
				ConnectionStrings = config.Environments[env].ConnectionStrings;
                _isConfigured     = true;
            }
        }
    }
}
