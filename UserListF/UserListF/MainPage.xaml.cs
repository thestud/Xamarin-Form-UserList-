using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using UserListF.Models;

namespace UserListF
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void AddUserClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserEntryPage
            {
                BindingContext = new User()
            }) ;
            
        }

        async void SelectUser(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new UserEntryPage
                {
                    BindingContext = e.SelectedItem as User
                });
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetUserAsync();
        }

    }
}
