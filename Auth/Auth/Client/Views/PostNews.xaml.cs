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
    public partial class PostNews : ContentPage
    {
        public PostNews()
        {
            InitializeComponent();
            BindingContext = new ViewNews();
        }
        async void Addnews_Clicked(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new NewsFeedNews());
        }
    }
}