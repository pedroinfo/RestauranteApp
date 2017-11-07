using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestauranteApp.Models
{
    [Table("Restaurante")]
    public class Restaurante
    {
        [Key]
        public int RestauranteId { get; set; }

        [Display(Name = "Restaurante")]
        [Required]
        public string Nome { get; set; }
    }
}