using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Server.Model;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountUser : ContentPage
    {
        public string WebAPIkey = "AIzaSyCEeTMHbfZeMKfYGpoeR_gyFs0lu16h32o";
        public AccountUser()
        {
            InitializeComponent();
            GetProfileInformationAndRefreshToken();
        }
        
        public void SetUsername(string username)
        {
            this.username = username;
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
                SetUsername(savedfirebaseauth.User.Email);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Alert", "Oh no !  Token expired", "OK");
            }



        }

        private string username;
        
        public string GetUsername()
        {
            return username;
        }

        private INavigation GetNavigation()
        {
            return Navigation;
        }

        void Logout_Clicked(System.Object sender, System.EventArgs e)
        {
            Preferences.Remove("MyFirebaseRefreshToken");
            App.Current.MainPage = new NavigationPage(new MainPage());

        }
        
        async void sendPrenium(System.Object sender, System.EventArgs e)
        {
            try
            {
                FirebaseClient fc = new FirebaseClient("https://test-abb0f-default-rtdb.firebaseio.com/");
                var result = await fc
                    .Child("DemandePrenium")
                    .PostAsync(new TableUsersPrenium() { Email= username, Date = DateTime.UtcNow.ToLocalTime()  });
                await App.Current.MainPage.DisplayAlert("Demande","Demande de prenium avec succès" , "OK");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "L'inscription n'est pas valide", "OK");
            }
        }
     
    }
}