using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTutorials.MarkupExtensions
{
    [ContentProperty (nameof(Source))]
    public class EmbeddedImage : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(Source))
                return null;

            return ImageSource.FromResource(Source);
        }
    }
}
