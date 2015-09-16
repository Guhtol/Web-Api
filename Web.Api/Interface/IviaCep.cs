using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Model;

namespace Web.Api.Infra
{
    public interface IviaCep
    {
        List<ViaCep> RetornaLatitudeLongitude(List<ViaCep> Cep, List<Distancia> Distancia);
    }
}
