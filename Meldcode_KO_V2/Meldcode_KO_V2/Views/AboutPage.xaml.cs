using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Meldcode_KO_V2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
		}

		private void goToMainPageHandler(object sender, EventArgs e)
		{
			App.Current.MainPage = new MainPage();
		}

	}

}
