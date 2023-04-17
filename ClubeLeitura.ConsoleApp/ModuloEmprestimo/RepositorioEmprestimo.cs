using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : CompartilhadoComun
    {
        public void InserirEmprestimo(Emprestimo emprestimo)
        {
            listasObj.Add(emprestimo);
            emprestimo.Id = listasObj.Count;

        }

        public void RegistrarEmprestimo(Emprestimo emprestimo)
        {
            InserirEmprestimo(emprestimo);
        }

        public List<object> SelecionarTodos()
        {
            return listasObj;
        }

        public void DeletarEmprestimo()
        {
            Console.WriteLine("Digite o ID da emprestimo que quer excluir: ");
            int idExcluir = Convert.ToInt32(Console.ReadLine());

            foreach (Emprestimo item in listasObj)
            {
                if (idExcluir == item.Id)
                {
                    listasObj.Remove(item);
                    return;
                }
            }
        }

        public void EditarEmprestimo(int id, Emprestimo emprestimoAtualizado)
        {
            Emprestimo emprestimo = SelecionarEmprestimoPorId(id);

            emprestimo.RevistaAmigo = emprestimoAtualizado.RevistaAmigo;
            emprestimo.AmigoRevista = emprestimoAtualizado.AmigoRevista;
            emprestimo.DataEmprestimo = emprestimoAtualizado.DataEmprestimo;
            emprestimo.DataDevolucao = emprestimoAtualizado.DataDevolucao;

        }
        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            Emprestimo emprestimo = null;

            foreach (Emprestimo item in listasObj)
            {
                if (item.Id == id)
                {
                    emprestimo = item;
                    break;
                }
            }
            return emprestimo;
        }

    }
}
