﻿using System;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;

namespace NerdStore.WebApp.MVC.Controllers
{
    public class VitrineController : Controller
    {
        public VitrineController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        private readonly IProdutoAppService _produtoAppService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Sobre(Guid id)
        {
            return View();
        }
    }
}