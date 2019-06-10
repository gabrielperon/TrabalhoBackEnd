using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EstudoDelegates
{
    public partial class frmCalculadora : Form
    {
        private delegate int ExecutarOperacao(int numero1, int numero2);
        private ExecutarOperacao minhaOperacao;


        public frmCalculadora()
        {
            InitializeComponent();
        }

        private void frmCalculadora_Load(object sender, EventArgs e)
        {

        }

       

        private int Calcular()
        {
            int numero1 = Convert.ToInt32(txbNumero1.Text);
            int numero2 = Convert.ToInt32(txbNumero1.Text);

            return minhaOperacao(numero1, numero2);
        }

        private int Somar(int numero1 , int numero2)
        {
            return numero1 + numero2;
        }

        private int Subtrair(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        private int Multiplicacao(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        private int Divisao(int numero1, int numero2)
        {
            return numero1 / numero2;
        }

        private void btnAdicao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Somar);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnSubtracao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Subtrair);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Multiplicacao);
            txbResultado.Text = Calcular().ToString();
        }

        private void btnDivisao_Click(object sender, EventArgs e)
        {
            minhaOperacao = new ExecutarOperacao(Divisao);
            txbResultado.Text = Calcular().ToString();
        }
    }
}
