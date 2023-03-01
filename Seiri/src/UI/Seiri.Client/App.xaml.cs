namespace Seiri.Client;



using Application = Microsoft.Maui.Controls.Application;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();


	UserAppTheme = AppTheme.Light;

	}


	protected override Window CreateWindow(IActivationState? activationState)
	{
		var windows = base.CreateWindow(activationState);

		var mainDisplayInfo = DeviceDisplay.Current.MainDisplayInfo;

		windows.Height = 700;
		windows.Width = 1100;

		windows.MinimumHeight = 700;
		windows.MinimumWidth = 1100;

		//windows.X = (1920 / 2) - ((1920 / 2) / 2);
		//windows.Y = (1080 / 2) - ((1080 / 2) / 2) - 10;


		//Center the window
		windows.X = (mainDisplayInfo.Width / mainDisplayInfo.Density - mainDisplayInfo.Width) / 2;
		windows.Y = (mainDisplayInfo.Height / mainDisplayInfo.Density - mainDisplayInfo.Height) / 2;

		return windows;
	}


}
