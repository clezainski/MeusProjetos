using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Livro
    {
        [Key]
        public int LivroID { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Por favor, insira o nome do livro.")]
        [StringLength(40, ErrorMessage = "Tamanho máximo é de até 40 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Por favor, insira o autor do livro.")]
        [StringLength(40, ErrorMessage = "Tamanho máximo é de até 40 caracteres")]
        public string Autor { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição do livro é necessária")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Tamanho máximo é de até 100 caracteres")]
        public string Descricao { get; set; }

        [Display(Name ="Genêro Literário")]
        public int LiteraturaID { get; set; }
        public virtual Literatura _literatura { get; set; }
    }
}