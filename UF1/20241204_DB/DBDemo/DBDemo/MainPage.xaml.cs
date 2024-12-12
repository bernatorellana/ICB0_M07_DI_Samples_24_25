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

        bool modeInsercio = false;


        public MainPage()
        {
            this.InitializeComponent();
            loadDepartaments();
        }

        private void loadDepartaments()
        {
            List<Dept> departaments = DeptDB.GetDepts();
            dtgDepts.ItemsSource = departaments;
            txbCount.Text = DeptDB.GetNumDepts() + "";
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
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (modeInsercio)
            {
                // MODE INSERT
                Dept d = new Dept(Int32.Parse(txbNum.Text), txbNom.Text, txbLoc.Text);

                DeptDB.Insert(d);
                modeInsercio = false;
            }
            else
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
            modeInsercio = true;
            dtgDepts.SelectedIndex = -1;
        }
    }
}
