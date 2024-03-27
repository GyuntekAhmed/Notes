namespace Notes.ViewModels;

using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

public class NoteViewModel : ObservableObject, IQueryAttributable
{
    private Models.Note note;

    public string Text
    {
        get => note.Text;
        set
        {
            if (note.Text != value)
            {
                note.Text = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime Date => note.Date;

    public string Identifier => note.FileName;

    public ICommand SaveCommand { get; private set; }

    public ICommand DeleteCommand { get; private set; }

    public NoteViewModel()
    {
        note = new Models.Note();
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    public NoteViewModel(Models.Note note)
    {
        this.note = note;
        SaveCommand = new AsyncRelayCommand(Save);
        DeleteCommand = new AsyncRelayCommand(Delete);
    }

    private async Task Save()
    {
        note.Date = DateTime.Now;
        note.Save();
        await Shell.Current.GoToAsync($"..?saved={note.FileName}");
    }

    private async Task Delete()
    {
        note.Delete();
        await Shell.Current.GoToAsync($"..?deleted={note.FileName}");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            note = Models.Note.Load(query["load"].ToString());
            RefreshProperties();
        }
    }

    public void Reload()
    {
        note = Models.Note.Load(note.FileName);
        RefreshProperties();
    }

    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Text));
        OnPropertyChanged(nameof(Date));
    }
}