using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : CompartilhadoComun
    {
        public RepositorioEmprestimo repositorioEmprestimo = null;
        public RepositorioRevista repositorioRevista = null;
        public RepositorioAmigo repositorioAmigo = null;

        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Emprestimop ===");
                Console.WriteLine("1 - Adicionar Emprestimop");
                Console.WriteLine("2 - Listar Emprestimop");
                Console.WriteLine("3 - Editar Emprestimop");
                Console.WriteLine("4 - Remover Emprestimop");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarEmprestimo();
                        break;
                    case 2:
                        ListarEmprestimo();
                        break;
                    case 3:
                        EditarEmprestimo();
                        break;
                    case 4:
                        repositorioEmprestimo.DeletarEmprestimo();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        Console.ReadKey();
                        break;
                }
            } while (opcao != 0);


        }
        public Emprestimo ObterEmprestimo()
        {
            Emprestimo emprestimos = new Emprestimo();
            Amigo amigoObj = null;
            Revista revistaObj = null;


            Console.WriteLine("Digite o ID da revista : ");
             int idRevista = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o ID amigo: ");
            int idAmigo = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a data da emprestimo: ");
             emprestimos.DataEmprestimo = Console.ReadLine();

            Console.WriteLine("Digite a data da devolução: ");
            emprestimos.DataDevolucao = Console.ReadLine();

            //emprestimos.AmigoRevista 
            //emprestimos.Status
            //emprestimos.RevistaAmigo
            // ??????????????????????????????
            //Amigo amigoID ,,,,,,,,,,
            //Revista revistaID ,,,,,,,

            foreach (Amigo amigo in repositorioAmigo.listasObj)
            //Tratar System.NullReferenceException
            {
                if (idAmigo == amigo.Id)
                {
                    amigoObj = amigo;
                }
            }
            foreach (Revista revista in repositorioRevista.listasObj)
            {
                if (idRevista == revista.Id)
                {
                    revistaObj = revista;
                }
            }


            return emprestimos;

        }

        public void CadastrarEmprestimo()
        {
            Emprestimo cadastroEmprestimo = ObterEmprestimo();
            repositorioEmprestimo.RegistrarEmprestimo(cadastroEmprestimo);
        }

        public void ListarEmprestimo()
        {
            listasObj = repositorioEmprestimo.SelecionarTodos();
            if (listasObj.Count == 0)
            {
                Console.WriteLine("Nenhuma emprestimo cadastrado.");
                Console.ReadKey();
            }
            else
            {
                foreach (Emprestimo item in listasObj)
                {
                    Console.WriteLine($"ID - {item.Id}-Amigo que pegou Revista: {item.AmigoRevista}\n  Revista que Pegou: {item.RevistaAmigo}\n Data: {item.DataEmprestimo}\n" +
                        $"Devolução: {item.DataDevolucao}\n");
                    Console.ReadKey();

                }
                Console.ReadKey();
            }

        }

        public void EditarEmprestimo()
        {

            int idSelecionado = EncontrarIdEmprestimo();
            Emprestimo emprestimo = ObterEmprestimo();

            repositorioEmprestimo.EditarEmprestimo(idSelecionado, emprestimo);


        }

        public int EncontrarIdEmprestimo()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id da emprestimo: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioEmprestimo.SelecionarEmprestimoPorId(idSelecionado) == null;

                if (idInvalido)
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
            } while (idInvalido);

            return idSelecionado;
        }
    }
}
