using Acr.UserDialogs;
using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Auth
{
    
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }
        public string WebAPIkey = "AIzaSyCEeTMHbfZeMKfYGpoeR_gyFs0lu16h32o";

         async void signupbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            await Task.Delay(2000);
            activity.IsEnabled = false;
            activity.IsRunning = false;
            activity.IsVisible = false;
            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(UserNewEmail.Text, UserNewPassword.Text);
                string gettoken = auth.FirebaseToken;
                await App.Current.MainPage.DisplayAlert("Bienvenue","Inscription réussis" , "OK");
                 string email = UserNewEmail.Text;
                string password = UserNewPassword.Text;
                FirebaseClient fc = new FirebaseClient("https://test-abb0f-default-rtdb.firebaseio.com/");
                var result = await fc
                    .Child("Users")
                    .PostAsync(new TableUsers() { Token = gettoken, Email = email, isPrenium= false})
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "L'inscription n'est pas valide", "OK");
            }
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            await Task.Delay(2000);
            activity.IsEnabled = false;
            activity.IsRunning = false;
            activity.IsVisible = false;
            await Navigation.PushAsync(new MainPage());
        }
      

    }
}