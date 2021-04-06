using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonCode : ContentPage
    {
        public ButtonCode()
        {
            InitializeComponent();

            Title = "Code Button Click";

            Label label = new Label
            {
                Text = "Click the Buttom below",
                FontSize = Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            Button button = new Button
            {
                Text = "Click the rotate Text ¡",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };

            button.Clicked += async (sender, e) =>
            {
                await label.RelRotateTo(360, 1000);
            };

            Content = new StackLayout
            {
                Children = {
                    label,
                    button
                }

            };
        }
    }
}