using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Configuration;
using System.Data;

namespace Balanza.Configs
{
    class SQLiteFramework
    {
        private SQLiteConnection con;
        private SQLiteCommand comando;
        private SQLiteDataAdapter dataAdapter;
        private SQLiteDataReader dr;
        private SQLiteTransaction tx;
        private String path;
        private Logger log;
        private int filasNonQuery = 0;
        private const String nombreBD= "BDBalanza.sqlite";
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();
        private String errorSQL = String.Empty;

        public SQLiteFramework() {
            con = new SQLiteConnection();
            log = new Logger();
            verificarBD();
        }

        private void SetConnection() {
            con = new SQLiteConnection("Data Source=" + Environment.CurrentDirectory + ConfigurationManager.AppSettings["rutaBD"].ToString() + "\\" + nombreBD + ";Version=3;");
        }

        private void verificarBD() {
            try
            {
                if (Directory.Exists(Environment.CurrentDirectory + ConfigurationManager.AppSettings["rutaBD"].ToString()))
                {
                    path = Environment.CurrentDirectory + ConfigurationManager.AppSettings["rutaBD"].ToString();
                    if (File.Exists(path + "\\" + nombreBD) == false)
                    {
                        SQLiteConnection.CreateFile(path + "\\" + nombreBD);
                        errorSQL = String.Empty;
                    }
                    crearTablas();
                }
                else
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + ConfigurationManager.AppSettings["rutaBD"].ToString());
                    verificarBD();
                }
            }
            catch (Exception e) {
                log.LogMessage("Error verificarBD:"+e.Message);
                errorSQL = e.Message;
            }
        }

        public bool ejecutarSentencia(String sql) {
            bool resultado = false;
            filasNonQuery = 0;
            try
            {
                SetConnection();
                con.Open();
                using (comando = new SQLiteCommand(sql, con)) {
                    filasNonQuery = comando.ExecuteNonQuery();
                    resultado = true;
                    errorSQL = String.Empty;
                }                
            }
            catch (Exception e)
            {
                log.LogMessage("Error ejecutarComando:" + e.Message);
                resultado = false;
                errorSQL = e.Message;
            }
            finally {
                cerrarBD();
            }
            return resultado;
        }

        public DataTable obtenerConsulta(String sql) {
            DT = new DataTable();
            DS = new DataSet();
            try
            {
                SetConnection();
                con.Open();
                using (dataAdapter = new SQLiteDataAdapter(sql, con))
                {
                    DS.Reset();
                    dataAdapter.Fill(DS);
                    DT = DS.Tables[0];
                }
                
                errorSQL = String.Empty;
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerConsulta:" + e.Message);
                errorSQL = e.Message;
            }
            finally
            {
                dataAdapter.Dispose();
                dataAdapter = null;
                cerrarBD();
            }
            return DT;
        }

        public String obtenerEscalar(String sql) {
            String escalar = String.Empty;
            try
            {
                SetConnection();
                con.Open();
                using (comando = new SQLiteCommand(sql, con))
                {
                    using(dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            escalar = dr[0].ToString();
                        }
                    }
                }
                                            
                errorSQL = String.Empty;
            }
            catch (Exception e)
            {
                log.LogMessage("Error obtenerEscalar:" + e.Message);
                errorSQL = e.Message;
            }
            finally {
                cerrarBD();
            }
            return escalar;
        }

        public int getFilasModificadas() {
            return filasNonQuery;
        }

        public String ultimoError()
        {
            return errorSQL;
        }

        private void cerrarBD() {
            try {
                if (con != null) {
                    con.Close();
                    con.Dispose();
                    dataAdapter = null;
                    dr = null;
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error cerrarBD:" + e.Message);
            }
        }

        public bool ejecutarTransaccion(List<String> listaSql) {
            bool resultado = false;
            try
            {
                SetConnection();
                con.Open();
                comando = new SQLiteCommand(con);

                using (tx = con.BeginTransaction())
                {
                    comando.Transaction = tx;
                    using (comando = con.CreateCommand())
                    {
                        foreach (String str in listaSql)
                        {
                            comando.CommandText = str;
                            comando.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                }
                
                resultado = true;
            }
            catch (Exception e)
            {
                log.LogMessage("Error ejecutarTransaccion:" + e.Message);
            }
            finally
            {
                cerrarBD();
            }
            return resultado;
        }

        private void crearTablas() {
            try
            {
                String sqlTable = String.Empty;

                sqlTable = "CREATE TABLE IF NOT EXISTS GRUPO(CODGRUPO INT NOT NULL PRIMARY KEY,DESGRUPO VARCHAR(100) NOT NULL,ESTADO CHAR(1) NOT NULL,EDITABLE CHAR(1) NOT NULL); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS DETALLE_GRUPO(CODGRUPO INT NOT NULL,VALOR VARCHAR(100) NOT NULL,VALOR_DEFECTO CHAR(1) NOT NULL,ESTADO VARCHAR(10) NOT NULL, PRIMARY KEY(CODGRUPO, VALOR),FOREIGN KEY(CODGRUPO) REFERENCES GRUPO(CODGRUPO) ON DELETE CASCADE ON UPDATE NO ACTION); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS PARAMETROS(CODIGO VARCHAR(30) NOT NULL PRIMARY KEY, VALOR VARCHAR(100)NOT NULL); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS CONF_BALANZA(COD_BALANZA VARCHAR(30) NOT NULL PRIMARY KEY,TAM_TRAMA INT NOT NULL,CAR_INI_TRA VARCHAR(10),CAR_EST_BAL VARCHAR(10),POS_INI_CEB INT,POS_FIN_CEB INT,POS_INI_PESO_ST INT,POS_FIN_PESO_ST INT,POS_INI_PESO_CT INT,POS_FIN_PESO_CT INT,ESTADO CHAR(1) NOT NULL,BAL_DEFAULT CHAR(1) NOT NULL,POS_DEC INT NOT NULL); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS NOTA_PESO(ID_PESO INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,TIPO_GRANO VARCHAR(50),FEC_REG_OPE TEXT NOT NULL,CIUDAD VARCHAR(50),CANT_SACOS INT, NUM_TICKET VARCHAR(50) NOT NULL,DNI_OPERADOR VARCHAR(20) NOT NULL,DNI_PRODUCTOR VARCHAR(50) NOT NULL, TOTAL_PESO_BRUTO FLOAT NOT NULL,TOTAL_PESO_NETO FLOAT NOT NULL,REPORTADO_CENTRAL CHAR(1) NOT NULL DEFAULT 'N',ID_BALANZA VARCHAR(100),EMPRESA VARCHAR2(100)); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS DETALLE_NOTA_PESO(ID_PESO INT NOT NULL,SECUENCIA INT NOT NULL,CANTIDAD INT NOT NULL, TIPO_SACO VARCHAR(50) NOT NULL,PESO_BRUTO_SACO FLOAT NOT NULL, PESO_NETO_SACO FLOAT, PESO_ESTABLE CHAR(1) NOT NULL, PRIMARY KEY(ID_PESO, SECUENCIA),FOREIGN KEY(ID_PESO) REFERENCES ID_PESO(NOTA_PESO) ON DELETE CASCADE ON UPDATE NO ACTION);";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS TIPO_SACO(TIPO_SACO VARCHAR(30) NOT NULL PRIMARY KEY, PESO FLOAT NOT NULL,ESTADO VARCHAR(1) DEFAULT 'A'); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS DINAMIC_CONTROLS(TIPO_OBJETO VARCHAR(50) NOT NULL PRIMARY KEY, DESC_OBJETO VARCHAR(50) NOT NULL, ESTADO VARCHAR(1) DEFAULT 'A'); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS CONFIG_CALIDAD(TIPO_GRANO VARCHAR NOT NULL,ID_CAMPO INTEGER NOT NULL,LABEL VARCHAR(50),TIPO VARCHAR(50) NOT NULL,COD_GRUPO INT,OBLIGATORIO CHAR(1) DEFAULT 'S',ESTADO CHAR(1) NOT NULL DEFAULT 'A',LABEL_ETIQUETA VARCHAR(50),IMPRESION CHAR(1) NOT NULL DEFAULT 'N',PRIMARY KEY(TIPO_GRANO, ID_CAMPO)); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS CALIDAD(ID_CALIDAD INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,FECHA_CALIDAD TEXT NOT NULL,ID_PESO INT NOT NULL,ESTADO VARCHAR(1) DEFAULT 'A',FOREIGN KEY(ID_PESO) REFERENCES ID_PESO(NOTA_PESO) ON DELETE CASCADE ON UPDATE NO ACTION); ";
                ejecutarSentencia(sqlTable);

                sqlTable = "CREATE TABLE IF NOT EXISTS DETALLE_CALIDAD(ID_CALIDAD INTEGER NOT NULL,ID_CAMPO INTEGER NOT NULL,LABEL VARCHAR(50) NOT NULL,VALOR VARCHAR(200),PRIMARY KEY(ID_CALIDAD, ID_CAMPO)); ";
                ejecutarSentencia(sqlTable);

                if (ConfigurationManager.AppSettings["insertarDatosBase"].ToString().Equals("1")) {

                    //DATOS
                    if(File.Exists(Environment.CurrentDirectory + ConfigurationManager.AppSettings["rutaDataBase"].ToString())) { 
                        string[] lines = System.IO.File.ReadAllLines(Environment.CurrentDirectory + ConfigurationManager.AppSettings["rutaDataBase"].ToString());
                        foreach (string line in lines)
                        {
                            ejecutarSentencia(line);
                        }
                    }


                }

                errorSQL = String.Empty;
            }
            catch (Exception e)
            {
                log.LogMessage("Error crearTablas:" + e.Message);
                errorSQL = e.Message;
            }
        }
    }
}
