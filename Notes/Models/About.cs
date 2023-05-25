namespace Notes.Models;

internal class About
{
    public string Title => AppInfo.Name;
    public string Version => AppInfo.VersionString;
    public string SourceCode => "https://github.com/emirhandemirden/.net-maui-simple-note-app";
    public string github => "https://github.com/emirhandemirden/";
    public string website => "https://emirhandemirden.infinityfreeapp.com/";
    public string Message => "This app is written in XAML and C# with .NET MAUI and made for help you to write and save your notes in your phone privately and without any hassle. \nIf you liked or if you have any other ideas to make it better please feedback us we care it.";
}