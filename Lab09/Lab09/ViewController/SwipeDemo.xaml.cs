using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab09.ViewController
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwipeDemo : ContentPage
    {
        public SwipeDemo()
        {
            InitializeComponent();
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            string direction = e.Direction.ToString();
            switch (direction) {
                case "Right":
                    ((BoxView)sender).BackgroundColor = Color.Red;
                    break;
                case "Left":
                    ((BoxView)sender).BackgroundColor = Color.Yellow;
                    break;
                case "Up":
                    ((BoxView)sender).BackgroundColor = Color.Green;
                    break;
                case "Down":
                    ((BoxView)sender).BackgroundColor = Color.Blue;
                    break;
            }
            _label.Text = $"Has dezlizado: {e.Direction.ToString()}";
        }
    }
}