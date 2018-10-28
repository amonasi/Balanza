using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balanza.UC
{
    public partial class UCTickerHour : UserControl
    {
        public UCTickerHour(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private void UCTickerHour_Load(object sender, EventArgs e)
        {
            inicializarTimer();
        }

        Timer fechaTimer;
        private int IDObjeto;

        public int getID()
        {
            return IDObjeto;
        }

        public void setearEtiqueta(String valor)
        {
            if (lbEtiqueta != null)
            {
                lbEtiqueta.Text = valor;
            }
        }

        public String obtenerEtiqueta()
        {
            if (lbEtiqueta.Text != null)
            {
                return lbEtiqueta.Text;
            }
            else
            {
                return String.Empty;
            }
        }

        public String obtenerValor()
        {
            if (tbTicker.Text != null)
            {
                return tbTicker.Text;
            }
            else
            {
                return String.Empty;
            }
        }

        public void setearValor(String valor)
        {
            if (tbTicker != null)
            {
                tbTicker.Text = valor;
            }
        }

        #region timer
        private void inicializarTimer()
        {
            bool resultado = false;
            try
            {
                if (fechaTimer == null)
                {
                    fechaTimer = new Timer();
                    fechaTimer.Interval = 1000;
                    fechaTimer.Tick += new EventHandler(_timer_Elapsed);
                    fechaTimer.Enabled = true; //
                    fechaTimer.Start();
                }
                resultado = true;
            }
            catch (Exception e)
            {

            }
        }

        private void _timer_Elapsed(object sender, EventArgs e)
        {
            tbTicker.Text = String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
        }

        public void pararTimer()
        {
            try
            {
                if (fechaTimer != null)
                {
                    fechaTimer.Stop();
                }
            }
            catch (Exception e)
            {

            }
        }
        #endregion
    }
}
