using System;
using System.Collections.Generic;

class Program
{
    static Estoque estoque = new Estoque();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Sistema de Gerenciamento de Estoque");
            Console.WriteLine("===================================");

            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Consultar Produto por Código");
            Console.WriteLine("3. Atualizar Estoque");
            Console.WriteLine("4. Gerar Relatórios");
            Console.WriteLine("5. Sair");

            Console.Write("Escolha uma opção: ");
            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    CadastrarProduto();
                    break;
                case 2:
                    ConsultarProdutoPorCodigo();
                    break;
                case 3:
                    AtualizarEstoque();
                    break;
                case 4:
                    GerarRelatorios();
                    break;
                case 5:
                    Console.WriteLine("Obrigado por usar o Sistema de Gerenciamento de Estoque. Até logo!");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarProduto()
    {
        try
        {
            Console.Write("Código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço unitário: ");
            decimal preco = decimal.Parse(Console.ReadLine());

            estoque.CadastrarProduto(codigo, nome, quantidade, preco);
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Formato de entrada inválido. Certifique-se de inserir números corretos.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void ConsultarProdutoPorCodigo()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            var produto = estoque.ConsultarProdutoPorCodigo(codigo);
            Console.WriteLine($"Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}");
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Produto não encontrado.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Formato de entrada inválido. Certifique-se de inserir um número correto.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void AtualizarEstoque()
    {
        try
        {
            Console.Write("Digite o código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade a ser adicionada (+) ou removida (-): ");
            int quantidade = int.Parse(Console.ReadLine());

            estoque.AtualizarEstoque(codigo, quantidade);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Formato de entrada inválido. Certifique-se de inserir um número correto.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void GerarRelatorios()
    {
        Console.Write("Digite o limite de quantidade para o relatório 1: ");
        int limiteQuantidade = int.Parse(Console.ReadLine());

        var relatorio1 = estoque.GerarRelatorioQuantidade(limiteQuantidade);
        ImprimirRelatorio("Produtos com quantidade em estoque abaixo do limite:", relatorio1);

        Console.Write("Digite o valor mínimo para o relatório 2: ");
        decimal minimo = decimal.Parse(Console.ReadLine());

        Console.Write("Digite o valor máximo para o relatório 2: ");
        decimal maximo = decimal.Parse(Console.ReadLine());

        var relatorio2 = estoque.GerarRelatorioPreco(minimo, maximo);
ImprimirRelatorio("Produtos com valor entre o mínimo e o máximo:", relatorio2);

        var relatorio3 = estoque.GerarRelatorioValorTotal();

        Console.WriteLine("Relatório 3: Valor total do estoque e valor total de cada produto");
        foreach (var item in relatorio3)
        {
            Console.WriteLine($"Produto: {item.Nome}, Quantidade: {item.Quantidade}, Valor Total: {item.ValorTotalProduto:C}");
        }
    }


static void ImprimirRelatorio(string titulo, IEnumerable<Produto> relatorio)
{
    Console.WriteLine(titulo);
    foreach (var produto in relatorio)
    {
        Console.WriteLine($"Código: {produto.Codigo}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}, Preço: {produto.Preco:C}");
    }
}
}