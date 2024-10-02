using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Listas de opções
        List<Lanche> lanches = new List<Lanche>
        {
            new Lanche("Hambúrguer", 15.00),
            new Lanche("Cheeseburger", 17.00),
            new Lanche("Hot Dog", 10.00),
            new Lanche("Sanduíche Natural", 12.00),
            new Lanche("X-Burguer", 18.00),
            new Lanche("Sanduiche de Frango", 14.00)
        };

        List<Bebida> bebidas = new List<Bebida>
        {
            new Bebida("Refrigerante", 5.00),
            new Bebida("Suco", 7.00),
            new Bebida("Água", 3.00),
            new Bebida("Cha Gelado", 6.00),
            new Bebida("Cerveja", 10.00)
        };

        List<Sobremesa> sobremesas = new List<Sobremesa>
        {
            new Sobremesa("Brownie", 8.00),
            new Sobremesa("Pudim", 6.00),
            new Sobremesa("Sorvete", 9.00),
            new Sobremesa("Torta de Limao", 7.00),
            new Sobremesa("Pave", 9.00)
        };

        // Exibir opções
        Console.WriteLine("Bem-vindo à Lanchonete!");
        var total = 0.0;

        total += EscolherItem("Lanches", lanches);
        total += EscolherItem("Bebidas", bebidas);
        total += EscolherItem("Sobremesas", sobremesas);

        // Escolha da forma de pagamento
        FormaPagamento pagamento = EscolherFormaPagamento();

        // Exibir comprovante
        ExibirComprovante(total, pagamento);
    }

    static double EscolherItem<T>(string tipo, List<T> itens) where T : Item
    {
        Console.WriteLine($"\nEscolha um(a) {tipo} (ou 0 para nenhum):");
        Console.WriteLine("0. Nenhum");

        for (int i = 0; i < itens.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {itens[i].Nome} - R$ {itens[i].Preco:F2}");
        }

        int escolha;
        do
        {
            Console.Write("Digite o número da sua escolha: ");
        } while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 0 || escolha > itens.Count);

        return escolha == 0 ? 0 : itens[escolha - 1].Preco;
    }

    static FormaPagamento EscolherFormaPagamento()
    {
        Console.WriteLine("\nEscolha a forma de pagamento:");
        Console.WriteLine("1. Dinheiro");
        Console.WriteLine("2. Cartão de Crédito");
        Console.WriteLine("3. Cartão de Débito");

        int escolha;
        do
        {
            Console.Write("Digite o número da sua escolha: ");
        } while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 3);

        return (FormaPagamento)escolha;
    }

    static void ExibirComprovante(double total, FormaPagamento pagamento)
    {
        Console.WriteLine("\n--- Comprovante de Pagamento ---");
        Console.WriteLine($"Total do pedido: R$ {total:F2}");
        Console.WriteLine($"Forma de pagamento: {pagamento}");
        Console.WriteLine("-------------------------------");
    }
}

abstract class Item
{
    public string Nome { get; }
    public double Preco { get; }

    protected Item(string nome, double preco)
    {
        Nome = nome;
        Preco = preco;
    }
}

class Lanche : Item
{
    public Lanche(string nome, double preco) : base(nome, preco) { }
}

class Bebida : Item
{
    public Bebida(string nome, double preco) : base(nome, preco) { }
}

class Sobremesa : Item
{
    public Sobremesa(string nome, double preco) : base(nome, preco) { }
}

enum FormaPagamento
{
    Dinheiro = 1,
    CartaoCredito,
    CartaoDebito
}
