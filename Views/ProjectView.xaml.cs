using Asana3.Maui.ViewModels;

namespace Asana3.Maui.Views;

public partial class ProjectView : ContentPage
{
	public ProjectView()
	{
		InitializeComponent();
        BindingContext = new ProjectPageViewModel(); 
       
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {

    }

    private void EditClicked(object sender, EventArgs e)
    {

    }

    private void DeleteClicked(object sender, EventArgs e)
    {

    }
}


