﻿using System;
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
using System.Diagnostics;

namespace VoiceBot
{
    public partial class Form1 : Form
    {
        //xzxsadaczzc
        //22222222233
        SpeechSynthesizer s = new SpeechSynthesizer();

        Boolean wake = true;
        Choices list = new Choices();
        public Form1()
        {

            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
            

            list.Add(new String[] { "Hello", "how are you", "what time is it", "what is today", "open google", "wake", "sleep"});

            Grammar gr = new Grammar(new GrammarBuilder(list));


            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeechRecognized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }



            s.SelectVoiceByHints(VoiceGender.Female);

            //s.Speak("Hello, My name is Friday");
            InitializeComponent();
        }


        public void say(String h)
        {
            s.Speak(h);
        }


        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String r = e.Result.Text;


            if (r == "wake" ) { wake = true; }
            if (r == "sleep") { wake = false; }


            if (wake == true)
            {

                if (r == "hello")
                {
                    say("hi");
                }

                if (r == "what time is it")
                {
                    say(DateTime.Now.ToString("h:mm tt"));
                }

                if (r == "what is today")
                {
                    say(DateTime.Now.ToString("d/M/yyyy"));
                }


                if (r == "how are you")
                {
                    say("Great, and you?");
                }

                if (r == "open google")
                {
                    Process.Start("http://google.co.th");
                }
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
