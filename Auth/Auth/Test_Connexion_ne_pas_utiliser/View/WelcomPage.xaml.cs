using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Login.ViewModel;

namespace Auth.Connexion.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomPage : ContentPage
    {
        WelcomePageVM welcomePageVM;
        public WelcomPage(string email)
        {
            InitializeComponent();
            welcomePageVM = new WelcomePageVM(email);
            BindingContext = welcomePageVM;
            

        }
        void dash_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new MyDashBoardPage());
        }
        void cat_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new MyDashBoardPage());
        }
        void cpt_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new MyDashBoardPage());
        }
        void contact_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new MyDashBoardPage());

        }
    }
}