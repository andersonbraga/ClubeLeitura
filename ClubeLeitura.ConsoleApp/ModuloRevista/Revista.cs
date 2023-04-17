using ClubeLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloRevista
{
    internal class Revista
    {
        public string Colecao { get; set; }
        public string Ano { get; set; }
        public string Edicao { get; set; }
        public Caixa CaixaGuardada{ get; set; }
        public int Id { get; set; }
    }
}
