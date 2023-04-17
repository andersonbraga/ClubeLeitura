using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : CompartilhadoComun
    {
        public RepositorioCaixa repositorioCaixa = null;


        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Caixas ===");
                Console.WriteLine("1 - Adicionar caixa");
                Console.WriteLine("2 - Listar caixa");
                Console.WriteLine("3 - Editar caixa");
                Console.WriteLine("4 - Remover caixa");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarCaixa();
                        break;
                    case 2:
                        ListarCaixas();
                        break;
                    case 3:
                        EditarCaixa();
                        break;
                    case 4:
                        repositorioCaixa.DeletarCaixas();
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
        public Caixa ObterCaixa()
        {
            Caixa caixas = new Caixa();


            Console.WriteLine("Digite a cor da Cauxa: ");
            caixas.Cor = Console.ReadLine();
            Console.WriteLine("Digite a Etiqueta da Caixa: ");
            caixas.Etiqueta = Console.ReadLine();
           

            return caixas;

        }

        public void CadastrarCaixa()
        {
            Caixa cadastroCaixa = ObterCaixa();
            repositorioCaixa.RegistrarCaixa(cadastroCaixa);
        }

        public void ListarCaixas()
        {
            listasObj = repositorioCaixa.SelecionarTodos();
            if (listasObj.Count == 0)
            {
                Console.WriteLine("Nenhuma caixa cadastrado.");
                Console.ReadKey();
            }
            else
            {
                foreach (Caixa item in listasObj)
                {
                    Console.WriteLine($"ID - {item.Id}-Cor da Caixa: {item.Cor}\n  Nome da Etiqueta: {item.Etiqueta}\n");
                    Console.ReadKey();

                }
                Console.ReadKey();
            }

        }

        public void EditarCaixa()
        {

            int idSelecionado = EncontrarIdCaixa();
            Caixa caixa = ObterCaixa();

            repositorioCaixa.EditarCaixa(idSelecionado, caixa);


        }

        public int EncontrarIdCaixa()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id da caixa: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioCaixa.SelecionarCaixaPorId(idSelecionado) == null;

                if (idInvalido)
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red);
            } while (idInvalido);

            return idSelecionado;
        }

    }
}
