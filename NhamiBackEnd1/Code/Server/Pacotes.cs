using NhamiBackEnd1.Code.AcessoBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhamiBackEnd1.Code
{
    class Pacote
    {
        //PackageType 
        public static PacoteType PackageType;

    }

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

        public int Deserialize(byte [] b)
        {
            this.u = new Utilizador();
            int size = u.Deserialize(b);
            int responseL = BitConverter.ToInt32(b, size);
            this.response = (Encoding.ASCII.GetString(b, size + 4, responseL));

            return b.Length;
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

        public PacoteRegisto(Utilizador u, string response)
        {
            this.u = u;
            this.response = response;
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
}
