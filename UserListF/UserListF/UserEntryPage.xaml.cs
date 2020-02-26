using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using UserListF.Models; 

namespace UserListF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserEntryPage : ContentPage
    {
        public UserEntryPage()
        {
            InitializeComponent();
        }

        protected async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            await App.Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }
    }
}