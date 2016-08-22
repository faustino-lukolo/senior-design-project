using System;
using System.Collections.Generic;
using Android.Speech.Tts; 
using IReach.Droid;
using IReach.Services; 
using Xamarin.Forms; 
using Object = Java.Lang.Object;


[assembly: Dependency(typeof(TextToSpeech_Android))]
namespace IReach.Droid
{
    public class TextToSpeech_Android : Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        private TextToSpeech speaker;
        private string toSpeak;

        public TextToSpeech_Android()
        {
        }

        public void Speak ( string text )
        {
            var context = Forms.Context;
            toSpeak = text;

            if (speaker == null)
            {
                speaker = new TextToSpeech(context, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
                System.Diagnostics.Debug.WriteLine("Spoke " + toSpeak);
            }

        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                System.Diagnostics.Debug.WriteLine("Speaker init");
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Its too Quiet");
            }
        }
    }
}