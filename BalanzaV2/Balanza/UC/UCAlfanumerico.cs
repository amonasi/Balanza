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
    public partial class UCAlfanumerico : UserControl
    {
        public UCAlfanumerico(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private bool obligatorio = false;
        private bool visible = false;
        private bool enabled = false;
        private int IDObjeto;

        public int getID()
        {
            return IDObjeto;
        }

        private void UCAlfanumerico_Load(object sender, EventArgs e)
        {

        }

        public void editable(bool editable)
        {
            tbValor.ReadOnly = editable;
        }

        public void longitud(int longitud)
        {
            tbValor.MaxLength = longitud;
        }

        public String obtenerValor() {
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

        private void tbValor_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
