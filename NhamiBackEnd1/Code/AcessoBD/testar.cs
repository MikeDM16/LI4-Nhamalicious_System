using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class testar
    {
        static void Main(string[] args)
        {
            DAOGestaoUtilizadores gestUtil = new DAOGestaoUtilizadores();
            DAORestaurante restaurantes = new DAORestaurante();

            string username = "mm", password = "cunha1234";
            Boolean r = gestUtil.loginProprietário(username, password);
            Console.WriteLine("Existe utilizador: " + r);

            restaurantes.pesquisaRestaurante(1);
        }
    }
}
