using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace BuscaminesApp
{



    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly int CELL_SIZE = 30;
        private const int FILES = 16;
        private const int COLUMNES = 16;
        private const int MINES = 40;
        private const int MINA = 9;

        private int[,] tauler;


        public MainPage()
        {
            this.InitializeComponent();

            initTauler();
        }

        private void initTauler()
        {
            tauler = new int[FILES, COLUMNES];
            int mines = 0;
            while (mines < MINES)
            {
                int f = new Random().Next(FILES);
                int c = new Random().Next(COLUMNES);
                if (tauler[f, c] != MINA)
                {
                    mines++;                
                    for(int k=-1 ; k<=1 ; k++)
                    {
                        for (int h = -1; h <=1 ; h++)
                        {
                            if (f + k < 0 || f + k >= FILES)    continue;
                            if( c + h < 0 || c + h >= COLUMNES) continue;
                            if (tauler[f + k, c + h] != MINA)
                            {
                                tauler[f + k, c + h]++;
                            }
                        }
                    }
                    tauler[f, c] = MINA;
                }
            }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            for (int files = 0; files < FILES; files++)
            {
                RowDefinition rowDef = new RowDefinition();
                rowDef.Height = new GridLength(CELL_SIZE);
                grid.RowDefinitions.Add(rowDef);
            }

            for (int columnes = 0; columnes < COLUMNES; columnes++)
            {
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.Width = new GridLength(CELL_SIZE);
                grid.ColumnDefinitions.Add(colDef);
            }
            int mineNumber = 0;

            //----------------------------------------------------------
            // Dibuixar línies horitzontals
            int x1 = 0;
            int x2 = COLUMNES * CELL_SIZE;
            for(int files = 0; files <= FILES; files++)
            {
                int y= files * CELL_SIZE;
                Line l = new Line();
                l.X1 = x1;
                l.Y1 = y;
                l.X2 = x2;
                l.Y2 = y;
                l.Stroke = new SolidColorBrush(Colors.Gray);
                cnv.Children.Add(l);

                l = new Line();
                l.Y1 = x1;
                l.X1 = y;
                l.Y2 = x2;
                l.X2 = y;
                l.Stroke = new SolidColorBrush(Colors.Gray);
                cnv.Children.Add(l);
            }



            //----------------------------------------------------------
            // Dibuixar mines i números
            for (int f = 0; f < FILES; f++)
            {
                for (int c = 0; c < COLUMNES; c++)
                {
                    TextBlock b = new TextBlock();
                    Grid.SetColumn(b, c);
                    Grid.SetRow(b, f);
                    b.FontFamily = new FontFamily("MINE-SWEEPER");
                    grid.Children.Add(b);
                    mineNumber = tauler[f,c];                       
                    b.Text = getTextFromNumber(mineNumber);
                    b.Foreground = getColorFromNumber(mineNumber);
                    b.FontSize = 15;
                    b.VerticalAlignment = VerticalAlignment.Center;
                    b.HorizontalAlignment = HorizontalAlignment.Center;
                    b.Padding = new Thickness(0);
                }
            }

        }

        private string getTextFromNumber(int mineNumber)
        {
            switch (mineNumber)
            {
                case 0:return "";
                case MINA: return "*";
                default: return mineNumber + "";
            }
        }

        private Brush getColorFromNumber(int mineNumber)
        {
            Color c;
            switch (mineNumber)
            {
                case 1: c = Colors.Blue; break;
                case 2: c = Colors.Green; break;
                case MINA: c = Colors.Black; break;
                default: c = Colors.Red; break;
            }
            return new SolidColorBrush(c);
        }
    }
}
