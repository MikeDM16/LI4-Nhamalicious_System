﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesPartilhadas;

namespace ClassesPartilhadas
{
    [SerializableAttribute]
    public class Cliente : Utilizador
    {
        Preferencia preferencias;
        List<Restaurante> favoritos;
        List<Visita> visitados;
        
        public Cliente() { }
        public Cliente(int idUtilizador, string nome, int idade, string username, string password, string email, Preferencia p, List<Restaurante> fav, List<Visita> v)
            :base(idUtilizador, nome, idade, username, password, email)
        {
            this.preferencias = p;      this.favoritos = fav;       this.visitados = v;
            
        }
        public Cliente(Preferencia pref, List<Restaurante> fav, List<Visita> vis)
        {
            this.preferencias = pref;
            this.favoritos = fav;       this.visitados = vis;
        }

        public override string  Marshalling()
        {
            return "Sou cliente";
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

            //...
            return byteList.ToArray();
        }

        public void SetPreferencias(Preferencia p) { this.preferencias = p; }
        public void SetFavoritos(List<Restaurante> fa) { this.favoritos = fa; }
        public void SetVisitados(List<Visita> v){ this.visitados = v;  }

        public List<Restaurante> GetFavoritos() { return this.favoritos; }
        public List<Visita> GetVistados() { return this.visitados;  }
        public Preferencia GetPreferencia() { return this.preferencias;  }
    }
}
