
namespace PasswordManager;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}


    private bool isPasswordHidden = true;

    private void OnShowHideClicked(object sender, EventArgs e)
    {
        if (isPasswordHidden)
        {
            var passwordLength = PasswordLabel.Text.Length;
            var hiddenPassword = new string('•', passwordLength);
            PasswordLabel.Text = hiddenPassword;
            isPasswordHidden = false;
        }
        else
        {
            PasswordLabel.Text = "MyPassword";
            isPasswordHidden = true;
        }
    }


    private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}


}

