using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meldcode_KO_V2.Models;

namespace Meldcode_KO_V2.Services
{
	public class MockDataStore : IDataStore<Item>
	{
		List<Item> items;

		public MockDataStore()
		{
			items = new List<Item>();
			var mockItems = new List<Item>
			{
				new Item { Id = Guid.NewGuid().ToString(), Text = "Hoofdmenu", Description="" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Noodsituatie", Description="" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Huiselijk Geweld", Description="" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Vermoeden van zedelijk misbruik", Description="door medewerker" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Seksueel misbruik", Description="kinderen onderling" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Download het protocol", Description="" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Informatie", Description="" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "FAQ", Description="" },
				new Item { Id = Guid.NewGuid().ToString(), Text = "Veilig Thuis", Description="" }
			};

			foreach (var item in mockItems)
			{
				items.Add(item);
			}
		}

		public async Task<bool> AddItemAsync(Item item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Item item)
		{
			var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Item> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}