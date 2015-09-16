using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Json;
using Web.Api.Model;
using System.Web;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using Web.Api.Model;


namespace Web.Api.Json
{
    public class Json:IJson
    {
        private ViaCepModel vcModel = new ViaCepModel();
        /// <summary>
        /// Utilize quando quiser buscar dados em Json da Via Cep
        /// </summary>
        /// <param name="json">entregue seu json para uma string para utilizar</param>
        /// <returns></returns>
        public List<ViaCepModel> DescerializarJsonViaCep(string json)
        {
            ViaCepModels listaCep = new ViaCepModels();
            ViaCepModel vcp = new ViaCepModel()
            {
                cep=JsonConvert.DeserializeObject<ViaCepModel>(json).cep,
                logradouro=JsonConvert.DeserializeObject<ViaCepModel>(json).logradouro,
                bairro=JsonConvert.DeserializeObject<ViaCepModel>(json).bairro,
                ibge = JsonConvert.DeserializeObject<ViaCepModel>(json).ibge,
                localidade = JsonConvert.DeserializeObject<ViaCepModel>(json).localidade,
                uf = JsonConvert.DeserializeObject<ViaCepModel>(json).uf
            };
            listaCep.IncluirCep(vcp);
            return listaCep.ListarViaCepModel();
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
