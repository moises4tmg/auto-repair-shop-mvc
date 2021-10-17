using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oficina.Models
{
    public class Funcionario
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo usuário é obrigatório")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório")]
        [Display(Name = "Senha")]
        public string Senha { get; set; } 

        [Display(Name = "Administrador")]
        public bool Administrador { get; set; }

        public List<Ordem> Ordens { get; set; }
    }
}