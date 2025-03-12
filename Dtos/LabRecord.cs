using System;

namespace HosxpUi.Dtos;

public class LabRecord
{
    public string HosGuid { get; set; }
    public string Hn { get; set; }
    public string Vn { get; set; }
    public string LastDep { get; set; }
    public string ClinicName { get; set; }
    public string PatientName { get; set; }
    public int LabOrderNumber { get; set; }
    public string LabOrderList { get; set; }
    public string LabConfirm { get; set; }
    public TimeOnly? ReportTime { get; set; }
    public string? LisOrderNo { get; set; }
}
