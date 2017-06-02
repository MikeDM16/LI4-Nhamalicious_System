using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ClassesPartilhadas
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