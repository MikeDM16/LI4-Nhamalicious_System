using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhamiBackEnd1.Code.AcessoBD
{
    class Restaurante
    {
        String designacao, localizacao;
        int idRestaurante, idProprietario, idTipoCozinha, contacto;
        double pontuacao;
        List<Prato> menu;

        public Restaurante(int idRestaurante, String designacao, double pontuacao, string localizacao, int idProprietario, int idTipoCozinha, int contacto)
        {
            this.designacao = designacao;                   this.localizacao = localizacao;
            this.idRestaurante = idRestaurante;             this.idProprietario = idProprietario;
            this.idTipoCozinha = idTipoCozinha;             this.contacto = contacto;
            this.pontuacao = pontuacao;                     this.menu = new List<Prato>();
        }

        public void AddPrato(Prato p) { this.menu.Add(p); }
        public List<Prato> GetPratos() { return this.menu;  }

        public void SetDesignacao(String designacao){   this.designacao = designacao;   }
        public void SetLocalizacao(String localizacao){ this.localizacao = localizacao; }
        public void SetIdRestaurante(int idRestaurante){    this.idRestaurante = idRestaurante; }
        public void SetIdProprietario(int idProprietario){  this.idProprietario = idProprietario;   }
        public void SetIdTipoCozinha(int idTipoCozinha){    this.idTipoCozinha = idTipoCozinha; }
        public void SetContacto(int contacto){  this.contacto = contacto;   }
        public void SetPontuacao(double pontuacao){ this.pontuacao = pontuacao; }
   
        public String GetDesignacao(){  return designacao;  }
        public String GetLocalizacao(){ return localizacao; }
        public int GetIdRestaurante(){  return idRestaurante;   }
        public int GetIdProprietario(){ return idProprietario;  }
        public int GetIdTipoCozinha(){  return idTipoCozinha;   }
        public int GetContacto(){       return contacto;    }
        public double GetPontuacao(){   return pontuacao;   }

    }
}
