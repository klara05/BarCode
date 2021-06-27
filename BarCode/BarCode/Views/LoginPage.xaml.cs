using BarCode.Models;
using BarCode.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows;
using Xamarin.Forms.Xaml;
using System.Data.SqlClient;
using System.Data;

namespace BarCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {


        //UserDB userData;

        public LoginPage()
        {
            InitializeComponent();
            //userData = new UserDB();
            NavigationPage.SetHasBackButton(this, false);
            //userNameEntry.ReturnCommand = new Command(() => passwordEntry.Focus());
            //firstPassword.ReturnCommand = new Command(() => secondPassword.Focus());
            //var forgetpassword_tap = new TapGestureRecognizer();
        }

        //string logesh;
        //private async void userIdCheckEvent(object sender, EventArgs e)
        //{
        //    if ((string.IsNullOrWhiteSpace(useridValidationEntry.Text)) || (string.IsNullOrWhiteSpace(useridValidationEntry.Text)))
        //    {
        //        await DisplayAlert("Alert", "Enter Mail Id", "OK");
        //    }
        //    else
        //    {
        //        logesh = useridValidationEntry.Text;
        //        var textresult = userData.updateUserValidation(useridValidationEntry.Text);
        //        if (textresult)
        //        {
        //            popupLoadingView.IsVisible = false;
        //            passwordView.IsVisible = true;
        //        }
        //        else
        //        {
        //            await DisplayAlert("User Mail Id Not Exist", "Enter Correct User Name", "OK");
        //        }
        //    }
        //}
        //private async void Password_ClickedEvent(object sender, EventArgs e)
        //{
        //    if (!string.Equals(firstPassword.Text, secondPassword.Text))
        //    {
        //        warningLabel.Text = "Enter Same Password";
        //        warningLabel.TextColor = Color.IndianRed;
        //        warningLabel.IsVisible = true;
        //    }
        //    else if ((string.IsNullOrWhiteSpace(firstPassword.Text)) || (string.IsNullOrWhiteSpace(secondPassword.Text)))
        //    {
        //        await DisplayAlert("Alert", " Enter Password", "OK");
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var return1 = userData.updateUser(logesh, firstPassword.Text);
        //            passwordView.IsVisible = false;
        //            if (return1)
        //            {
        //                await DisplayAlert("Password Updated", "User Data updated", "OK");
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }
        //}


        async void LoginValidation_ButtonClicked(object sender, EventArgs e)
        {
            string strConnString = "data source=192.168.0.19,1433; initial catalog=Login; user id=test123; password=Plastik123; Connect Timeout=10";
            SqlConnection connection = new SqlConnection(strConnString);
            {
                string userName = userNameEntry.Text;
                string userPassword = passwordEntry.Text;

                string query = @"if exists (Select Username from Login where Username='" + userName + "'AND Password= '" + userPassword + "') select 0  else  select 1  ";
                connection.Open();

                SqlCommand date = new SqlCommand(query, connection);
                int x = Convert.ToInt32(date.ExecuteScalar());
                if (x == 1)
                {
                    await DisplayAlert("Greska", "Ne postojeci korisnik", "OK");
                    connection.Close();
                    userNameEntry.Text = "";
                    passwordEntry.Text = "";

                }
                else if (x == 0)
                {
                    await DisplayAlert("Uspjesno", "Postojeci korisnik", "OK");
                    userNameEntry.Text = "";
                    passwordEntry.Text = "";
                    await Navigation.PushAsync(new ScanPage());

                }

            }

      

        }
    }

}