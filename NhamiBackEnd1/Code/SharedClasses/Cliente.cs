using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhamiBackEnd1.Code.AcessoBD;
using NhamiBackEnd1.Code.SharedClasses;

namespace NhamiBackEnd1.Code.SharedClasses
{
    public class Cliente : Utilizador
    {
        Preferencia preferencias;
        List<Restaurante> favoritos;
        List<Restaurante> visitados;
        
        public Cliente() { }
        public Cliente(int idUtilizador, string nome, int idade, string username, string password, string email, Preferencia p, List<Restaurante> fav, List<Restaurante> v)
            :base(idUtilizador, nome, idade, username, password, email)
        {
            this.preferencias = p;      this.favoritos = fav;       this.visitados = v;
            
        }
        public Cliente(Preferencia pref, List<Restaurante> fav, List<Restaurante> vis)
        {
            this.preferencias = pref;
            this.favoritos = fav;       this.visitados = fav;
        }

        public override string  Marshalling()
        {
            return "Sou cliente";
        }

        public void SetPreferencias(Preferencia p) { this.preferencias = p; }
        public void SetFavoritos(List<Restaurante> fa) { this.favoritos = fa; }
        public void SetVisitados(List<Restaurante> v){ this.visitados = v;  }

        public List<Restaurante> GetFavoritos() { return this.favoritos; }
        public List<Restaurante> GetVistados() { return this.visitados;  }
        public Preferencia GetPreferencia() { return this.preferencias;  }
    }
}
