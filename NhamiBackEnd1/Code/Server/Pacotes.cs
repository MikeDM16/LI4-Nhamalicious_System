using NhamiBackEnd1.Code.AcessoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhamiBackEnd1.Code
{
    class Pacote { }
    enum PacoteType
    {
        Login,Registo, AltPref, InserirRestaurante, InserirPrato,
    }

    class PacoteLogin : Pacote
    {
        Utilizador u;
        string response;

        public PacoteLogin(Utilizador u, string response)
        {
            this.u = u;
            this.response = response;
        }
        public PacoteLogin() { }
        public int Deserialize(byte [] b, int a)
        {
            this.u = new Utilizador();
            int size = u.Deserialize(b,a);
            int responseL = BitConverter.ToInt32(b, size+a);
            this.response = (Encoding.ASCII.GetString(b, a+size + 4, responseL));

            return b.Length;
        }
        public string GetResponse()
        {
            return response;
        }

        /// <summary>
        ///  Serializes this package to a byte array.
        /// </summary>
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(u.ToByteArray());
            byteList.AddRange(Encoding.ASCII.GetBytes(response));

            return byteList.ToArray();
        }
    }

    class PacoteRegisto : Pacote
    {
        Utilizador u;
        string response;
        public PacoteRegisto() { }
        public PacoteRegisto(Utilizador u, string response)
        {
            this.u = u;
            this.response = response;
        }
        public string GetResponse()
        {
            return response;
        }
        /// <summary>
        ///  Serializes this package to a byte array.
        /// </summary>
        public byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(u.ToByteArray());
            byteList.AddRange(Encoding.ASCII.GetBytes(response));

            return byteList.ToArray();
        }

        public int Deserialize(byte[] b, int a)
        {
            this.u = new Utilizador();
            int size = u.Deserialize(b,a);
            int responseL = BitConverter.ToInt32(b, a + size);
            this.response = (Encoding.ASCII.GetString(b, a + size + 4, responseL));

            return b.Length;
        }
    }
}
