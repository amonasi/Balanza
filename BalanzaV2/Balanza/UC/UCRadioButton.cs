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
    public partial class UCRadioButton : UserControl
    {
        public UCRadioButton(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private void UCRadioButton_Load(object sender, EventArgs e)
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
            return rbValor.Checked;
        }

        public String obtenerEtiqueta()
        {
            if (rbValor.Text != null)
            {
                return rbValor.Text;
            }
            else
            {
                return String.Empty;
            }
        }

        public void setearEtiqueta(String valor)
        {
            if (rbValor != null)
            {
                rbValor.Text = valor;
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
            rbValor.Visible = valor;
        }

        public bool esVisible()
        {
            return visible;
        }

        public void editable(bool valor)
        {
            enabled = valor;
            rbValor.Enabled = valor;
        }

        public bool estaHabilitado()
        {
            return rbValor.Enabled;
        }

        public bool obtenerValor()
        {
            if (rbValor.Checked != null)
            {
                return rbValor.Checked;
            }
            else
            {
                return false;
            }
        }

        public void setearValor(bool valor)
        {
            if (rbValor.Checked != null)
            {
                rbValor.Checked = valor;
            }
        }
    }
}
