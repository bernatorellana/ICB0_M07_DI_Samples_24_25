using DB;
using Model.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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

namespace DBDemo
{

    



    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        private const int ITEMS_PER_PAGE = 4;

        private enum Mode
        {

            INICIAL,
            INSERCIO,
            MODIFICACIO
        }

        //bool modeInsercio = false;

        private Mode mode;

        private Mode ModeActual
        {
            get { return mode; }
            set { 
                mode = value;
                switch (mode)
                {
                    case Mode.INSERCIO:
                        btnAdd.Visibility = Visibility.Collapsed;
                        btnCancel.Visibility = Visibility.Visible;
                        btnSave.Visibility = Visibility.Visible;

                        dtgDepts.SelectedItem = null;
                        txbLoc.Text = "";
                        txbNom.Text = "";
                        txbNum.Text = "";
                        txbNom.IsEnabled = true;
                        txbLoc.IsEnabled = true;
                        break;

                    case Mode.INICIAL:
                        btnAdd.Visibility = Visibility.Visible;
                        btnCancel.Visibility = Visibility.Collapsed;
                        btnSave.Visibility = Visibility.Collapsed;

                        dtgDepts.SelectedItem = null;
                        txbLoc.Text = "";
                        txbNom.Text = "";
                        txbNum.Text = "";
                        txbNom.IsEnabled = false;
                        txbLoc.IsEnabled = false;

                        break;

                    case Mode.MODIFICACIO:
                        btnAdd.Visibility = Visibility.Collapsed;
                        btnCancel.Visibility = Visibility.Visible;
                        btnSave.Visibility = Visibility.Visible;
                        txbNom.IsEnabled = true;
                        txbLoc.IsEnabled = true;
                        break;
                    
                }
            }
        }



        public MainPage()
        {
            this.InitializeComponent();
            ModeActual = Mode.INICIAL;
            loadDepartaments();
        }

        private void loadDepartaments()
        {
            long numDept = DeptDB.GetNumDepts();

            int numPage = (int)MathF.Ceiling(numDept / (float)ITEMS_PER_PAGE);
            pgc.MaxPage = numPage;
            pgc.MinPage = Math.Min(numPage, 1);
            pgc.CurrentPage = Math.Min(pgc.MaxPage, pgc.CurrentPage);
            pgc.CurrentPage = Math.Max(pgc.MinPage, pgc.CurrentPage);

            List<Dept> departaments = DeptDB.GetDepts(pgc.CurrentPage,ITEMS_PER_PAGE);
            dtgDepts.ItemsSource = departaments;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dtgDepts.SelectedItem != null)
            {
                if(DeptDB.DeleteDept((dtgDepts.SelectedItem as Dept).DeptNo))
                {
                    loadDepartaments();
                }
            }
        }

        private void dtgDepts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dept d = dtgDepts.SelectedItem as Dept;
            if (d!=null)
            {                
                txbNum.Text = d.DeptNo.ToString();
                txbNom.Text = d.DName.ToString();
                txbLoc.Text = d.Loc.ToString();
                ModeActual = Mode.MODIFICACIO;
            } else
            {
                ModeActual = Mode.INICIAL;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ModeActual==Mode.INSERCIO)
            {
                // MODE INSERT
                Dept d = new Dept(0, txbNom.Text, txbLoc.Text);

                DeptDB.Insert(d);
                loadDepartaments();
                ModeActual = Mode.INICIAL;
            }
            else if (ModeActual == Mode.MODIFICACIO)
            {
                // MODE UPDATE
                Dept d = dtgDepts.SelectedItem as Dept;
                d.DName = txbNom.Text;
                d.Loc = txbLoc.Text;

                if (d != null)
                {
                    if (DeptDB.update(d))
                    {

                    }
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ModeActual = Mode.INSERCIO;
            dtgDepts.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ModeActual = Mode.INICIAL;
        }

        private void pgc_PageChanged(View.PaginationControl sender, EventArgs args)
        {
            loadDepartaments();
        }
    }
}
