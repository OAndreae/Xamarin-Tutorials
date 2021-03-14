using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SwitchInput : ContentView
    {
        public static readonly BindableProperty GlyphProperty = BindableProperty.Create("Glyph", typeof(string), typeof(SwitchInput), "");
        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }


        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(SwitchInput), "");
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly BindableProperty HasBlankGlyphProperty = BindableProperty.Create("HasBlankGlyph", typeof(bool), typeof(SwitchInput));
        public bool HasBlankGlyph
        {
            get { return (bool)GetValue(HasBlankGlyphProperty); }
            set { SetValue(HasBlankGlyphProperty, value); }
        }

        public static readonly BindableProperty GlyphColorProperty = BindableProperty.Create("GlyphColor", typeof(Color), typeof(SwitchInput));
        public Color GlyphColor
        {
            get { return (Color)GetValue(GlyphColorProperty); }
            set { SetValue(GlyphColorProperty, value); }
        }


        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create("IsToggled", typeof(bool), typeof(SwitchInput));
        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

        public SwitchInput()
        {
            InitializeComponent();
            this.Margin = new Thickness(0, 4);
            BindingContext = this;
        }
    }
}