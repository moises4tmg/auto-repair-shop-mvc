using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oficina.Models
{
    public class Cliente
    {

        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }


        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }


        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Número de CPF inválido")]
        public string Cpf { get; set; }


        [Display(Name = "Endereço")]
        public string Endereco { get; set; }


        [Display(Name = "Cidade")]
        public string Cidade { get; set; }


        [Display(Name = "UF")]
        public string Estado { get; set; }


        [Display(Name = "CEP")]
        public string Cep { get; set; }


        [Display(Name = "Fone 1")]
        [Required(ErrorMessage = "Número de telefone inválido")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número de telefone inválido")]
        public string Fone1 { get; set; }


        [Display(Name = "Fone 2")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Número de telefone inválido")]
        public string Fone2 { get; set; }


        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email inválido")]
        /*[EmailAddress]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", 
            ErrorMessage = "Números e caracteres especiais não são permitidos no nome.")]*/
        public string Email { get; set; }


        public List<Ordem> Ordens { get; set; }
    }
}