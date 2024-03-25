namespace Notes.Views;

public partial class About : ContentPage
{
	public About()
	{
		InitializeComponent();
	}

	private async void LearnMoreClicked(object sender, EventArgs e)
	{
		if(BindingContext is Models.About about)
		{
			await Launcher.Default.OpenAsync(about.MoreInfoUrl);
		}
	}
}