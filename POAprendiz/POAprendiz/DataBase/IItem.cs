using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POAprendiz.DataBase
{
    public interface IItem
    {
        int Id { get; set; }
        int Codigo { get; set; }
        string Nome { get; set; }
        string Descricao { get; set; }
        string Link { get; set; }
    }
}
