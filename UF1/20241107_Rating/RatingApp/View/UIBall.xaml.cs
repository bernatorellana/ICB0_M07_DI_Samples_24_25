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
    public sealed partial class UIBall : UserControl
    {
        public UIBall()
        {
            this.InitializeComponent();
        }



        public bool Enabled
        {
            get { return (bool)GetValue(DisabledProperty); }
            set { SetValue(DisabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Disabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisabledProperty =
            DependencyProperty.Register("Enabled", typeof(bool), typeof(UIBall), new PropertyMetadata(false, EnabledChangedStatic));

        private static void EnabledChangedStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UIBall uIBall = (UIBall)d;
            uIBall.imgOverlay.Visibility = uIBall.Enabled ? Visibility.Collapsed: Visibility.Visible;
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(UIBall), new PropertyMetadata(0));


    }
}
