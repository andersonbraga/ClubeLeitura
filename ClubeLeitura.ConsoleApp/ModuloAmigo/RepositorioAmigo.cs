using ClubeLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloAmigo
{
    internal class RepositorioAmigo : CompartilhadoComun
    {
           
        public void InserirAmigo(Amigo amigo)
        {
            listasObj.Add(amigo);
            amigo.Id = listasObj.Count;
            
        }

        public void RegistrarAmigo(Amigo amigo)
        {
            InserirAmigo(amigo);
        }

        public List<object> SelecionarTodos()
        {
             return listasObj;
        }

        public void DeletarAmigos()
        {       
            Console.WriteLine("Digite o ID do amigo que quer excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Amigo item in listasObj)
            {
                if(idExcluir == item.Id)
                {
                    listasObj.Remove(item);
                    return;
                }
             }
        }

        public void EditarAmigo(int id, Amigo amigoAtualizado)
        {
            Amigo amigo = SelecionarAmigoPorId(id);

            amigo.Nome = amigoAtualizado.Nome;
            amigo.NomeResponsavel = amigoAtualizado.NomeResponsavel;
            amigo.Telefone = amigoAtualizado.Telefone;
            amigo.Endereco = amigoAtualizado.Endereco;
        }
        public Amigo SelecionarAmigoPorId(int id)
        {
            Amigo amigo = null;

            foreach (Amigo item in listasObj)
            {
                if (item.Id == id)
                {
                    amigo = item;
                    break;
                }
            }
            return amigo;
        }
    }
}
