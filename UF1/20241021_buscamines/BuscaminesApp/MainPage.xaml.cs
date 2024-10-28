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
using Windows.UI.Xaml.Media.Imaging;
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

        public enum MODE
        {
            IN_GAME,
            GAME_OVER
        }

        private MODE mode;

        public MODE Mode
        {
            get { return mode; }
            set { 
                switch(value)
                {
                    case MainPage.MODE.IN_GAME:break;
                    
                    case MainPage.MODE.GAME_OVER:break;
                        
                }
                mode = value; // !!!
            }
        }


        private readonly int CELL_SIZE = 32;
        private const int FILES = 16;
        private const int COLUMNES = 16;
        private const int MINES = 40;
        private const int MINA = 9;

        private int[,] tauler;
        private Dictionary<Punt,Image> imageList = new Dictionary<Punt, Image>();



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
                    b.Visibility = Visibility.Collapsed;
                    //-----------------------------------------------
                    // Tapem ara el número amb la imatge
                    //< Image Source = "/Assets/tile.png" />
                    Image im = new Image();
                    BitmapImage i = new BitmapImage();
                    i.UriSource = new Uri("ms-appx://BuscaminesApp/Assets/tile.png");
                    i.DecodePixelHeight = CELL_SIZE;
                    i.DecodePixelWidth = CELL_SIZE;
                    i.DecodePixelType = DecodePixelType.Logical;
                    im.Source = i;
                    im.Stretch = Stretch.UniformToFill;
                    im.MaxHeight = CELL_SIZE;
                    im.MaxWidth = CELL_SIZE;
                    
                    im.Height = CELL_SIZE;
                    im.Width= CELL_SIZE;
                    Grid.SetColumn(im, c);
                    Grid.SetRow(im, f);
                    grid.Children.Add(im);

                    

                    im.Tapped += Im_Tapped;
                    im.RightTapped += Im_RightTapped;

                    Punt p = new Punt(f, c);
                    p.isFlagged = false;
                    p.MinaText = b; // desem la referència del textbox que està sota l'Image
                    im.Tag = p;
                    imageList.Add(p, im);
                }
            }

        }

        private void Im_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            if (Mode == MODE.GAME_OVER) return;

            Image tapa = (Image)sender;
            Punt p = (Punt)tapa.Tag;
            BitmapImage i = new BitmapImage();
            if (p.isFlagged)
            {
                i.UriSource = new Uri("ms-appx://BuscaminesApp/Assets/tile.png");
            } else
            {
                i.UriSource = new Uri("ms-appx://BuscaminesApp/Assets/flag.png");
            }
            tapa.Source = i;
            p.isFlagged = !p.isFlagged;

        }

        private void Im_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Mode == MODE.GAME_OVER) return;

            Image i = (Image)sender;
            Punt p = (Punt)i.Tag;
            if (p.isFlagged) return; // No podem clicar sobre banderes
            
            i.Visibility = Visibility.Collapsed;
            p.MinaText.Visibility=Visibility.Visible;
            int valor = tauler[p.F, p.C];
            if(valor == MINA)
            {
                Mode = MODE.GAME_OVER;

            } else
            {
                destapa(p);
            }            
        }

        private void destapa(Punt p)
        {
            if (p.F < 0 || p.F >= FILES || p.C < 0 || p.C >= COLUMNES) return;
            

            imageList[p].Visibility = Visibility.Collapsed;
            p.MinaText.Visibility= Visibility.Visible;

            if (tauler[p.F, p.C] > 0) return;

            int[,] mods = { {  0,  1 }, 
                            {  0, -1 }, 
                            { -1,  0 }, 
                            {  1,  0 }, 
                            /*/{  1,  1 }, 
                            { -1,  1 }, 
                            {  1, -1 }, 
                            { -1, -1 }*/ };
            for(int i=0;i<mods.GetLength(0);i++)
            {
                Punt n = new Punt(p.F + mods[i,0], p.C + mods[i, 1]);
                if (imageList.ContainsKey(n) && imageList[n].Visibility != Visibility.Visible) continue;

                if (imageList.ContainsKey(n)) {
                    Punt complet = imageList[n].Tag as Punt;
                    destapa(complet);
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
