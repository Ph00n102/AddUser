namespace HosxpUi.Models
{
    public class ProgressNote
    {
        public string progressNoteDate { get; set; }
        public List<CreateUser> createUser { get; set; }
    }

     public class CreateUser
    {
        public string createUser { get; set; }
        public List<ProgressNoteList> progressNoteList { get; set; }
    }

    public class ProgressNoteList
    {
        public int progressNoteId { get; set; }
        public string progressNoteDate { get; set; }
        public string progressNoteTime { get; set; }
        public string progressNoteOwnerType { get; set; }
        public int progressNoteItemId { get; set; }
        public string an { get; set; }
        public string progressNoteItemType { get; set; }
        public string progressNoteItemDetail { get; set; }
        public string progressNoteItemDetail2 { get; set; }
    }

}