namespace HosxpUi.Models
{
    public class Pttypeno 
    {
        public string Hn { get; set; } = null!;

        public DateOnly? Expiredate { get; set; }
        public string? Hname { get; set; }
        public string Pttype { get; set; } = null!;
        public string Name { get; set; } = null!;

        public string? Pttypeno1 { get; set; }

        public DateOnly? Begindate { get; set; }

        public string? Hospmain { get; set; }

        public string? Hospsub { get; set; }

        public string? HosGuid { get; set; }

        public string? HosGuidExt { get; set; }
    }
}