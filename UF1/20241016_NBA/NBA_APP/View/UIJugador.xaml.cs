using NBA_APP.Model;
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

namespace NBA_APP.View
{
    public sealed partial class UIJugador : UserControl
    {
        public UIJugador()
        {
            this.InitializeComponent();


        }



        public Jugador ThePlayer
        {
            get { return (Jugador)GetValue(ThePlayerProperty); }
            set { SetValue(ThePlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ThePlayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ThePlayerProperty =
            DependencyProperty.Register("ThePlayer", typeof(Jugador), typeof(UIJugador), new PropertyMetadata(null));





    }
}
