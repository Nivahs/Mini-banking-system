//ARRAY int[] numeros = { 1, 2, 3, 4, 5 };
//int[] numeros = new int[4]
//LISTA List<int> lista = new List<int>();


using System;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
class Program
{
    static void Main(string[] args)
    {
        ContaBancaria contaBancaria = new ContaBancaria(0);
        Menu menu= new Menu();
        menu.VisualizarMenu(contaBancaria);
        
    }

}
class ContaBancaria
{
    private double Saldo { get; set; }

    public ContaBancaria(double saldo)
    {
        Saldo = saldo;
    }

    public void AdicionarSaldo(double a)
    {
        if (a < 0)
        {
            Console.WriteLine("Digite um valor maior que 0!");
        }
        else
        {
            Saldo += a;
            Console.WriteLine($"Saldo atual: {Saldo}");
        }
    }

    public void RealizarSaque(double b)
    {
        if (b > Saldo)
        {
            Console.WriteLine("Valor de saque indisponível");
        }
        else
        {
            Saldo -= b;
            Console.WriteLine("Saque realizado.");
            Console.WriteLine($"Novo saldo: {Saldo}");
            
        }
    }
    
    public void ConsultaSaldos()
    {
        Console.WriteLine($"Saldo em conta bancária: {Saldo} ");
    }

}

class Menu
{
    public void VisualizarMenu(ContaBancaria contaBancaria)
    {
        int opcao;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENU PRINCIPAL ===");
            Console.WriteLine("1 - Consultar saldo");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");

            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Entrada Inválida. Tente novamente");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    contaBancaria.ConsultaSaldos();
                    break;
                case 2:
                    int addValue;
                    Console.Write("Valor para depósitar: ");
                    addValue = int.Parse(Console.ReadLine()!);
                    contaBancaria.AdicionarSaldo(addValue);
                    Console.WriteLine("Depósito realizado.");
                    break;
                case 3:
                    double valorSaque = 0;
                    Console.Write("Valor do saque: ");
                    valorSaque = double.Parse(Console.ReadLine()!);

                    contaBancaria.RealizarSaque(valorSaque);
                    
                    break;
                case 0:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            if (opcao != 0)
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }

        } while (opcao != 0);
    }

}
