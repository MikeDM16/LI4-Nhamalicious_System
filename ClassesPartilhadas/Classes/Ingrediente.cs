using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesPartilhadas;

namespace ClassesPartilhadas
{
    [SerializableAttribute]
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
