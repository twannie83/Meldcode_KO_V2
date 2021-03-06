﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Meldcode_KO_V2.Models;
using Meldcode_KO_V2.ViewModels;

namespace Meldcode_KO_V2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
		ItemDetailViewModel viewModel;

		public ItemDetailPage(ItemDetailViewModel viewModel)
		{
			InitializeComponent();

			BindingContext = this.viewModel = viewModel;

			//Setup url
			var url = "https://meldcodekmko.nl/";
			var newUrl = "";

			if (viewModel.Item.Text != null)
			{
				newUrl = viewModel.Item.Text.ToString();
			}
			

			//URL binder
			if (newUrl == "Noodsituatie")
			{
				url = "https://meldcodekmko.nl/noodsituatie/";
			}
			else if (newUrl == "Huiselijk Geweld")
			{
				url = "https://meldcodekmko.nl/1-stappenplan-huiselijk-geweld/";
			}
			else if (newUrl == "Vermoeden van zedelijk misbruik")
			{
				url = "https://meldcodekmko.nl/scherm-0-fc2-vermoeden-van-misbruik-door-een-medewerker/";
			}
			else if (newUrl == "Seksueel misbruik")
			{
				url = "https://meldcodekmko.nl/fc3-scherm-1-grensoverschrijdend-gedrag/";
			}
			else if (newUrl == "Download het protocol")
			{
				url = "https://meldcodekmko.nl/protocol-downloaden/";
			}
			else if (newUrl == "Informatie")
			{
				url = "https://meldcodekmko.nl/fc4-scherm-1-informatie/";
			}
			else if (newUrl == "FAQ")
			{
				url = "https://meldcodekmko.nl/fc5-scherm-1-faq/";
			}
			else if (newUrl == "Veilig Thuis")
			{
				url = "https://meldcodekmko.nl/noodsituatie/";
			}




			WebView webview = new WebView
	
			{
				Source = url,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			this.Content = new StackLayout
			{
				Children = {
					 webview
				}
			};
		}

		public ItemDetailPage()
		{
			InitializeComponent();

			var item = new Item
			{
				Text = "Item 1",
				Description = "This is an item description."
			};

			viewModel = new ItemDetailViewModel(item);
			BindingContext = viewModel;
		}

		async void About_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
		}

		/*function for formatting URL en use tel and mailto in url*/
		private void OnNavigating(object sender, WebNavigatingEventArgs e)
		{
			if (e.Url.ToLower().Contains("tel:"))
			{
				e.Cancel = true;
				var uri = new Uri(e.Url);
				Device.OpenUri(uri);
			}
			else
			{
				e.Cancel = false;
			}
		}

	}
}