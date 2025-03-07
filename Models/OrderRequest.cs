using System;

namespace HosxpUi.Models;

public class OrderRequest
{
    public string An { get; set; }
    public string LoginName { get; set; }
    public string OrderDoctor { get; set; }
    public List<OrderItem> OnedayOrders { get; set; }
    public List<OrderItem> ContinuousOrders { get; set; }
}
