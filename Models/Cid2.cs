namespace HosxpUi.Models
{
    public class ClaimType
    {
        public string claimType { get; set; }
        public string claimTypeName { get; set; }
    }

    public class HospMain
    {
        public string hcode { get; set; }
        public string hname { get; set; }
    }
    

    public class Cid2
    {
        public string pid { get; set; }
        public string titleName { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string nation { get; set; }
        public string birthDate { get; set; }
        public string sex { get; set; }
        public DateTime transDate { get; set; }
        public string mainInscl { get; set; }
        public string subInscl { get; set; }
        public string age { get; set; }
        public DateTime checkDate { get; set; }
        public List<ClaimType> claimTypes { get; set; }
        public string correlationId { get; set; }
        public HospMain hospMain { get; set; }
        public DateTime startDateTime { get; set; }

         
        
    }
}