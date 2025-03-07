using System;

namespace HosxpUi.Models;

public class LogEntry
{
    public string message { get; set; }
    public string messageTemplate { get; set; }
    public string level { get; set; }
    public DateTime timestamp { get; set; }
}
