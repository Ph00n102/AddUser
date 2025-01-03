namespace HosxpUi.Models
{
    public class ClinicVisit
    {
        public string? Hn { get; set; }

        public string Clinic { get; set; } = null!;

        public string Vn { get; set; } = null!;

        public int? VisitType { get; set; }

        public string? HosGuid { get; set; }

        public string? AfbCheck { get; set; }

        public int? AfbMonthNumber { get; set; }

        public string? HosGuidExt { get; set; }

        public int? SkhInsert { get; set; }
    }
}