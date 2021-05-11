using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace Lab10.ViewModel
{
    public class NamedColor
    {
        private NamedColor() { }

        public string Name { get; private set; }
        public string FriendlyName { get; private set; }
        public Color Color { get; private set; }
        public string RgbDisplay { get; private set; }
        static NamedColor() 
        {
            List<NamedColor> all = new List<NamedColor>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (FieldInfo fieldInfo in typeof(Color).GetRuntimeFields())
            {
                if (fieldInfo.IsPublic && fieldInfo.IsStatic
                    && fieldInfo.FieldType == typeof(Color)) 
                {
                    string name = fieldInfo.Name;
                    stringBuilder.Clear();
                    int index = 0;

                    foreach (char ch in name) 
                    {
                        if (index != 0 && Char.IsUpper(ch)) 
                        {
                            stringBuilder.Append("");
                        }
                        stringBuilder.Append(ch);
                        index++;
                    }

                    Color color = (Color)fieldInfo.GetValue(null);

                    NamedColor namedColor = new NamedColor
                    {
                        Name = name,
                        FriendlyName = stringBuilder.ToString(),
                        Color = color,
                        RgbDisplay = String.Format("{0:X2}-{1:X2}-{2:X2}",
                        (int)(255 * color.R), (int)(255 * color.G), (int)(255 * color.B))
                    };

                    all.Add(namedColor);
                }
            }
            all.TrimExcess();
            All = all;
        }

        public static IList<NamedColor> All { get; private set; }
    }
}
