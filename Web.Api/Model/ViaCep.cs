using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Infra;

namespace Web.Api.Model
{
    public class ViaCep : Distancia, IviaCep
    {
        public string cep { get; set; }
        public string logradouro  { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }

        public List<ViaCep> RetornaLatitudeLongitude(List<ViaCep> Cep, List<Distancia> Distancia)
        {
            Cep.ForEach(itemCep =>
            {
                Distancia.ForEach(itemDistancia =>
                {
                    itemCep.lat = itemDistancia.lat;
                    itemCep.lng = itemDistancia.lng;
                });
            });
            //foreach(var item in Distancia)
            //{
            //    foreach(var item2 in Cep)
            //    {
            //        item2.lat = item.lat;
            //        item2.lng = item.lng;
            //    }
            //}
            return Cep.ToList();
        }
    }

}
