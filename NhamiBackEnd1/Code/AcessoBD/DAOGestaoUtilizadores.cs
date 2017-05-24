using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class DAOGestaoUtilizadores
    {
        public Boolean loginProprietário(string username, string password)
        {
            Boolean r = false;
            //Eventualmente passar a coneção como variavel global do DAO
            SqlConnection myConnection = new SqlConnection("user id=username;" +
                                       "password=password;server=localhost;" +
                                       "Trusted_Connection=yes;" +
                                       "database=Nhamalicious; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Proprietario " +
                                                          "WHERE Proprietario.Username = '" + username + "' " +
                                                          "AND Proprietario.Password = '" + password + "'; ",
                                                       myConnection);

                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                    //Se devolveu resultados é porque os parametros estão corretos
                    r = true;
                else r = false;

                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
            return r;
        }
    }
}
