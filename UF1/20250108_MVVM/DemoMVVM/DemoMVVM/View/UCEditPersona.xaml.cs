using DemoMVVM.Model;
using DemoMVVM.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace DemoMVVM.View
{
    public sealed partial class UCEditPersona : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public UCEditPersona()
        {
            this.InitializeComponent();
        }

        public PersonaViewModel PersonaEnEdicio { get; private set; }

        public PersonaViewModel LaPersona
        {
            get { return (PersonaViewModel)GetValue(LaPersonaProperty); }
            set { SetValue(LaPersonaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LaPersona.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LaPersonaProperty =
            DependencyProperty.Register("LaPersona", typeof(PersonaViewModel), typeof(UCEditPersona), new PropertyMetadata(null, OnPersonaChangedCallbackStatic));

        private static void OnPersonaChangedCallbackStatic(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UCEditPersona u = (UCEditPersona)d;
            u.OnPersonaChangedCallback(d,e);
        }

        private void OnPersonaChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (PersonaEnEdicio == null || LaPersona.Id != PersonaEnEdicio.Id)
            {
                PersonaEnEdicio = new PersonaViewModel(LaPersona);
            }
        }

        


    }
}
