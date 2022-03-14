using Auth.Category;
using Auth.Connexion.View;
using Firebase.Auth;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auth
{
    public partial class MyDashBoardPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyCEeTMHbfZeMKfYGpoeR_gyFs0lu16h32o";
        public MyDashBoardPage()
        {
            InitializeComponent();

            GetProfileInformationAndRefreshToken();
        }

        async private void GetProfileInformationAndRefreshToken()
        {
            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {
                //This is the saved firebaseauthentication that was saved during the time of login
                var savedfirebaseauth = JsonConvert.DeserializeObject<Firebase.Auth.FirebaseAuth>(Preferences.Get("MyFirebaseRefreshToken", ""));
                //Here we are Refreshing the token
                var RefreshedContent = await authProvider.RefreshAuthAsync(savedfirebaseauth);
                Preferences.Set("MyFirebaseRefreshToken", JsonConvert.SerializeObject(RefreshedContent));
                //Now lets grab user information
                MyUserName.Text = savedfirebaseauth.User.Email;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }



        }



       /* void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new MainPage());

        }*/
        void Sport_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new Sprt());
        }
        void Food_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new Food());
        }
        void News_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new New());
        }
        void Pros_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new Pro());
        }
        void Account_Clicked(object sender, EventArgs args)
        {
           // App.Current.MainPage.Navigation.PushAsync(new WelcomPage());
        }

    }
}