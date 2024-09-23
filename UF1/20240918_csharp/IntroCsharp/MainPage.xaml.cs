﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
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

namespace IntroCsharp
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int fantasticaVariable = 123;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            int variableLocalissima = 234;
            txbSortida.Text = "Hola bon dia";
            Debug.WriteLine("Saludos desde el Averno");



            int i = 0;
            float f = 234.3f;

            decimal nomina = 234.23M;

            var cosaQueMeDaLaGana = 123;

            String nom = "Paquito";
            nom = nom + " Mas Cositas";

            String missatge = $"Estimado señor {nom}, vagi vosté a parir panteres.";


            String cadenaMoltLlarga = @"SELECT * FROM  
                                        EMP WHERE EMP_NO = 123
                                        AND OFICI = 'COMERCIAL'";


            String ip = "123.12.43.123";
            String[] octets = ip.Split(".");

            String numero = "2323";
            numero = numero.PadLeft(10, ' ');

            
            txbSortida.Text = missatge;

            //---------------------------------------------------------
            // Conversió de número a cadena
            float numeraco = 234.234f;
            // Conversió usant l'idioma per defecte
            txbSortida.Text = "" + numeraco.ToString("#########.00");
            // Conversió usant l'idioma customitzat
            CultureInfo us = new CultureInfo("en-US");
            txbSortida.Text = ""+numeraco.ToString("#########.00",us);
            //---------------------------------------------------------
            decimal resultat = 0;
            if(Decimal.TryParse("123,7", out resultat))
            {
                txbSortida.Text = "Felicitats";
            } else
            {
                Debug.WriteLine("Maleït número !!!");
            }
            //---------------------------------------------------------
            DateTime ara = DateTime.Now;
            DateTime avui = DateTime.Today;
            DateTime unaData = new DateTime(2025, 09, 12, 4, 56, 23);
            CultureInfo ca = new CultureInfo("en-UK");
            String dataAmbFormat = ara.ToString("dd/MMMM/yyyy HH:mm:ss",ca);
            txbSortida.Text = dataAmbFormat;
            //--------------------------------------------------------------
            try
            {
                DateTime laData = DateTime.ParseExact(dataAmbFormat, "dd/MMMM/yyyy HH:mm:ss", ca);
            }
            catch(Exception e)
            {

            }

        }
    }
}
