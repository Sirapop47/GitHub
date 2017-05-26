using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        public Form1()
        {
            s.SelectVoiceByHints(VoiceGender.Female);
            s.Speak("hello, how are you?");
            InitializeComponent();
        }


    }
}
