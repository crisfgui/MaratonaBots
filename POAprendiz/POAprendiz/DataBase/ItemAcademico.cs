using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POAprendiz.DataBase
{
    public class ItemAcademico : IItem
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Link { get; set; }

        public DateTime? Data { get; set; }
        public decimal? Valor { get; set; }
        public CategoriaEnum Categoria { get; set; }

        public enum CategoriaEnum
        {
            Indefinido = 0,
            Certificacao = 1,
            Curso = 2,
            Workshop = 3
        }
    }
}

