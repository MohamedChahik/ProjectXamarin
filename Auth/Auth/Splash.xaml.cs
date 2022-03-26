using Auth.Connexion.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Login.ViewModel;

namespace Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        Image imagelancement;
        public Splash()
        {
           NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            imagelancement = new Image
            {
                Source = "splash.jpg",
                WidthRequest = 200,
                HeightRequest = 250,

            };
            AbsoluteLayout.SetLayoutFlags(imagelancement, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(imagelancement,new Rectangle(0.5, 0.5,AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(imagelancement);
            this.BackgroundColor = Color.White;
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Splashimage size at start
            await imagelancement.ScaleTo(1, 2000);
            await imagelancement.ScaleTo(0.9, 1500 , Easing.Linear);
            await imagelancement.ScaleTo(2,1200 ,Easing.Linear);

            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}