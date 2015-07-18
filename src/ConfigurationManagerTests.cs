
namespace JsonConfigurationManager {
    using System;
    using System.Collections.Generic;
    using Contest.Core;
    using _ = System.Action<Contest.Core.Runner>;
    
    //Wanna run these tests? See Readme.md.-
    class ConfigurationManagerTests {
        
        //AppSettings
        _ it_should_return_null_for_non_existing_key = assert =>
            assert.IsNull(ConfigurationManager.AppSettings["missing_key"]);

        _ it_should_read_existing_key = assert =>
            assert.Equal("foo", ConfigurationManager.AppSettings["foo"]);

        //ConnectionStrings
        _ it_should_throw_when_asking_for_non_existing_connections = test =>
            test.ShouldThrow<KeyNotFoundException>(()=> {
                    var fruli = ConfigurationManager.ConnectionStrings["fruli"];
                });

        _ it_should_return_existing_connections = assert =>
            assert.IsNotNull(ConfigurationManager.ConnectionStrings["connSql"]);

        _ it_should_return_connstr_for_existing_connections = assert =>
            assert.Equal("server=FOO;Database=BAR;", 
                    ConfigurationManager.ConnectionStrings["connSql"].ConnectionString);

        _ it_should_return_provider_name_for_existing_connections = assert =>
            assert.Equal("System.Data.SqlClient", 
                    ConfigurationManager.ConnectionStrings["connSql"].ProviderName);
    }
}
