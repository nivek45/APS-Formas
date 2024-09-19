using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AulaAPS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cmbForma_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbForma.Text)
            {
                case "Quadrado":
                    SelecionarQuadrado();
                    break;
                case "Triângulo":
                    SelecionarTriangulo();
                    break;
                case "Retângulo":
                    SelecionarRetangulo();
                    break;
                case "Circunferência":
                    SelecionarCircunferencia();
                    break;
            }
        }

        private void SelecionarQuadrado()
        {
            ExibirBase(true);
            ExibirAltura(false);
            lblRaio.Visible = txtRaio.Visible = false;
            cmbTriangulo.Visible = false;
        }
        private void SelecionarTriangulo()
        {
            cmbTriangulo.Visible = true;
            ExibirBase(false);
            ExibirRaio(false);
            ExibirAltura(false);
        }
        private void SelecionarRetangulo()
        {
            ExibirBase(true);
            ExibirAltura(true);
            ExibirRaio(false);
            cmbTriangulo.Visible = false;

        }

        private void SelecionarCircunferencia()
        {
            ExibirBase(false);
            ExibirAltura(false);
            ExibirRaio(true);
            cmbTriangulo.Visible = false;
        }

        private void SelecionarTrianguloReto()
        {
            ExibirBase(true);
            ExibirAltura(true);
        }

        private void SelecionarTrianguloIsosceles()
        {
            ExibirBase(true);
            ExibirAltura(true);
        }
        private void SelecionarTrianguloEquilatero()
        {
            ExibirBase(true);
            ExibirAltura(true);
        }




        private void ExibirBase(bool visivel)
        {
            lblBase.Visible = txtBase.Visible = visivel;
        }

        private void ExibirAltura(bool visivel)
        {
            lblAltura.Visible = txtAltura.Visible = visivel;
        }

        private void ExibirRaio(bool visivel)
        {
            lblRaio.Visible = txtRaio.Visible = visivel;
        }

        private double ConvertToDouble(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            CultureInfo culture = new CultureInfo("pt-BR");
            return double.Parse(text, culture);
        }

        
        private void btnCriar_Click(object sender, EventArgs e)
        {
            cmbObjetos.Items.Clear(); 

            if (cmbForma.Text.Equals("Quadrado"))
            {
                FormaGeometrica quadrado = new Quadrado()
                {
                    Lado = ConvertToDouble(txtBase.Text) 
                };
                cmbObjetos.Items.Add(quadrado);
            }
            else if (cmbForma.Text.Equals("Triângulo"))
            {
                if (cmbTriangulo.Text.Equals("Isósceles"))
                {
                    FormaGeometrica trianguloIsosceles = new TrianguloIsosceles()
                    {
                        LadoBase = ConvertToDouble(txtBase.Text),
                        Altura = ConvertToDouble(txtAltura.Text)
                    };
                    cmbObjetos.Items.Add(trianguloIsosceles);
                }
                else if (cmbTriangulo.Text.Equals("Reto"))
                {
                    FormaGeometrica trianguloReto = new TrianguloReto()
                    {
                        Base = ConvertToDouble(txtBase.Text),
                        Altura = ConvertToDouble(txtAltura.Text)
                    };
                    cmbObjetos.Items.Add(trianguloReto);
                }
                else if (cmbTriangulo.Text.Equals("Equilátero"))
                {
                    FormaGeometrica trianguloEquilatero = new TrianguloEquilatero()
                    {
                        Lado = ConvertToDouble(txtBase.Text)
                    };
                    cmbObjetos.Items.Add(trianguloEquilatero);
                }
            }
            else if (cmbForma.Text.Equals("Retângulo"))
            {
                FormaGeometrica retangulo = new Retangulo()
                {
                    Base = ConvertToDouble(txtBase.Text),
                    Altura = ConvertToDouble(txtAltura.Text)
                };
                cmbObjetos.Items.Add(retangulo);
            }
            else if (cmbForma.Text.Equals("Circunferência"))
            {
                FormaGeometrica circunferencia = new Circunferencia()
                {
                    Raio = ConvertToDouble(txtRaio.Text) 
                };
                cmbObjetos.Items.Add(circunferencia);
            }
        }


        private void ExibirArea(bool visivel)
        {
            lblArea.Visible = txtArea.Visible = visivel;
        }

        private void ExibirPerimetro(bool visivel)
        {
            lblPerimetro.Visible = txtPerimetro.Visible = visivel;
        }

        private void cmbObjetos_SelectedIndexChanged(object sender, EventArgs e)
{
            FormaGeometrica obj = cmbObjetos.SelectedItem as FormaGeometrica;
            if (obj != null)
            {
                txtArea.Text = obj.CalcularArea().ToString();
                txtPerimetro.Text = obj.CalcularPerimetro().ToString();
            }
}


        private void txtArea_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbTriangulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbTriangulo.Text)
            {
                case "Reto":
                    SelecionarTrianguloReto();
                    break;
                case "Isósceles":
                    SelecionarTrianguloIsosceles();
                    break;
                case "Equilátero":
                    SelecionarTrianguloEquilatero();
                    break;
            }
        }

        private void txtBase_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            ExibirBase(false);
            ExibirRaio(false);
            ExibirAltura(false);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
