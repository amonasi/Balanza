using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Balanza.Configs;
using Balanza.Bean;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;

namespace Balanza.Configs
{
    class DAL
    {
        SQLiteFramework sqlFrame;
        Logger log;
        String sql = String.Empty;
        Security seguridad;

        public const String SEG_USU = "U";
        public const String SEG_ADM = "A";

        public DAL() {
            sqlFrame = new SQLiteFramework();
            log = new Logger();
            seguridad = new Security();
        }

        public String obtenerParametro(String codigo) {
            String parametro = String.Empty;
            try
            {
                sql = "SELECT VALOR FROM PARAMETROS WHERE CODIGO='"+codigo+"';";
                parametro = sqlFrame.obtenerEscalar(sql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerParametro: "+e.Message);
            }
            finally {

            }
            return parametro;
        }

        public DataTable obtenerListaTipoSacos(bool activo)
        {
            DataTable tabla = new DataTable();
            try
            {
                if (activo) { 
                    sql = "SELECT TIPO_SACO,PESO,CASE ES_NEGATIVO WHEN 'S' THEN 'True' ELSE 'False' END ES_NEGATIVO,CASE ESTADO WHEN 'A' THEN 'True' ELSE 'False' END ESTADO FROM TIPO_SACO WHERE ESTADO='A';";
                }
                else
                {
                    sql = "SELECT TIPO_SACO,PESO,CASE ES_NEGATIVO WHEN 'S' THEN 'True' ELSE 'False' END ES_NEGATIVO,CASE ESTADO WHEN 'A' THEN 'True' ELSE 'False' END ESTADO FROM TIPO_SACO;";
                }
                tabla = sqlFrame.obtenerConsulta(sql);

            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerListaTipoSacos: " + e.Message);
            }
            finally
            {

            }
            return tabla;
        }

        public List<ParametroBean> obtenerListaParametros()
        {
            DataTable tabla = new DataTable();
            ParametroBean bean;
            List<ParametroBean> lista=new List<ParametroBean>();
            try
            {
                sql = "SELECT CODIGO,VALOR FROM PARAMETROS;";
                tabla=sqlFrame.obtenerConsulta(sql);

                if (tabla != null) {
                    if (tabla.Rows.Count > 0) {
                        foreach(DataRow dr in tabla.Rows) {
                            bean = new ParametroBean();
                            bean.CODIGO=dr[0].ToString();
                            bean.VALOR = dr[1].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerListaParametros: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        public bool actualizarParametros(List<ParametroBean> parametros) {
            bool resultado = false;
            try
            {
                foreach(ParametroBean p in parametros)
                {
                    sql = "UPDATE PARAMETROS SET VALOR='"+p.VALOR+"' WHERE CODIGO='"+p.CODIGO+"';";
                    resultado=sqlFrame.ejecutarSentencia(sql);
                    if (!resultado)
                    {
                        return false;
                    }
                }
                resultado = true;
            }
            catch (Exception e)
            {
                log.LogMessage("Error actualizarParametros: " + e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        public BalanzaBean obtenerBalanza()
        {
            BalanzaBean balanza = new BalanzaBean();
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT COD_BALANZA,TAM_TRAMA,CAR_INI_TRA,CAR_EST_BAL,POS_INI_CEB,POS_FIN_CEB,POS_INI_PESO_ST,POS_FIN_PESO_ST,POS_INI_PESO_CT,POS_FIN_PESO_CT,ESTADO,BAL_DEFAULT,POS_DEC FROM CONF_BALANZA WHERE BAL_DEFAULT='S';";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        DataRow dr = tabla.Rows[0];
                        balanza = new BalanzaBean();
                        balanza.COD_BALANZA = dr[0].ToString();
                        balanza.TAM_TRAMA = int.Parse(dr[1].ToString());
                        balanza.CAR_INI_TRA = dr[2].ToString();
                        balanza.CAR_EST_BAL = dr[3].ToString();
                        balanza.POS_INI_CEB = int.Parse(dr[4].ToString());
                        balanza.POS_FIN_CEB = int.Parse(dr[5].ToString());
                        balanza.POS_INI_PESO_ST = int.Parse(dr[6].ToString());
                        balanza.POS_FIN_PESO_ST = int.Parse(dr[7].ToString());
                        balanza.POS_INI_PESO_CT = int.Parse(dr[8].ToString());
                        balanza.POS_FIN_PESO_CT = int.Parse(dr[9].ToString());
                        balanza.ESTADO = dr[10].ToString();
                        balanza.BAL_DEFAULT = dr[11].ToString();
                        balanza.POS_DEC = int.Parse(dr[12].ToString());
                    }
                }

            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerBalanza: " + e.Message);
            }
            finally
            {

            }
            return balanza;
        }

        public List<BalanzaBean> obtenerTodasBalanzas()
        {
            List<BalanzaBean> lista = new List<BalanzaBean>();
            BalanzaBean balanza = new BalanzaBean();
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT COD_BALANZA,TAM_TRAMA,CAR_INI_TRA,CAR_EST_BAL,POS_INI_CEB,POS_FIN_CEB,POS_INI_PESO_ST,POS_FIN_PESO_ST,POS_INI_PESO_CT,POS_FIN_PESO_CT,ESTADO,BAL_DEFAULT FROM CONF_BALANZA;";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {

                            balanza = new BalanzaBean();
                            balanza.COD_BALANZA = dr[0].ToString();
                            balanza.TAM_TRAMA = int.Parse(dr[1].ToString());
                            balanza.CAR_INI_TRA = dr[2].ToString();
                            balanza.CAR_EST_BAL = dr[3].ToString();
                            balanza.POS_INI_CEB = int.Parse(dr[4].ToString());
                            balanza.POS_FIN_CEB = int.Parse(dr[5].ToString());
                            balanza.POS_INI_PESO_ST = int.Parse(dr[6].ToString());
                            balanza.POS_FIN_PESO_ST = int.Parse(dr[7].ToString());
                            balanza.POS_INI_PESO_CT = int.Parse(dr[8].ToString());
                            balanza.POS_FIN_PESO_CT = int.Parse(dr[9].ToString());
                            balanza.ESTADO = dr[10].ToString();
                            balanza.BAL_DEFAULT = dr[11].ToString();
                            lista.Add(balanza);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerTodasBalanzas: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        public DataTable obtenerBalanzas()
        {
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT COD_BALANZA,TAM_TRAMA,CAR_INI_TRA,CAR_EST_BAL,POS_INI_CEB,POS_FIN_CEB,POS_INI_PESO_ST,POS_FIN_PESO_ST,POS_INI_PESO_CT,POS_FIN_PESO_CT,CASE ESTADO WHEN 'A' THEN 'True' ELSE 'False' END ESTADO,CASE BAL_DEFAULT WHEN 'S' THEN 'True' ELSE 'False' END BAL_DEFAULT,POS_DEC FROM CONF_BALANZA;";
                tabla = sqlFrame.obtenerConsulta(sql);
                return tabla;
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerBalanzas: " + e.Message);
            }
            finally
            {

            }
            return tabla;
        }

        public DataTable obtenerDetalleGrupo(String codGrupo)
        {
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT CODGRUPO, VALOR,CASE VALOR_DEFECTO WHEN 'S' THEN 'True' ELSE 'False' END VALOR_DEFECTO,CASE ESTADO WHEN 'A' THEN 'True' ELSE 'False' END ESTADO FROM DETALLE_GRUPO WHERE CODGRUPO="+codGrupo+";";
                tabla = sqlFrame.obtenerConsulta(sql);
                return tabla;
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerDetalleGrupo: " + e.Message);
            }
            finally
            {

            }
            return tabla;
        }

        public bool actualizarBalanzas(List<BalanzaBean> lista)
        {
            bool resultado = false;
            String sql = String.Empty;
            List<String> lisSQL = new List<String>();
            try
            {
                foreach(BalanzaBean b in lista)
                {
                    sql = "UPDATE CONF_BALANZA SET TAM_TRAMA="+b.TAM_TRAMA+", CAR_INI_TRA='" + b.CAR_INI_TRA+"', CAR_EST_BAL='"+b.CAR_EST_BAL+ "', POS_INI_CEB="+b.POS_INI_CEB+", POS_FIN_CEB="+b.POS_FIN_CEB+", POS_INI_PESO_ST="+b.POS_INI_PESO_ST+", POS_FIN_PESO_ST="+b.POS_FIN_PESO_ST+", POS_INI_PESO_CT="+b.POS_INI_PESO_CT+", POS_FIN_PESO_CT="+b.POS_FIN_PESO_CT+", ESTADO='"+b.ESTADO+"', BAL_DEFAULT='"+b.BAL_DEFAULT+ "', POS_DEC=" + b.POS_DEC + " WHERE COD_BALANZA='" + b.COD_BALANZA+"';";
                    lisSQL.Add(sql);
                }
                resultado = sqlFrame.ejecutarTransaccion(lisSQL);

                if (!resultado)
                {
                    throw new Exception(sqlFrame.ultimoError());
                }
            }
            catch(Exception e)
            {
                log.LogMessage("Error actualizarBalanzas: "+e.Message+" sql: "+sql);
            }
            return resultado;
        }

        public GrupoBean obtenerGrupo(String codGrupo)
        {
            GrupoBean grupo = new GrupoBean();
            DataTable tabla = new DataTable();
            DataTable tablaDetalle = new DataTable();

            try
            {
                sql = "SELECT CODGRUPO,DESGRUPO,ESTADO,EDITABLE FROM GRUPO WHERE ESTADO='A' AND CODGRUPO='" + codGrupo + "';";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        DataRow dr = tabla.Rows[0];
                        grupo = new GrupoBean();
                        grupo.CODGRUPO = dr[0].ToString();
                        grupo.DESGRUPO = dr[1].ToString();
                        grupo.ESTADO = dr[2].ToString();
                        grupo.EDITABLE = dr[3].ToString();

                        sql = "SELECT CODGRUPO,VALOR,VALOR_DEFECTO,ESTADO FROM DETALLE_GRUPO WHERE ESTADO='A' AND CODGRUPO='" + codGrupo + "';";
                        tablaDetalle = sqlFrame.obtenerConsulta(sql);

                        if (tablaDetalle != null)
                        {
                            if (tablaDetalle.Rows.Count > 0)
                            {
                                foreach(DataRow drdg in tablaDetalle.Rows) { 
                                    DetalleGrupoBean detalle = new DetalleGrupoBean();
                                    detalle.CODGRUPO = drdg[0].ToString();
                                    detalle.VALOR = drdg[1].ToString();
                                    detalle.VALOR_DEFECTO = drdg[2].ToString();
                                    detalle.ESTADO = drdg[3].ToString();
                                    grupo.DETALLE.Add(detalle);
                                }
                            }
                        }

                    }
                }

            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerGrupo: " + e.Message);
            }
            finally
            {

            }
            return grupo;
        }

        public List<GrupoBean> obtenerListaGrupos(bool todos)
        {
            List<GrupoBean> lista = new List<GrupoBean>();
            GrupoBean grupo = new GrupoBean();
            DataTable tabla = new DataTable();
            DataTable tablaDetalle = new DataTable();

            try
            {
                if (todos)
                {
                    sql = "SELECT CODGRUPO,DESGRUPO,ESTADO,EDITABLE FROM GRUPO;";
                }
                else
                {
                    sql = "SELECT CODGRUPO,DESGRUPO,ESTADO,EDITABLE FROM GRUPO WHERE ESTADO='A';";
                }
                
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    foreach(DataRow dr in tabla.Rows)
                    {
                        grupo = new GrupoBean();
                        grupo.CODGRUPO = dr[0].ToString();
                        grupo.DESGRUPO = dr[1].ToString();
                        grupo.ESTADO = dr[2].ToString();
                        grupo.EDITABLE = dr[3].ToString();

                        sql = "SELECT CODGRUPO,VALOR,VALOR_DEFECTO,ESTADO FROM DETALLE_GRUPO WHERE ESTADO='A' AND CODGRUPO='"+ grupo.CODGRUPO + "';";
                        tablaDetalle = sqlFrame.obtenerConsulta(sql);

                        if (tablaDetalle != null)
                        {
                            if (tablaDetalle.Rows.Count > 0)
                            {
                                foreach (DataRow drdg in tablaDetalle.Rows)
                                {
                                    DetalleGrupoBean detalle = new DetalleGrupoBean();
                                    detalle.CODGRUPO = drdg[0].ToString();
                                    detalle.VALOR = drdg[1].ToString();
                                    detalle.VALOR_DEFECTO = drdg[2].ToString();
                                    detalle.ESTADO = drdg[3].ToString();
                                    grupo.DETALLE.Add(detalle);
                                }
                            }
                        }
                        lista.Add(grupo);
                    }
                }

            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerListaGrupos: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        public DataTable obtenerListaGrupos()
        {
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT CODGRUPO,DESGRUPO FROM GRUPO WHERE ESTADO = 'A' UNION SELECT 0,'---' ;";
                tabla = sqlFrame.obtenerConsulta(sql);
                return tabla;
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerListaGrupos: " + e.Message);
            }
            finally
            {

            }
            return tabla;
        }

        public bool eliminarDetalleGrupo(String codGrupo,String valor) {
            bool resultado = false;
            try
            {
                sql = "DELETE FROM DETALLE_GRUPO WHERE CODGRUPO='" + codGrupo + "' AND VALOR='"+valor+"';";
                resultado = sqlFrame.ejecutarSentencia(sql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error eliminarDetalleGrupo: " + codGrupo + " " + valor+ e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        public bool eliminarDetalleGrupo(String codGrupo)
        {
            bool resultado = false;
            try
            {
                sql = "DELETE FROM DETALLE_GRUPO WHERE CODGRUPO='" + codGrupo + "';";
                resultado = sqlFrame.ejecutarSentencia(sql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error eliminarDetalleGrupo: "+ codGrupo+" " + e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        public bool insertarDetalleGrupo(DetalleGrupoBean grupo)
        {
            bool resultado = false;
            try
            {
                resultado = eliminarDetalleGrupo(grupo.CODGRUPO, grupo.VALOR);

                if (!resultado) {
                    return false;
                }

                sql = "INSERT INTO DETALLE_GRUPO(CODGRUPO,VALOR,VALOR_DEFECTO,ESTADO) VALUES('" + grupo.CODGRUPO + "','" + grupo.VALOR + "','" + grupo.VALOR_DEFECTO + "','" + grupo.ESTADO + "');";
                resultado = sqlFrame.ejecutarSentencia(sql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error insertarDetalleGrupo: " + grupo.CODGRUPO + " " + grupo.VALOR + e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        public bool actualizarGrupo(GrupoBean grupo)
        {
            bool resultado = false;
            try
            {
                sql = "UPDATE GRUPO SET DESGRUPO='" + grupo.DESGRUPO + "',EDITABLE='" + grupo.EDITABLE + "',ESTADO='" + grupo.ESTADO + "' WHERE CODGRUPO='" + grupo.CODGRUPO + "';";
                resultado = sqlFrame.ejecutarSentencia(sql);

                if (!resultado) {
                    return false;
                }

                resultado = eliminarDetalleGrupo(grupo.CODGRUPO);

                foreach (DetalleGrupoBean dg in grupo.DETALLE) {
                    resultado = insertarDetalleGrupo(dg);
                    if (!resultado)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error actualizarGrupo: " + grupo.CODGRUPO + " Detalle: " + grupo.DETALLE.Count + e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        public bool eliminarNotaPeso(Int64 id)
        {
            bool resultado = false;
            try
            {
                sql = "DELETE FROM DETALLE_NOTA_PESO WHERE ID_PESO='" + id + "';";
                resultado = sqlFrame.ejecutarSentencia(sql);

                if (!resultado)
                {
                    return false;
                }

                sql = "DELETE FROM NOTA_PESO WHERE ID_PESO='" + id + "';";
                resultado = sqlFrame.ejecutarSentencia(sql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error eliminarNotaPeso: " + id + " " + e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        public bool actualizarIDCentralNotaPeso(Int64 id,String IDCentral)
        {
            bool resultado = false;
            try
            {
                sql = "UPDATE NOTA_PESO SET ID_CENTRAL='"+ IDCentral + "' WHERE ID_PESO='" + id + "';";
                resultado = sqlFrame.ejecutarSentencia(sql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error actualizarIDCentralNotaPeso: " + id + " " + e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        private List<NotaPesoBean> obtenerNotasPeso()
        {
            DataTable tabla = new DataTable();
            NotaPesoBean bean;
            List<NotaPesoBean> lista = new List<NotaPesoBean>();
            try
            {
                sql = "SELECT ID_PESO,TIPO_GRANO,FEC_REG_OPE,CIUDAD,CANT_SACOS,NUM_TICKET,DNI_OPERADOR,DNI_PRODUCTOR,TOTAL_PESO_BRUTO,TOTAL_PESO_NETO,REPORTADO_CENTRAL,EMPRESA,ID_BALANZA FROM NOTA_PESO;";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new NotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.TIPO_GRANO = dr[1].ToString();
                            bean.FEC_REG_OPE = dr[2].ToString();
                            bean.CIUDAD = dr[3].ToString();
                            bean.CANT_SACOS = int.Parse(dr[4].ToString());
                            bean.NUM_TICKET = dr[5].ToString();
                            bean.DOC_OPERADOR = dr[6].ToString();
                            bean.DOC_PRODUCTOR = dr[7].ToString();
                            bean.TOTAL_PESO_BRUTO = float.Parse(dr[8].ToString());
                            bean.TOTAL_PESO_NETO = float.Parse(dr[9].ToString());
                            bean.REPORTADO_CENTRAL = dr[10].ToString();
                            bean.EMPRESA = dr[11].ToString();
                            bean.ID_BALANZA = dr[12].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerNotasPeso: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        //Recupera solo 1 -- Cuerpo
        private List<DetalleNotaPesoBean> obtenerDetalleNotaPeso(int ID)
        {
            DataTable tabla = new DataTable();
            DetalleNotaPesoBean bean;
            List<DetalleNotaPesoBean> lista = new List<DetalleNotaPesoBean>();
            try
            {
                sql = "SELECT ID_PESO,SECUENCIA,TIPO_SACO,CANTIDAD,PESO_BRUTO_SACO,PESO_NETO_SACO,PESO_ESTABLE FROM DETALLE_NOTA_PESO WHERE ID_PESO="+ID+";";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new DetalleNotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.SECUENCIA = int.Parse(dr[1].ToString());
                            bean.TIPO_SACO = dr[2].ToString();
                            bean.CANTIDAD = int.Parse(dr[3].ToString());
                            bean.PESO_BRUTO_SACO = float.Parse(dr[4].ToString());
                            bean.PESO_NETO_SACO = float.Parse(dr[5].ToString());
                            bean.PESO_ESTABLE = dr[6].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerDetalleNotasPeso: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        //Recupera solo 1 -- Cabecera
        public NotaPesoBean obtenerNotaPeso(int ID)
        {
            DataTable tabla = new DataTable();
            NotaPesoBean bean=new NotaPesoBean();
            try
            {
                sql = "SELECT ID_PESO,TIPO_GRANO,FEC_REG_OPE,CIUDAD,CANT_SACOS,NUM_TICKET,DNI_OPERADOR,DNI_PRODUCTOR,TOTAL_PESO_BRUTO,TOTAL_PESO_NETO,REPORTADO_CENTRAL,EMPRESA,ID_BALANZA FROM NOTA_PESO WHERE ID_PESO="+ID+";";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new NotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.TIPO_GRANO = dr[1].ToString();
                            bean.FEC_REG_OPE = dr[2].ToString();
                            bean.CIUDAD = dr[3].ToString();
                            bean.CANT_SACOS = int.Parse(dr[4].ToString());
                            bean.NUM_TICKET = dr[5].ToString();
                            bean.DOC_OPERADOR = dr[6].ToString();
                            bean.DOC_PRODUCTOR = dr[7].ToString();
                            bean.TOTAL_PESO_BRUTO = float.Parse(dr[8].ToString());
                            bean.TOTAL_PESO_NETO = float.Parse(dr[9].ToString());
                            bean.REPORTADO_CENTRAL = dr[10].ToString();
                            bean.EMPRESA = dr[11].ToString();
                            bean.ID_BALANZA = dr[12].ToString();
                            bean.DETALLE = obtenerDetalleNotaPeso(bean.ID_PESO);
                            bean.CALIDAD = obtenerCalidadNotaPeso(bean.ID_PESO);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerNotaPeso: " + e.Message);
            }
            finally
            {

            }
            return bean;
        }

        private List<DetalleNotaPesoBean> obtenerDetalleNotasPeso()
        {
            DataTable tabla = new DataTable();
            DetalleNotaPesoBean bean;
            List<DetalleNotaPesoBean> lista = new List<DetalleNotaPesoBean>();
            try
            {
                sql = "SELECT ID_PESO,SECUENCIA,TIPO_SACO,CANTIDAD,PESO_BRUTO_SACO,PESO_NETO_SACO,PESO_ESTABLE FROM DETALLE_NOTA_PESO;";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new DetalleNotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.SECUENCIA = int.Parse(dr[1].ToString());
                            bean.TIPO_SACO = dr[2].ToString();
                            bean.CANTIDAD = int.Parse(dr[3].ToString());
                            bean.PESO_BRUTO_SACO = float.Parse(dr[4].ToString());
                            bean.PESO_NETO_SACO = float.Parse(dr[5].ToString());
                            bean.PESO_ESTABLE = dr[6].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerDetalleNotasPeso: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        public List<NotaPesoBean> obtenerNotasCompletas() {
            DataTable tabla = new DataTable();
            NotaPesoBean bean;
            List<NotaPesoBean> lista = new List<NotaPesoBean>();
            List<DetalleNotaPesoBean> listaDetalle = new List<DetalleNotaPesoBean>();

            try
            {
                lista = obtenerNotasPeso();
                listaDetalle = obtenerDetalleNotasPeso();

                foreach (NotaPesoBean n in lista) {
                        n.DETALLE=listaDetalle.FindAll(x => x.ID_PESO == n.ID_PESO);
                        n.CALIDAD = obtenerCalidadNotaPeso(n.ID_PESO);
                }  
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerNotasCompletas: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        //Consulta por Fecha
        public List<NotaPesoBean> obtenerNotasFecha(String fecIni, String fecFin)
        {
            DataTable tabla = new DataTable();
            NotaPesoBean bean;
            List<NotaPesoBean> lista = new List<NotaPesoBean>();
            List<DetalleNotaPesoBean> listaDetalle = new List<DetalleNotaPesoBean>();

            try
            {
                lista = obtenerNotasPesoFecha(fecIni,fecFin);
                listaDetalle = obtenerDetalleNotasPesoFecha(fecIni,fecFin);

                foreach (NotaPesoBean n in lista)
                {
                    n.DETALLE = listaDetalle.FindAll(x => x.ID_PESO == n.ID_PESO);
                    n.CALIDAD = obtenerCalidadNotaPeso(n.ID_PESO);
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerNotasFecha: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        private List<NotaPesoBean> obtenerNotasPesoFecha(String fecIni, String fecFin)
        {
            DataTable tabla = new DataTable();
            NotaPesoBean bean;
            List<NotaPesoBean> lista = new List<NotaPesoBean>();
            try
            {
                sql = "SELECT ID_PESO,TIPO_GRANO,FEC_REG_OPE,CIUDAD,CANT_SACOS,NUM_TICKET,DNI_OPERADOR,DNI_PRODUCTOR,TOTAL_PESO_BRUTO,TOTAL_PESO_NETO,REPORTADO_CENTRAL,EMPRESA,ID_BALANZA FROM NOTA_PESO WHERE FEC_REG_OPE BETWEEN '" + fecIni + "' AND '" + fecFin + "';";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new NotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.TIPO_GRANO = dr[1].ToString();
                            bean.FEC_REG_OPE = dr[2].ToString();
                            bean.CIUDAD = dr[3].ToString();
                            bean.CANT_SACOS = int.Parse(dr[4].ToString());
                            bean.NUM_TICKET = dr[5].ToString();
                            bean.DOC_OPERADOR = dr[6].ToString();
                            bean.DOC_PRODUCTOR = dr[7].ToString();
                            bean.TOTAL_PESO_BRUTO = float.Parse(dr[8].ToString());
                            bean.TOTAL_PESO_NETO = float.Parse(dr[9].ToString());
                            bean.REPORTADO_CENTRAL = dr[10].ToString();
                            bean.EMPRESA = dr[11].ToString();
                            bean.ID_BALANZA = dr[12].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerNotasPesoFecha: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        private List<DetalleNotaPesoBean> obtenerDetalleNotasPesoFecha(String fecIni, String fecFin)
        {
            DataTable tabla = new DataTable();
            DetalleNotaPesoBean bean;
            List<DetalleNotaPesoBean> lista = new List<DetalleNotaPesoBean>();
            try
            {
                sql = "SELECT NP.ID_PESO,SECUENCIA,TIPO_SACO,CANTIDAD,PESO_BRUTO_SACO,PESO_NETO_SACO,PESO_ESTABLE FROM DETALLE_NOTA_PESO DNP, NOTA_PESO NP WHERE NP.ID_PESO=DNP.ID_PESO AND FEC_REG_OPE BETWEEN '"+fecIni+"' AND '"+fecFin+"';";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new DetalleNotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.SECUENCIA = int.Parse(dr[1].ToString());
                            bean.TIPO_SACO = dr[2].ToString();
                            bean.CANTIDAD = int.Parse(dr[3].ToString());
                            bean.PESO_BRUTO_SACO = float.Parse(dr[4].ToString());
                            bean.PESO_NETO_SACO = float.Parse(dr[5].ToString());
                            bean.PESO_ESTABLE = dr[6].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerDetalleNotasPesoFecha: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        //Consulta por ID

        public List<NotaPesoBean> obtenerNotasID(String ID)
        {
            DataTable tabla = new DataTable();
            NotaPesoBean bean;
            List<NotaPesoBean> lista = new List<NotaPesoBean>();
            List<DetalleNotaPesoBean> listaDetalle = new List<DetalleNotaPesoBean>();

            try
            {
                lista = obtenerNotasPesoID(ID);
                listaDetalle = obtenerDetalleNotasPesoID(ID);

                foreach (NotaPesoBean n in lista)
                {
                    n.DETALLE = listaDetalle.FindAll(x => x.ID_PESO == n.ID_PESO);
                    n.CALIDAD = obtenerCalidadNotaPeso(n.ID_PESO);
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerNotasID: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        private List<NotaPesoBean> obtenerNotasPesoID(String ID)
        {
            DataTable tabla = new DataTable();
            NotaPesoBean bean;
            List<NotaPesoBean> lista = new List<NotaPesoBean>();
            try
            {
                sql = "SELECT ID_PESO,TIPO_GRANO,FEC_REG_OPE,CIUDAD,CANT_SACOS,NUM_TICKET,DNI_OPERADOR,DNI_PRODUCTOR,TOTAL_PESO_BRUTO,TOTAL_PESO_NETO,REPORTADO_CENTRAL,EMPRESA,ID_BALANZA FROM NOTA_PESO WHERE ID_PESO = " + ID + ";";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new NotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.TIPO_GRANO = dr[1].ToString();
                            bean.FEC_REG_OPE = dr[2].ToString();
                            bean.CIUDAD = dr[3].ToString();
                            bean.CANT_SACOS = int.Parse(dr[4].ToString());
                            bean.NUM_TICKET = dr[5].ToString();
                            bean.DOC_OPERADOR = dr[6].ToString();
                            bean.DOC_PRODUCTOR = dr[7].ToString();
                            bean.TOTAL_PESO_BRUTO = float.Parse(dr[8].ToString());
                            bean.TOTAL_PESO_NETO = float.Parse(dr[9].ToString());
                            bean.REPORTADO_CENTRAL = dr[10].ToString();
                            bean.EMPRESA = dr[11].ToString();
                            bean.ID_BALANZA = dr[12].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerNotasPesoID: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        private List<DetalleNotaPesoBean> obtenerDetalleNotasPesoID(String ID)
        {
            DataTable tabla = new DataTable();
            DetalleNotaPesoBean bean;
            List<DetalleNotaPesoBean> lista = new List<DetalleNotaPesoBean>();
            try
            {
                sql = "SELECT NP.ID_PESO,SECUENCIA,TIPO_SACO,CANTIDAD,PESO_BRUTO_SACO,PESO_NETO_SACO,PESO_ESTABLE FROM DETALLE_NOTA_PESO DNP, NOTA_PESO NP WHERE NP.ID_PESO=DNP.ID_PESO AND NP.ID_PESO= " + ID + ";";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new DetalleNotaPesoBean();
                            bean.ID_PESO = int.Parse(dr[0].ToString());
                            bean.SECUENCIA = int.Parse(dr[1].ToString());
                            bean.TIPO_SACO = dr[2].ToString();
                            bean.CANTIDAD = int.Parse(dr[3].ToString());
                            bean.PESO_BRUTO_SACO = float.Parse(dr[4].ToString());
                            bean.PESO_NETO_SACO = float.Parse(dr[5].ToString());
                            bean.PESO_ESTABLE = dr[6].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerDetalleNotasPesoID: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        public bool insertarNotaPeso(ref NotaPesoBean nota)
        {
            bool resultado = false;
            List<String> lista = new List<String>();
            try
            {

                //Insertando cabecera
                sql = "INSERT INTO NOTA_PESO(TIPO_GRANO,FEC_REG_OPE,CIUDAD,CANT_SACOS,NUM_TICKET,DNI_OPERADOR,DNI_PRODUCTOR,TOTAL_PESO_BRUTO,TOTAL_PESO_NETO,REPORTADO_CENTRAL,ID_BALANZA,EMPRESA)" + 
                        "VALUES('"+nota.TIPO_GRANO+"','"+nota.FEC_REG_OPE+"','"+nota.CIUDAD + "',"+nota.CANT_SACOS + ",'"+nota.NUM_TICKET + "','"+nota.DOC_OPERADOR + "','"+nota.DOC_PRODUCTOR + "',"+nota.TOTAL_PESO_BRUTO + ","+nota.TOTAL_PESO_NETO + ",'"+nota.REPORTADO_CENTRAL+"','"+nota.ID_BALANZA+"','"+nota.EMPRESA+"')";

                lista.Add(sql);

                resultado = sqlFrame.ejecutarTransaccion(lista);

                obtenerUltimoID(ref nota.ID_PESO);

            }
            catch (Exception e)
            {
                log.LogMessage("Error insertarNotaPeso: " + e.Message);
            }
            return resultado;
        }

        public bool insertarDetalleNotaPeso(NotaPesoBean nota)
        {
            bool resultado = false;
            List<String> lista = new List<String>();
            try
            {
                //insertando detalle
                foreach (DetalleNotaPesoBean det in nota.DETALLE)
                {
                    sql = "INSERT INTO DETALLE_NOTA_PESO(ID_PESO,SECUENCIA, TIPO_SACO,CANTIDAD,PESO_BRUTO_SACO, PESO_NETO_SACO, PESO_ESTABLE)" +
                        "VALUES(" + det.ID_PESO + "," + det.SECUENCIA + ",'" + det.TIPO_SACO + "'," + det.CANTIDAD + "," + det.PESO_BRUTO_SACO + "," + det.PESO_NETO_SACO + ",'" + det.PESO_ESTABLE + "');";
                    lista.Add(sql);
                }

                resultado = sqlFrame.ejecutarTransaccion(lista);
            }
            catch (Exception e)
            {
                log.LogMessage("Error insertarDetalleNotaPeso: " + e.Message);
            }
            return resultado;
        }

        public bool insertarTipoSaco(List<String> lista)
        {
            bool resultado = false;
            try
            {
                resultado = sqlFrame.ejecutarTransaccion(lista);
            }
            catch (Exception e)
            {
                log.LogMessage("Error insertarTipoSaco: " + e.Message);
            }
            return resultado;
        }

        public bool obtenerUltimoID(ref int ID) {
            bool resultado = false;
            string entero = String.Empty;
            try
            {
                entero=sqlFrame.obtenerEscalar("SELECT MAX(ID_PESO) FROM NOTA_PESO");
                if (entero == String.Empty)
                {
                    ID = 0;
                }
                else
                {
                    ID = int.Parse(entero);
                }
                resultado = true;
            }
            catch (Exception e) {
                log.LogMessage("Error obtenerUltimoID: " + e.Message);
            }
            return resultado;
        }

        public bool licenciaValida(String licencia) {
            bool resultado = false;
            try
            {
                String valorActual = String.Empty;
                String lic = String.Empty;
                seguridad.SimpleEncrypt(sqlFrame.obtenerEscalar("SELECT strftime('%Y%m%d', date('now'))"), ref valorActual);
                seguridad.SimpleDecrypt(licencia, ref lic);
                seguridad.SimpleDecrypt(valorActual, ref valorActual);

                if (int.Parse(lic) < int.Parse(valorActual)) {
                    resultado = false;
                }

                resultado = true;
            }
            catch (Exception ex) {
                log.LogMessage("Error licenciaValida: " + ex.Message + "Lic: "+licencia);
            }
            return resultado;
        }

        public bool generarTicket(ref String ticket)
        {
            bool resultado=false;
            try
            {
                String anio=String.Empty;
                String loc=String.Empty;
                String secuencia=String.Empty;
                

                int temp, larCar;

                if (appConfig("anioNumTicket").Equals("1")) {
                    anio = sqlFrame.obtenerEscalar("SELECT strftime('%Y', date('now'))")+"-";
                }

                loc = obtenerParametro("ID_LOC");
                secuencia = obtenerParametro("SEC_TICKET");

                larCar = int.Parse(obtenerParametro("LAR_TICKET"));
                temp = int.Parse(secuencia);
                temp++;

                StringBuilder sb = new StringBuilder(larCar - secuencia.Length);
                ticket = anio + loc + '-' + sb.Insert(0, "0", larCar - secuencia.Length).ToString() + temp;
                log.LogMessage("Ticket Generado:" + ticket);
                resultado=true;
            }
            catch (Exception e)
            {
                log.LogMessage("generarTicket:" + e.Message);   
            }
            return resultado;
        }

        public bool nextTicket()
        {
            bool resultado = false;
            try
            {
                String secuencia = obtenerParametro("SEC_TICKET");
                int next = int.Parse(secuencia) + 1;
                resultado=sqlFrame.ejecutarSentencia("UPDATE PARAMETROS SET VALOR='"+next+"' WHERE CODIGO='SEC_TICKET';");
            }
            catch (Exception e)
            {
                log.LogMessage("nextTicket:" + e.Message);
            }
            return resultado;
        }

        private bool validarContraseña(String clave, String tipo)
        {
            bool resultado = false;

            try
            {
                Security seguridad = new Security();
                String encriptado = String.Empty;
                String valorConfig = String.Empty;
                seguridad.SimpleEncrypt(clave, ref encriptado);
                if (tipo.Equals(SEG_ADM))
                {
                    valorConfig=obtenerParametro("CLA_ADM");
                }
                if (tipo.Equals(SEG_USU))
                {
                    valorConfig=obtenerParametro("CLA_USU");
                }

                if (encriptado.Equals(valorConfig))
                {
                    resultado = true;
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error --> validarContraseña: " + e.Message);
                throw new Exception("Error --> validarContraseña: " + e.Message);
            }

            return resultado;
        }

        public bool validaAutenticacion(String tipo)
        {
            bool resultado = false;
            String clave = String.Empty;
            try
            {
                DialogResult dialogo;
                dialogo = autenticacion(ref clave);
                if (dialogo == DialogResult.OK)
                {
                    if (validarContraseña(clave, tipo))
                    {
                        resultado = true;
                        return resultado;
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error --> validaAutenticacion: " + e.Message);
                throw new Exception("Error --> validaAutenticacion: " + e.Message);
            }

            return resultado;
        }

        //Crear ventana de autenticacion
        private static DialogResult autenticacion(ref String value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox tbClave = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = "Autenticación:";
            label.Text = "Ingrese la contraseña:";
            tbClave.Text = value;
            tbClave.PasswordChar = '*';

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancelar";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            tbClave.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            tbClave.Anchor = tbClave.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, tbClave, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = tbClave.Text;
            return dialogResult;
        }

        public String appConfig(String id)
        {
            try
            {
                return ConfigurationManager.AppSettings[id].ToString();
            }
            catch (Exception e) {
                log.LogMessage("appConfig: "+e.Message);
                return String.Empty;
            }
            
        }

        /// <summary>
        /// Procedimientos asociados a la calidad de la nota de peso
        /// </summary>

        //Tipo Objeto
        public DataTable obtenerTipoObjeto()
        {
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT TIPO_OBJETO,DESC_OBJETO FROM DINAMIC_CONTROLS WHERE ESTADO = 'A';";
                tabla = sqlFrame.obtenerConsulta(sql);
                return tabla;
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerTipoObjeto: " + e.Message);
            }
            finally
            {

            }
            return tabla;
        }

        //Configuracion de Calidad
        public List<ConfigCalidadBean> obtenerConfiguracionCalidad(String tipoGrano)
        {
            DataTable tabla = new DataTable();
            ConfigCalidadBean bean;
            List<ConfigCalidadBean> lista = new List<ConfigCalidadBean>();
            try
            {
                sql = "SELECT TIPO_GRANO,ID_CAMPO,LABEL,TIPO,COD_GRUPO,OBLIGATORIO,ESTADO,LABEL_ETIQUETA,IMPRESION FROM CONFIG_CALIDAD WHERE TIPO_GRANO='"+tipoGrano+"' AND ESTADO='A';";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new ConfigCalidadBean();
                            bean.TIPO_GRANO = dr[0].ToString();
                            bean.ID_CAMPO = int.Parse(dr[1].ToString());
                            bean.LABEL = dr[2].ToString();
                            bean.TIPO = dr[3].ToString();
                            bean.COD_GRUPO = int.Parse(dr[4].ToString());
                            bean.OBLIGATORIO = dr[5].ToString();
                            bean.ESTADO = dr[6].ToString();
                            bean.LABEL_ETIQUETA = dr[7].ToString();
                            bean.IMPRESION = dr[8].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerConfiguracionCalidad: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        public bool grabarConfigCalidad(List<ConfigCalidadBean> listaConfiguracion,String tipoGrano)
        {
            bool resultado = false;
            List<String> listaSql = new List<string>();
            String sql = String.Empty;
            try
            {
                sql = "DELETE FROM CONFIG_CALIDAD WHERE TIPO_GRANO='"+ tipoGrano + "';";
                listaSql.Add(sql);

                foreach (ConfigCalidadBean bean in listaConfiguracion)
                {
                    sql = "INSERT INTO CONFIG_CALIDAD(TIPO_GRANO,ID_CAMPO,LABEL,TIPO,COD_GRUPO,OBLIGATORIO,LABEL_ETIQUETA,IMPRESION,ESTADO) VALUES('"+tipoGrano+"',"+bean.ID_CAMPO+",'"+bean.LABEL+"','"+bean.TIPO+"',"+bean.COD_GRUPO+",'"+bean.OBLIGATORIO+ "','"+bean.LABEL_ETIQUETA+"','"+bean.IMPRESION+ "','" + bean.ESTADO + "'); ";
                    listaSql.Add(sql);
                }

                resultado = sqlFrame.ejecutarTransaccion(listaSql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error grabarConfigCalidad: " + e.Message);
            }
            finally
            {

            }

            return resultado;
        }

        //Recuperar Nota de Calidad

        public List<DetalleCalidadBean> obtenerDetalleCalidad(int ID_CALIDAD)
        {
            DataTable tabla = new DataTable();
            DetalleCalidadBean bean;
            List<DetalleCalidadBean> lista = new List<DetalleCalidadBean>();
            try
            {
                sql = "SELECT ID_CALIDAD,ID_CAMPO,LABEL,VALOR FROM DETALLE_CALIDAD WHERE ID_CALIDAD="+ ID_CALIDAD+";";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        foreach (DataRow dr in tabla.Rows)
                        {
                            bean = new DetalleCalidadBean();
                            bean.ID_CALIDAD = int.Parse(dr[0].ToString());
                            bean.ID_CAMPO = int.Parse(dr[1].ToString());
                            bean.LABEL = dr[2].ToString();
                            bean.VALOR = dr[3].ToString();
                            lista.Add(bean);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerDetalleCalidad: " + e.Message);
            }
            finally
            {

            }
            return lista;
        }

        public DataTable obtenerconfiguracionCalidadDT(String TIPO_GRANO)
        {
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT TIPO_GRANO,ID_CAMPO,LABEL,TIPO,COD_GRUPO, CASE OBLIGATORIO WHEN 'S' THEN 'True' ELSE 'False' END OBLIGATORIO,CASE ESTADO WHEN 'A' THEN 'True' ELSE 'False' END ESTADO,LABEL_ETIQUETA,CASE IMPRESION WHEN 'S' THEN 'True' ELSE 'False' END IMPRESION FROM CONFIG_CALIDAD WHERE TIPO_GRANO='" + TIPO_GRANO+"';";
                tabla = sqlFrame.obtenerConsulta(sql);

                if (tabla != null)
                {
                    if (tabla.Rows.Count > 0)
                    {
                        return tabla;
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerDetalleCalidadDT: " + e.Message);
            }
            finally
            {

            }
            return tabla;
        }

        public CalidadBean obtenerCalidad(int ID_CALIDAD)
        {
            CalidadBean calidad = new CalidadBean();
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT ID_CALIDAD,ID_PESO,FECHA_CALIDAD,ESTADO FROM CALIDAD WHERE ID_CALIDAD=" + ID_CALIDAD + ";";
                tabla = sqlFrame.obtenerConsulta(sql);
                foreach (DataRow dr in tabla.Rows)
                {
                    calidad.ID_CALIDAD = int.Parse(dr[0].ToString());
                    calidad.ID_PESO = int.Parse(dr[1].ToString());
                    calidad.FECHA_CALIDAD = dr[2].ToString();
                    calidad.ESTADO = dr[3].ToString();
                    calidad.DETALLE = obtenerDetalleCalidad(ID_CALIDAD);
                }
            }
            catch(Exception e)
            {
                log.LogMessage("Error obtenerCalidad: " + e.Message);
            }
            finally
            {

            }
            return calidad;
        }

        public CalidadBean obtenerCalidadNotaPeso(int ID_PESO)
        {
            CalidadBean calidad = new CalidadBean();
            DataTable tabla = new DataTable();
            try
            {
                sql = "SELECT ID_CALIDAD,ID_PESO,FECHA_CALIDAD,ESTADO FROM CALIDAD WHERE ID_PESO=" + ID_PESO + ";";
                tabla = sqlFrame.obtenerConsulta(sql);
                foreach (DataRow dr in tabla.Rows)
                {
                    calidad.ID_CALIDAD = int.Parse(dr[0].ToString());
                    calidad.ID_PESO = int.Parse(dr[1].ToString());
                    calidad.FECHA_CALIDAD = dr[2].ToString();
                    calidad.ESTADO = dr[3].ToString();
                    calidad.DETALLE = obtenerDetalleCalidad(calidad.ID_CALIDAD);
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerCalidadNotaPeso: " + e.Message);
            }
            finally
            {

            }
            return calidad;
        }

        //Grabar Nota de calidad

        public bool grabarCalidad(CalidadBean calidad)
        {
            bool resultado = false;
            List<String> listaSQL = new List<String>();
            String sql = String.Empty;
            int IDCAL = 0;
            try
            {
                if (calidad != null)
                {
                    //Es una calidad nueva
                    if (calidad.ID_CALIDAD == 0)
                    {
                        sql = "INSERT INTO CALIDAD(FECHA_CALIDAD,ID_PESO,ESTADO) VALUES('"+calidad.FECHA_CALIDAD+"',"+calidad.ID_PESO+",'"+calidad.ESTADO+"');";

                        resultado=sqlFrame.ejecutarSentencia(sql);
                        
                        if (resultado) {

                            resultado = obtenerUltimaCalidad(ref IDCAL);

                            if (resultado)
                            {
                                calidad.ID_CALIDAD = IDCAL;
                                foreach (DetalleCalidadBean bean in calidad.DETALLE)
                                {
                                    bean.ID_CALIDAD = IDCAL;
                                    sql = "INSERT INTO DETALLE_CALIDAD(ID_CALIDAD,ID_CAMPO,LABEL,VALOR) VALUES(" + calidad.ID_CALIDAD + "," + bean.ID_CAMPO + ",'" + bean.LABEL + "','" + bean.VALOR + "')";
                                    listaSQL.Add(sql);
                                }

                                resultado = sqlFrame.ejecutarTransaccion(listaSQL);

                                if (resultado)
                                {
                                    return true;
                                }
                                else
                                {
                                    eliminarNotaCalidad(calidad.ID_CALIDAD);
                                    return false;
                                }
                            }
                            else {
                                eliminarNotaCalidad(IDCAL);
                                return false;
                            }
   
                        }
                        else
                        {
                            return false;
                        }
                        
                    }
                }
            }    
            catch (Exception e)
            {
                log.LogMessage("Error grabarCalidad: " + e.Message);
                eliminarNotaCalidad(IDCAL);
            }
            finally
            {

            }
            return resultado;
        }

        public bool obtenerUltimaCalidad(ref int ID)
        {
            bool resultado = false;
            string entero = String.Empty;
            try
            {
                entero = sqlFrame.obtenerEscalar("SELECT MAX(ID_CALIDAD) FROM CALIDAD");
                if (entero == String.Empty)
                {
                    ID = 0;
                }
                else
                {
                    ID = int.Parse(entero);
                }
                resultado = true;
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerUltimaCalidad: " + e.Message);
            }
            return resultado;
        }

        public bool eliminarNotaCalidad(Int64 id)
        {
            bool resultado = false;
            try
            {
                sql = "DELETE FROM DETALLE_CALIDAD WHERE ID_CALIDAD='" + id + "';";
                resultado = sqlFrame.ejecutarSentencia(sql);

                if (!resultado)
                {
                    return false;
                }

                sql = "DELETE FROM CALIDAD WHERE ID_CALIDAD='" + id + "';";
                resultado = sqlFrame.ejecutarSentencia(sql);
            }
            catch (Exception e)
            {
                log.LogMessage("Error eliminarNotaCalidad: " + id + " " + e.Message);
            }
            finally
            {

            }
            return resultado;
        }

        public String horaActual()
        {
            String mes, dia, hora, minuto, segundo, horaActual;
            horaActual = String.Empty;
            if (DateTime.Now.Month.ToString().Length == 1)
            {
                mes = "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                mes = DateTime.Now.Month.ToString();
            }
            if (DateTime.Now.Day.ToString().Length == 1)
            {
                dia = "0" + DateTime.Now.Day.ToString();
            }
            else
            {
                dia = DateTime.Now.Day.ToString();
            }
            if (DateTime.Now.Hour.ToString().Length == 1)
            {
                hora = "0" + DateTime.Now.Hour.ToString();
            }
            else
            {
                hora = DateTime.Now.Hour.ToString();
            }
            if (DateTime.Now.Minute.ToString().Length == 1)
            {
                minuto = "0" + DateTime.Now.Minute.ToString();
            }
            else
            {
                minuto = DateTime.Now.Minute.ToString();
            }
            if (DateTime.Now.Second.ToString().Length == 1)
            {
                segundo = "0" + DateTime.Now.Second.ToString();
            }
            else
            {
                segundo = DateTime.Now.Second.ToString();
            }

            horaActual = DateTime.Now.Year.ToString() + "-" + mes + "-" + dia + " " + hora + ":" + minuto + ":" + segundo;

            return horaActual;
        }

        //Para devolver etiquetas dinamicas de impresion
        public String devolverEtiquetaCalidad(String tipoGrano,int ID, out bool mandatory)
        {
            String etiqueta = String.Empty;
            mandatory = false;
            try
            {
                List<ConfigCalidadBean> lista;

                lista = obtenerConfiguracionCalidad(tipoGrano);
                foreach(ConfigCalidadBean bean in lista)
                {
                    if (bean.ID_CAMPO == ID)
                    {
                        if (bean.IMPRESION.Equals("S"))
                        {
                            mandatory = true;
                        }
                        return bean.LABEL_ETIQUETA;
                    }
                }
            }catch(Exception e)
            {
                log.LogMessage("Error devolverEtiquetaCalidad: " + ID + " " + e.Message);
            }
            return etiqueta;
        }

        public bool pesoNegativo(String tipoSaco)
        {
            bool resultado = false;
            try
            {
                sql = "SELECT ES_NEGATIVO FROM TIPO_SACO WHERE TIPO_SACO='" + tipoSaco + "';";
                String peso = sqlFrame.obtenerEscalar(sql);

                if (peso.Equals("S"))
                {
                    resultado=true;
                }
            }
            catch(Exception e)
            {
                log.LogMessage("Error pesoNegativo: " + e.Message);
            }
            return resultado;
        }
    }
}
