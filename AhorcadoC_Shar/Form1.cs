using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AhorcadoC_Shar
{
    public partial class Form1 : Form
    {
        int numeroFallos = 0;
        Boolean gameOver = false;
        String palabraOculta = "";
        public String eligePalabra()
        {
            String[] listaPalabras = { "HOLA", "CETYS", "sinchan","willyrex","animalcruising","fabio","ramiro","poter",
            "homero","coronavirus","mayoralptoamo"};
            Random aleatorio = new Random();
            int posicion = aleatorio.Next(listaPalabras.Length);
            return listaPalabras[posicion].ToUpper();
        }
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.ahorcado_0;
            palabraOculta = eligePalabra();
            String auxiliar = "";
            for (int i = 0; i < palabraOculta.Length; i++)
            {
                auxiliar = auxiliar + "_ ";
            }
            label1.Text = auxiliar;
        }

        public void botonPulsado(object sender, EventArgs e)
        {
            Button miBoton = (Button)sender;
            String letra = miBoton.Text;
            letra = letra.ToUpper();
            if (!gameOver)
            {
                if (palabraOculta.Contains(letra))
                {
                    for (int i = 0; i < palabraOculta.Length; i++)//Ponemos la letra en los huecos correspondientes
                    {
                        if (palabraOculta[i] == letra[0])
                        {//Si esta la palabra la ponemos donde los guiones
                         //quita el guión bajo de la letra correspondiente
                            label1.Text = label1.Text.Substring(0, 2 * i)
                                    + letra
                                    + label1.Text.Substring(2 * i + 1);
                        }
                    }
                    int posicion = palabraOculta.IndexOf(letra);
                    label1.Text = label1.Text.Remove(2 * posicion, 1).Insert(2 * posicion, letra);

                }
                else
                {
                    numeroFallos++;
                }
                miBoton.Enabled = false;
            }
            if (!label1.Text.Contains('_'))
            {
                numeroFallos = -100;
            }
            if (numeroFallos > 5)
            {
                gameOver = true;
            }
            switch (numeroFallos)
            {
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                case 6: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
                case -100: pictureBox1.Image = Properties.Resources.acertasteTodo; break;
                default: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
            }
        }
    }
}
