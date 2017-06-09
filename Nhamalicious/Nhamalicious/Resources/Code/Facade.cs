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
using NhamiBackEnd1.Code.AcessoBD;
using ClassesPartilhadas;

namespace Nhamalicious.Resources.Code
{
    public class Facade
    {
        static DAOGestaoUtilizadores DGU = new DAOGestaoUtilizadores();
        static DAORestaurante DR = new DAORestaurante();
        static DAOPreferenciasUtilizador DPU = new DAOPreferenciasUtilizador();

       /* public Facade()
        {
            this.DGU = new DAOGestaoUtilizadores();
            this.DR = new DAORestaurante();
            this.DPU = new DAOPreferenciasUtilizador();
        }*/

        public static Utilizador ConnectLogin(string id, string password)
        {
            Utilizador u = null;

            u = DGU.LoginUtilizador(id, password);

            //if (u is Proprietario)
            //{
            //    return u;
            //}
            //else
            //{
            //    if (u is Cliente)
            //    {
            //        return u;
            //    }
            //}
            if (u == null) return new Cliente(-1, "M", 22, "asd", "asd", "asd", null, null, null);
            return u;
        }


        public static int RegistaUtilizador(Utilizador u)
        {
            int r = DGU.RegistaUtilizador(u);
            DGU.RegistaRestaurantes(u);
            return r;
        }
        

        public static void RegistaRestaurante(Utilizador u)
        {
            DGU.RegistaRestaurantes(u);
        }
    }
}