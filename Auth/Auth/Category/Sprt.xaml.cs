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
    public partial class Sprt : ContentPage
    {
        public Sprt()
        {
            InitializeComponent();
        }
        void sportpost_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new NewsPage());
        }

        void addsportpost_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new AdminNewsFeedPage());
        }
    }
}