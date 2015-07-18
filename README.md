How to use json file instead of app.config

I think we all agree that working with any kind of xml files is a bit of a pain in the ass. App.config is not an exception to that rule, so I'll show you a little trick that will help you to wipe out those nasty files and replacing them for a more sane config file format with almost no changes to your code base.
Thanks to Json.Net, is really easy to read/write C# objects to json files, so if you are starting a new project, use a plain old C# object to store your settings and you are done. But what appens if you wanna replace the way you work with settings in an existing code base? I guess you will try to do it in a way that doesn't requires a whole lotta canges. Well this is one!

TODO: Code

Probabbly you already notice, but the API of our new class is exactly the same as the System.Configuration.ConfigurationManager's one. This means that you only have to replace the using statement at the top of you .cs files to point to what ever namespace you use for this new ConfigurationManager class and you are all set.
It wasn't that hard, rigth?


And last but not least, by using this technique you can configure multliple environments into a single file and even switch them at runtime.

As far as I can tell there is only one caveat to this approach and assembly biindings redirects. If you can live without that, give json files a try. If you cannot and know how to implement that feature without using an App.config file, let me know it the comments.



