using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Aula1406.Models
{
    public class Categoria
    {
        [Key, ScaffoldColumn(false)]
        public int CategoriaID { get; set; }
        [Required(ErrorMessage ="Favor preencher o campo nome!")]
        [StringLength(10, ErrorMessage = "Não pode exceder o tamanho máximo de 10 caracteres")]
        public string Nome { get; set; }
        [Display(Name ="Descrição"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        [Required]
        public bool Ativo { get; set; }
    }
}