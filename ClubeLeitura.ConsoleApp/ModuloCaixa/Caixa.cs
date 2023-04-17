using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public int Id { get; set; }
        public string Cor {get; set; }
        public string Etiqueta { get; set; }
        public List<object> RevistaCaixa { get; set; } = new List<object>();
        
    }
}
