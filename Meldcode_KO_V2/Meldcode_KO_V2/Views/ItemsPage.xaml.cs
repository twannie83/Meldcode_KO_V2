﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Meldcode_KO_V2.Models;
using Meldcode_KO_V2.Views;
using Meldcode_KO_V2.ViewModels;

namespace Meldcode_KO_V2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
		ItemsViewModel viewModel;
		public bool startup;

		public ItemsPage()
		{
			InitializeComponent();

			BindingContext = viewModel = new ItemsViewModel();
			
			startup = true;
		}

		async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
		{
			var item = args.SelectedItem as Item;
			if (item == null)
				return;

			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

			// Manually deselect item.
			ItemsListView.SelectedItem = null;
		}

		async void About_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new AboutPage()));
		}

		async protected override void OnAppearing()
		{
			base.OnAppearing();

			if (viewModel.Items.Count == 0)
				viewModel.LoadItemsCommand.Execute(null);

			//function for setting startpage on startup
			if (startup == true)
			{ 
			Item item = new Item();
			await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
			startup = false;
			}
		}

		/*Bind onClick image to menu url*/
		async void OnImageNameTapped(object sender, EventArgs args)
		{
			try
			{
				var item = new Item();
				await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}