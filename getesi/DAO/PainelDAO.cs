using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getesi.DAO
{
    class PainelDAO
    {
        int op;
	    string qtdPaineis;
        bool abrigo;
        bool modelo;
        bool material;
        int instalacao;
        string distanciaEnergia;
        string enterrada;
        string externa;
        int trvEnterrada;
        string seguranca;
        bool chave;
        bool alarme;

        public int getOp()
        {
            return op;
        }
        public void setOp(int op)
        {
            this.op = op;
        }
        public string getQtdPaineis()
        {
            return qtdPaineis;
        }
        public void setQtdPaineis(string qtdPaineis)
        {
            this.qtdPaineis = qtdPaineis;
        }
        public bool getAbrigo()
        {
            return abrigo;
        }
        public void setAbrigo(bool abrigo)
        {
            this.abrigo = abrigo;
        }
        public bool getModelo()
        {
            return modelo;
        }
        public void setModelo(bool modelo)
        {
            this.modelo = modelo;
        }
        public bool getMaterial()
        {
            return material;
        }
        public void setMaterial(bool material)
        {
            this.material = material;
        }
        public int getInstalacao()
        {
            return instalacao;
        }
        public void setInstalacao(int instalacao)
        {
            this.instalacao = instalacao;
        }
        public string getDistanciaEnergia()
        {
            return distanciaEnergia;
        }
        public void setDistanciaEnergia(string distanciaEnergia)
        {
            this.distanciaEnergia = distanciaEnergia;
        }
        public string getEnterrada()
        {
            return enterrada;
        }
        public void setEnterrada(string enterrada)
        {
            this.enterrada = enterrada;
        }
        public string getExterna()
        {
            return externa;
        }
        public void setExterna(string externa)
        {
            this.externa = externa;
        }
        public int getTrvEnterrada()
        {
            return trvEnterrada;
        }
        public void setTrvEnterrada(int trvEnterrada)
        {
            this.trvEnterrada = trvEnterrada;
        }
        public string getSeguranca()
        {
            return seguranca;
        }
        public void setSeguranca(string seguranca)
        {
            this.seguranca = seguranca;
        }
        public bool getChave()
        {
            return chave;
        }
        public void setChave(bool chave)
        {
            this.chave = chave;
        }
        public bool getAlarme()
        {
            return alarme;
        }
        public void setAlarme(bool alarme)
        {
            this.alarme = alarme;
        }
    }
}
