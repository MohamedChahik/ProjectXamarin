using System;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace FBGroupingApp.Client.Model
{
	public class ClientNewsModel
	{
     public string News { get; set; }
     public  ImageSource NewsImagePath { get; set; }

	public string Email { get; set; }



	 public ClientNewsModel()
    {

    }
}

    public class GroupedClientNewsModel : ObservableCollection<ClientNewsModel>
	{
		public string NewsDateTime { get; set; }
	}
}
