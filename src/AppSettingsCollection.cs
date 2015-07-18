
namespace JsonConfigurationManager {
    using System;
    using System.Collections.Generic;
    using Settings = System.Collections.Generic.Dictionary<string, string>;

	public class AppSettingsCollection {
        readonly Settings _settings = new Settings();

	    public AppSettingsCollection(Settings settings){
			_settings = settings;
		}

		public string this[string key] {
			get{ return _settings.ContainsKey(key) ? _settings[key] : null; }
			set{ _settings[key] = value; }
		}
	}
}
