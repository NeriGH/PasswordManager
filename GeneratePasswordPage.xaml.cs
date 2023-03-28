using System;
using System.Linq;
using Microsoft.Maui.Controls;

namespace PasswordManager;

public partial class GeneratePasswordPage : ContentPage
{
	public GeneratePasswordPage()
	{
		InitializeComponent();
	}

    private void OnGeneratePasswordClicked(object sender, EventArgs e)
    {
        // Get the length of the password from the slider control
        int passwordLength = (int)lengthSlider.Value;

        // Define the character sets to use for the password based on the switch controls
        string uppercaseChars = uppercaseSwitch.IsToggled ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : "";
        string lowercaseChars = lowercaseSwitch.IsToggled ? "abcdefghijklmnopqrstuvwxyz" : "";
        string numericChars = numericSwitch.IsToggled ? "0123456789" : "";
        string specialChars = specialSwitch.IsToggled ? "!@#$%^&*()_+-={}[]|\\:;\"'<>,.?/" : "";

        // Combine the character sets into a single set
        string allChars = uppercaseChars + lowercaseChars + numericChars + specialChars;

        // Create a random number generator
        Random rand = new Random();

        // Generate the password
        string password = new string(Enumerable.Repeat(allChars, passwordLength)
            .Select(s => s[rand.Next(s.Length)]).ToArray());

        // Display the password
        passwordLabel.Text = password;

        // Show the "Copy to Clipboard" button
        copyToClipboardButton.IsVisible = true;


    }

    private void OnCopyToClipboardClicked(object sender, EventArgs e)
    {
        string password = passwordLabel.Text;
        if (!string.IsNullOrEmpty(password))
        {
            Clipboard.SetTextAsync(password);
            DisplayAlert("Success", "Password copied to clipboard", "OK");
        }
    }


}