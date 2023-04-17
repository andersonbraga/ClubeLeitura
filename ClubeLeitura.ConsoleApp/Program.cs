using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeLeitura.ConsoleApp.ModuloRevista;

//Lista To-Do
/* Tratar System.NullReferenceException e todas outras
 * Corrigir Bug do Id
 * Utilizar Polimorfismo
 * Utilizar mais Herança em Propriedades repetidas ex: (id)
 * Implementar Funcionalidade do Status do Emprestimo, Aberto, Fechado ou Devolvido e Historico
 * Trazer Metodo Deletar dos Repositorios para Telas
 * 
 */


namespace ClubeLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TelaAmigo telaAmigo1 = new TelaAmigo();
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            telaAmigo1.repositorioAmigo = repositorioAmigo;

            TelaCaixa telaCaixa = new TelaCaixa();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa(); 
            telaCaixa.repositorioCaixa = repositorioCaixa;

            TelaRevista telaRevista = new TelaRevista();
            RepositorioRevista repositorioRevista = new RepositorioRevista();
            telaRevista.repositorioRevista = repositorioRevista;

            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            telaEmprestimo.repositorioEmprestimo = repositorioEmprestimo;
         


            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Principal ===");
                Console.WriteLine("1 - Gerenciar Amigos");
                Console.WriteLine("2 - Gerenciar Revistas");
                Console.WriteLine("3 - Gerenciar Empréstimos");
                Console.WriteLine("4 - Gerenciar Caixas");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("======================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        
                        telaAmigo1.MostrarMenu();
                        // chamar o menu de Gerenciar Amigos
                        //telaAmigo.MostrarMenu();
                        break;
                    case 2:
                        telaRevista.MostrarMenu();
                        // chamar o menu de Gerenciar Revistas
                        break;
                    case 3:
                        telaEmprestimo.MostrarMenu();
                        // chamar o menu de Gerenciar Empréstimos
                        break;
                    case 4:
                        telaCaixa.MostrarMenu();
                        // chamar o menu de Gerenciar Caixas
                        break;
                    
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcao != 0);

        }
    }
}