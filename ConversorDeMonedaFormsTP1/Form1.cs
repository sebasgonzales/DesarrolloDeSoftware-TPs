using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversorDeMonedaFormsTP1
{
    public partial class ConversorDeMoneda : Form
    {

        double tasaUSDaARS = 738; // Tasa de cambio ARS a USD Blue
        double tasaARSaUSD = (1.00/738.00); // Tasa de cambio USD Blue a ARS 


        public ConversorDeMoneda()
        {
            InitializeComponent();
            comboBox1.Items.Add("USD a ARS");
            comboBox1.Items.Add("ARS a USD");

        }

        private void convertir_Click(object sender, EventArgs e)
        {
            try
            {
                double cantidad = double.Parse(textBox1.Text);
                double resultado;



                if (comboBox1.SelectedItem != null)
                {
                    if (comboBox1.SelectedItem.ToString() == "USD a ARS")
                    {
                        resultado = cantidad * tasaUSDaARS;
                        label4.Text = resultado.ToString("N2") + " ARS"; 
                    }
                    else if (comboBox1.SelectedItem.ToString() == "ARS a USD")
                    {
                        resultado = cantidad * tasaARSaUSD;
                        label4.Text = resultado.ToString("N5") + " USD";

                    }
                }
                else
                {
                    MessageBox.Show("Seleccione una dirección de conversión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiar_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label4.Text = "";
            comboBox1.SelectedIndex = -1; // Desseleccionar dirección de conversión
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void titulo_Click(object sender, EventArgs e)
        {

        }

        private void labelResultado(object sender, EventArgs e)
        {

        }

        private void comboBoxTiposMoneda(object sender, EventArgs e)
        {

        }

        private void labelImporte(object sender, EventArgs e)
        {

        }

    }
}
