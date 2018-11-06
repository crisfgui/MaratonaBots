using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Linq;
using POAprendiz.DataBase;
using System.Collections.Generic;
using System.Threading;

namespace POAprendiz.Dialogs
{
    [Serializable]
    public class LuisDialog : LuisDialog<object>
    {
        public LuisDialog(ILuisService servico) : base(servico) { }

        [LuisIntent("None")]
        public async Task ProcessarIntencaoNone(IDialogContext contexto, LuisResult resultadoLuis)
        {
            await contexto.PostAsync("Desculpe, sou um bot que ainda está aprendendo. Por favor, repita a pergunta com outras palavras.");
            contexto.Done<string>(null);
        }

        [LuisIntent("Saudacao")]
        public async Task ProcessarIntencaoSaudacao(IDialogContext contexto, LuisResult resultadoLuis)
        {
            await contexto.PostAsync("Oi! Sou uma aprendiz de Product Owner, durante meus estudos criei um repósitório de informações e gostaria de compartilha-lo.");
            contexto.Done<string>(null);
        }

        [LuisIntent("Pratica")]
        public async Task ProcessarIntencaoPratica(IDialogContext contexto, LuisResult resultadoLuis)
        {
            var resultadosPesquisa = new ModeloPratica().ObterItens();

            foreach (var item in resultadosPesquisa)
            {
                var heroCard = new HeroCard
                {
                    Title = item.Nome,
                    Subtitle = item.Descricao,
                    Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Detalhes", value: item.Link) }
                };

                var message = contexto.MakeMessage();
                message.Attachments.Add(heroCard.ToAttachment());
                await contexto.PostAsync(message);
                heroCard.ToAttachment();
            }

            await contexto.PostAsync("Agora é colocar em prática.");
            contexto.Done<string>(null);
        }

        [LuisIntent("Conhecimento")]
        public async Task ProcessarIntencaoConhecimento(IDialogContext contexto, LuisResult resultadoLuis)
        {
            await contexto.Forward(new QnaDialog(), ExecutarAposQnaMaker, contexto.Activity, CancellationToken.None);
            contexto.Done<string>(null);
        }

        [LuisIntent("Academico")]
        public async Task ProcessarIntencaoAcademico(IDialogContext contexto, LuisResult resultadoLuis)
        {
            var entidades = resultadoLuis?.Entities?.Where(e => e.Type == "Certificação" || e.Type == "Curso" || e.Type == "Workshop");

            if (entidades.Count() > 0)
            {
                var tipoIdentificado = resultadoLuis?.Entities.OrderBy(a => a.Score).FirstOrDefault().Type;

                var categoria = ConverterEntidadeLuisEmCategoriaProduto(tipoIdentificado);
                
                var resultadosPesquisa = new ModeloAcademico().ObterItensAcademicoBaseConhecimentoAPI(categoria: categoria, quantidadeItens: 3, itensAleatorios: true);

                if(resultadosPesquisa.Count() == 0)
                    await contexto.PostAsync($"Desculpe, não consegui encontrar nada interessante sobre o tema, mas irei me esforçar mais para aprender sobre o assunto. ");
                else
                    await contexto.PostAsync($"Veja esses links sobre {tipoIdentificado}.");

                foreach (var item in resultadosPesquisa)
                {
                    var heroCard = new HeroCard
                    {
                        Title = item.Nome,
                        Subtitle = item.Descricao,
                        Text = tipoIdentificado,
                        Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, "Detalhes", value: item.Link) }
                    };

                    var message = contexto.MakeMessage();
                    message.Attachments.Add(heroCard.ToAttachment());
                    await contexto.PostAsync(message);
                    heroCard.ToAttachment();
                }

                await contexto.PostAsync("Espero ter contribuido para seu aprendizado.");
            }
            else
                await contexto.PostAsync(@" :( Não consegui encontrar nada interessante sobre o tema, mas irei me esforçar mais para aprender sobre o assunto. 
                                        Por enquanto eu tenho um repositório sobre: certificações, cursos e workshops.");

            contexto.Done<string>(null);
        }

        private ItemAcademico.CategoriaEnum ConverterEntidadeLuisEmCategoriaProduto(string entidadeLuis)
        {
            switch (entidadeLuis)
            {
                case "Certificação":
                    return ItemAcademico.CategoriaEnum.Certificacao;
                case "Curso":
                    return ItemAcademico.CategoriaEnum.Curso;
                case "Workshop":
                    return ItemAcademico.CategoriaEnum.Workshop;
                default:
                    return ItemAcademico.CategoriaEnum.Indefinido;
            }
        }

        private async Task ExecutarAposQnaMaker(IDialogContext contexto, IAwaitable<object> resultadoAposQnAMaker)
        {  
            contexto.Wait(ExecutarAposQnaMaker);
        }
    }
} 


