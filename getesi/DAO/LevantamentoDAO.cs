using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace getesi.DAO
{
    class LevantamentoDAO
    {
        int op;
        DateTime data;
        string responsavel;
        string local;
        string referencia;
        string endereco;
        string observacao;

        ComunicacaoDAO comunicacaoDAO = new ComunicacaoDAO();
        PainelDAO painelDAO = new PainelDAO();
        ReservacaoDAO reservacaoDAO = new ReservacaoDAO();
        VazaoDAO vazaoDAO = new VazaoDAO();
        PressaoDAO pressaoDAO = new PressaoDAO();
        BombasDAO bombaDAO = new BombasDAO();
        DosadoresDAO dosadorDAO = new DosadoresDAO();

        public int getOp()
        {
            return op;
        }
        public void setOp(int op)
        {
            this.op = op;
        }
        public DateTime getData()
        {
            return data;
        }
        public void setData(DateTime data)
        {
            this.data = data;
        }
        public string getResponsavel()
        {
            return responsavel;
        }
        public void setResponsavel(string responsavel)
        {
            this.responsavel = responsavel;
        }
        public string getLocal()
        {
            return local;
        }
        public void setLocal(string local)
        {
            this.local = local;
        }
        public string getReferencia()
        {
            return referencia;
        }
        public void setReferencia(string referencia)
        {
            this.referencia = referencia;
        }
        public string getEndereco()
        {
            return endereco;
        }
        public void setEndereco(string endereco)
        {
            this.endereco = endereco;
        }
        public string getObservacao()
        {
            return observacao;
        }
        public void setObservacao(string observacao)
        {
            this.observacao = observacao;
        }

//Método Inserir Levantamento
        public bool inserirLevantamento()
        {
            bool aux = false;
            String sql = "INSERT INTO levantamento(op, data, responsavel, local, referencia, endereco, observacao) VALUES(" + op + ", '" + data + "', '" + responsavel + "', '" + local + "', '" + referencia + "', '" + endereco + "', '" + observacao +"' )";
            if (DAO.ConexaoPG.getInstancia().persistir(sql))
            {
                String sql2 = "INSERT INTO comunicacao(op, comunicacao, coordenada, trafego, visada, distanciaLink, alturaNecessaria, qtdAntenas, suporte, energia, radioPainel, infra, distanciaPainel, externa, enterrada, trvEnterrada)";
                sql2 += "VALUES(" + op + ", " + comunicacaoDAO.getComunicacao() + ", '" + comunicacaoDAO.getCoordenada() + "', '" + comunicacaoDAO.getTrafego() + "', '" + comunicacaoDAO.getVisada() + "', '" + comunicacaoDAO.getDistanciaLink() + "', '" + comunicacaoDAO.getAlturaNecessaria();
                sql2 += "', " + comunicacaoDAO.getQtdAntenas() + ", " + comunicacaoDAO.getSuporte() + ", " + comunicacaoDAO.getEnergia() + ", " + comunicacaoDAO.getRadioPainel() + ", " + comunicacaoDAO.getInfra() + ", '" + comunicacaoDAO.getDistanciaPainel() + "', '" + comunicacaoDAO.getExterna() + "', '" + comunicacaoDAO.getEnterrada() + "', " + comunicacaoDAO.getTrvEnterrada() + " )";
                if (DAO.ConexaoPG.getInstancia().persistir(sql2))
                {
                    String sql3 = "INSERT INTO painel(op, qtdPaineis, abrigo, modelo, material, instalacao, distanciaEnergia, enterrada, externa, trvEnterrada, seguranca, chave, alarme) VALUES(" + op + ", " + painelDAO.getQtdPaineis() + ", " + painelDAO.getAbrigo();
                    sql3 += "," + painelDAO.getModelo() + ", " + painelDAO.getMaterial() + ", " + painelDAO.getInstalacao() + ", '" + painelDAO.getDistanciaEnergia() + "', '" + painelDAO.getEnterrada() + "', '" + painelDAO.getExterna() + "', " + painelDAO.getTrvEnterrada() + ", '" + painelDAO.getSeguranca() + "', " + painelDAO.getChave() + ", " + painelDAO.getAlarme() + " )";
                    if (DAO.ConexaoPG.getInstancia().persistir(sql3))
                    {
                        String sql4 = "INSERT INTO reservacao(op, reservacao, quantidade, automatizar, altura_1, coluna_1, tipo_1, modelo_1, material_1, sensor_1, infra_1, colar_1, colarTamanho_1, offset_1, distanciaInfra_1, externa_1, enterrada_1, trvEnterrada_1, altura_2, coluna_2, tipo_2, modelo_2, material_2, sensor_2, infra_2, colar_2, colarTamanho_2, offset_2, distanciaInfra_2, externa_2, enterrada_2, trvEnterrada_2)";
                        sql4 += "VALUES(" + op + ", " + reservacaoDAO.getReservacao() + ", " + reservacaoDAO.getQuantidade() + ", " + reservacaoDAO.getAutomatizar();
                        sql4 += ", '" + reservacaoDAO.getAltura_1() + "', '" + reservacaoDAO.getColuna_1() + "', " + reservacaoDAO.getTipo_1() + ", " + reservacaoDAO.getModelo_1() + ", " + reservacaoDAO.getMaterial_1() + ", " + reservacaoDAO.getSensor_1() + ", " + reservacaoDAO.getInfra_1() + ", " + reservacaoDAO.getColar_1() + ", " + reservacaoDAO.getColarTamanho_1().ToString().Replace(",", ".") + ", " + reservacaoDAO.getOffset_1().ToString().Replace(",", ".") + ", '" + reservacaoDAO.getDistanciaInfra_1() + "', '" + reservacaoDAO.getExterna_1() + "', '" + reservacaoDAO.getEnterrada_1() + "', " + reservacaoDAO.getTrvEnterrada_1();
                        sql4 += ", '" + reservacaoDAO.getAltura_2() + "', '" + reservacaoDAO.getColuna_2() + "', " + reservacaoDAO.getTipo_2() + ", " + reservacaoDAO.getModelo_2() + ", " + reservacaoDAO.getMaterial_2() + ", " + reservacaoDAO.getSensor_2() + ", " + reservacaoDAO.getInfra_2() + ", " + reservacaoDAO.getColar_2() + ", " + reservacaoDAO.getColarTamanho_2().ToString().Replace(",", ".") + ", " + reservacaoDAO.getOffset_2().ToString().Replace(",", ".") + ", '" + reservacaoDAO.getDistanciaInfra_2() + "', '" + reservacaoDAO.getExterna_2() + "', '" + reservacaoDAO.getEnterrada_2() + "', " + reservacaoDAO.getTrvEnterrada_2() + ")";
                        if (DAO.ConexaoPG.getInstancia().persistir(sql4))
                        {
                            String sql5 = "INSERT INTO vazao(op, vazao, quantidade, tipoSensor_1, tipoLocal_1, infra_1, diametro_1, tubo_1, pito_1, garganta_1, altura_1, vzMaxima_1, distanciaInfra_1, externa_1, enterrada_1, trvEnterrada_1, tipoSensor_2, tipoLocal_2, infra_2, diametro_2, tubo_2, pito_2, garganta_2, altura_2, vzMaxima_2, distanciaInfra_2, externa_2, enterrada_2, trvEnterrada_2, ";
                            sql5 += "tipoSensor_3, tipoLocal_3, infra_3, diametro_3, tubo_3, pito_3, garganta_3, altura_3, vzMaxima_3, distanciaInfra_3, externa_3, enterrada_3, trvEnterrada_3, tipoSensor_4, tipoLocal_4, infra_4, diametro_4, tubo_4, pito_4, garganta_4, altura_4, vzMaxima_4, distanciaInfra_4, externa_4, enterrada_4, trvEnterrada_4) VALUES(" + op + ", " + vazaoDAO.getVazao() + ", " + vazaoDAO.getQuantidade();
                            sql5 += ", " + vazaoDAO.getTipoSensor_1() + ", " + vazaoDAO.getTipoLocal_1() + ", " + vazaoDAO.getInfra_1() + ", '" + vazaoDAO.getDiametro_1() + "', '" + vazaoDAO.getTubo_1() + ", " + vazaoDAO.getPito_1() + ", " + vazaoDAO.getGarganta_1() + ", " + vazaoDAO.getAltura_1() + ", " + vazaoDAO.getVzMaxima_1() + ", '" + vazaoDAO.getDistanciaInfra_1() + "', '" + vazaoDAO.getExterna_1() + "', '" + vazaoDAO.getEnterrada_1() + "', " + vazaoDAO.getTrvEnterrada_1();
                            sql5 += ", " + vazaoDAO.getTipoSensor_2() + ", " + vazaoDAO.getTipoLocal_2() + ", " + vazaoDAO.getInfra_2() + ", '" + vazaoDAO.getDiametro_2() + "', '" + vazaoDAO.getTubo_2() + ", " + vazaoDAO.getPito_2() + ", " + vazaoDAO.getGarganta_2() + ", " + vazaoDAO.getAltura_2() + ", " + vazaoDAO.getVzMaxima_2() + ", '" + vazaoDAO.getDistanciaInfra_2() + "', '" + vazaoDAO.getExterna_2() + "', '" + vazaoDAO.getEnterrada_2() + "', " + vazaoDAO.getTrvEnterrada_2();
                            sql5 += ", " + vazaoDAO.getTipoSensor_3() + ", " + vazaoDAO.getTipoLocal_3() + ", " + vazaoDAO.getInfra_3() + ", '" + vazaoDAO.getDiametro_3() + "', '" + vazaoDAO.getTubo_3() + ", " + vazaoDAO.getPito_3() + ", " + vazaoDAO.getGarganta_3() + ", " + vazaoDAO.getAltura_3() + ", " + vazaoDAO.getVzMaxima_3() + ", '" + vazaoDAO.getDistanciaInfra_3() + "', '" + vazaoDAO.getExterna_3() + "', '" + vazaoDAO.getEnterrada_3() + "', " + vazaoDAO.getTrvEnterrada_3();
                            sql5 += ", " + vazaoDAO.getTipoSensor_4() + ", " + vazaoDAO.getTipoLocal_4() + ", " + vazaoDAO.getInfra_4() + ", '" + vazaoDAO.getDiametro_4() + "', '" + vazaoDAO.getTubo_4() + ", " + vazaoDAO.getPito_4() + ", " + vazaoDAO.getGarganta_4() + ", " + vazaoDAO.getAltura_4() + ", " + vazaoDAO.getVzMaxima_4() + ", '" + vazaoDAO.getDistanciaInfra_4() + "', '" + vazaoDAO.getExterna_4() + "', '" + vazaoDAO.getEnterrada_4() + "', " + vazaoDAO.getTrvEnterrada_4() + ")";
                            if (DAO.ConexaoPG.getInstancia().persistir(sql5))
                            {
                                String sql6 = "INSERT INTO pressao(op, pressao, quantidade, diametro_1, prRede_1, tipoTubo_1, colar_1, infra_1, distanciaInfra_1, externa_1, enterrada_1, trvEnterrada_1, diametro_2, prRede_2, tipoTubo_2, colar_2, infra_2, distanciaInfra_2, externa_2, enterrada_2, trvEnterrada_2, diametro_3, prRede_3, tipoTubo_3, colar_3, infra_3, distanciaInfra_3, externa_3, enterrada_3, trvEnterrada_3)VALUES(" + op + ", " + pressaoDAO.getPressao() + ", " + pressaoDAO.getQuantidade();
                                sql6 += "," + pressaoDAO.getDiametro_1() + ", " + pressaoDAO.getPrRede_1() + "," + pressaoDAO.getTipoTubo_1() + "," + pressaoDAO.getColar_1() + ", " + pressaoDAO.getInfra_1() + ", " + pressaoDAO.getDistanciaInfra_1() + ", " + pressaoDAO.getExterna_1() + ", " + pressaoDAO.getEnterrada_1() + ", " + pressaoDAO.getTrvEnterrada_1();
                                sql6 += "," + pressaoDAO.getDiametro_2() + ", " + pressaoDAO.getPrRede_2() + "," + pressaoDAO.getTipoTubo_2() + "," + pressaoDAO.getColar_2() + ", " + pressaoDAO.getInfra_2() + ", " + pressaoDAO.getDistanciaInfra_2() + ", " + pressaoDAO.getExterna_2() + ", " + pressaoDAO.getEnterrada_2() + ", " + pressaoDAO.getTrvEnterrada_2();
                                sql6 += "," + pressaoDAO.getDiametro_3() + ", " + pressaoDAO.getPrRede_3() + "," + pressaoDAO.getTipoTubo_3() + "," + pressaoDAO.getColar_3() + ", " + pressaoDAO.getInfra_3() + ", " + pressaoDAO.getDistanciaInfra_3() + ", " + pressaoDAO.getExterna_3() + ", " + pressaoDAO.getEnterrada_3() + ", " + pressaoDAO.getTrvEnterrada_3() + ")";
                                if (DAO.ConexaoPG.getInstancia().persistir(sql6))
                                {
                                    String sql7 = "INSERT INTO bombas(op, bombas, qtdBombas, multimedidor, qtdMultimedidor, tc, qtdTc, acionamento_1, intervencao_1, infra_1, potencia_1, modelo_1, distanciaInfra_1, externa_1, enterrada_1, trvEnterrada_1, acionamento_2, intervencao_2, infra_2, potencia_2, modelo_2, distanciaInfra_2, externa_2, enterrada_2, trvEnterrada_2, acionamento_3, intervencao_3, infra_3, potencia_3, modelo_3, distanciaInfra_3, externa_3, enterrada_3, trvEnterrada_3, ";
                                    sql7 += "acionamento_4, intervencao_4, infra_4, potencia_4, modelo_4, distanciaInfra_4, externa_4, enterrada_4, trvEnterrada_4, acionamento_5, intervencao_5, infra_5, potencia_5, modelo_5, distanciaInfra_5, externa_5, enterrada_5, trvEnterrada_5, acionamento_6, intervencao_6, infra_6, potencia_6, modelo_6, distanciaInfra_6, externa_6, enterrada_6, trvEnterrada_6)";
                                    sql7 += "VALUES(" + op + ", " + bombaDAO.getBombas() + ", " + bombaDAO.getQtdBombas() + ", " + bombaDAO.getMultimedidor() + ", " + bombaDAO.getQtdMultimedidor() + ", " + bombaDAO.getTc() + ", " + bombaDAO.getQtdTc();
                                    sql7 += "," + bombaDAO.getAcionamento_1() + ", " + bombaDAO.getIntervencao_1() + ", " + bombaDAO.getInfra_1() + ", '" + bombaDAO.getPotencia_1() + "', '" + bombaDAO.getModelo_1() + "', '" + bombaDAO.getDistanciaInfra_1() + "', '" + bombaDAO.getExterna_1() + "', '" + bombaDAO.getEnterrada_1() + "', " + bombaDAO.getTrvEnterrada_1();
                                    sql7 += "," + bombaDAO.getAcionamento_2() + ", " + bombaDAO.getIntervencao_2() + ", " + bombaDAO.getInfra_2() + ", '" + bombaDAO.getPotencia_2() + "', '" + bombaDAO.getModelo_2() + "', '" + bombaDAO.getDistanciaInfra_2() + "', '" + bombaDAO.getExterna_2() + "', '" + bombaDAO.getEnterrada_2() + "', " + bombaDAO.getTrvEnterrada_2();
                                    sql7 += "," + bombaDAO.getAcionamento_3() + ", " + bombaDAO.getIntervencao_3() + ", " + bombaDAO.getInfra_3() + ", '" + bombaDAO.getPotencia_3() + "', '" + bombaDAO.getModelo_3() + "', '" + bombaDAO.getDistanciaInfra_3() + "', '" + bombaDAO.getExterna_3() + "', '" + bombaDAO.getEnterrada_3() + "', " + bombaDAO.getTrvEnterrada_3();
                                    sql7 += "," + bombaDAO.getAcionamento_4() + ", " + bombaDAO.getIntervencao_4() + ", " + bombaDAO.getInfra_4() + ", '" + bombaDAO.getPotencia_4() + "', '" + bombaDAO.getModelo_4() + "', '" + bombaDAO.getDistanciaInfra_4() + "', '" + bombaDAO.getExterna_4() + "', '" + bombaDAO.getEnterrada_4() + "', " + bombaDAO.getTrvEnterrada_4();
                                    sql7 += "," + bombaDAO.getAcionamento_5() + ", " + bombaDAO.getIntervencao_5() + ", " + bombaDAO.getInfra_5() + ", '" + bombaDAO.getPotencia_5() + "', '" + bombaDAO.getModelo_5() + "', '" + bombaDAO.getDistanciaInfra_5() + "', '" + bombaDAO.getExterna_5() + "', '" + bombaDAO.getEnterrada_5() + "', " + bombaDAO.getTrvEnterrada_5();
                                    sql7 += "," + bombaDAO.getAcionamento_6() + ", " + bombaDAO.getIntervencao_6() + ", " + bombaDAO.getInfra_6() + ", '" + bombaDAO.getPotencia_6() + "', '" + bombaDAO.getModelo_6() + "', '" + bombaDAO.getDistanciaInfra_6() + "', '" + bombaDAO.getExterna_6() + "', '" + bombaDAO.getEnterrada_6() + "', " + bombaDAO.getTrvEnterrada_6() + ")";
                                    if (DAO.ConexaoPG.getInstancia().persistir(sql7))
                                    {
                                        String sql8 = "INSERT INTO dosadores(op, dosadores, dosagemCloro, analDigCloro, infraCloro, distanciaCloro, externaCloro, enterradaCloro, trvEnterradaCloro, dosagemFluor, analDigFluor, infraFluor, distanciaFluor, externaFluor, enterradaFluor, trvEnterradaFluor) VALUES(" + op + ", " + dosadorDAO.getDosadores();
                                        sql8 += ", '" + dosadorDAO.getDosagemCloro() + "', " + dosadorDAO.getAnalDigCloro() + ", " + dosadorDAO.getInfraCloro() + ", '" + dosadorDAO.getDistanciaCloro() + "', '" + dosadorDAO.getExternaCloro() + "', '" + dosadorDAO.getEnterradaCloro() + "', " + dosadorDAO.getTrvEnterradaCloro();
                                        sql8 += ", '" + dosadorDAO.getDosagemFluor() + "', " + dosadorDAO.getAnalDigFluor() + ", " + dosadorDAO.getInfraFluor() + ", '" + dosadorDAO.getDistanciaFluor() + "', '" + dosadorDAO.getExternaFluor() + "', '" + dosadorDAO.getEnterradaFluor() + "', " + dosadorDAO.getTrvEnterradaFluor() + ")";
                                        aux = DAO.ConexaoPG.getInstancia().persistir(sql8);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return aux;
        }
    }
}
