using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Infra
{
    public interface IRequisiçãoHttp
    {
        HttpClient PreparaHttpClient(string url,string type,string name = "", string senha = "");
        string RetonarMenssagemHttp(string url, HttpClient httpClient);

    }
}
