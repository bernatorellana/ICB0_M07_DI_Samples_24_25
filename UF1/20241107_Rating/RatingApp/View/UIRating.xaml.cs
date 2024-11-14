using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace RatingApp.View
{
    public sealed partial class UIRating : UserControl
    {

        private const int MAX = 5;
        public UIRating()
        {
            this.InitializeComponent();
        }



        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UIRating), new PropertyMetadata(0, ValueChangedStatic));

        private static void ValueChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIRating obj = (UIRating)d;
            obj.ValueChanged(d, e);
        }

        private void ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(stc.Children.Count == 0) crearBoles();

            for (int i = 0; i < MAX; i++)
            {
                UIBall bola = (UIBall)stc.Children[i];
                bola.Enabled = (i < Value);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //crearBoles();
        }

        private void crearBoles()
        {
            stc.Children.Clear();
            for (int i = 0; i < MAX; i++)
            {
                UIBall bola = new UIBall();
                bola.Enabled = (i < Value);
                bola.Tag = i + 1;
                bola.Tapped += Bola_Tapped;
                stc.Children.Add(bola);
            }
        }

        private void Bola_Tapped(object sender, TappedRoutedEventArgs e)
        {
            UIBall bola = (UIBall)sender;
            this.Value = (int)bola.Tag;
        }
    }
}
