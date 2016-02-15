using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getesi.DAO
{
    class ComunicacaoDAO
    {
        int op;
	    bool comunicacao;
        string coordenada;
        string trafego;
        string visada;
        string distanciaLink;
	    string alturaNecessaria;
        bool QtdAntenas;
        bool suporte;
        bool energia;
        bool radioPainel;
        bool infra;
        string distanciaPainel;
        string externa;
        string enterrada;
        int trvEnterrada;

        public int getOp()
        {
            return op;
        }
        public void setOp(int op)
        {
            this.op = op;
        }
        public bool getComunicacao()
        {
            return comunicacao;
        }
        public void setComunicacao(bool comunicacao)
        {
            this.comunicacao = comunicacao;
        }
        public string getCoordenada()
        {
            return coordenada;
        }
        public void setCoordenada(string coordenada)
        {
            this.coordenada = coordenada;
        }
        public string getTrafego()
        {
            return trafego;
        }
        public void setTrafego(string trafego)
        {
            this.trafego = trafego;
        }
        public string getVisada()
        {
            return visada;
        }
        public void setVisada(string visada)
        {
            this.visada = visada;
        }
        public string getDistanciaLink()
        {
            return distanciaLink;
        }
        public void setDistanciaLink(string distanciaLink)
        {
            this.distanciaLink = distanciaLink;
        }
        public string getAlturaNecessaria()
        {
            return alturaNecessaria;
        }
        public void setAlturaNecessaria(string alturaNecessaria)
        {
            this.alturaNecessaria = alturaNecessaria;
        }
        public bool getQtdAntenas()
        {
            return QtdAntenas;
        }
        public void setQtdAntenas(bool qtdAntenas)
        {
            QtdAntenas = qtdAntenas;
        }
        public bool getSuporte()
        {
            return suporte;
        }
        public void setSuporte(bool suporte)
        {
            this.suporte = suporte;
        }
        public bool getEnergia()
        {
            return energia;
        }
        public void setEnergia(bool energia)
        {
            this.energia = energia;
        }
        public bool getRadioPainel()
        {
            return radioPainel;
        }
        public void setRadioPainel(bool radioPainel)
        {
            this.radioPainel = radioPainel;
        }
        public bool getInfra()
        {
            return infra;
        }
        public void setInfra(bool infra)
        {
            this.infra = infra;
        }
        public string getDistanciaPainel()
        {
            return distanciaPainel;
        }
        public void setDistanciaPainel(string distanciaPainel)
        {
            this.distanciaPainel = distanciaPainel;
        }
        public string getExterna()
        {
            return externa;
        }
        public void setExterna(string externa)
        {
            this.externa = externa;
        }
        public string getEnterrada()
        {
            return enterrada;
        }
        public void setEnterrada(string enterrada)
        {
            this.enterrada = enterrada;
        }
        public int getTrvEnterrada()
        {
            return trvEnterrada;
        }
        public void setTrvEnterrada(int trvEnterrada)
        {
            this.trvEnterrada = trvEnterrada;
        }
    }
}
