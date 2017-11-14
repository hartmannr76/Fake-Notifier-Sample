# Fake-Notifier-Sample
This is an idea that I have been playing with for some time and just wanted to get it out as a sample repo.

Essentially, when someone else needs to consume your application as a dependency, you should take responsibility of publishing a valid "fake" version of it that offers the same API's and functions _very_ similarly to your real application.

I say similarly because this proposal leaves all business logic intact, and swaps out anything that communicates with an external resource.

To add an additional layer of safety, what is included in the published artifacts (in the case of non-fake) does not allow the application to "boot up" as a fake. It simply fails. The "fake" artifacts allow you to spin it up either way.

### Running as a fake
1) `dotnet restore`
2) `cd ./scr/API`
3) `dotnet build /p:Configuration=Fake`
4) `ASPNETCORE_ENVIRONMENT=Development dotnet run -c=Fake --no-build`

### Running as a real service
** To verify fake assets aren't published, you can blow out your `build` directory in the root **
1) `dotnet restore`
2) `cd ./scr/API`
3) `dotnet build`
4) `ASPNETCORE_ENVIRONMENT=Development dotnet run --no-build`

If you attempt to run the "real" version with the `dotnet run -c=Fake` command, you should see an error like the following:
```
rickyMac:API rhartmann$ ASPNETCORE_ENVIRONMENT=Development dotnet run -c=Fake --no-build
dotnet exec needs a managed .dll or .exe extension. The application specified was '/Users/rhartmann/src/sample/build/Sample.API/Fake/bin/netcoreapp2.0/Sample.API.dll'
```
