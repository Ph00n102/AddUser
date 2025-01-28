using System;

namespace HosxpUi.ViewModels;

public class IpdVsVitalSign
{
    public DateTime vsDatetime { get; set; }
    public decimal? bt { get; set; }
    public uint? pr { get; set; }
    public uint? rr { get; set; }
    public uint? sbp { get; set; }
    public uint? dbp { get; set; }
    public int? map { get; set; }
    public uint? sat { get; set; } 
}
