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
    public partial class UCDate : UserControl
    {
        public UCDate(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private void UCDate_Load(object sender, EventArgs e)
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

        public bool editable(bool editable)
        {
            return dtValor.Enabled = editable;
        }

        public String obtenerValor()
        {
            if (dtValor.Text != null)
            {
                return dtValor.Text;
            }
            else
            {
                return String.Empty;
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

        public void setearValor(String valor)
        {
            if (dtValor != null)
            {
                dtValor.Text = valor;
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
            dtValor.Visible = valor;
        }

        public bool esVisible()
        {
            return visible;
        }

        public void setearReadOnly(bool valor)
        {
            enabled = valor;
            dtValor.Enabled = valor;
        }

        public bool esReadOnly()
        {
            return enabled;
        }
    }
}
