using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactUsPage : ContentPage
    {
        public ContactUsPage()
        {
            InitializeComponent();
        }

        private INavigation GetNavigation()
        {
            return Navigation;
        }


        async void findUsButton(object sender, EventArgs args)
        {
            /*App.Current.MainPage = new NavigationPage(new MyLocationPage());*/
            await Navigation.PushAsync(new MyLocationPage());
        }
    }
}