using System;
using System.Windows.Input;

using Xamarin.Forms;

namespace Meldcode_KO_V2.ViewModels
{
	public class AboutViewModel : BaseViewModel
	{
		public AboutViewModel()
		{
			Title = "About";

			OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://meldcodekmko.nl")));
		}

		public ICommand OpenWebCommand { get; }
	}
}