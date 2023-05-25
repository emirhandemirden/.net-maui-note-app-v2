namespace Notes.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePage : ContentPage{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

    public NotePage() {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));
    }

    private void LoadNote(string fileName) {
        Models.Note noteModel = new Models.Note();
        noteModel.Filename = fileName;
        if (File.Exists(fileName)) {
            noteModel.Date = File.GetCreationTime(fileName);
            string[] text = File.ReadAllText(fileName).Split(','); ;
            noteModel.Title = text[0];
            noteModel.Text = text[1];
        }
        BindingContext = noteModel;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e) {
        if (BindingContext is Models.Note note) File.WriteAllText(note.Filename, Entry_Title.Text + "," + TextEditor.Text);
        await DisplayAlert("Saved", "You saved this note succesfully", "OK");
        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e) {
        if (await DisplayAlert("Are you sure?", "Do you want to delete this note?\nIf you continue you can never take it back.", "Yes", "No")) {
            if (BindingContext is Models.Note note) {
                // Delete the file.
                if (File.Exists(note.Filename)) File.Delete(note.Filename);
            }
            await DisplayAlert("Deleted", "You deleted this note succesfully", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }

    public string ItemId { set { LoadNote(value); } }
}