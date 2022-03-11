using Auth.Client.ViewModel;
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
    public partial class PostSport : ContentPage
    {
        public PostSport()
        {
            InitializeComponent();
            BindingContext = new ViewSport();
        }
    }
}