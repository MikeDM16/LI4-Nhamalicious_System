using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedClasses;

namespace SharedClasses
{
    [SerializableAttribute]
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

        public override byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(this.GetIdade()));
            byteList.AddRange(BitConverter.GetBytes(this.GetIdUtilizador()));
            byteList.AddRange(BitConverter.GetBytes(this.GetNome().Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(this.GetNome()));
            byteList.AddRange(BitConverter.GetBytes(this.GetUsername().Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(this.GetUsername()));
            byteList.AddRange(BitConverter.GetBytes(this.GetEmail().Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(this.GetEmail()));
            // ...
            return byteList.ToArray();
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
