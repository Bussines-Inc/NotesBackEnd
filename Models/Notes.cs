namespace NotesBackend.Models
{
    public class Notes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? NoteCreateDate { get; set; }
        public DateTime? NoteUpdateDate { get; set; }
        public DateTime? NoteDeleteDate { get; set; }
        public DateTime? NoteFinishDate { get; set; }
        public string Status { get; set; }
        public int IdCategory { get; set; }


    }
}