using ClubeLeitura.ConsoleApp.Compartilhado;
using ClubeLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    internal class RepositorioCaixa : CompartilhadoComun
    {
      
            public void InserirCaixa(Caixa caixa)
            {
                listasObj.Add(caixa);
                caixa.Id = listasObj.Count;

            }

            public void RegistrarCaixa(Caixa caixa)
            {
                InserirCaixa(caixa);
            }

            public List<object> SelecionarTodos()
            {
                return listasObj;
            }

            public void DeletarCaixas()
            {
                Console.WriteLine("Digite o ID da caixa que quer excluir: ");
                int idExcluir = Convert.ToInt32(Console.ReadLine());

                foreach (Caixa item in listasObj)
                {
                    if (idExcluir == item.Id)
                    {
                        listasObj.Remove(item);
                        return;
                    }
                }
            }

            public void EditarCaixa(int id, Caixa caixaAtualizado)
            {
                Caixa caixa = SelecionarCaixaPorId(id);

                caixa.Etiqueta = caixaAtualizado.Etiqueta;
                caixa.Cor = caixaAtualizado.Cor;
              
            }
            public Caixa SelecionarCaixaPorId(int id)
            {
                Caixa caixa = null;

                foreach (Caixa item in listasObj)
                {
                    if (item.Id == id)
                    {
                        caixa = item;
                        break;
                    }
                }
                return caixa;
            }
        }
    }

