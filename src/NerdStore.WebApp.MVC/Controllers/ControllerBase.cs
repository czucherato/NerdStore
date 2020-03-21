using System;
using MediatR;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        public ControllerBase(
            IMediatorHandler mediatorHandler,
            INotificationHandler<DomainNotification> notification)
        {
            _mediatorHandler = mediatorHandler;
            _notificationHandler = (DomainNotificationHandler)notification;
        }

        private readonly IMediatorHandler _mediatorHandler;
        private readonly DomainNotificationHandler _notificationHandler;

        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        protected bool OperacaoValida()
        {
            return !_notificationHandler.TemNotificacao();
        }

        protected IEnumerable<string> ObterMensagensErro()
        {
            return _notificationHandler.ObterNotificacoes().Select(x => x.Value).ToList();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNotificacoes(new DomainNotification(codigo, mensagem));
        }
    }
}