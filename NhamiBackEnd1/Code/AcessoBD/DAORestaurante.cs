using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using NhamiBackEnd1.Code.AcessoBD;
using NhamiBackEnd1.Code.SharedClasses;

namespace NhamiBackEnd1.Code.AcessoBD
{
    public class DAORestaurante
    {
        /* Método para determinar o conjunto de pratos associados 
         a um tipo de cozinha especifico pré definido. 
         arg tipo: 1 - Chinesa; 2 - Indiana; 3 - Japonesa; 4 - Vegetariana*/
        public List<Restaurante> PesquisaTipoCozinha(int tipo)
        {
            List<Restaurante> ListRest = null;
            SqlConnection myConnection = new SqlConnection("user id=username; password=password;server=localhost;" +
                                                           "Trusted_Connection=yes; database=Nhamalicious; connection timeout=30");
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Prato " +
                                                        "JOIN Restaurante ON Restaurante.idRestaurante = Prato.idRestaurante " +
                                                        "WHERE  Restaurante.idTipoCozinha = " + tipo, myConnection);
                
                List<Prato> Pratos = new List<Prato>();
                int idP, idRest; double p;  string desig, desc;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {                
                    idP = Convert.ToInt32( myReader["idPrato"].ToString() );
                    desig = myReader["Designacao"].ToString();
                    desc = myReader["Descricao"].ToString();
                    p = Convert.ToDouble(myReader["Preco"].ToString());
                    idRest = Convert.ToInt32(myReader["idRestaurante"].ToString());

                    Prato Prato = new Prato(idP, desig, desc, p, idRest);
                    Pratos.Add(Prato);
                }
                
                myReader.Close();
                myCommand = new SqlCommand("SELECT * FROM Restaurante " +
                                                  "WHERE  Restaurante.idTipoCozinha = " + tipo,
                                                   myConnection);
                
                Dictionary<int, Restaurante> Restaurantes = new Dictionary<int, Restaurante>();
                int idProp, idTipoCozinha, contacto; string local;
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    idRest = Convert.ToInt32(myReader["idRestaurante"].ToString());
                    desig = myReader["Designacao"].ToString();
                    p = Convert.ToDouble(myReader["Pontuacao"].ToString());
                    local = myReader["Localizacao"].ToString();
                    idProp = Convert.ToInt32(myReader["idProprietário"].ToString());
                    idTipoCozinha = Convert.ToInt32(myReader["idTipoCozinha"].ToString());
                    contacto = Convert.ToInt32(myReader["Contacto"].ToString());

                    Restaurante Rest = new Restaurante(idRest, desig, p, local, idProp, idTipoCozinha, contacto);
                    Restaurantes.Add(idRest, Rest);
                }
                myConnection.Close();

                foreach(Prato Prato in Pratos)
                {
                    idRest = Prato.GetIdRestaurante();
                    Restaurantes[idRest].AddPrato(Prato);
                }

                ListRest = new List<Restaurante>();
                foreach(KeyValuePair<int, Restaurante> R in Restaurantes){
                    ListRest.Add(R.Value);
                }
            }
            catch (Exception e) { Console.WriteLine(e); }
            return ListRest;
        }
    }
}
