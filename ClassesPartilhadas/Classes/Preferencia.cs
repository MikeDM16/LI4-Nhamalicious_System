using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesPartilhadas;

namespace ClassesPartilhadas
{
    public class Preferencia
    {
        int ordemPreferencia;
        List<int> preferenciaTiposCozinha;
        List<Ingrediente> preferenciaIngrediente;
        
        public Preferencia(int ordemPreferencia, List<int> TiposCozinha, List<Ingrediente> ingrs)
        {
            this.ordemPreferencia = ordemPreferencia;
            this.preferenciaTiposCozinha = TiposCozinha;
            this.preferenciaIngrediente = ingrs;
        }

        public int GetOrdemPreferencia() { return this.ordemPreferencia; }
        public List<int> GetPreferenciaTiposCozinha() { return this.preferenciaTiposCozinha; }
        public List<Ingrediente> GetPreferenciaIngredientes() { return this.preferenciaIngrediente;  }

    }
}
