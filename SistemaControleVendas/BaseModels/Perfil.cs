using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Perfil
    {

        [Key]
        public int PerfilID { get; set; }

        [Required(ErrorMessage = "O nome do perfil é necessário")]
        [StringLength(10, ErrorMessage = "Tamanho máximo é 10 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição do curso é necessária")]
        [DataType(DataType.MultilineText)]
        [StringLength(100, ErrorMessage = "Tamanho máximo é 100 caracteres")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Administrador")]
        public bool Admin { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
