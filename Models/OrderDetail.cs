namespace HosxpUi.Models 
{
    public class OrderDetail 
    {
        public string an { get; set; }
        public List<Oneday> oneday { get; set; }
        public List<Continuou> continuous { get; set; }
    }
}