using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Model;

namespace Web.Api.Json
{
    public interface IJson
    {
        List<ViaCepModel> DescerializarJsonViaCep(string json);
        List<Distancia> DescerializarJsonGeologic(string json);
    }
}
