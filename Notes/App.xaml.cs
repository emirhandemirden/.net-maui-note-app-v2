using Notes.Views;

namespace Notes;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

        AppActions.SetAsync(
            new AppAction("NotePage", "Add Note", icon: "add_note"),
            new AppAction("AllNotesPage", "List Of Notes", icon: "notes_list"),
            new AppAction("AboutPage", "App Information", icon: "app_info")
        );


        AppActions.OnAppAction += AppActions_OnAppAction;
    }

    private void AppActions_OnAppAction(object sender, AppActionEventArgs e)
    {
        // Don't handle events fired for old application instances
        // and cleanup the old instance's event handler
        if (Current != this && Current is App app)
        {
            AppActions.OnAppAction -= app.AppActions_OnAppAction;
            return;
        }
        MainThread.BeginInvokeOnMainThread(async () =>
        {
            if(e.AppAction.Id == "NotePage") await Current.MainPage.Navigation.PushModalAsync(new NotePage());
            else if(e.AppAction.Id == "AllNotesPage") await Current.MainPage.Navigation.PushModalAsync(new AllNotesPage());
            else if(e.AppAction.Id == "AboutPage") await Current.MainPage.Navigation.PushModalAsync(new AboutPage());
        });
    }
}
