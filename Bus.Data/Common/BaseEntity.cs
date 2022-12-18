using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bus.Data.Common
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("false")]
        public bool isDisable { get; set; }
    }
}
