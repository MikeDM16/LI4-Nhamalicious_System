using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhamiBackEnd1.Code.AcessoBD;
using NhamiBackEnd1.Code.SharedClasses;

namespace NhamiBackEnd1.Code.SharedClasses
{
    public class Cliente
    {
        Preferencia preferencias;
        List<Restaurante> favoritos;
        List<Restaurante> visitados;
        
        public Cliente(Preferencia pref, List<Restaurante> fav, List<Restaurante> vis)
        {
            this.preferencias = pref;
            this.favoritos = fav;       this.visitados = fav;
        }
    }
}
