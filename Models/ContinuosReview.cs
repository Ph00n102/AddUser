using System;

namespace HosxpUi.Models;

public class ContinuosReview
{
    public int orderItemId { get; set; }
    public string orderType { get; set; }
    public string orderDate { get; set; }
    public string orderTime { get; set; }
    public string orderItemType { get; set; }
    public object offOrderItemId { get; set; }
    public string drugName { get; set; }
    public string orderItemDetail { get; set; }
}
