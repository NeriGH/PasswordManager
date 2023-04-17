using PasswordManager.Models;
using PasswordManager.ViewModels;

namespace PasswordManager.Views;

public partial class PasswordListPage : ContentPage
{
	private PasswordListPageViewModel _viewMode;
	public PasswordListPage(PasswordListPageViewModel viewModel)
	{
		InitializeComponent();
		_viewMode = viewModel;
		this.BindingContext = viewModel;
	}

    private void OnShowHidePasswordClicked(object sender, EventArgs e)
    {
        // Get the button that was clicked
        var button = (Button)sender;

        // Get the corresponding PasswordModel object from the BindingContext
        var password = (PasswordModel)button.BindingContext;

        // Toggle the IsPasswordVisible property of the PasswordModel object
        password.IsPasswordVisible = !password.IsPasswordVisible;

        // Update the text of the password label
        var passwordLabel = (Label)button.Parent.FindByName("PasswordLabel");
        passwordLabel.Text = password.IsPasswordVisible ? password.Password : new string('\u2022', password.Password.Length);
    }



    protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewMode.GetPasswordListCommand.Execute(null);
	}
}