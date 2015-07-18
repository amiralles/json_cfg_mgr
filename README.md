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



Probably you already notice, but the API of our brand new class is exactly the same as the System.Configuration.ConfigurationManager's one. This means that you only have to replace the using statement at the top of you .cs files to point to whatever namespace you use for this new ConfigurationManager class and you are all set. It wasn't that hard, right?

And last but not least, by using this technique you can configure multliple environments into a single file and even switch them at runtime.

As far as I can tell there is only one caveat to this approach and assembly bindings redirects. If you can live without that, give it a try to json files. If you cannot and you know how to implement that feature without using an App.config file, let me know it the comments.

###How to build

Just go to the **~/src** directory and run **msbuild** or **xbuild**.

###How to run the tests

Go to the **~/tool** directory and run **bash test.sh Debug** or **test.bat Debug** if you are running on Windows.
(\* if you build in *Release* mode replace *Debug* with *Release* when running the tests)

If you wanna know a little more about the testing framework I'm using in this project, visit 
[Contest Home Page](https://github.com/amiralles/contest)


