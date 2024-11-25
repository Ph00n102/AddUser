namespace HosxpUi.Models 
{
    public class PtNote
    {
        public int ptnoteId { get; set; }
        public string hn { get; set; }
        public string noteflag { get; set; }
        public string ptnote1 { get; set; }
        public object vstdate { get; set; }
        public object vsttime { get; set; }
        public string groupname { get; set; }
        public string plainText { get; set; }
        public object prscNoteText { get; set; }
        public DateTime noteDatetime { get; set; }
        public string noteStaff { get; set; }
        public object usernameList { get; set; }
        public string hasExpired { get; set; }
        public string expireDate { get; set; }
        public string publicNote { get; set; }
        public object encryptNote { get; set; }
        public object hosGuid { get; set; }
        public object showAllDep { get; set; }
        public object checkGroup { get; set; }
        public object ptnoteHtml { get; set; }
    }
}