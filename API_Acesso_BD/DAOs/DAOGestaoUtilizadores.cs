using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SharedClasses;

namespace API_Acesso_BD
{
    public class DAOGestaoUtilizadores
    {
        private SqlConnection myConnection;
        private DAOPreferenciasUtilizador DAOpreferencias; 

        //Construtor da classe
        public DAOGestaoUtilizadores()
        {
            this.myConnection = new SqlConnection("user id=username;" +
                                                  "password=password;server=10.0.2.2;" +
                                                  "Trusted_Connection=yes;" +
                                                  "database=Nhamalicious; " +
                                                  "connection timeout=30");
            DAOpreferencias = new DAOPreferenciasUtilizador();
        }

        /*--------------------------------------------------------------------
         * Método que realiza o registo de um proprietário, consuante o seu 
         * perfil de utilização : Cliente ou Proprietário
         --------------------------------------------------------------------*/
         public int RegistaUtilizador(Utilizador u)
        {
            int r = (-1);
            if (u is Proprietario){  r = RegistaProprietario(u); }
            else if(u is Cliente){  r = RegistaCliente(u);      }

            return r;
        }

        /*-----------------------------------------------------------------------
         * Método que realiza o registo de um Proprietário na base de dados, 
         * assim como o seu(s) restaurante(s) e pratos do respectivo restaurante
         ------------------------------------------------------------------------*/
        private int RegistaProprietario(Utilizador u)
        {           

            int idade, r = 1; ; string nome, usr, psw, email;
            nome = u.GetNome();
            idade = u.GetIdade(); usr = u.GetUsername();
            psw = u.GetPassword(); email = u.GetEmail();
            List<Restaurante> lista = ((Proprietario)u).GetRestaurantesProprietario();
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;

                string username = u.GetUsername();
                //Verificar se já existe um username igual ao introduzido
                SqlCommand myCommand = new SqlCommand("SELECT P.Username FROM Proprietario AS P" +
                                "WHERE P.Username = '" + username + "'; ", myConnection);
                myReader = myCommand.ExecuteReader();
                if( myReader.Read())
                {
                    myReader.Close();
                    return (-2);
                }
                myReader.Close();


                //Inserir o proprietario na base de dados
                myCommand = new SqlCommand("INSERT INTO [dbo].[Proprietario] " +
                    "([Nome], [Idade], [Username], [Password], [FotoPerfil], [Email] " +
                    "VALUES " +
                    "('" + nome + "', " + idade + ", '" + usr + "', '" + psw + "', " +
                    " NULL, '" + email + "' );" , myConnection);
                myReader = myCommand.ExecuteReader();
                myReader.Close();
                myConnection.Close();  //Evitar conflitos com proximas conexões

                RegistaRestaurantes(u);    
                 
                r = 0;
            }
            catch (Exception e) { Console.WriteLine(e); }
            return r;
        }

        /*-----------------------------------------------------------------------
         * Método que realiza o registo do(s) restaurante(s) e pratos do 
         * respectivo restaurante de um determinado utilizador Proprietário
         ------------------------------------------------------------------------*/
        public void RegistaRestaurantes(Utilizador u)
        {
            
            try
            {
                myConnection.Open();

                SqlDataReader myReader = null;
                string usr = u.GetUsername(), psw = u.GetPassword();
                List<Restaurante> listaRest = ((Proprietario)u).GetRestaurantesProprietario();

                //Determinar o id atribuido ao proprietario acabado de inserir
                SqlCommand myCommand = new SqlCommand("SELECT P.idProprietario FROM Proprietario AS P " +
                                            "WHERE P.Username = '" + usr + "' " +
                                            "AND P.Password = '" + psw + "'; ", myConnection);
                int idProp = (-1);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    idProp = Convert.ToInt32(myReader["idProprietario"].ToString());
                }
                myReader.Close();

                int idTipoCozinha, contacto;
                string desig, local; double pontos;
                //Inserir os restaurantes do proprietário (pelo menos existe 1 estabelecimento)
                foreach (Restaurante rest in listaRest)
                {
                    desig = rest.GetDesignacao(); pontos = rest.GetPontuacao();
                    local = rest.GetLocalizacao(); contacto = rest.GetContacto();
                    idTipoCozinha = rest.GetIdTipoCozinha();
                    List<Prato> listaPratos = rest.GetPratos();

                    //Inserir o restaurante, associado ao seu proprietário
                    myCommand = new SqlCommand("INSERT INTO [dbo].[Restaurante] " +
                        "([Designacao], [Pontuacao], [Localizacao], [Contacto], [idproprietario],[idTipoCozinha]) " +
                        "VALUES " +
                        "( '" + desig + "', " + pontos + ", '" + local + "', " + contacto + ", " + idProp + ", " + idTipoCozinha + ";", myConnection);
                    myReader = myCommand.ExecuteReader();
                    myReader.Close();

                    //Determinar o id atribuido ao restaurante acabado de adicionar
                    myCommand = new SqlCommand("SELECT R.idRestaurante FROM Restaurante AS R " +
                           "WHERE R.idproprietario = " + idProp + " AND R.Designacao = '" + desig + "';", myConnection);
                    int idRest = (-1);
                    myReader = myCommand.ExecuteReader();
                    if (myReader.Read())
                    {
                        idRest = Convert.ToInt32(myReader["idRestaurante"].ToString());
                    }
                    myReader.Close();

                    //Para cada restaurante insirir a sua lista de restaurantes
                    string desc; double preco;
                    foreach (Prato p in listaPratos)
                    {
                        desig = p.GetDesignacao();
                        desc = p.GetDescricao();
                        preco = p.GetPreco();

                        myCommand = new SqlCommand("INSERT INTO [dbo].[Prato] " +
                            "([Designacao], [Descricao], [Preco], [idRestaurante]) " +
                            "VALUES " +
                            "( '" + desig + "', '" + desc + "', " + preco + ", " + idRest + "); ", myConnection);
                        myReader = myCommand.ExecuteReader();
                        myReader.Close();
                    }
                }
                
            }
            catch (Exception e) { Console.WriteLine(e); }

        }    


        /*--------------------------------------------------------------------
         * Método que realiza o registo de um cliente na base de dados
         ---------------------------------------------------------------------*/
        private int RegistaCliente(Utilizador u)
        {
            int idade, ordem, r = 1; ;       string nome, usr, psw, email;
            nome = u.GetNome();
            idade = u.GetIdade();          usr = u.GetUsername();
            psw = u.GetPassword();         email = u.GetEmail();
            ordem = ((Cliente) u).GetPreferencia().GetOrdemPreferencia();
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;

                string username = u.GetUsername();

                //Verificar se já existe um username igual ao introduzido
                SqlCommand myCommand = new SqlCommand("SELECT C.Username FROM Cliente AS C" +
                                "WHERE C.Username = '" + username + "'; ", myConnection);
                myReader = myCommand.ExecuteReader();
                if (myReader.Read())
                {
                    myReader.Close();
                    return (-2);
                }
                myReader.Close();

                myCommand = new SqlCommand("INSERT INTO [dbo].[Cliente] " +
                    "([Nome], [Idade], [Username], [Password], [FotoPerfil], [Email], [OrdemPreferencia]) " +
                    "VALUES " +
                    "('" + nome +  "', " + idade + ", '" + usr + "', '" + psw + "', " + 
                    " NULL, '" + email + "', " + ordem +") ", myConnection);

                myReader = myCommand.ExecuteReader();
                myReader.Close();
                myConnection.Close();  //Evitar conflitos com proximas conexões 
                r = 0;

            }
            catch (Exception e) { Console.WriteLine(e); }
            return r;
        }

        /*--------------------------------------------------------------------
         * Método que determina se a credênciais de login de um utilizador
         * (cliente ou proprietário) são válidas.
         * retorna um  Utilizador se login validado, null caso contrário
         * TESTATO E FUNCIONAL
         ---------------------------------------------------------------------*/
        public Utilizador LoginUtilizador(string username, string password)
        {
            Utilizador utilizador = null;
            utilizador = GetDadosProprietario(username, password);
            if (utilizador != null) return utilizador;
            //utilizador = GetDadosCliente(username, password);
            //if (utilizador != null) return utilizador;
            return utilizador;
        }

        /*--------------------------------------------------------------------
         * Metodo auxiliar no processo de Login. Se os dados de acesso/login 
         * forem corretos para um cliente, devolve as informações relativas ao 
         * utilizador Cliente 
         * TESTADO E FUNCIONAL
         --------------------------------------------------------------------*/
        private Utilizador GetDadosCliente(string username, string password)
        {
            int idCli, idade;            string nome, usr, psw, email;
            StringBuilder s = new StringBuilder();
            SqlDataReader myReader = null;
            try
            {
                myConnection.Open();
                
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Cliente " +
                                                      "WHERE Cliente.Username = '" + username + "' " +
                                                      "AND Cliente.Password = '" + password + "'; ",
                                                       myConnection);

                myReader = myCommand.ExecuteReader();                
                if (myReader.Read()) //Se encontrou na table cliente
                {
                    idCli = Convert.ToInt32(myReader["idCliente"].ToString());
                    nome = myReader["Nome"].ToString();
                    idade = Convert.ToInt32(myReader["Idade"].ToString());
                    usr = myReader["Username"].ToString();
                    psw = myReader["Password"].ToString();
                    email = myReader["Email"].ToString();
                    myConnection.Close();  //Evitar conflitos com proximas conexões 
                    Preferencia p = DAOpreferencias.GetDadosPreferencia(username);                    
                    List<Restaurante> fav = DAOpreferencias.GetDadosFavoritos(username);
                    List<Visita> vis = DAOpreferencias.GetDadosVisitados(username);

                    return new Cliente(idCli, nome, idade, usr, psw, email, p, fav, vis);
                
                }
                 
            }
            catch (Exception e) { s.Append(e); }
            finally
            {
                //Evitar conflitos com proximas conexões 
                myReader.Close();
                myConnection.Close();
            }

            return null;
        }

        /*--------------------------------------------------------------------
         * Metodo auxiliar no processo de Login. Se os dados de acesso forem 
         * corretos para um proprietario, devolve as informações relativas ao 
         * utilizador Proprietario
         * TESTADO E FUNCIONAL
        --------------------------------------------------------------------*/
        private Utilizador GetDadosProprietario(string username, string password)
        {
            
            int idProp, idade;
            string nome, usr, psw, email;
            SqlDataReader myReader = null;
            try
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand("SELECT * FROM Proprietario " +
                                                      "WHERE Proprietario.Username = '" + username + "' " +
                                                      "AND Proprietario.Password = '" + password + "'; ",
                                                      myConnection);

                myReader = myCommand.ExecuteReader();
                if (myReader.Read())//Se encontrou na table Propriatario; 
                {
                    idProp = Convert.ToInt32(myReader["idProprietario"].ToString());
                    nome = myReader["Nome"].ToString();
                    idade = Convert.ToInt32(myReader["Idade"].ToString());
                    usr = myReader["Username"].ToString();
                    psw = myReader["Password"].ToString();
                    email = myReader["Email"].ToString();
                    myConnection.Close();  //Evitar conflitos com proximas conexões                                     
                    List<Restaurante> props = GetRestaurantesProp(username);

                    return new Proprietario(idProp, nome, idade, usr, psw, email, props);
                }
               
            }
            catch (Exception e) { Console.WriteLine(e); }
            finally
            {
                myReader.Close();
                myConnection.Close();  //Evitar conflitos com proximas conexões 
            }

            return null;
        }

        /* ---------------------------------------------------------------------
         * Metodo que devolve os Restaurantes de um determinado Proprietário
         * TESTADO E FUNCIONAL!
         * --------------------------------------------------------------------- */
        public List<Restaurante> GetRestaurantesProp(string proprietario)
        {
            List<Restaurante> rests = new List<Restaurante>();
            try
            {
                myConnection.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand(
                    "SELECT R.idRestaurante, R.Designacao, R.Pontuacao, R.Localizacao, " +
                    "R.idproprietario, R.idTipoCozinha, R.Contacto FROM Proprietario AS P " +
                    "JOIN Restaurante AS R ON R.idproprietario = P.idProprietario " + 
                    "WHERE P.Username = '" + proprietario + "';", myConnection);

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

                    Restaurante restaurante = new Restaurante(idRest, desig, p, local, idProp, idTipoCozinha, contacto);
                    rests.Add(restaurante);
                }
                myReader.Close();
                
                foreach(Restaurante r in rests)
                {
                    idRest = r.GetIdRestaurante();
                    myCommand = new SqlCommand("SELECT * FROM Prato AS P " +
                            "JOIN Restaurante AS R  ON R.idRestaurante = " + idRest + ";", 
                            this.myConnection);

                    List<Prato> Pratos = new List<Prato>();
                    int idP; string desc;
                    myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        idP = Convert.ToInt32(myReader["idPrato"].ToString());
                        desig = myReader["Designacao"].ToString();
                        desc = myReader["Descricao"].ToString();
                        p = Convert.ToDouble(myReader["Preco"].ToString());
                        idRest = Convert.ToInt32(myReader["idRestaurante"].ToString());

                        Prato Prato = new Prato(idP, desig, desc, p, idRest);
                        Pratos.Add(Prato);
                    }
                    myReader.Close();
                    r.SetMenu(Pratos);
                }
                myConnection.Close();
            }
            catch (Exception e) { Console.WriteLine(e); }
            
            return rests;

        }

    }

    public class RespostaU
    {
        public int codigoErro;
        public Utilizador u;
        public string tipo;

        public RespostaU(int i, Utilizador p)
        {
            codigoErro = i;
            u = p;
            if (u is Cliente)
            {
                tipo = "Sou um cliente";
            }
            else
            {
                if (u is Proprietario)
                {
                    tipo = "Sou um proprietario";
                }
                else tipo = "Não sou nada";
            }
        }
    }
}
