using System;
using System.ComponentModel.DataAnnotations;

namespace Oficina.Models
{
    public class Ordem
    {
        [Key]
        [Display(Name = "ID")]
        public int Id { get; set; }


        [Display(Name = "ID do Cliente")]
        public int ClienteId { get; set; }


        [Display(Name = "ID do Mecânico")]
        public int FuncionarioId { get; set; }


        [Display(Name = "Descrição do Defeito")]
        public string DescricaoDefeito { get; set; }


        [Display(Name = "Descrição da Solução")]
        public string DescricaoSolucao { get; set; }


        [Display(Name = "Placa")]
        public string Placa { get; set; }


        [Display(Name = "Data de Registro")]
        public DateTime DataRegistro { get; set; }


        [Display(Name = "Prazo de Entrega")]
        public DateTime DataPrazo { get; set; }


        [Display(Name = "Total(R$)")]
        public double PrecoTotal { get; set; }


        [Display(Name = "Cliente")]
        public virtual Cliente Cliente { get; set; }


        [Display(Name = "Mecânico")]
        public virtual Funcionario Funcionario { get; set; }
    }
}