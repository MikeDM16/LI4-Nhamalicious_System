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

namespace Nhamalicious
{
    class Resultado
    {
        public string NomePrato { get; set; }
        public string NomeRestaurante { get; set; }
        public string Preco { get; set; }
        public string Descricao { get; set; }
        public string TipoCozinha { get; set; }
    }
}