using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;


namespace Convertidor_de_texto_a_voz
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer boca = new SpeechSynthesizer();
        List<VoiceInfo> vocesInfo = new List<VoiceInfo>();

        public Form1()
        {
            InitializeComponent();
            foreach (InstalledVoice voz in boca.GetInstalledVoices())
            {
                vocesInfo.Add(voz.VoiceInfo);
                comboBox1.Items.Add(voz.VoiceInfo.Name);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int indice;

            double volumen = trackBar2.Value;
            double rate = trackBar1.Value;

            try
            {
                indice = comboBox1.SelectedIndex;
                String nombre = vocesInfo.ElementAt(indice).Name;
                boca.SelectVoice(nombre);
                boca.Volume = (int)volumen;
                boca.Rate = (int)rate;
                boca.Speak(textBox1.Text);
            }catch(Exception)
            {
                MessageBox.Show("Elige una voz");
            }

        }
    }
}
