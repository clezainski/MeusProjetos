using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1406.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage ="Favor preencher o campo nome!")]
        public string Nome { get; set; }
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        [Required]
        public bool Ativo { get; set; }
    }
}