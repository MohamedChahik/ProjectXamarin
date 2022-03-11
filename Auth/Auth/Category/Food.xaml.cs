using Auth.Client;
using Auth.Client.Views;
using Auth.Serveur.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auth.Category
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Food : ContentPage
    {
        public Food()
        {
            InitializeComponent();
        }

        void foodpost_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new NewsPage());
        }

        void addfoodpost_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new AdminNewsFeedPage());
        }
    }
}