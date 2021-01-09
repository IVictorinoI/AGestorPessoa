using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Infra
{
    public class Identificator
    {
        [Key]
        public int Id { get; set; }
    }
}
