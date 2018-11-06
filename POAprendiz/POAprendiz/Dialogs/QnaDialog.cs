using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace POAprendiz.Dialogs
{
    [Serializable]
    public class QnaDialog : QnAMakerDialog
    {
        public QnaDialog() : base(new QnAMakerService(new QnAMakerAttribute(
            ConfigurationManager.AppSettings["QnaSubscriptionKey"],
            ConfigurationManager.AppSettings["QnaKnowledgebaseId"],
            "Ainda estou aprendendo, no momento não possuo a resposta mas irei pesquisar.",
            0.75))){  }
    }
}