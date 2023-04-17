using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : CompartilhadoComun
    {
        public RepositorioCaixa repositorioCaixa = null;
        public RepositorioRevista repositorioRevista = null;


        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Revistas ===");
                Console.WriteLine("1 - Adicionar Revistas");
                Console.WriteLine("2 - Listar Revistas");
                Console.WriteLine("3 - Editar Revistas");
                Console.WriteLine("4 - Remover Revistas");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarRevista();
                        break;
                    case 2:
                        ListarRevistas();
                        break;
                    case 3:
                        EditarRevista();
                        break;
                    case 4:
                        repositorioRevista.DeletarRevista();
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
        public Revista ObterRevista()
        {
            Revista revistas = new Revista();
            Caixa caixaObj = null;

            Console.WriteLine("Digite o Ano da revista: ");
            revistas.Ano = Console.ReadLine();
            Console.WriteLine("Digite a Edição da revista ");
            revistas.Edicao = Console.ReadLine();
            Console.WriteLine("Digite a Coleção da revista: ");
            revistas.Colecao = Console.ReadLine();
            Console.WriteLine("Digite a Caixa da revista ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            foreach (Caixa caixa in repositorioCaixa.listasObj)
            {
                if (idCaixa == caixa.Id)
                {
                    caixaObj = caixa;
                }
            }
            while (caixaObj == null)
            {
               
                Console.WriteLine("Digite o id da caixa: ");
                idCaixa = int.Parse(Console.ReadLine());

                foreach (Caixa caixa in repositorioCaixa.listasObj)
                {
                    if (idCaixa == caixa.Id)
                    {
                        caixaObj = caixa;
                    }
                }
            }

            return revistas;

        }

        public void CadastrarRevista()
        {
            Revista cadastroRevista = ObterRevista();
            repositorioRevista.RegistrarRevista(cadastroRevista);
        }

        public void ListarRevistas()
        {
            listasObj = repositorioRevista.SelecionarTodos();
            if (listasObj.Count == 0)
            {
                Console.WriteLine("Nenhuma revista cadastrado.");
                Console.ReadKey();
            }
            else
            {
                foreach (Revista item in listasObj)
                {
                    Console.WriteLine($"ID - {item.Id}-Edição da Revista: {item.Edicao}\n  Ano: {item.Ano}\n Caixa Guardada: { item.CaixaGuardada} \n Coleção: {item.Colecao}\\n ");
                    Console.ReadKey();

                }
                Console.ReadKey();
            }

        }

        public void EditarRevista()
        {

            int idSelecionado = EncontrarIdRevista();
            foreach (Revista revista in repositorioRevista.listasObj)
            {
                if (revista.Id == idSelecionado)
                {
                    foreach (Caixa caixa in repositorioCaixa.listasObj)
                    {
                        if (revista.CaixaGuardada.Id == caixa.Id)
                        {
                            caixa.RevistaCaixa.Remove(revista);
                        }
                    }
                }


            }
            Revista revistaEditada = ObterRevista();

            repositorioRevista.EditarRevista(idSelecionado, revistaEditada);
        }

        public int EncontrarIdRevista()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id da revista: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioRevista.SelecionarRevistaPorId(idSelecionado) == null;

                if (idInvalido)
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
            } while (idInvalido);

            return idSelecionado;
        }
    }
}
