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

        public Proprietario() { }
        public Proprietario(int idUtilizador, string nome, int idade, string username, string password, string email, List<Restaurante> res)
            :base(idUtilizador, nome, idade, username, password, email)
        {
            this.restaurantes = new List<Restaurante>();
            this.restaurantes = res;
        }

        public Proprietario(List<Restaurante> restaurantes)
        {
            this.restaurantes = new List<Restaurante>();
            this.restaurantes = restaurantes;
        }

        public override string Marshalling()
        {
            return "Sou proprietário";
        }

        public List<Restaurante> GetRestaurantesProprietario()
        {
            return this.restaurantes;
        }


    }
}
