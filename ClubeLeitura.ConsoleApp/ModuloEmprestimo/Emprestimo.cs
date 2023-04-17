using ClubeLeitura.ConsoleApp.ModuloAmigo;
using ClubeLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class Emprestimo
    {
        public int Id { get; set; }
        public Amigo AmigoRevista { get; set; }
        public Revista RevistaAmigo { get; set; }
        public string Status { get; set; }
        public string DataEmprestimo { get; set; }
        public string DataDevolucao { get; set; }
    }
}
