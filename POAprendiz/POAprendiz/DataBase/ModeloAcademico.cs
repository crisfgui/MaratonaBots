using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace POAprendiz.DataBase
{
    public class ModeloAcademico
    {
        private readonly string _BaseConhecimentoPOKey = ConfigurationManager.AppSettings["BaseConhecimentoPOKey"];
        private readonly string _BaseConhecimentoPOUri = ConfigurationManager.AppSettings["BaseConhecimentoPOUri"];

        public List<ItemAcademico> ObterItens()
        {
            List<ItemAcademico> itens = new List<ItemAcademico>
            {
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 01, Nome = "KMP I",      Descricao = "Aspercom",   Link = "http://aspercom.com.br/treinamento/kanban/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 02, Nome = "KMP II",     Descricao = "Aspercom",   Link = "http://aspercom.com.br/treinamento/kmp/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 03, Nome = "CSPO",       Descricao = "K21",        Link = "https://www.knowledge21.com.br/treinamentos/curso/certified-scrum-product-owner/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 04, Nome = "LKU",        Descricao = "K21",        Link = "https://www.knowledge21.com.br/treinamentos/curso/kanban-oficial-lku/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 05, Nome = "PSPO I",     Descricao = "SCRUM.ORG",  Link = "https://www.scrum.org/professional-scrum-product-owner-i-certification" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 06, Nome = "PSPO II",    Descricao = "SCRUM.ORG",  Link = "https://www.scrum.org/professional-scrum-certifications/professional-scrum-product-owner-ii-assessment" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 07, Nome = "IPOF",       Descricao = "SCRUM.AS",   Link = "https://www.scrum.as/certification.php" },

                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 08, Nome = "TKP",               Descricao = "Aspercom",     Link = "http://aspercom.com.br/treinamento/workshop-kanban/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 09, Nome = "Direto ao Ponto",   Descricao = "Caroli.Org",   Link = "http://www.caroli.org/treinamento-lean-inception/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 10, Nome = "Agile Lego",        Descricao = "Hilflex",      Link = "http://agiletrendsbr.com/agile-lego-challenge/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 11, Nome = "Desafio PMO Ágil",  Descricao = "Hiflex",       Link = "http://agiletrendsbr.com/cursos-e-treinamentos-associados/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 12, Nome = "Agile na Prática",  Descricao = "Agile Trends", Link = "http://agiletrendsbr.com/cursos-e-treinamentos-associados/" },

                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 13, Nome = "Treinamento Scrum",             Descricao = "Aspercom",              Link = "http://aspercom.com.br/treinamento/scrum/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 14, Nome = "Gestão de Conflitos",           Descricao = "K21",                   Link = "https://www.knowledge21.com.br/treinamentos/curso/gestao-de-conflitos/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 15, Nome = "Product Owner",                 Descricao = "Portal Treinamento",    Link = "https://www.portaldotreinamento.com.br/curso/product-owner/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 16, Nome = "Formação Total em Scrum",       Descricao = "Udemy",                 Link = "https://www.udemy.com/formacao-total-em-scrum/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 17, Nome = "Scrum - Padrões para Adoção",   Descricao = "Udemy",                 Link = "https://www.udemy.com/scrum-padroes-para-adocao/" },
                new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 18, Nome = "Histórias de usuários",         Descricao = "Udemy",                 Link = "https://www.udemy.com/criando-historias-de-usuario-de-forma-efetiva/" },
            };

            return itens;
        }

        public List<ItemAcademico> ObterItensAcademico(ItemAcademico.CategoriaEnum categoria, int quantidadeItens, bool itensAleatorios)
        {
            //TODO: Tratar tamanho da lista, verificar se tem disponivel a quantidade solicitado 
            //TODO: Tratar parâmetros, por exemplo, quantidade de itens deve ser superior a 0 
            //TODO: Tratar filtro quando usuário informar uma certificação especifica 

            var itensDisponiveis = ObterItens().Where(a => a.Categoria == categoria).OrderByDescending(b => b.Codigo).ToList();
            var itensSelecionados = new List<ItemAcademico>();

            if (itensAleatorios)
            {
                for (int i = 0; i < quantidadeItens; i++)
                {

                    int posicao = new Random().Next(itensDisponiveis.Count());
                    itensSelecionados.Add(itensDisponiveis[posicao]);
                    itensDisponiveis.RemoveAt(posicao);
                }
            }
            else
                foreach (ItemAcademico item in itensDisponiveis)
                    itensSelecionados.Add(item);

            return itensSelecionados;
        }

        public List<ItemAcademico> ObterItensAcademicoBaseConhecimentoAPI(ItemAcademico.CategoriaEnum categoria, int quantidadeItens, bool itensAleatorios)
        {
            var uri = _BaseConhecimentoPOUri + "GetByCategory/" + (int)categoria;

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _BaseConhecimentoPOKey);
            var resultado = client.GetAsync(uri).Result;

            if (!resultado.IsSuccessStatusCode)
                return null; 

            var resultadoJsonString = resultado.Content.ReadAsStringAsync().Result;
            var itensDisponiveis = JsonConvert.DeserializeObject<List<ItemAcademico>>(resultadoJsonString);
            
            var itensSelecionados = new List<ItemAcademico>();

            if (itensAleatorios)
            {
                for (int i = 0; i < quantidadeItens; i++)
                {
                    int posicao = new Random().Next(itensDisponiveis.Count());
                    itensSelecionados.Add(itensDisponiveis[posicao]);
                    itensDisponiveis.RemoveAt(posicao);
                }
            }
            else
                foreach (ItemAcademico item in itensDisponiveis)
                    itensSelecionados.Add(item);

            return itensSelecionados;
        }
    }
}
