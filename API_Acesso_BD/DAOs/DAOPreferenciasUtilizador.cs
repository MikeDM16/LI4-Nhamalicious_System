using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhamiBackEnd1.Code.AcessoBD;
using ClassesPartilhadas;

namespace NhamiBackEnd1.Code.AcessoBD
{
    class DAOPreferenciasUtilizador
    {
        private SqlConnection myConnection;

        //Construtor da classe
        public DAOPreferenciasUtilizador()
        {
            this.myConnection = new SqlConnection("user id=username;" +
                                                  "password=password;server=localhost;" +
                                                  "Trusted_Connection=yes;" +
                                                  "database=Nhamalicious; " +
                                                  "connection timeout=30");
        }

        /*--------------------------------------------------------------------
        * Metodo que retorna os dados relativos às preferencias de um 
        * determinado cliente
        * TESTADO E FUNCIONAL
        --------------------------------------------------------------------*/
        public Preferencia GetDadosPreferencia(string usernameCli)
        {
            Preferencia p = null;
            List<Ingrediente> ingrs = GetDadosListaIngredientes(usernameCli);
            List<string> prefsCozinha = GetDadosTipoCozinha(usernameCli);
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT Cliente.OrdemPreferencia FROM Cliente " +
                                                      "WHERE Cliente.Username = '" + usernameCli + "';", myConnection);

                int ordem = (-1);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    ordem = Convert.ToInt16(myReader["OrdemPreferencia"].ToString());
                }
                myReader.Close();
                myConnection.Close();

                p = new Preferencia(ordem, prefsCozinha, ingrs);
            }
            catch (Exception e) { Console.WriteLine(e); }
            return p;

        }

        /*--------------------------------------------------------------------
         * Metodo que retorna os dados relativos aos tipos de cozinha preferidos 
         * por um determinado cliente
         * TESTADO E FUNCIONAL
         --------------------------------------------------------------------*/
        public List<string> GetDadosTipoCozinha(string usernameCli)
        {
            List<int> lista = null;
            List<string> nomes = null;
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT Cozinha.Designacao, Cozinha.idCozinha FROM Cliente AS C " +
                    "JOIN Cliente_Preferencia_Cozinha AS PrefsC ON PrefsC.idClientePref = C.idCliente " +
                    "JOIN Cozinha ON Cozinha.idCozinha = PrefsC.idCozinhaPref " +
                    "WHERE C.Username = '" + usernameCli + "';", myConnection);

                int valor; string designacao;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    valor = Convert.ToInt16(myReader["idCozinha"].ToString());
                    designacao = myReader["Designacao"].ToString();
                    //Eventualmente seria melhor guardar uma lista com os nomes do tipo de cozinha
                    lista.Add(valor);
                    nomes.Add(designacao);
                }
                myReader.Close();
                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
            return nomes;
        }

        /*--------------------------------------------------------------------
         * Metodo que retorna a lista dos ingredientes que nao são desejados  
         * por um determinado cliente
         * TESTADO E FUNCIONAL!
         --------------------------------------------------------------------*/
        public List<Ingrediente> GetDadosListaIngredientes(string usernameCli)
        {
            List<Ingrediente> lista = null;
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT Ingrediente.Designação FROM Cliente " +
                    "JOIN Cliente_Preferencia_Ingredientes AS Ingrs ON Ingrs.idCliente = Cliente.idCliente " +
                    "JOIN Ingrediente ON Ingrediente.idIngrediente = Ingrs.idIngrediente " +
                    "WHERE Cliente.Username = '" + usernameCli + "';", myConnection);

                string designacao;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    designacao = myReader["Designação"].ToString();
                    Ingrediente i = new Ingrediente(designacao);
                    lista.Add(i);
                }
                myReader.Close();
                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }

            return lista;
        }

        /*----------------------------------------------------------------
         * Metodo que devolve a lista de Restaurantes Favoritos de um 
         * determinado Cliente
         * TESTADO E FUNCIONAL!
         * ---------------------------------------------------------------*/
        public List<Restaurante> GetDadosFavoritos(string usernameCli)
        {
            List<Restaurante> fav = null;
            try
            {
                this.myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT R.idRestaurante, R.Designacao, R.Pontuacao, R.Localizacao, " +
                    " R.idproprietario, R.idTipoCozinha, R.Contacto FROM Restaurante AS R " +
                    "JOIN Cliente_Prefere_Restaurante ON Cliente_Prefere_Restaurante.idRestaurante = R.idRestaurante " +
                    "JOIN Cliente AS C ON C.idCliente = Cliente_Prefere_Restaurante.idCliente " +
                    "WHERE C.Username = '" + usernameCli + "';", myConnection);

                myReader = myCommand.ExecuteReader();
                int idRest, idProp, idTipoCozinha, contacto;
                string desig, local; double p;
                while (myReader.Read())
                {
                    idRest = Convert.ToInt32(myReader["idRestaurante"].ToString());
                    desig = myReader["Designacao"].ToString();
                    p = Convert.ToDouble(myReader["Pontuacao"].ToString());
                    local = myReader["Localizacao"].ToString();
                    idProp = Convert.ToInt32(myReader["idProprietario"].ToString());
                    idTipoCozinha = Convert.ToInt32(myReader["idTipoCozinha"].ToString());
                    contacto = Convert.ToInt32(myReader["Contacto"].ToString());

                    Restaurante Rest = new Restaurante(idRest, desig, p, local, idProp, idTipoCozinha, contacto);
                    fav.Add(Rest);
                }
                myReader.Close();
                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }

            return fav;
        }

        /*----------------------------------------------------------------
         * Metodo que devolve a lista de Restaurantes visitados de um 
         * determinado Cliente, numa determinada data
         * TESTADO E FUNCIONAL!
         * ---------------------------------------------------------------*/
        public List<Visita> GetDadosVisitados(string usernameCli)
        {
            List<Visita> vis = null;
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT R.idRestaurante, R.Designacao, R.Pontuacao, R.Localizacao, " +
                    " R.idproprietario, R.idTipoCozinha, R.Contacto FROM Restaurante AS R " +
                    "JOIN Cliente_Visita_Restaurante AS VisR ON VisR.Restaurante_idRestaurante = R.idRestaurante " +
                    "JOIN Cliente AS C ON C.idCliente = VisR.Cliente_idCliente " +
                    "WHERE C.Username = '" + usernameCli + "';", myConnection);

                myReader = myCommand.ExecuteReader();
                int idRest, idProp, idTipoCozinha, contacto;
                string desig, local; double p; DateTime data;
                Visita v;
                while (myReader.Read())
                {
                    idRest = Convert.ToInt32(myReader["idRestaurante"].ToString());
                    desig = myReader["Designacao"].ToString();
                    p = Convert.ToDouble(myReader["Pontuacao"].ToString());
                    local = myReader["Localizacao"].ToString();
                    idProp = Convert.ToInt32(myReader["idProprietario"].ToString());
                    idTipoCozinha = Convert.ToInt32(myReader["idTipoCozinha"].ToString());
                    contacto = Convert.ToInt32(myReader["Contacto"].ToString());
                    data = DateTime.Parse(myReader["Data"].ToString());

                    Restaurante Rest = new Restaurante(idRest, desig, p, local, idProp, idTipoCozinha, contacto);
                    v = new Visita(Rest, data);
                    vis.Add(v);
                }
                myReader.Close();
                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }

            return vis;

        }
    }
}
