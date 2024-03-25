namespace Notes.Models
{
    public class Note
    {
        public string FileName { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTime Date { get; set; }
    }
}
