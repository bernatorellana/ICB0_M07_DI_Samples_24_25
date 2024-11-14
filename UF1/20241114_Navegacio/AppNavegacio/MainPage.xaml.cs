﻿using System;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AppNavegacio
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Dictionary<string, string> data = new Dictionary<string, string>();
        Persona p = new Persona("Maria", "Sánchez");
        public MainPage()
        {
            this.InitializeComponent();
            data.Add("nom", "Maria");
            data.Add("cognom", "Fuentes Pardas");
        }



        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //frm.Navigate(typeof(MainPage), p);
        }

        private void NavigationView_ItemInvoked(NavigationView sender, 
            NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItem item = (NavigationViewItem)sender.SelectedItem;
            frm.Navigate(Type.GetType(item.Tag.ToString()), p);
        }
    }
}
