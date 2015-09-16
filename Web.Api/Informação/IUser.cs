using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Api.Model;

namespace Web.Api.Informação
{
    public interface IUser
    {
        List<ViaCepModel> ListarInformacoes(List<ViaCepModel> Cep, List<Distancia> Distancia);
    }
}
