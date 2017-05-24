using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhamiBackEnd1.Code.AcessoBD
{
    class Utilizador
    {
        int idUtilizador, idade;
        string nome, username, password, email;


        public Utilizador(int idUtilizador, string nome, int idade, string username, string password, string email)
        {
            this.idUtilizador = idUtilizador;            this.idade = idade;
            this.nome = nome;                               this.username = username;
            this.password = password;                       this.email = email;
        }

        public int GetIdUtilizador(){ return idUtilizador;  }
        public int GetIdade(){  return idade;   }
        public string GetNome(){    return nome;    }
        public string GetUsername(){    return username;    }
        public string GetPassword(){    return password;    }
        public string GetEmail(){       return email;       }

        public void SetIdUtilizador(int idUtilizador){  this.idUtilizador = idUtilizador;   }
        public void SetIdade(int idade){    this.idade = idade; }
        public void SetNome(string nome){   this.nome = nome;   }
        public void SetUsername(string username) {  this.username = username; }
        public void SetPassword(string password){   this.password = password;   }
        public void SetEmail(string email){         this.email = email; }

    }
}
