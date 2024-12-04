namespace HosxpUi.Models
{
    public class PatientDto
{

    public int? OappId { get; set; }
    public string? Hn { get; set; }
    public string? Doctor { get; set; }
    public string? Name { get; set; }
    public DateOnly? Vstdate { get; set; }
    public DateOnly? NextDate { get; set; }
    public TimeOnly? NextTime { get; set; }
    public string? Vn { get; set; }
    public string? Department { get; set; }
    public string? Pname { get; set; }
    public string? Fname { get; set; }
    public string? Lname { get; set; }
    public string? Cid { get; set; }
    public string? Clinic { get; set; }
    public string? Hometel { get; set; }
    public string correlationId { get; set; }
    public DateOnly DateOnly { get; set; } = DateOnly.FromDateTime(DateTime.Now); 
    public TimeOnly TimeOnly { get; set; } = TimeOnly.FromDateTime(DateTime.Now);
    public string? PtName => $"{Pname} {Fname} {Lname}";
    public DateOnly? Expiredate { get; set; }

    public string Pttype { get; set; } = null!;
    
    public string PttName { get; set; } = null!;
    public string? Pttypeno1 { get; set; }

    public DateOnly? Begindate { get; set; }
    public int? Age { get; set; }
    public int? Oqueue { get; set; }
    public string? Image { get; set; }
    public string? VisitVn { get; set; }

}
}