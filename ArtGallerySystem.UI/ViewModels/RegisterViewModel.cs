using ArtGallerySystem.Application.ClientUseCases.Commands;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;
using System.Diagnostics;

namespace ArtGallerySystem.UI.ViewModels
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public RegisterViewModel(IMediator mediator)
        {
            _mediator = mediator;
            UpdateCanRegister();
        }

        [ObservableProperty] private string _name;
        [ObservableProperty] private string _surname;
        [ObservableProperty] private string _email;
        [ObservableProperty] private string _phone;
        [ObservableProperty] private string _password;
        [ObservableProperty] private Color _nameBorderColor = Colors.Red;
        [ObservableProperty] private Color _surnameBorderColor = Colors.Red;
        [ObservableProperty] private Color _emailBorderColor = Colors.Red;
        [ObservableProperty] private Color _phoneBorderColor = Colors.Red;
        [ObservableProperty] private Color _passwordBorderColor = Colors.Red;
        [ObservableProperty] private string _nameValidationMessage;
        [ObservableProperty] private string _surnameValidationMessage;
        [ObservableProperty] private string _emailValidationMessage;
        [ObservableProperty] private string _phoneValidationMessage;
        [ObservableProperty] private string _passwordValidationMessage;
        [ObservableProperty] private bool _canRegister;

        partial void OnNameChanged(string value)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    NameBorderColor = Colors.Green;
                    NameValidationMessage = string.Empty;
                }
                else
                {
                    NameBorderColor = Colors.Red;
                    NameValidationMessage = "Name cannot be empty.";
                }
                UpdateCanRegister();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
            
        }

        partial void OnSurnameChanged(string value)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    SurnameBorderColor = Colors.Green;
                    SurnameValidationMessage = string.Empty;
                }
                else
                {
                    SurnameBorderColor = Colors.Red;
                    SurnameValidationMessage = "Surname cannot be empty.";
                }
                UpdateCanRegister();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        partial void OnEmailChanged(string value)
        {
            try
            {
                if (IsEmail(value))
                {
                    EmailBorderColor = Colors.Green;
                    EmailValidationMessage = string.Empty;
                }
                else
                {
                    EmailBorderColor = Colors.Red;
                    EmailValidationMessage = "Invalid email format.";
                }
                UpdateCanRegister();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
 
        }

        partial void OnPhoneChanged(string value)
        {
            try
            {
                if (IsPhoneNumber(value))
                {
                    PhoneBorderColor = Colors.Green;
                    PhoneValidationMessage = string.Empty;
                }
                else
                {
                    PhoneBorderColor = Colors.Red;
                    PhoneValidationMessage = "Invalid phone number format.";
                }
                UpdateCanRegister();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        partial void OnPasswordChanged(string value)
        {
            try
            {
                if (IsPassword(value))
                {
                    PasswordBorderColor = Colors.Green;
                    PasswordValidationMessage = string.Empty;
                }
                else
                {
                    PasswordBorderColor = Colors.Red;
                    PasswordValidationMessage = "Password must be 6-20 characters and contain letters and digits.";
                }
                UpdateCanRegister();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        private void UpdateCanRegister()
        {
            CanRegister = !string.IsNullOrWhiteSpace(Name) && NameBorderColor == Colors.Green
                          && !string.IsNullOrWhiteSpace(Surname) && SurnameBorderColor == Colors.Green
                          && IsEmail(Email) && EmailBorderColor == Colors.Green
                          && IsPhoneNumber(Phone) && PhoneBorderColor == Colors.Green
                          && IsPassword(Password) && PasswordBorderColor == Colors.Green;
        }

        [RelayCommand]
        async Task RegisterAsync()
        {
            if (!CanRegister) return;

            await RegisterUserAsync();
        }

        private async Task RegisterUserAsync()
        {
            var client = await _mediator.Send(new GetClientByEmailPhoneRequest(Email, Phone));
            if (client == null)
            {
                await _mediator.Send(new AddClientCommand(Name, Surname, Email, Phone, Password));
                await Shell.Current.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Email/phone already in use", "OK");
            }
        }

        static bool IsEmail(string email)
        {
            string emailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex emailRegex = new(emailPattern);
            return emailRegex.IsMatch(email) && !string.IsNullOrWhiteSpace(email);
        }

        static bool IsPassword(string password)
        {
            if (password.Length < 6 || password.Length > 20)
                return false;
            bool hasLetter = false;
            bool hasDigit = false;
            foreach (char c in password)
            {
                if (char.IsLetter(c))
                    hasLetter = true;
                else if (char.IsDigit(c))
                    hasDigit = true;
            }
            return hasLetter && hasDigit;
        }

        static bool IsPhoneNumber(string phoneNumber)
        {
            string phonePattern = @"^\+375(29|33|25|44)\d{7}$";
            Regex phoneRegex = new(phonePattern);
            return phoneRegex.IsMatch(phoneNumber) && !string.IsNullOrWhiteSpace(phoneNumber);
        }
    }
}
