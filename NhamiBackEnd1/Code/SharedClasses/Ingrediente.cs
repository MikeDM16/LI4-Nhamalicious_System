using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhamiBackEnd1.Code.AcessoBD;
using NhamiBackEnd1.Code.SharedClasses;

namespace NhamiBackEnd1.Code.SharedClasses
{
    public class Ingrediente
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
