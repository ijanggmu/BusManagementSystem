using Bus.Data.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bus.Data
{
    public class BusDetails : BaseEntity
    {
        [Required]
        public string BusName { get; set; }
        [Required]
        public int BusNo { get; set; }
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        public virtual Route Route { get; set; }
        public virtual Route Route { get; set; }
    }
}
