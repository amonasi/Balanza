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
    public partial class UCPercentage : UserControl
    {
        public UCPercentage(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private void UCPercentage_Load(object sender, EventArgs e)
        {

        }

        private bool obligatorio = false;
        private bool visible = false;
        private bool enabled = false;
        private int IDObjeto;

        public int getID()
        {
            return IDObjeto;
        }

        public void editable(bool editable)
        {
            tbValor.ReadOnly = editable;
        }

        public void longitud(int longitud)
        {
            tbValor.MaxLength = longitud;
        }

        public String obtenerValor()
        {
            if (tbValor.Text != null)
            {
                return tbValor.Text;
            }
            else
            {
                return String.Empty;
            }
        }

        public void setearValor(String valor)
        {
            if (tbValor != null)
            {
                tbValor.Text = valor;
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

        public void setearEtiqueta(String valor)
        {
            if (lbEtiqueta != null)
            {
                lbEtiqueta.Text = valor;
            }
        }

        public void setearObligatorio(bool valor)
        {
            obligatorio = valor;
        }

        public bool esObligatorio()
        {
            return obligatorio;
        }

        public void setearVisible(bool valor)
        {
            visible = valor;
            tbValor.Visible = valor;
        }

        public bool esVisible()
        {
            return visible;
        }

        public void setearReadOnly(bool valor)
        {
            enabled = valor;
            tbValor.ReadOnly = valor;
        }

        public bool esReadOnly()
        {
            return enabled;
        }

        public void inputMask(String mascara)
        {
            tbValor.Mask = mascara;
        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            try
            {
                float valor=float.Parse(tbValor.Text.Substring(1,tbValor.Text.Length-1));
                if (valor > 100)
                {
                    tbValor.Text = "100.00";
                    MessageBox.Show("El valor de porcentaje no puede ser mayor a 100");
                } 
            }
            catch(Exception ex)
            {
                
            }
        }
    }
}
