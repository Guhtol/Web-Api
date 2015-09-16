using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Model
{
    public class ViaCepModel:Distancia
    {
        public string cep { get; set; }
        public string logradouro  { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string ibge { get; set; }
    }
    public class ViaCepModels
    {
        List<ViaCepModel> listaCep = new List<ViaCepModel>();
        public void IncluirCep(ViaCepModel v)
        {
            listaCep.Add(v);
        }
        public List<ViaCepModel> ListarViaCepModel()
        {
            return listaCep;
        }
    }
}
