namespace HosxpUi.Models
{
    public class AuthenClaimDto
        {
            public string ClaimType { get; set; }
            public string ClaimCode { get; set; }
            public string Hcode { get; set; }
            public DateTime ClaimDateTime { get; set; }
            public DateTime CheckDate { get; set; }
        }
}