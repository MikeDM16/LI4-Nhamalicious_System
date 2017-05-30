using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesPartilhadas;

namespace ClassesPartilhadas
{
    [SerializableAttribute]
    public class Pacote { }
    [SerializableAttribute]
    public enum PacoteType
    {
        Login,Registo, AltPref, InserirRestaurante, InserirPrato,
    }
    [SerializableAttribute]
    public class PacoteLogin : Pacote
    {
        Utilizador u;
        short tipo;
        string response;

        public PacoteLogin(Utilizador u, string response)
        {
            this.u = u;
            if (u is Cliente) { tipo = 1; }
            else
            {
                if (u is Proprietario) { tipo = 0; }
                else { tipo = (-1); }
            }

            this.response = response;
        }
        public PacoteLogin() { }
        //public int Deserialize(byte [] b, int a)
        //{
        //    this.u = new Utilizador();
        //    this.tipo = BitConverter.ToInt16(b, a);
        //    int size = u.Deserialize(b,a);
        //    int responseL = BitConverter.ToInt32(b, size+a);
        //    this.response = (Encoding.ASCII.GetString(b, a+size + 4, responseL));

        //    return (size + 4 + responseL);
        //}
        public string GetResponse()
        {
            return response;
        }

        /// <summary>
        ///  Serializes this package to a byte array.
        /// </summary>
        //public byte[] ToByteArray()
        //{
        //    List<byte> byteList = new List<byte>();
        //    byteList.AddRange(BitConverter.GetBytes(tipo));
        //    byteList.AddRange(u.ToByteArray());
        //    byteList.AddRange(BitConverter.GetBytes(response.Length));
        //    byteList.AddRange(Encoding.ASCII.GetBytes(response));

        //    return byteList.ToArray();
        //}
        
        public Utilizador GetUtilizador() { return this.u;  }

        internal void SetResponse(string v)
        {
            this.response = v;
        }
        
    }
    [SerializableAttribute]
    public class PacoteRegisto : Pacote
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

            return (size + 4 + responseL);
        }
    }
}
