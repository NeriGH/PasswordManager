using PasswordManager.Views;

namespace PasswordManager;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUpdatePasswordDetail),typeof(AddUpdatePasswordDetail));
	}
}
