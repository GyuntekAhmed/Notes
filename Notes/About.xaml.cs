namespace Notes;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}

	private async void LearnMore_Clicked(object sender, EventArgs e)
	{
		await Launcher.Default.OpenAsync("https://github.com/GyuntekAhmed/Notes/tree/master/Notes");
	}
}