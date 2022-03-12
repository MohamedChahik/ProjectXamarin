using Auth.Client.Views;
using Auth.Server.Views;
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
    public partial class Pro : ContentPage
    {
        public Pro()
        {
            InitializeComponent();
        }
        void propost_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new PostPro());
        }

        void addpropost_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new NewsFeedPro());
        }
    }
}