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
    public partial class UCCheckBox : UserControl
    {
        public UCCheckBox(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private void UCCheckBox_Load(object sender, EventArgs e)
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

        public bool estaSeleccionado()
        {
            return cbValor.Checked;
        }

        public bool obtenerValor()
        {
            if (cbValor.Checked != null)
            {
                return cbValor.Checked;
            }
            else
            {
                return false;
            }
        }

        public void setearValor(bool valor)
        {
            if (cbValor != null)
            {
                cbValor.Checked = valor;
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
            cbValor.Visible = valor;
        }

        public bool esVisible()
        {
            return visible;
        }

        public void editable(bool valor)
        {
            enabled = valor;
            cbValor.Enabled = valor;
        }

        public bool estaHabilitado()
        {
            return cbValor.Enabled;
        }

        public String obtenerEtiqueta()
        {
            if (cbValor.Checked != null)
            {
                return cbValor.Text;
            }
            else
            {
                return String.Empty;
            }
        }

        public void setearEtiqueta(String valor)
        {
            if (cbValor != null)
            {
                cbValor.Text = valor;
            }
        }
    }
}
