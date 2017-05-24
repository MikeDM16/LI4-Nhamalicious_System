using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace NhamiBackEnd1.Code.AcessoBD
{
    class DAORestaurante
    {

        public void pesquisaRestaurante(int tipo)
        {
            // Realiza pesquisa por tipo de cozinha ´pré definido
            //   1 - Chinesa; 2 - Indiana; 3 - Japonesa; 4 - Vegetariana

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
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Prato " +
                                                        "JOIN Restaurante ON Restaurante.idRestaurante = Prato.idRestaurante " +
                                                        "WHERE  Restaurante.idTipoCozinha = " + tipo,
                                                        myConnection);
                myReader = myCommand.ExecuteReader();
                int i = 0;
                while (myReader.Read())
                {
                    Console.WriteLine("Prato " + i++ + ": " + myReader["Designacao"].ToString());
                    // Agora é pegar em todas as colunas e construir classes
                }

                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
        }
    }
}
