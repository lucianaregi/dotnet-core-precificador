using Microsoft.EntityFrameworkCore.Migrations;

namespace APIPrecificador.Migrations
{
    public partial class Populadb : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Cosméticos','http://www.soakilo.com.br/Imagens/1.jpg')");
            mb.Sql("Insert into Categorias(Nome, ImagemUrl) Values('Acessórios','http://www.soakilo.com.br/Imagens/2.jpg')");

            mb.Sql("Insert into Fornecedores(Nome) Values('Miess')");
            mb.Sql("Insert into Fornecedores(Nome) Values('Gall')");

            mb.Sql("Insert into Markups(DespesaFixa, DespesaVariavel, MargemLucro, ValorMarkup,DataCadastro,FornecedorId)" +
            "Values(12, 15, 18, 1.83, now(),(Select FornecedorId from Fornecedores where Nome='Miess'))");


            mb.Sql("Insert into Produtos(Nome,Descricao,PrecoCompra,PrecoVenda,ImagemUrl,Quantidade,DataCadastro,DataCompra,CategoriaId, FornecedorId, MarkupId) " +
            "Values('Pomada Oriental','Para massagem',4.40,8.80,'http://www.soakilo.com.br/Imagens/1.jpg',5,now(),now(),(Select CategoriaId from Categorias where Nome='Cosméticos'),(Select FornecedorId from Fornecedores where Nome='Miess'),1)");
            mb.Sql("Insert into Produtos(Nome,Descricao,PrecoCompra,PrecoVenda,ImagemUrl,Quantidade,DataCadastro,DataCompra,CategoriaId, FornecedorId, MarkupId) " +
            "Values('Pétalas Aromáticas','Para decoração',7.20,14.40,'http://www.soakilo.com.br/Imagens/2.jpg',3,now(),now(),(Select CategoriaId from Categorias where Nome='Acessórios'),(Select FornecedorId from Fornecedores where Nome='Gall'),1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Categorias");
            mb.Sql("Delete from Produtos");
        }
    }
}
