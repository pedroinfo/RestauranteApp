using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestauranteApp.Models
{
    [Table("Prato")]
    public class Prato
    {
        [Key]
        public int PratoId { get; set; }

       
        public int RestauranteId { get; set; }

        [Required]
        [Display(Name = "Prato")]
        public string Nome { get; set; }

        [Required]
        [Display(Name = "Preço R$")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public Restaurante Restaurante { get; set; }
    }
}