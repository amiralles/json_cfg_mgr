namespace JsonConfigurationManager {
    using System;
    using System.Collections.Generic;

    public class EnvCfg {
        public Dictionary<string, string>    AppSettings { get; set; }
        public Dictionary<string, DbSetting> ConnectionStrings { get; set; }
    }
}
