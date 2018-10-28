using System;
using System.IO.Ports;
using Balanza.Configs;

namespace Balanza.Configs
{
    /// <summary>
    /// Manager for serial port data
    /// </summary>
    public class SerialPortManager : IDisposable
    {
        public SerialPortManager(String puerto, int baudRate, Parity paridad, int dataBits, StopBits stopBits)
        {
            try { 
                puertoSerial = puerto;
                baudRateSerial = baudRate;
                paridadSerial = paridad;
                dataBitsSerial = dataBits;
                stopBitsSerial = stopBits;

                datos = new DAL();
                log = new Logger();
                log.LogMessage("puertoSerial: " + puerto);
                log.LogMessage("baudRateSerial:" + baudRate);
                log.LogMessage("dataBitsSerial: " + dataBits);

                
            }
            catch (Exception ex)
            {
                log.LogMessage("SerialPortManager: " + ex.Message);
            }
        }


        ~SerialPortManager()
        {
            Dispose(false);
        }


        #region Fields
        private SerialPort _serialPort;
        private string _latestRecieved = String.Empty;
        public event EventHandler<SerialDataEventArgs> NewSerialDataRecieved;

        private String puertoSerial;
        private int baudRateSerial;
        private Parity paridadSerial;
        private int dataBitsSerial;
        private StopBits stopBitsSerial;
        private Logger log;
        private DAL datos;
        private String trama;
        private String saltoLineaSerial;
        #endregion


        #region Event handlers
        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try {
                log.LogMessage("_serialPort_DataReceived");

                /*
                int dataLength = _serialPort.BytesToRead;

                log.LogMessage("Cantidad de bits por leer: "+ dataLength);

                byte[] data = new byte[dataLength];
                int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                if (nbrDataRead == 0)
                    return;
                */

                trama=_serialPort.ReadLine();

                //Comprobando que no llegue basura que desborde la memoria.
                if (trama.Length > int.Parse(datos.appConfig("MaxLongitudTramaBalanza")))
                {
                    trama = trama.Substring(0, int.Parse(datos.appConfig("MaxLongitudTramaBalanza")));
                }

                // Send data to whom ever interested
                NewSerialDataRecieved(this, new SerialDataEventArgs(trama));
            }
            catch (System.OutOfMemoryException oe)
            {
                log.LogMessage("Error de memoria SerialPortManager: " + oe.Message);
            }
            catch (Exception ex)
            {
                log.LogMessage("_serialPort_DataReceivedException: " + ex.Message);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Connects to a serial port defined through the current settings
        /// </summary>
        public void StartListening()
        {
            try {
                log.LogMessage("StartListening");

                // Closing serial port if it is open
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                }

                // Setting serial port settings
                _serialPort = new SerialPort();
                _serialPort.PortName = puertoSerial;
                _serialPort.BaudRate = baudRateSerial;
                _serialPort.Parity = paridadSerial;
                _serialPort.DataBits = dataBitsSerial;
                _serialPort.StopBits = stopBitsSerial;
                _serialPort.NewLine = "\r";

                _serialPort.ReadTimeout = 1000;

                // Subscribe to event and open serial port for data
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                _serialPort.Open();
            }
            catch (Exception ex)
            {
                log.LogMessage("StartListeningException: " + ex.Message);
            }
        }

        /// <summary>
        /// Closes the serial port
        /// </summary>
        public void StopListening()
        {
            log.LogMessage("StopListening");
            _serialPort.Close();
        }

        // Call to release serial port
        public void Dispose()
        {
            Dispose(true);
        }

        // Part of basic design pattern for implementing Dispose
        protected virtual void Dispose(bool disposing)
        {
            try {
                log.LogMessage("DisposeSerial");

                if (disposing)
                {
                    _serialPort.DataReceived -= new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                }
                // Releasing serial port (and other unmanaged objects)
                if (_serialPort != null)
                {
                    if (_serialPort.IsOpen)
                        _serialPort.Close();

                    _serialPort.Dispose();
                }
            }
            catch (Exception ex)
            {
                log.LogMessage("DisposeSerialException: " + ex.Message);
            }
        }


        #endregion

    }

    /// <summary>
    /// EventArgs used to send bytes recieved on serial port
    /// </summary>
    public class SerialDataEventArgs : EventArgs
    {
        public SerialDataEventArgs(byte[] dataInByteArray)
        {
            Data = dataInByteArray;
        }

        public SerialDataEventArgs(String trama)
        {
            tramaPuerto = trama;
        }

        /// <summary>
        /// Byte array containing data from serial port
        /// </summary>
        public byte[] Data;
        public string tramaPuerto;
    }
}
