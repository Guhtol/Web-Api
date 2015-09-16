using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Testando.Models;
using Web.Api.Informação;
using Web.Api.Infra;
using Web.Api.Json;
using Web.Api.Model;

namespace Testando.Controllers
{
    public class TesteViaCepController : Controller
    {
        private IRequisiçãoHttp requisiçãoHttp = new RequisicaoHttp();
        private IJson jsonDeserializacao = new Json();
        private IUser user = new User();
        private HttpClient httpClient;
        string json = "";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BuscaCep(CepViewModel model)
        {

            if (ModelState.IsValid)
            {
                httpClient = requisiçãoHttp.PreparaHttpClient("http://viacep.com.br/ws/", "application/json");
                json = requisiçãoHttp.RetonarMenssagemHttp(model.Cep + "/json/", httpClient);
                var viaCep = jsonDeserializacao.DescerializarJsonViaCep(json);
                httpClient = requisiçãoHttp.PreparaHttpClient("http://maps.googleapis.com/maps/api/geocode/json", "application/json");
                viaCep.ForEach(item =>
                {
                    json = requisiçãoHttp.RetonarMenssagemHttp("?address=" + item.localidade + "+" + item.logradouro + "&sensor=false", httpClient);
                });
                //json = requisiçãoHttp.RetonarMenssagemHttp("?address=1600+Amphitheatre+Parkway,+Mountain+View,+CA&sensor=false", httpClient);

                var google = jsonDeserializacao.DescerializarJsonGeologic(json);
                var dadosCliente = user.ListarInformacoes(viaCep, google);
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