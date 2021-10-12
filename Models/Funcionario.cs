using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oficina.Models
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }

        public List<Ordem> Ordens { get; set; }
    }
}