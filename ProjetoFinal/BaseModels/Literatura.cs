using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Literatura
    {
        [Key]
        public int LiteraturaID { get; set; }

        [Display(Name ="Gênero literário:")]
        [Required(ErrorMessage = "Por favor, insira o nome do genêro literário.")]
        [StringLength(40, ErrorMessage = "Tamanho máximo são de 40 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Idade miníma recomendada:")]
        [Required(ErrorMessage = "Por favor, insira a idade miníma recomendada.")]
        public int Idade { get; set; }
    }
}
