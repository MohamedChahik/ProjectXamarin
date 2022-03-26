using Auth.Client.ViewModel;
using Auth.Server.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Auth.Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostPro : ContentPage
    {
        public PostPro()
        {
            InitializeComponent();
            BindingContext = new ViewPro();
        }
        async void Addpro_Clicked(object sender, EventArgs args)
        {

            await Navigation.PushAsync(new NewsFeedPro());
        }
    }
}