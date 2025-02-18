﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;
using static BuscaminesApp.View.UIBoard;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace BuscaminesApp
{

    


    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            imgFace.Source = new BitmapImage(
                new Uri("ms-appx:///Assets/face.png")
            );
            board.Mode = MODE.READY;
        }

        private void board_OnGameOver(object sender, EventArgs e)
        {
            imgFace.Source = new BitmapImage(
                    new Uri("ms-appx:///Assets/face_ko.png")
                    );
        }

        private async void board_OnWin(object sender, EventArgs e)
        {
            imgFace.Source = new BitmapImage(
                new Uri("ms-appx:///Assets/face_win.png")
            );
            MessageDialog md = new MessageDialog("YOU WIN!");
            await md.ShowAsync();
        }
    }
}
