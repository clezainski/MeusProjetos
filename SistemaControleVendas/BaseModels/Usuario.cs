using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseModels
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "O nome é necessário")]
        [StringLength(10, ErrorMessage = "Tamanho máximo é 10 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O sobrenome é necessário")]
        [StringLength(10, ErrorMessage = "Tamanho máximo é 10 caracteres")]
        public string Sobrenome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O CPF é necessário")]
        [StringLength(11, ErrorMessage = "Tamanho máximo é 11 caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O e-mail é necessário")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido")]
        public string Email { get; set; }

        [Display(Name = "Nome de usuário")]
        [Required(ErrorMessage = "O nome de usuário necessário")]
        [StringLength(10, ErrorMessage = "Tamanho máximo é 10 caracteres")]
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "A senha é necessária")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme sua senha")]
        [Compare("Senha",ErrorMessage ="Por favor, confirme sua senha.")]
        [DataType(DataType.Password)]
        public string ConfirmaSenha { get; set; }

        [Display(Name = "Usuário administrador")]
        [Required]
        public bool Administrador { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
