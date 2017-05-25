﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhamiBackEnd1.Code.AcessoBD;
using NhamiBackEnd1.Code.SharedClasses;

namespace NhamiBackEnd1.Code.AcessoBD
{
    public class Testar
    {
        public static string testarBD()
        {
            DAOGestaoUtilizadores gestUtil = new DAOGestaoUtilizadores();
            DAORestaurante restaurantes = new DAORestaurante();
            StringBuilder s = new StringBuilder();

            //---------------------------------------------------------------//
            string username = "jose", password = "cunha1234";
            Utilizador r = gestUtil.LoginUtilizador(username, password);
            s.Append("Existe utilizador: " + r.Marshalling() + ". ");
            //---------------------------------------------------------------//
            List<Restaurante> rests =  restaurantes.PesquisaTipoCozinha(1);
            if (rests != null)
                s.Append("Nr de Restaurantes = " + rests.Count);
            else
                s.Append("Está a null");
            return s.ToString() ;
            //---------------------------------------------------------------//
        }
    }
}
