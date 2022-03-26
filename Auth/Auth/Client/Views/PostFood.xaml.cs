using Auth.Client.ViewModel;
using Auth.Server.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auth.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostFood : ContentPage
    {
        public PostFood()
        {
            InitializeComponent();
            BindingContext = new ViewFood();
        }

        async void Addfood_Clicked(object sender, EventArgs args)
        {
           
            await Navigation.PushAsync(new NewsFeedFood());
        }
    }
}