using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Model;

namespace Web.Api.Informação
{
    public class User:IUser
    {
        public List<ViaCepModel> ListarInformacoes(List<ViaCepModel> Cep, List<Distancia> Distancia)
        {
            foreach(var item in Distancia)
            {
                foreach(var item2 in Cep)
                {
                    item2.lat = item.lat;
                    item2.lng = item.lng;
                }
            }
            return Cep.ToList();
        }
    }
}
