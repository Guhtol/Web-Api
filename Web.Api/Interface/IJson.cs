using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Model;

namespace Web.Api.Infra
{
    public interface IJson
    {
        List<ViaCep> DescerializarJsonViaCep(string json);
        List<Distancia> DescerializarJsonGeologic(string json);
    }
}
