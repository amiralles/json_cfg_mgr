namespace JsonConfigurationManager {
    using System;
    using System.Collections.Generic;

    public class Config {
        public Config() {
            Environments = new Dictionary<string, EnvCfg>();
        }

        public Dictionary<string, EnvCfg> Environments { get; set; }
    }
}

