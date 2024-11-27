namespace HosxpUi.Models 
{
    public class OrderDetail 
    {
        public string orderDate { get; set; }
        public List<Oneday> oneday { get; set; }
        public List<Continuou> continuous { get; set; }
    }
}