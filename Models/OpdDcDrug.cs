namespace HosxpUi.Models
{
    public class OpdDcDrug
    {
        public string dchdate { get; set; }
        public List<DrugInfo2> drugInfo { get; set; }
    }

    public class DrugInfo2
    {
        public string hn { get; set; }
        public string an { get; set; }
        public string rxdate { get; set; }
        public string dchdate { get; set; }
        public string icode { get; set; }
        public string drugName { get; set; }
        public object nondrugName { get; set; }
        public string strength { get; set; }
        public string usageName1 { get; set; }
        public string usageName2 { get; set; }
        public string usageName3 { get; set; }
        public object spUsageName1 { get; set; }
        public object spUsageName2 { get; set; }
        public object spUsageName3 { get; set; }
        public int qty { get; set; }
        public string dosageform { get; set; }
    }
}