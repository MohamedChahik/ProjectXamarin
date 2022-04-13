using Auth.Category;
using Auth.Client.Views;
using Auth.Connexion.View;
using Firebase.Auth;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Client.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auth
{
    public partial class MyDashBoardPage : ContentPage
    {
        public string WebAPIkey = "AIzaSyCEeTMHbfZeMKfYGpoeR_gyFs0lu16h32o";

        private string username;

        public string GetUsername()
        {
            return username;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }
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
                /*MyUserName.Text = savedfirebaseauth.User.Email;*/
                SetUsername(savedfirebaseauth.User.Email);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }



        }


        async void PreniumClicked(object sender, EventArgs args)
        {
            /*Preferences.Get("MyFirebaseRefreshToken", "");*/
            if (username == "simohamed.chahik@gmail.com")
            {
                await Navigation.PushAsync( new PostPrenium());
            }
            else await DisplayAlert("Alert", "Vous n'êtes pas un utilisateur prenium", "OK");
        }
        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new MainPage());

        }
     
      
        async void Food_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PostFood());
        }
        async void News_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PostNews());
        }
        async void Pros_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PostPro());
        }
        async void Sport_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PostSport());
        }
       
        void cat_Clicked(object sender, EventArgs args)
        {
            App.Current.MainPage = new NavigationPage(new MyDashBoardPage());
        }
        async void cpt_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new PostProvider());
        }
        async void contact_Clicked(object sender, EventArgs args)
        {
         
            await Navigation.PushAsync(new ContactUsPage());
        }
        async void user_Clicked(object sender, EventArgs args)
        {
         
            await Navigation.PushAsync(new AccountUser());
        }

    }
}