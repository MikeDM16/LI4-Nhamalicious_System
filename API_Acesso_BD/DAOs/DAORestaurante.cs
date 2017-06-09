using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SharedClasses;

namespace API_Acesso_BD
{
    public class DAORestaurante
    {
        private SqlConnection myConnection;

        public DAORestaurante()
        {
            this.myConnection = new SqlConnection("user id=username; " +
                                                  "password=password;server=10.0.2.2;" +
                                                  "Trusted_Connection=yes; " +
                                                  "database=Nhamalicious; " +
                                                  "connection timeout=30");
        }

        /*---------------------------------------------------------------------
         * Método para realizar a pesquisa através da designação do nome, 
         * completo ou não, de um prato 
         ----------------------------------------------------------------------*/

        /*---------------------------------------------------------------------
         * Método para determinar o conjunto de pratos associados 
         * a um tipo de cozinha especifico pré definido.
         * arg tipo: Chinesa; Indiana; Japonesa; Vegetariana
         ----------------------------------------------------------------------*/
        public List<Restaurante> PesquisaTipoCozinha(string tipo)
        {
            List<Restaurante> ListRest = null;
            
            try
            {
                this.myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Prato AS P " +
                    "JOIN Restaurante AS R  ON R.idRestaurante = P.idRestaurante " +
                    "JOIN Cozinha AS C ON C.idCozinha = R.idTipoCozinha " +
                    "WHERE C.Designacao = '" + tipo + "';", this.myConnection);
                
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
                myCommand = new SqlCommand("SELECT * FROM Restaurante AS R " +
                                           "JOIN Cozinha AS C ON C.idCozinha = R.idTipoCozinha " +
                                           "WHERE C.Designacao = '" + tipo + "';", myConnection);


                Dictionary<int, Restaurante> Restaurantes = new Dictionary<int, Restaurante>();
                int idProp, idTipoCozinha, contacto; string local;
                myReader = myCommand.ExecuteReader();
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
                    Restaurantes.Add(idRest, Rest);
                }
                this.myConnection.Close();

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
