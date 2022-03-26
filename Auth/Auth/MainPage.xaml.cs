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
    public partial class MainPage : ContentPage
    {   
        public MainPage()
        {
            InitializeComponent();
           
           
        }
        public string WebAPIkey = "AIzaSyCEeTMHbfZeMKfYGpoeR_gyFs0lu16h32o";

        async void loginbutton_Clicked(System.Object sender, System.EventArgs e)
        {
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            await Task.Delay(2000);
            activity.IsEnabled = false;
            activity.IsRunning = false;
            activity.IsVisible = false;

            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(WebAPIkey));
            try
            {

                var auth = await authProvider.SignInWithEmailAndPasswordAsync(UserLoginEmail.Text, UserLoginPassword.Text);
                var content = await auth.GetFreshAuthAsync();
                var serializedcontnet = JsonConvert.SerializeObject(content);
                Preferences.Set("MyFirebaseRefreshToken", serializedcontnet);
                await Navigation.PushAsync(new MyDashBoardPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", "Invalid useremail or password", "OK");
            }
        }
        async void Register_Clicked(object sender, EventArgs args)
        {
            //Activité indicator sur le bouton de 2s
            activity.IsEnabled = true;
            activity.IsRunning = true;
            activity.IsVisible = true;
            await Task.Delay(2000);
            activity.IsEnabled = false;
            activity.IsRunning = false;
            activity.IsVisible = false;

            await Navigation.PushAsync(new Register());

            

        }
       

    }
}


