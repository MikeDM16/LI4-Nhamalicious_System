using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NhamiBackEnd1.Code.AcessoBD;
using ClassesPartilhadas;

namespace NhamiBackEnd1.Code.AcessoBD
{
    public class DAOGestaoUtilizadores
    {
        /*Método que determina se a credências de login de um utilizador 
         (cliente ou proprietário) são válidas 
         return true - login confirmado; return false - login não aceite */
        public Utilizador LoginUtilizador(string username, string password)
        {
            Utilizador utilizador = null;
            SqlConnection myConnection = new SqlConnection("user id=username;" +
                                                           "password=password;server=localhost;" +
                                                           "Trusted_Connection=yes;" +
                                                           "database=Nhamalicious; " +
                                                           "connection timeout=30");
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Cliente " +
                                                          "WHERE Cliente.Username = '" + username + "' " +
                                                          "AND Cliente.Password = '" + password + "'; ",
                                                       myConnection);

                myReader = myCommand.ExecuteReader();
                if (myReader.Read()){ utilizador = GetDadosCliente(); } //Se encontrou na table cliente
                else{
                    myReader.Close();
                    myCommand = new SqlCommand("SELECT * FROM Proprietario " +
                                                         "WHERE Proprietario.Username = '" + username + "' " +
                                                         "AND Proprietario.Password = '" + password + "'; ",
                                                      myConnection);
                    myReader = myCommand.ExecuteReader();
                    if (myReader.Read()){ utilizador = GetDadosProprietario(); } //Se encontrou na table Propriatario; 
                }
                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
            return utilizador;
        }

        private Utilizador GetDadosCliente()
        {
            Utilizador cliente = new Cliente();
            return cliente;
        }

        private Utilizador GetDadosProprietario()
        {
            Utilizador proprietario = new Proprietario();
            return proprietario;
        }

    }
}
