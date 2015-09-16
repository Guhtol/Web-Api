using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Web.Api.Model;
using Newtonsoft.Json;


namespace Web.Api.Infra
{
    public class RequisicaoHttp:IRequisiçãoHttp
    {
        private HttpClient httpClient;
        private HttpClientHandler httpClientHandler;
        private HttpResponseMessage httpResponseMessage;
        /// <summary>
        /// Class responsável por criar o HttpClient 
        //
        /// </summary>
        /// <param name="url">Url base da requisição do Api</param>
        /// <param name="type"> tipo de dados a ser recebido exemplo Json</param>
        /// <param name="name">se tiver credencial nome do usuário</param>
        /// <param name="senha"> ser tiver senha nome da senha</param>
        /// <returns></returns>
        public HttpClient PreparaHttpClient(string url,string type,string name="",string senha="")
        {
            httpClientHandler = new HttpClientHandler();
            if(!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(senha))
            {
                httpClientHandler.Credentials = new NetworkCredential(name, senha);
            }
            httpClient = new HttpClient(httpClientHandler);
            httpClient.BaseAddress = new Uri(url);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(type));
            return httpClient;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url">Aqui envia os parametros da Url</param>
        /// <param name="httpClient"></param>
        /// <returns></returns>
        public string RetonarMenssagemHttp(string url, HttpClient httpClient)
        {
            httpResponseMessage = httpClient.GetAsync(url).Result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var jsonString = httpResponseMessage.Content.ReadAsStringAsync();
                return jsonString.Result;
                //string logradouro = JsonConvert.DeserializeObject<ViaCepModel>(JsonString.Result);
            }
            return null;
        }
    }
}
