using ClubeLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class RepositorioRevista : CompartilhadoComun
    {
        public void InserirRevista(Revista revista)
        {
            listasObj.Add(revista);
            revista.Id = listasObj.Count;

        }

        public void RegistrarRevista(Revista revista)
        {
            InserirRevista(revista);
        }

        public List<object> SelecionarTodos()
        {
            return listasObj;
        }

        public void DeletarRevista()
        {
            Console.WriteLine("Digite o ID da revista que quer excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Revista item in listasObj)
            {
                if (idExcluir == item.Id)
                {
                    listasObj.Remove(item);
                    return;
                }
            }
        }

        public void EditarRevista(int id, Revista revistaAtualizado)
        {
            Revista revista = SelecionarRevistaPorId(id);

            revista.Ano = revistaAtualizado.Ano;
            revista.Edicao = revistaAtualizado.Edicao;
            revista.Colecao = revistaAtualizado.Colecao;
            revista.CaixaGuardada = revistaAtualizado.CaixaGuardada;

        }
        public Revista SelecionarRevistaPorId(int id)
        {
            Revista revista = null;

            foreach (Revista item in listasObj)
            {
                if (item.Id == id)
                {
                    revista = item;
                    break;
                }
            }
            return revista;
        }
    }
}
