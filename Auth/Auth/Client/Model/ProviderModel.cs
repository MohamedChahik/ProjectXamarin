using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FBGroupingApp.Client.Model
{
	public class ProviderModel
	{
		public string Username { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
    	public  ImageSource ProviderImagePath { get; set; }

	 public ProviderModel() {}
}
    public class GroupedClientProviderModel : ObservableCollection<ProviderModel>
	{
		public string ProviderDateTime { get; set; }
	}
}
