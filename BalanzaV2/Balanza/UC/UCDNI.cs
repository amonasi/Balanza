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
    public partial class UCDNI : UserControl
    {
        public UCDNI(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private void UCDNI_Load(object sender, EventArgs e)
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

        private void tbValor_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void tbValor_Leave(object sender, EventArgs e)
        {
            if (tbValor.Text.Length > 0 && tbValor.Text.Length < tbValor.MaxLength)
            {
                MessageBox.Show("Cantidad de caracteres insuficientes.", "Error");
                tbValor.Text = String.Empty;
            }
        }
    }
}
