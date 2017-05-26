using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassesPartilhadas;

namespace ClassesPartilhadas
{
    public class Utilizador
    {
        int idUtilizador, idade;
        string nome, username, password, email;

        public Utilizador() { }
        public Utilizador(string usrname, string pass)
        {
            this.password = pass;       this.username = usrname;
        }
        public Utilizador(Utilizador u)
        {
            this.idUtilizador = u.GetIdUtilizador(); this.idade = u.GetIdade();
            this.nome = u.GetNome(); this.username = u.GetNome();
            this.password = u.GetPassword(); this.email = u.GetEmail();
        }

        public Utilizador(int idUtilizador, string nome, int idade, string username, string password, string email)
        {
            this.idUtilizador = idUtilizador; this.idade = idade;
            this.nome = nome; this.username = username;
            this.password = password; this.email = email;
        }

        public  int GetIdUtilizador() { return idUtilizador; }
        public int GetIdade() { return idade; }
        public string GetNome() { return nome; }
        public string GetUsername() { return username; }
        public string GetPassword() { return password; }

        public string GetEmail() { return email; }

        private void SetIdUtilizador(int idUtilizador) { this.idUtilizador = idUtilizador; }
        public void SetIdade(int idade) { this.idade = idade; }
        public void SetNome(string nome) { this.nome = nome; }
        private void SetUsername(string username) { this.username = username; }
        public void SetPassword(string password) { this.password = password; }
        public void SetEmail(string email) { this.email = email; }


        public virtual byte[] ToByteArray()
        {
            List<byte> byteList = new List<byte>();
            byteList.AddRange(BitConverter.GetBytes(idade));
            byteList.AddRange(BitConverter.GetBytes(idUtilizador));
            byteList.AddRange(BitConverter.GetBytes(nome.Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(nome));
            byteList.AddRange(BitConverter.GetBytes(password.Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(password));
            byteList.AddRange(BitConverter.GetBytes(username.Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(username));
            byteList.AddRange(BitConverter.GetBytes(email.Length));
            byteList.AddRange(Encoding.ASCII.GetBytes(email));

            return byteList.ToArray();
        }
        public virtual string Marshalling()
        {
            return "sou utilizador";
        }

        public int Deserialize(byte[] b, int a)
        {            
            this.idade = BitConverter.ToInt32(b, a);
            this.idUtilizador = BitConverter.ToInt32(b, 4 + a);
            int nomeL = BitConverter.ToInt32(b, 8 + a);
            this.nome = (Encoding.ASCII.GetString(b, 12 + a, nomeL));
            int passL = BitConverter.ToInt32(b, a + 12 + nomeL);
            this.password = (Encoding.ASCII.GetString(b, a + 16 + nomeL, passL));
            int usernameL = BitConverter.ToInt32(b, a + 16 + nomeL + passL);
            this.username = (Encoding.ASCII.GetString(b, a + 20 + nomeL + passL, usernameL));
            int emailL = BitConverter.ToInt32(b, a + 20 + nomeL + passL + usernameL);
            this.email = (Encoding.ASCII.GetString(b, a + 24 + nomeL + passL + usernameL, emailL));

            return (4 + 4 + 4 + nomeL + 4 + passL + 4 + usernameL + 4 + emailL);
        }
    }
}
