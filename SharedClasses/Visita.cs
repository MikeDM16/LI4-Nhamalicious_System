using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SharedClasses
{
    public class Visita
    {
        private Restaurante restaurante;
        private DateTime data;

        public Visita(Restaurante r, DateTime d)
        {
            this.restaurante = r; this.data = d;
        }

        public Restaurante GetRestaurante() { return this.restaurante; }
        public DateTime GetDataVisita() { return this.data; }
    }
}