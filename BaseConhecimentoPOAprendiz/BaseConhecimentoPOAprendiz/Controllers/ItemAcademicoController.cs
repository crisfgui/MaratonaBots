using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseConhecimentoPOAprendiz.Models;
using Microsoft.AspNetCore.Mvc;
using static BaseConhecimentoPOAprendiz.Models.ItemAcademico;

namespace BaseConhecimentoPOAprendiz.Controllers
{
    [Route("api/ItemAcademico")]
    public class ItemAcademicoController : Controller
    {
        private readonly BaseConhecimentoContext _baseConhecimentoContext;

        public ItemAcademicoController(BaseConhecimentoContext baseConhecimentoContext)
        {
            _baseConhecimentoContext = baseConhecimentoContext;

            if (_baseConhecimentoContext.ItemAcademico.Count() == 0)
                CriarItensAcademicos();
        }

        [HttpGet]        
        public void GetAll()
        {
            
        }
        
        [HttpGet("{codigoCategoria}", Name = "GetByCategory")]
        [Route("GetByCategory/{codigoCategoria}")]        
        public IEnumerable<ItemAcademico> GetByCategory(long codigoCategoria)
        {  
           return _baseConhecimentoContext.ItemAcademico.Where(a => a.Categoria == (ItemAcademico.CategoriaEnum)codigoCategoria).ToList();
        }

        private void CriarItensAcademicos()
        {
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 01, Nome = "KMP I", Descricao = "Aspercom", Link = "http://aspercom.com.br/treinamento/kanban/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 02, Nome = "KMP II",     Descricao = "Aspercom",   Link = "http://aspercom.com.br/treinamento/kmp/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 03, Nome = "CSPO", Descricao = "K21", Link = "https://www.knowledge21.com.br/treinamentos/curso/certified-scrum-product-owner/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 04, Nome = "LKU", Descricao = "K21", Link = "https://www.knowledge21.com.br/treinamentos/curso/kanban-oficial-lku/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 05, Nome = "PSPO I", Descricao = "SCRUM.ORG", Link = "https://www.scrum.org/professional-scrum-product-owner-i-certification" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 06, Nome = "PSPO II", Descricao = "SCRUM.ORG", Link = "https://www.scrum.org/professional-scrum-certifications/professional-scrum-product-owner-ii-assessment" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Certificacao, Codigo = 07, Nome = "IPOF", Descricao = "SCRUM.AS", Link = "https://www.scrum.as/certification.php" });

            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 08, Nome = "TKP", Descricao = "Aspercom", Link = "http://aspercom.com.br/treinamento/workshop-kanban/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 09, Nome = "Direto ao Ponto", Descricao = "Caroli.Org", Link = "http://www.caroli.org/treinamento-lean-inception/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 10, Nome = "Agile Lego", Descricao = "Hilflex", Link = "http://agiletrendsbr.com/agile-lego-challenge/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 11, Nome = "Desafio PMO Ágil", Descricao = "Hiflex", Link = "http://agiletrendsbr.com/cursos-e-treinamentos-associados/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Workshop, Codigo = 12, Nome = "Agile na Prática", Descricao = "Agile Trends", Link = "http://agiletrendsbr.com/cursos-e-treinamentos-associados/" });

            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 13, Nome = "Treinamento Scrum", Descricao = "Aspercom", Link = "http://aspercom.com.br/treinamento/scrum/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 14, Nome = "Gestão de Conflitos", Descricao = "K21", Link = "https://www.knowledge21.com.br/treinamentos/curso/gestao-de-conflitos/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 15, Nome = "Product Owner", Descricao = "Portal Treinamento", Link = "https://www.portaldotreinamento.com.br/curso/product-owner/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 16, Nome = "Formação Total em Scrum", Descricao = "Udemy", Link = "https://www.udemy.com/formacao-total-em-scrum/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 17, Nome = "Scrum - Padrões para Adoção", Descricao = "Udemy", Link = "https://www.udemy.com/scrum-padroes-para-adocao/" });
            _baseConhecimentoContext.ItemAcademico.Add(new ItemAcademico { Categoria = ItemAcademico.CategoriaEnum.Curso, Codigo = 18, Nome = "Histórias de usuários", Descricao = "Udemy", Link = "https://www.udemy.com/criando-historias-de-usuario-de-forma-efetiva/" });

            _baseConhecimentoContext.SaveChanges();
        }
    }
}
