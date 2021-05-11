using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lab09.View
{
    public class PanContainer : ContentView
    {
        double x, y;

        public PanContainer()
        {
            // Configure PanGestureRecognizer.TouchPoints para controlar
            // número de puntos de contacto necesarios para desplazarse
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {

                case GestureStatus.Running:
                    //Traduzca y asegúrese de no desplazarnos más allá de los límites del elemento de interfaz de usuario envuelto.
                    Content.TranslationX = Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - App.ScreenWidth));
                    Content.TranslationY = Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - App.ScreenHeight));
                    break;

                case GestureStatus.Completed:
                    // Almacenar la traducción aplicada durante el pan.
                    x = Content.TranslationX;
                    y = Content.TranslationY;
                    break;
            }
        }
    }
}
