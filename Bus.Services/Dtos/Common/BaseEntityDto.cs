using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bus.Services.Dtos.Common
{
    public class BaseEntityDto
    {
        [Key]
        public int Id { get; set; }

        [DefaultValue("false")]
        public bool isDisable { get; set; }
    }
}
