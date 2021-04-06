using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace Lab5
{
    [Preserve(AllMembers = true)]
    [ContentProperty(nameof(Source))]
    class ImagenResourceExtencion : IMarkupExtension
    {
        public String Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) 
        {
            if (Source == null) {
                return null;
            }

            var imageSource = ImageSource.FromResource(Source,
                typeof(ImagenResourceExtencion).GetTypeInfo().Assembly);
            return imageSource;
        }
    }
}
