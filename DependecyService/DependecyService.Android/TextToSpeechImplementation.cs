using DependecyService.Droid;
using Xamarin.Forms;
using Android.Speech.Tts;
using Android.Runtime;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace DependecyService.Droid
{
    class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeck;
        public void Speak(string text)
        {
            toSpeck = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(Android.App.Application.Context, this);
            }
            else 
            {
                speaker.Speak(toSpeck, QueueMode.Flush, null, null);
            }
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            speaker.Speak(toSpeck, QueueMode.Flush, null, null);
        }
    }
}