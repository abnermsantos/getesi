using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getesi.DAO
{
    class ReservacaoDAO
    {
        int op;
	    bool reservacao;
        int quantidade;
        int automatizar;
        string altura_1;
        string coluna_1;
        int tipo_1;
	    int modelo_1;
	    int material_1;
	    int sensor_1;
        bool infra_1;
        bool colar_1;
        string colarTamanho_1;
        string offset_1;
        string distanciaInfra_1;
        string externa_1;
        string enterrada_1;
        int trvEnterrada_1;
        string altura_2;
        string coluna_2;
        int tipo_2;
	    int modelo_2;
	    int material_2;
	    int sensor_2;
        bool infra_2;
        bool colar_2;
        string colarTamanho_2;
        string offset_2;
        string distanciaInfra_2;
        string externa_2;
        string enterrada_2;
        int trvEnterrada_2;

        public int getOp()
        {
            return op;
        }
        public void setOp(int op)
        {
            this.op = op;
        }
        public bool getReservacao()
        {
            return reservacao;
        }
        public void setReservacao(bool reservacao)
        {
            this.reservacao = reservacao;
        }
        public int getQuantidade()
        {
            return quantidade;
        }
        public void setQuantidade(int quantidade)
        {
            this.quantidade = quantidade;
        }
        public int getAutomatizar()
        {
            return automatizar;
        }
        public void setAutomatizar(int automatizar)
        {
            this.automatizar = automatizar;
        }
        public string getAltura_1()
        {
            return altura_1;
        }
        public void setAltura_1(string altura_1)
        {
            this.altura_1 = altura_1;
        }
        public string getColuna_1()
        {
            return coluna_1;
        }
        public void setColuna_1(string coluna_1)
        {
            this.coluna_1 = coluna_1;
        }
        public int getTipo_1()
        {
            return tipo_1;
        }
        public void setTipo_1(int tipo_1)
        {
            this.tipo_1 = tipo_1;
        }
        public int getModelo_1()
        {
            return modelo_1;
        }
        public void setModelo_1(int modelo_1)
        {
            this.modelo_1 = modelo_1;
        }
        public int getMaterial_1()
        {
            return material_1;
        }
        public void setMaterial_1(int material_1)
        {
            this.material_1 = material_1;
        }
        public int getSensor_1()
        {
            return sensor_1;
        }
        public void setSensor_1(int sensor_1)
        {
            this.sensor_1 = sensor_1;
        }
        public bool getInfra_1()
        {
            return infra_1;
        }
        public void setInfra_1(bool infra_1)
        {
            this.infra_1 = infra_1;
        }
        public bool getColar_1()
        {
            return colar_1;
        }
        public void setColar_1(bool colar_1)
        {
            this.colar_1 = colar_1;
        }
        public string getColarTamanho_1()
        {
            return colarTamanho_1;
        }
        public void setColarTamanho_1(string colarTamanho_1)
        {
            this.colarTamanho_1 = colarTamanho_1;
        }
        public string getOffset_1()
        {
            return offset_1;
        }
        public void setOffset_1(string offset_1)
        {
            this.offset_1 = offset_1;
        }
        public string getDistanciaInfra_1()
        {
            return distanciaInfra_1;
        }
        public void setDistanciaInfra_1(string distanciaInfra_1)
        {
            this.distanciaInfra_1 = distanciaInfra_1;
        }
        public string getExterna_1()
        {
            return externa_1;
        }
        public void setExterna_1(string externa_1)
        {
            this.externa_1 = externa_1;
        }
        public string getEnterrada_1()
        {
            return enterrada_1;
        }
        public void setEnterrada_1(string enterrada_1)
        {
            this.enterrada_1 = enterrada_1;
        }
        public int getTrvEnterrada_1()
        {
            return trvEnterrada_1;
        }
        public void setTrvEnterrada_1(int trvEnterrada_1)
        {
            this.trvEnterrada_1 = trvEnterrada_1;
        }
        public string getAltura_2()
        {
            return altura_2;
        }
        public void setAltura_2(string altura_2)
        {
            this.altura_2 = altura_2;
        }
        public string getColuna_2()
        {
            return coluna_2;
        }
        public void setColuna_2(string coluna_2)
        {
            this.coluna_2 = coluna_2;
        }
        public int getTipo_2()
        {
            return tipo_2;
        }
        public void setTipo_2(int tipo_2)
        {
            this.tipo_2 = tipo_2;
        }
        public int getModelo_2()
        {
            return modelo_2;
        }
        public void setModelo_2(int modelo_2)
        {
            this.modelo_2 = modelo_2;
        }
        public int getMaterial_2()
        {
            return material_2;
        }
        public void setMaterial_2(int material_2)
        {
            this.material_2 = material_2;
        }
        public int getSensor_2()
        {
            return sensor_2;
        }
        public void setSensor_2(int sensor_2)
        {
            this.sensor_2 = sensor_2;
        }
        public bool getInfra_2()
        {
            return infra_2;
        }
        public void setInfra_2(bool infra_2)
        {
            this.infra_2 = infra_2;
        }
        public bool getColar_2()
        {
            return colar_2;
        }
        public void setColar_2(bool colar_2)
        {
            this.colar_2 = colar_2;
        }
        public string getColarTamanho_2()
        {
            return colarTamanho_2;
        }
        public void setColarTamanho_2(string colarTamanho_2)
        {
            this.colarTamanho_2 = colarTamanho_2;
        }
        public string getOffset_2()
        {
            return offset_2;
        }
        public void setOffset_2(string offset_2)
        {
            this.offset_2 = offset_2;
        }
        public string getDistanciaInfra_2()
        {
            return distanciaInfra_2;
        }
        public void setDistanciaInfra_2(string distanciaInfra_2)
        {
            this.distanciaInfra_2 = distanciaInfra_2;
        }
        public string getExterna_2()
        {
            return externa_2;
        }
        public void setExterna_2(string externa_2)
        {
            this.externa_2 = externa_2;
        }
        public string getEnterrada_2()
        {
            return enterrada_2;
        }
        public void setEnterrada_2(string enterrada_2)
        {
            this.enterrada_2 = enterrada_2;
        }
        public int getTrvEnterrada_2()
        {
            return trvEnterrada_2;
        }
        public void setTrvEnterrada_2(int trvEnterrada_2)
        {
            this.trvEnterrada_2 = trvEnterrada_2;
        }
    }
}
