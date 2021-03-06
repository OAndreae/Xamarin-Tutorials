using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactBook.Extensions
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextInput : ContentView
    {
        public static readonly BindableProperty GlyphProperty = BindableProperty.Create("Glyph", typeof(string), typeof(TextInput), "");
        public string Glyph
        {
            get { return (string)GetValue(GlyphProperty); }
            set { SetValue(GlyphProperty, value); }
        }


        public static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(TextInput), "");
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }


        public static readonly BindableProperty TextProperty = BindableProperty.Create("Text", typeof(string), typeof(TextInput), "", BindingMode.TwoWay);
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }


        public static readonly BindableProperty HasBlankGlyphProperty = BindableProperty.Create("HasBlankGlyph", typeof(bool), typeof(TextInput));
        public bool HasBlankGlyph
        {
            get { return (bool)GetValue(HasBlankGlyphProperty); }
            set { SetValue(HasBlankGlyphProperty, value); }
        }

        public static readonly BindableProperty GlyphColorProperty = BindableProperty.Create("GlyphColor", typeof(Color), typeof(TextInput));
        public Color GlyphColor
        {
            get { return (Color)GetValue(GlyphColorProperty); }
            set { SetValue(GlyphColorProperty, value); }
        }


        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create("Keyboard", typeof(Keyboard), typeof(TextInput));
        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == GlyphProperty.PropertyName)
                glyph.Text = Glyph;
            if (propertyName == GlyphColorProperty.PropertyName)
                glyph.TextColor = GlyphColor;
            if (propertyName == LabelProperty.PropertyName)
            {
                sideLabel.Text = Label;
                entry.Placeholder = Label;
            }
            if (propertyName == TextProperty.PropertyName)
                entry.Text = Text;
            if (propertyName == HasBlankGlyphProperty.PropertyName)
                blankGlyph.IsVisible = HasBlankGlyph;
            if (propertyName == KeyboardProperty.PropertyName)
                entry.Keyboard = Keyboard;
        }

        public TextInput()
        {
            InitializeComponent();
            this.Margin = new Thickness(0, 1);
            BindingContext = this;
        }
    }
}