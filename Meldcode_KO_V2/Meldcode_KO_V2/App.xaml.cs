using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Meldcode_KO_V2.Views;

using Meldcode_KO_V2.Models;
using Meldcode_KO_V2.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Meldcode_KO_V2
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
