using System;
using System.Collections.Generic;
using System.Linq;

public class Estoque
{
    private List<Produto> estoque = new List<Produto>();

    public void CadastrarProduto(int codigo, string nome, int quantidade, decimal preco)
    {
        var produto = new Produto
        {
            Codigo = codigo,
            Nome = nome,
            Quantidade = quantidade,
            Preco = preco
        };

        estoque.Add(produto);
        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    public Produto ConsultarProdutoPorCodigo(int codigo)
    {
        var produto = estoque.FirstOrDefault(p => p.Codigo == codigo);
        if (produto == null)
        {
            throw new InvalidOperationException("Produto não encontrado.");
        }

        return produto;
    }

    public void AtualizarEstoque(int codigo, int quantidade)
    {
        var produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

        if (produto == null)
        {
            throw new InvalidOperationException("Produto não encontrado.");
        }

        if (produto.Quantidade + quantidade < 0)
        {
            throw new InvalidOperationException("Quantidade insuficiente em estoque para a saída.");
        }

        produto.Quantidade += quantidade;
        Console.WriteLine("Estoque atualizado com sucesso!");
    }

    public IEnumerable<Produto> GerarRelatorioQuantidade(int limiteQuantidade)
    {
        return estoque.Where(p => p.Quantidade < limiteQuantidade);
    }

    public IEnumerable<(string Nome, int Quantidade, decimal ValorTotalProduto)> GerarRelatorioValorTotal()
    {
        return from produto in estoque
               let valorTotalProduto = produto.Quantidade * produto.Preco
               select (produto.Nome, produto.Quantidade, ValorTotalProduto: valorTotalProduto);
    }

    public IEnumerable<Produto> GerarRelatorioPreco(decimal minimo, decimal maximo)
    {
        return estoque.Where(p => p.Preco >= minimo && p.Preco <= maximo);
    }
}
