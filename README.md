##How about using json files instead of app.config

I think we all agree that working with any kind of xml files is a bit of a pain in the ass. App.config is not an exception to that rule, so I'll show you a little trick that will help you to wipe out those nasty files replacing them for a more sane config file format with almost no changes to your code base. Thanks to Json.Net, is really easy to read/write C# objects to json files, so if you are starting a new project, use a plain old C# object to store your settings and you are done. But what happens if you wanna replace the way you work with settings in an existing code base? I guess you will try to do it in a way that doesn't requires a whole lotta changes. Well this is one!

```csharp
//This is how you access settings.
var someSetting = ConfigurationManager.AppSettings["foo"];

//This is how you access conneciton strings.
var conn = ConfigurationManager.ConnectionStrings["connSql"];

//And properties on some connection string.
var connStr  = ConfigurationManager.ConnectionStrings["connSql"].ConnectionString;
var connProv = ConfigurationManager.ConnectionStrings["connSql"].ProviderName;

//Wanna see more use cases? Take a look at ConfigurationManagerTests.cs.-
```

Probably, you already notice that the API of our brand new class is exactly the same as the System.Configuration.ConfigurationManager's one. This means that you only have to replace the using statement at the top of you .cs files to point to whatever namespace you use for this new ConfigurationManager class and you are all set. It wasn't that hard, right?

Now lets take a look at the __actual configuration file__. (config.json).
```javascript
{
    "Environments": {
        "DEV": {
            "AppSettings": {
                "foo":"foo",
            },
            "ConnectionStrings":{
                "connSql":{
					"ProviderName":"System.Data.SqlClient",
                    "ConnectionString":"server=FOO;Database=BAR;"
                }
            }
        }
    }
}
```
Not sure about you, but to me this code looks cleaner than the cryptic xml settings you usually find stuffed into app.config files.
And last but not least, by using this technique you can configure multliple environments into a single file. By default, it'll be using DEV environment, but you can add more _Environments_ and point ConfigurationManager to them. Once again, the way you use ConfigurationManager shouldn't chage.

(\* And, with a bit of extra work, it could also be used to swap environments/configurations at runtime. Admittedly, this is a dangerous thing to do, but it's also applicable in particular cases).

As far as I can tell, there is only one caveat to this approach, and is assembly bindings redirects. If you can live without 'em, give json files a try. If you cannot and know how to implement that feature without using an App.config file, just let me know. Or even better, send me a pull request!

###How to build

Just go to the **~/src** directory and run **xbuild** or **msbuild**.

###How to run the tests

Go to the **~/tool** directory and run **bash test.sh Debug** or if you are running on Windows **test.bat Debug**.
(\* if you build in *Release* mode replace *Debug* with *Release* when running the tests)

If you wanna know a little more about the testing framework I'm using in this project, visit 
[Contest Home Page](https://github.com/amiralles/contest), and of course, let me know if you have any issue.
