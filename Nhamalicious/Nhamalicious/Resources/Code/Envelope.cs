using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhamiBackEnd1.Code.Server
{
    class Envelope
    {
        PacoteType pt;
        Pacote p;

        public Envelope(PacoteType pt, Pacote p)
        {
            this.pt = pt;
            this.p = p;
        }

        public Envelope()
        {
        }

        public PacoteType GetPacoteType()
        {
            return pt;
        }

        public Pacote GetPacote()
        {
            return p;
        }

        public byte[] ToByteArray(){
            List<byte> byteList = new List<byte>();
            int pty = (int)pt;
            byteList.AddRange(BitConverter.GetBytes(pty));
            PacoteType ptt = (PacoteType)pty;
            switch (ptt)
            {
                case (PacoteType.Login):{
                        PacoteLogin pl = (PacoteLogin)p;
                        byteList.AddRange(pl.ToByteArray());
                        return byteList.ToArray();
                }
                case (PacoteType.Registo):
                    {
                        PacoteRegisto pl = (PacoteRegisto)p;
                        byteList.AddRange(pl.ToByteArray());
                        return byteList.ToArray();
                    }
            }

            return byteList.ToArray();
        }
    }
    
}
