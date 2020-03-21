﻿using System;
using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Core.Communication.Mediator;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        public CarrinhoController(
            IMediatorHandler mediatorHandler,
            IProdutoAppService produtoAppService,
            INotificationHandler<DomainNotification> _notificationHandler)
            : base(mediatorHandler, _notificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _produtoAppService = produtoAppService;
        }

        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProdutoAppService _produtoAppService;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterProdutoPorId(id);
            if (produto is null) return BadRequest();

            if (produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatorHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return RedirectToAction("Index");
            }

            TempData["Erros"] = ObterMensagensErro();
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}
