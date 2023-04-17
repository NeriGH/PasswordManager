using PasswordManager.ViewModels;

namespace PasswordManager.Views;

public partial class AddUpdatePasswordDetail : ContentPage
{
	public AddUpdatePasswordDetail(AddUpdatePasswordDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel; 
	}
}