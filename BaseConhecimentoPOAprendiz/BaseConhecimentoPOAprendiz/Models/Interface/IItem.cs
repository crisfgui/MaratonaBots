using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseConhecimentoPOAprendiz.Models.Interface
{
    public interface IItem
    {
        int Codigo { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }
        string Link { get; set; }
    }
}
