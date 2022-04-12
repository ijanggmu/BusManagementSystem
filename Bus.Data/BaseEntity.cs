using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.Data
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
