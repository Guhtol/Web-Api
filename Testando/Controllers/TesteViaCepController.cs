using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Testando.Models;
using Web.Api.Infra;
using Web.Api.Model;

namespace Testando.Controllers
{
    public class TesteViaCepController : Controller
    {
        private IRequisiçãoHttp irequisiçãoHttp = new RequisicaoHttp();
        private IJson ijsonDeserializacao = new Json();
        private IviaCep iviaCep = new ViaCep();
        private HttpClient httpClient;
        string json = "";
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscaCep(CepViewModel model)
        {

            if (ModelState.IsValid)
            {
                httpClient = irequisiçãoHttp.PreparaHttpClient("http://viacep.com.br/ws/", "application/json");
                json = irequisiçãoHttp.RetonarMenssagemHttp(model.Cep + "/json/", httpClient);
                var viaCep = ijsonDeserializacao.DescerializarJsonViaCep(json);
                httpClient = irequisiçãoHttp.PreparaHttpClient("http://maps.googleapis.com/maps/api/geocode/json", "application/json");
                viaCep.ForEach(item =>
                {
                    json = irequisiçãoHttp.RetonarMenssagemHttp("?address=" + item.localidade + "+" + item.logradouro + "&sensor=false", httpClient);
                });

                var google = ijsonDeserializacao.DescerializarJsonGeologic(json);
                var dadosCliente = iviaCep.RetornaLatitudeLongitude(viaCep, google);
                dadosCliente.ForEach(item =>
                {
                    model.Cep = item.cep;
                    model.Latitude = item.lat;
                    model.Longitude = item.lng;
                });
            }
            return View("Index", model);
        }
    }
}