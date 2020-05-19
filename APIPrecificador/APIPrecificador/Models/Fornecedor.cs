using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIPrecificador.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        public int FornecedorId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        public ICollection<Produto> Produtos { get; set; }
    }
}
