using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIPrecificador.Models
{
    [Table("Markups")]
    public class Markup
    {
        [Key]
        public int MarkupId { get; set; }
        [Required]
        public decimal DespesaFixa { get; set; }
        [Required]
        public decimal DespesaVariavel { get; set; }
        [Required]
        public decimal MargemLucro { get; set; }
        public decimal ValorMarkup { get; set; }
        public DateTime DataCadastro { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }
    }
}
