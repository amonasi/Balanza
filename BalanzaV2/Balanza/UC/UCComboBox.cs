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
    public partial class UCComboBox : UserControl
    {
        public UCComboBox(int ID)
        {
            InitializeComponent();
            IDObjeto = ID;
        }

        private void UCComboBox_Load(object sender, EventArgs e)
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
            return cmbValor.Enabled = editable;
        }

        public String obtenerValor()
        {
            if (cmbValor.SelectedItem != null)
            {
                return cmbValor.SelectedItem.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        public void setearValor(String valor)
        {
                cmbValor.SelectedItem = valor;
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
            cmbValor.Visible = valor;
        }

        public bool esVisible()
        {
            return visible;
        }

        public bool esEditable()
        {
            return cmbValor.Enabled;
        }

        public void cargarCombo(List<String> lista)
        {
            try
            {
                cmbValor.Items.Clear();
                foreach(String str in lista)
                {
                    cmbValor.Items.Add(str);
                }
            }
            catch(Exception e)
            {

            }
        }

    }
}
