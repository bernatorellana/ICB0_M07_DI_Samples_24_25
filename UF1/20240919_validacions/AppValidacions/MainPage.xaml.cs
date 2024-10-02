using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.Mime.MediaTypeNames;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AppValidacions
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
            List<int> list = new List<int>();
            for (int dia = 1; dia < 32; dia++)
            {
                list.Add(dia);
            }
            cboDia.ItemsSource = list;
            //*********************************************
            List<string> mesos = new List<string>();
            DateTime dateTime = new DateTime(2024, 01, 01);
            for (int i = 0; i < 12; i++)
            {
                mesos.Add(dateTime.ToString("MMMM"));
                dateTime = dateTime.AddMonths(1);
            }
            cboMes.ItemsSource = mesos;

            //***********************************************
            DateTime avui = DateTime.Today;
            List<int> anys = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                anys.Add(avui.Year);
                avui = avui.AddYears(1);
            }
            cboAny.ItemsSource = anys;

        }

        // Caràcters / icones d'error i ok
        private const string ICON_OK = "";
        private const string ICON_ERR = "";


        private void txbAlcada_TextChanged(object sender, TextChangedEventArgs e)
        {
            float alcada;
            bool ok = float.TryParse(txbAlcada.Text, out alcada);
            mostrarIcona(ok, txtAlcadaIcon);
        }

        private void mostrarIcona(bool ok, TextBlock txtIcon)
        {
            txtIcon.Text = ok ? ICON_OK : ICON_ERR;
            txtIcon.Foreground = new SolidColorBrush(ok ? Colors.Green : Colors.Red);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern int MapVirtualKey(int uCode, uint uMapType);


        private void txbAlcada_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Mirem si el shift està apretat (crida simpàtica al code de Windows)
            bool shiftApretat = Window.Current.CoreWindow.GetKeyState(VirtualKey.Shift).HasFlag(CoreVirtualKeyStates.Down);
            
            // Convertim el codi de tecla a un caràcter per a que sigui més fàcil de gestionar
            char c = (char)MapVirtualKey((int)e.Key, (uint)2);
            //bool isNumber = (e.Key >= VirtualKey.Number0 && e.Key <= VirtualKey.Number9);

            e.Handled =  !(  
                        (c==',' && !txbAlcada.Text.Contains(",") ) ||  // Acceptem una coma si és la primera.
                        e.Key ==VirtualKey.Back ||                     // Acceptem esborrar (back).
                        (Char.IsNumber(c)&& !shiftApretat)              // Acceptem tecles numèriques si no està el shift apretat.
                    ); // true intercepta la tecla
        }

        private void txbDataNaix_LostFocus(object sender, RoutedEventArgs e)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("es-ES");
            DateTime data;
            bool ok = DateTime.TryParseExact(
                txbDataNaix.Text, 
                "dd/MM/yyyy", 
                culture,
                DateTimeStyles.None,
                out data);
            mostrarIcona(ok, txtDataNaixIcon);

            if (ok) {
                cboDia.SelectedValue = data.Day;
                cboMes.SelectedValue = data.ToString("MMMM");
                cboAny.SelectedValue = data.Year;
            }
        }

        private void txbDataNaix_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
  

            // Mirem si el shift està apretat (crida simpàtica al code de Windows)
            bool shiftApretat = Window.Current.CoreWindow.GetKeyState(VirtualKey.Shift).HasFlag(CoreVirtualKeyStates.Down);

            // Convertim el codi de tecla a un caràcter per a que sigui més fàcil de gestionar
            char c = (char)MapVirtualKey((int)e.Key, (uint)2);
            //bool isNumber = (e.Key >= VirtualKey.Number0 && e.Key <= VirtualKey.Number9);

            int numBarres = txbDataNaix.Text.Count(ch => ch == '/');
            
                e.Handled = !(
                        ((c == '/'|| c=='7'&&shiftApretat ) && numBarres<2) ||  // Acceptem una coma si és la primera.
                        e.Key == VirtualKey.Back ||                     // Acceptem esborrar (back).
                        (Char.IsNumber(c) && !shiftApretat)              // Acceptem tecles numèriques si no està el shift apretat.
                    ); // true intercepta la tecla
        }
    }
    }
