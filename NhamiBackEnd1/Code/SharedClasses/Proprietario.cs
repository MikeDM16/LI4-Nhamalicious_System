using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhamiBackEnd1.Code.AcessoBD;
using NhamiBackEnd1.Code.SharedClasses;

namespace NhamiBackEnd1.Code.SharedClasses
{
    public class Proprietario : Utilizador
    {
        List<Restaurante> restaurantes; 

        public Proprietario(List<Restaurante> restaurantes)
        {
            this.restaurantes = new List<Restaurante>();
            this.restaurantes = restaurantes;
        }

        public List<Restaurante> GetRestaurantesProprietario()
        {
            return this.restaurantes;
        }


    }
}
