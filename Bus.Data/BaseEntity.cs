using System.ComponentModel.DataAnnotations;

namespace Bus.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
