﻿using System.Diagnostics;
using Ecommerce.Models;
using Ecommerce.Models.Entities;
using Ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IServizioProdotto _sp;
        private readonly IServizioCliente _sc;
        private readonly IServizioCarrello _scart;


		public HomeController(ILogger<HomeController> logger, IServizioProdotto servizioprodotto, IServizioCliente serviziocliente, IServizioCarrello serviziocarrello)
		{
			_logger = logger;
			_sp = servizioprodotto;
            _sc = serviziocliente;
            _scart = serviziocarrello;
		}

		public IActionResult Index()
		{	//lista prodotti
			var prodotti= _sp.GetAll().ToList();
			return View(prodotti);
		}
       
        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
		//autorize admin
        public IActionResult Create(Prodotto p)
		{
			if (ModelState.IsValid)
			{
				var result=_sp.CreaProdotto(p);
				if(result)
					return RedirectToAction("Index");

			}
			return View(p);
		}
		public IActionResult VistaCarrello()
		{//prendo id del cliente
            //prendo id carrello
            //var cliente= _sc.GetById().ToList();
			return View();
		}
		//autorize admin
		public IActionResult Delete(int id)
		{
            var result = _sp.EliminaProdotto(id);
            if (result)
                return RedirectToAction("Index");
            return View();
        }
        public IActionResult Details(int id)
        {
			var prodotto = _sp.GetProdottoById(id);
            return View(prodotto);
        }
        //autorize admin
        public IActionResult Edit(int id)
        {
            var prodotto = _sp.GetProdottoById(id);
            return View(prodotto);
        }
        [HttpPost]
        //autorize admin
        public ActionResult Edit(Prodotto model)
        {

            if (ModelState.IsValid)
            {
                var result = _sp.ModificaProdotto(model);
                if (result)
                    return RedirectToAction("Index", "Home");
                else
                {
                    ModelState.AddModelError("model", "Impossibile eseguire il comando di inserimento sul database");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddtoCart(Prodotto p, IFormCollection fields)
        {
            var idcarrello = _scart.GetIdCarrelloAttuale();
            var idprodotto = p.IdProdotto;// _sp.GetIdProdotto();
            var prodotto = _sp.GetAll().SingleOrDefault(x=>x.IdProdotto==idprodotto);
            _scart.AggiungiProdottoAlCarrello(idcarrello, idprodotto, int.Parse(fields["quantita"]));

                       //var idcarrello= _scart.GetCarrelloById(1).IdCarrello;
                        //var idprodotto = _scart.GetIdProdotto();
                     // var prodotto = _sp.GetProdottoById(idprodotto).IdProdotto;
             //_scart.AggiungiProdottoAlCarrello(quantita);
                     //_scart.CreaCarrello();
           
            

            return RedirectToAction("Index");
        }
        public IActionResult AggiungiProdotto()
        {
           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //autorize all
        public IActionResult AggiungiProdotto(Prodotto p)
        { 
            if (ModelState.IsValid)
            {
                var result = _sp.CreaProdotto(p);
                if (result)
                    return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }
      
        public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}