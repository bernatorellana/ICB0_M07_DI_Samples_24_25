using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace _20241007_Llibres
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


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/Dracula.txt"));
            using (var inputStream = await file.OpenReadAsync())
            using (var classicStream = inputStream.AsStreamForRead())
            using (var streamReader = new StreamReader(classicStream))
            {
                DateTime before = DateTime.Now;
                Dictionary<String, Int32> paraulesUniques = new Dictionary<String, Int32>();

                while (streamReader.Peek() >= 0)
                {
                    char[] separadors = new char[] { ' ', '.', ':', ';', '-', '?', '!' , '"', '\'', '#'};
                    String[] paraules = streamReader.ReadLine().ToLower().Split(
                        separadors, StringSplitOptions.RemoveEmptyEntries);
                    //Debug.WriteLine(string.Format("the line is {0}", streamReader.ReadLine()));
                    
                    foreach(var paraula in paraules)
                    {
                        int recompte = 0;
                        if (paraulesUniques.ContainsKey(paraula))
                        {
                            recompte = paraulesUniques[paraula];
                        }
                        recompte++;
                        paraulesUniques[paraula] = recompte;
                    }
                }
                
                List<KeyValuePair<String, Int32>> valors = paraulesUniques.ToList();
                valors.Sort( (valor1, valor2) =>  valor2.Value - valor1.Value);
                for(int i=0;i<10;i++)
                {
                    Debug.WriteLine(valors[i]);
                }


                DateTime after = DateTime.Now;

                TimeSpan t = after-before;
                double ms = t.TotalMilliseconds;
                Debug.WriteLine("El número de paraules és :" + paraulesUniques.Count);
                Debug.WriteLine("Execution time:"+ms);

            }
        }
    }
}
