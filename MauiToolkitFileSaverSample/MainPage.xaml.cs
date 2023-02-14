using CommunityToolkit.Maui.Storage;
using System.Text;

namespace MauiToolkitFileSaverSample;

public partial class MainPage : ContentPage
{
	IFileSaver fileSaver;
	CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
	public MainPage(IFileSaver fileSaver)
	{
		InitializeComponent();
		this.fileSaver = fileSaver;
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		try
		{
			using var stream = new MemoryStream(Encoding.Default.GetBytes("Have you subscribed to this amazing channel yet?!"));
			var path = await fileSaver.SaveAsync("subscribe.txt", stream, cancellationTokenSource.Token);

			fileSaverResult.Text = path;
		}
		catch
		{
			// Exception thrown when user cancels
		}
    }
}

