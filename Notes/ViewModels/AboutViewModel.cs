namespace Notes.ViewModels;

using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

public class AboutViewModel
{
    public string Title => AppInfo.Name;

    public string Version => AppInfo.VersionString;

    public string MoreInfoUrl => "https://github.com/GyuntekAhmed/Notes";

    public string Message => "This app is written in XAML and C# with .NET MAUI.";

    public ICommand ShowMoreInfoCommand { get; }

    public AboutViewModel()
    {
        ShowMoreInfoCommand = new AsyncRelayCommand(ShowMoreInfo);
    }

    async Task ShowMoreInfo() =>
        await Launcher.Default.OpenAsync(MoreInfoUrl);
}