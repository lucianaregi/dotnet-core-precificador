using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIPrecificador.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }

        [StringLength(300)]
        public string ImagemUrl { get; set; }

        public int Quantidade { get; set; }
        public DateTime DataCadastro { get; set; }

        public DateTime DataCompra { get; set; }

        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }

        public Fornecedor Fornecedor { get; set; }
        public int FornecedorId { get; set; }

        public Markup Markup { get; set; }
        public int MarkupId { get; set; }
    }
}
