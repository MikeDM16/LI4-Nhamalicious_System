using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhamiBackEnd1.Code.AcessoBD
{
    class Prato
    {
        int idPrato, idRestaurante;
        string designacao, descricao;
        double preco;

        public Prato(int idPrato, string designacao, string descricao, double preco, int idRestaurante)
        {
            this.idPrato = idPrato;                 this.idRestaurante = idRestaurante;
            this.designacao = designacao;           this.descricao = descricao;
            this.preco = preco;
        }

        public int GetIdPrato(){    return idPrato; }
        public int GetIdRestaurante(){  return idRestaurante;}
        public string GetDesignacao(){  return designacao;}
        public string GetDescricao(){   return descricao;}
        public double GetPreco(){       return preco;}

        public void SetIdPrato(int idPrato){    this.idPrato = idPrato;}
        public void SetIdRestaurante(int idRestaurante){    this.idRestaurante = idRestaurante;}
        public void SetDesignacao(string designacao){       this.designacao = designacao;}
        public void SetDescricao(string descricao){     this.descricao = descricao;}
        public void SetPreco(double preco){             this.preco = preco;}
    }
}
