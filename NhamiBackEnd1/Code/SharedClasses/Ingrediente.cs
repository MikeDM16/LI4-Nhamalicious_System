using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhamiBackEnd1.Code.SharedClasses
{
    class Ingrediente
    {
        string designacao;

        public Ingrediente(string designacao)
        {
            this.designacao = designacao;
        }

        public string GetDesignacao() { return this.designacao;  }
        public void SetDesignacao(string d) { this.designacao = d;  }
    }
}
