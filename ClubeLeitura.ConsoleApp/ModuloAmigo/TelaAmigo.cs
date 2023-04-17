using ClubeLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo : CompartilhadoComun
    {
        
       
        public RepositorioAmigo repositorioAmigo = null;
        
        
        public void MostrarMenu()
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("=== Menu Amigos ===");
                Console.WriteLine("1 - Adicionar amigo");
                Console.WriteLine("2 - Listar amigos");
                Console.WriteLine("3 - Editar amigo");
                Console.WriteLine("4 - Remover amigo");
                Console.WriteLine("0 - Voltar ao menu principal");
                Console.WriteLine("====================");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarAmigo();
                        break;
                    case 2:
                        ListarAmigos();
                        break;
                    case 3:
                       EditarAmigo();
                       break;
                    case 4:
                        repositorioAmigo.DeletarAmigos();
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
        public Amigo ObterAmigo( )
        {
            Amigo amigos = new Amigo();


            Console.WriteLine("Digite o nome do Amigo: ");
            amigos.Nome = Console.ReadLine();
            Console.WriteLine("Digite o Nome do Responsavel do Amigo: ");
            amigos.NomeResponsavel = Console.ReadLine();
            Console.WriteLine("Digite o Numero do Telefone do Amigo: ");
            amigos.Telefone = Console.ReadLine();
            Console.WriteLine("Digite o Endereço do Amigo: ");
            amigos.Endereco = Console.ReadLine();

            return amigos;

        }

        public void CadastrarAmigo()
        {
            Amigo cadastroAmigo = ObterAmigo();
            repositorioAmigo.RegistrarAmigo(cadastroAmigo);
        }

        public void ListarAmigos()
        {
            listasObj = repositorioAmigo.SelecionarTodos();
            if (listasObj.Count == 0)
            {
                Console.WriteLine("Nenhuma equipamento cadastrado.");
                Console.ReadKey();
            }
            else
            {
                foreach (Amigo item in listasObj)
                {
                    Console.WriteLine($"ID - {item.Id}-Nome do Amigo: {item.Nome}\n  Nome do Responsavel: {item.NomeResponsavel}\n  Numero do Telefone: {item.Telefone}\n" +
                        $"  Endereço:{item.Endereco}");
                    Console.ReadKey();
                   
                }
                Console.ReadKey();
            }

        }

        public void EditarAmigo()
        {
          
            int idSelecionado = EncontrarIdEquipamento();
            Amigo amigo = ObterAmigo();

            repositorioAmigo.EditarAmigo(idSelecionado,amigo);

            
        }

        public int EncontrarIdEquipamento()
        {
            int idSelecionado;
            bool idInvalido;
            do
            {
                Console.WriteLine("Digite o Id do amigo: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());
                
                idInvalido = repositorioAmigo.SelecionarAmigoPorId(idSelecionado) == null;

                if (idInvalido)
                    Console.WriteLine("Id inválido, tente novamente", ConsoleColor.Red); 
            } while (idInvalido);

            return idSelecionado;
        }



    }
}
