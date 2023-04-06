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


    protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewMode.GetPasswordListCommand.Execute(null);
	}
}