using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Infra;
using Web.Api.Model;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Web.Api.Model;


namespace Web.Api.Infra
{
    public class Json:IJson
    {
        //private ViaCepModel vcModel = new ViaCepModel();
        /// <summary>
        /// Utilize quando quiser buscar dados em Json da Via Cep
        /// </summary>
        /// <param name="json">entregue seu json para uma string para utilizar</param>
        /// <returns></returns>
        public List<ViaCep> DescerializarJsonViaCep(string json)
        {
            List<ViaCep> listaCep = new List<ViaCep>();
            ViaCep vcp = new ViaCep()
            {
                cep=JsonConvert.DeserializeObject<ViaCep>(json).cep,
                logradouro=JsonConvert.DeserializeObject<ViaCep>(json).logradouro,
                bairro=JsonConvert.DeserializeObject<ViaCep>(json).bairro,
                ibge = JsonConvert.DeserializeObject<ViaCep>(json).ibge,
                localidade = JsonConvert.DeserializeObject<ViaCep>(json).localidade,
                uf = JsonConvert.DeserializeObject<ViaCep>(json).uf
            };
            listaCep.Add(vcp);
            return listaCep.ToList();
        }
        public List<Distancia> DescerializarJsonGeologic(string json)
        {
            json = JObject.Parse(json).SelectToken("results").ToString();
            JavaScriptSerializer js = new JavaScriptSerializer();
            var query = js.Deserialize<List<Geometry>>(json);
            List<Distancia> distancia = new List<Distancia>();
            foreach (var i in query)
            {
                Distancia d = new Distancia();
                d.lat = i.geometry.location.lat;
                d.lng = i.geometry.location.lng;
                distancia.Add(d);
            }
            return distancia;
        }
    }
}
