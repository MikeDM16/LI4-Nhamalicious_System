using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace NhamiBackEnd1.Code.AcessoBD
{
    class DAOGestaoUtilizadores
    {
        /*Método que determina se a credências de login de um utilizador 
         (cliente ou proprietário) são válidas 
         return true - login confirmado; return false - login não aceite */
        public Boolean LoginUtilizador(string username, string password)
        {
            Boolean r = false;
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
                if (myReader.Read()){ r = true; } //Se encontrou na table cliente
                else{
                    myReader.Close();
                    myCommand = new SqlCommand("SELECT * FROM Proprietario " +
                                                         "WHERE Proprietario.Username = '" + username + "' " +
                                                         "AND Proprietario.Password = '" + password + "'; ",
                                                      myConnection);
                    myReader = myCommand.ExecuteReader();
                    if (myReader.Read()){   r = true; } //Se encontrou na table Propriatario; 
                }
                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
            return r;
        }
    }
}
