using System;
using System.Collections.Generic;
using System.Web;
using System.Threading;
using System.IO;
using System.Configuration;

namespace Balanza.Configs
{
    class Logger
    {

        public Logger()
        {

        }

        private Boolean verificarRuta(String nombreArchivo, ref String path)
        {
            Boolean resultado = false;

            if (Directory.Exists(ConfigurationManager.AppSettings["rutaLog"].ToString()))
            {
                path = ConfigurationManager.AppSettings["rutaLog"].ToString();
                if (File.Exists(ConfigurationManager.AppSettings["rutaLog"].ToString() + "\\" + nombreArchivo))
                {
                    resultado = true;
                }
                else
                {
                    try
                    {
                        File.Create(ConfigurationManager.AppSettings["rutaLog"].ToString() + "\\" + nombreArchivo).Close();
                        resultado = true;

                    }
                    catch (Exception)
                    {
                        resultado = false;
                    }
                }
            }
            else
            {
                if (Directory.Exists(Environment.CurrentDirectory + "\\Logs"))
                {
                    path = Environment.CurrentDirectory + "\\Logs";
                    if (File.Exists(Environment.CurrentDirectory + "\\Logs\\" + nombreArchivo))
                    {
                        resultado = true;
                    }
                    else
                    {
                        try
                        {
                            File.Create(Environment.CurrentDirectory + "\\Logs\\" + nombreArchivo).Close();
                            resultado = true;
                        }
                        catch (Exception)
                        {
                            resultado = false;
                        }
                    }
                }
                else
                {
                    try
                    {
                        Directory.CreateDirectory(Environment.CurrentDirectory + "\\Logs");
                        File.Create(Environment.CurrentDirectory + "\\Logs\\" + nombreArchivo).Close();
                        path = Environment.CurrentDirectory + "\\Logs";
                        resultado = true;
                    }
                    catch (Exception)
                    {
                        resultado = false;
                    }
                }
            }
            return resultado;
        }

        public void LogMessage(String pMessage)
        {

            if (ConfigurationManager.AppSettings["enabledLog"].ToString().Equals("1"))
            {

                bool Successful = false;

                String nombreArchivo = DateTime.Today.Year.ToString() + DateTime.Today.Month.ToString() + DateTime.Today.Day.ToString() + ".txt";
                String path = String.Empty;

                if (verificarRuta(nombreArchivo, ref path))
                {

                    for (int idx = 0; idx < 10; idx++)
                    {
                        try
                        {
                            // Escribe el mensaje en la ruta verificada
                            StreamWriter str = new StreamWriter(path + "\\" + nombreArchivo, true);
                            // Write text with no buffering
                            str.AutoFlush = true;
                            str.WriteLine("Fecha: " + DateTime.Now.ToString() + Environment.NewLine + "Detalle: " + pMessage);
                            str.Close();

                            Successful = true;
                        }
                        catch (Exception e)
                        {
                            Console.Write(e.Message);
                        }

                        if (Successful == true)
                        {
                            // Exito al grabarlo
                            break;
                        }
                        else
                        {
                            // Si falla, reintenta en 100 milliseconds
                            Thread.Sleep(100);
                        }
                    }

                }
            }

        }

        public void LogMessage(String pMessage, String nombreArchivo, bool fechaHabil)
        {

            if (ConfigurationManager.AppSettings["enabledLog"].ToString().Equals("1"))
            {

                bool Successful = false;

                if (nombreArchivo.IndexOf(".txt") < 0)
                {
                    nombreArchivo = nombreArchivo + ".txt";
                }

                String path = String.Empty;

                if (verificarRuta(nombreArchivo, ref path))
                {

                    for (int idx = 0; idx < 10; idx++)
                    {
                        try
                        {
                            // Escribe el mensaje en la ruta verificada
                            StreamWriter str = new StreamWriter(path + "\\" + nombreArchivo, true);
                            // Write text with no buffering
                            str.AutoFlush = true;
                            if (fechaHabil)
                            {
                                str.WriteLine("Fecha: " + DateTime.Now.ToString() + Environment.NewLine + "Detalle: " + pMessage);
                            }
                            else
                            {
                                str.WriteLine("Detalle: " + pMessage);
                            }
                            str.Close();

                            Successful = true;
                        }
                        catch (Exception e)
                        {
                            Console.Write(e.Message);
                        }

                        if (Successful == true)
                        {
                            // Exito al grabarlo
                            break;
                        }
                        else
                        {
                            // Si falla, reintenta en 100 milliseconds
                            Thread.Sleep(100);
                        }
                    }

                }
            }

        }

        public void LogMessage(String pMessage, String nombreArchivo)
        {

            if (ConfigurationManager.AppSettings["enabledLog"].ToString().Equals("1"))
            {

                bool Successful = false;

                if (nombreArchivo.IndexOf(".txt") < 0)
                {
                    nombreArchivo = nombreArchivo + ".txt";
                }

                String path = String.Empty;

                if (verificarRuta(nombreArchivo, ref path))
                {

                    for (int idx = 0; idx < 10; idx++)
                    {
                        try
                        {
                            // Escribe el mensaje en la ruta verificada
                            StreamWriter str = new StreamWriter(path + "\\" + nombreArchivo, true);
                            // Write text with no buffering
                            str.AutoFlush = true;
                            str.WriteLine("Fecha: " + DateTime.Now.ToString() + Environment.NewLine + "Detalle: " + pMessage);
                            str.Close();

                            Successful = true;
                        }
                        catch (Exception e)
                        {
                            Console.Write(e.Message);
                        }

                        if (Successful == true)
                        {
                            // Exito al grabarlo
                            break;
                        }
                        else
                        {
                            // Si falla, reintenta en 100 milliseconds
                            Thread.Sleep(100);
                        }
                    }

                }
            }

        }

        public void LogMessage(Exception pExeption)
        {
            String str_inner = "";

            try
            {
                str_inner = Environment.NewLine +
                "Inner Exception Msg: " + pExeption.InnerException.Message +
                "Inner Exception Stack: " + pExeption.InnerException.StackTrace;
            }
            catch (Exception)
            {

            }

            LogMessage("Exception: " + pExeption.Message + Environment.NewLine + "Stack: " + str_inner);
        }

        public String RutaLog()
        {
            return ConfigurationManager.AppSettings["rutaLog"].ToString();
        }

    }
}
