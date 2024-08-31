using ArtGallerySystem.UI.ViewModels;
using System.Text.RegularExpressions;

namespace ArtGallerySystem.UI.Pages;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
		BindingContext = registerViewModel;
        //Email.TextChanged += (s, e) =>
        //{
        //    if (IsEmail(e.NewTextValue))
        //        EmailBorder.Stroke = Colors.Green;
        //    else
        //        EmailBorder.Stroke = Colors.Red;
        //};

        //Password.TextChanged += (s, e) =>
        //{
        //    if (IsPassword(e.NewTextValue))
        //        PasswordBorder.Stroke = Colors.Green;
        //    else
        //        PasswordBorder.Stroke = Colors.Red;
        //};
        //Phone.TextChanged += (s, e) =>
        //{
        //    if (IsPhoneNumber(e.NewTextValue))
        //        PhoneBorder.Stroke = Colors.Green;
        //    else
        //        PhoneBorder.Stroke = Colors.Red;
        //};
    }
    //static bool IsEmail(string email)
    //{
    //    string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
    //    Regex emailRegex = new(emailPattern);
    //    if (emailRegex.IsMatch(email) && !string.IsNullOrWhiteSpace(email))
    //        return true;
    //    else
    //        return false;
    //}
    //static bool IsPassword(string password)
    //{
    //    if (password.Length < 6 || password.Length > 20)
    //        return false;
    //    bool hasLetter = false;
    //    bool hasDigit = false;
    //    foreach (char c in password)
    //    {
    //        if (char.IsLetter(c))
    //            hasLetter = true;
    //        else if (char.IsDigit(c))
    //            hasDigit = true;
    //    }
    //    return hasLetter && hasDigit;
    //}
    //static bool IsPhoneNumber(string phoneNumber)
    //{
    //    string phonePattern = @"^\+375(29|33|25|44)\d{7}$";
    //    Regex phoneRegex = new(phonePattern);
    //    return phoneRegex.IsMatch(phoneNumber) && !string.IsNullOrWhiteSpace(phoneNumber);
    //}
}