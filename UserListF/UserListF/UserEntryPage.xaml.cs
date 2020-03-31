using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UserListF.Models;
using System.Text.RegularExpressions;
using UserListF.Validators;

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
            /* perform validation
             * I would like to make these tags a separate logic then here
             * 
             */

            LettersAndNumbersValidator lettersAndNumbersValidator = new LettersAndNumbersValidator();

            NoRepeatingPatternValidator noRepeatingPatternValidator = new NoRepeatingPatternValidator();

            StringValidator stringValidator = new StringValidator();

            // making all fields required
            if(UserName.Text == null || !stringValidator.validate(UserName.Text))
            {
                ErrorLabel.Text = "User Name must be 5 characters long and no longer than 12 characters";
                UserName.BackgroundColor = Color.Yellow;
                return;
            }

            if (FirstName.Text == null || !stringValidator.validate(FirstName.Text))
            {
                ErrorLabel.Text = "First Name must be 5 characters long and no longer than 12 characters";
                FirstName.BackgroundColor = Color.Yellow;
                return;
            }

            if (LastName.Text == null || !stringValidator.validate(LastName.Text))
            {
                ErrorLabel.Text = "Last Name must be 5 characters long and no longer than 12 characters";
                LastName.BackgroundColor = Color.Yellow;
                return;
            }

            // Password is null 
            if (PasswordField.Text == null || (!stringValidator.validate(PasswordField.Text)))
            {
                // ^.{0}$
                ErrorLabel.Text = "Password must be 5 characters long and no longer than 12 characters";
                PasswordField.BackgroundColor = Color.Yellow;
                // PasswordField.BorderColor 
                return; 
            } 

            if (!lettersAndNumbersValidator.validate(PasswordField.Text))
            {
                ErrorLabel.Text = "Password must consist of a mixture of letters and numerical digits only, with at least one of each.";
                PasswordField.BackgroundColor = Color.Yellow;
                return;
            }

            if(!noRepeatingPatternValidator.validate(PasswordField.Text))
            {
                ErrorLabel.Text = "Password must not have repeatable patterns.";
                PasswordField.BackgroundColor = Color.Yellow;
                return; 
            }

            // Password is accepted
            UserName.BackgroundColor = Color.White;
            FirstName.BackgroundColor = Color.White;
            LastName.BackgroundColor = Color.White;
            PasswordField.BackgroundColor = Color.White;

            var user = (User)BindingContext;
            await App.Database.SaveUserAsync(user);
            await Navigation.PopAsync();
        }
    }
}