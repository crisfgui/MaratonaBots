using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POAprendiz.DataBase
{
    public class ModeloPratica
    {
        public List<ItemPratica> ObterItens()
        {
            List<ItemPratica> itens = new List<ItemPratica>
            {
                new ItemPratica { Codigo = 01, Nome = "InfoQ",  Descricao = "Priorizar",                    Link = "https://www.infoq.com/br/presentations/agilemart-o-case-do-backlog-que-foi-parar-nas-prateleiras-de-um-supermercado" },
                new ItemPratica { Codigo = 02, Nome = "InfoQ",  Descricao = "Fatiar/Priorizar",             Link = "https://www.infoq.com/br/presentations/a-arte-de-fatiar-user-stories-a-dor-e-o-valor?utm_source=notification_email&utm_campaign=notifications&utm_medium=link&utm_content=content_in_followed_topic&utm_term=daily" },
                new ItemPratica { Codigo = 03, Nome = "Evento", Descricao = "Agile Trends",                 Link = "http://agiletrendsbr.com/" },
                new ItemPratica { Codigo = 04, Nome = "Evento", Descricao = "Scrum Gathering Rio",          Link = "https://scrumrio.com/" },
                new ItemPratica { Codigo = 05, Nome = "Meetup", Descricao = "Agile Minas",                  Link = "https://www.meetup.com/pt-BR/Agile-Minas/?_cookie-check=PP6W3X1tYs0QJeNj" },
                new ItemPratica { Codigo = 06, Nome = "Meetup", Descricao = "Café, testes e pão de queijo", Link = "https://www.meetup.com/pt-BR/Cafe-testes-e-pao-de-queijo/" },
            };

            return itens;
        }
    }
}
