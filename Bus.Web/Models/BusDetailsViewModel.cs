namespace Bus.Web.Models
{
    public class BusDetailsViewModel
    {
        public int Id { get; set; }
        public string BusName { get; set; }
        public int BusNo { get; set; }
        public int routeId { get; set; }
        public string routeName { get; set; }
    }
}
