using Lib.EF.Service;
using Lib.Model.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Demo_EF_ORM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs ex)
        {
            ContextFactory fabrica = new ContextFactory();
            var context = fabrica.CreateDbContext();
            // vamos al "var"

            //inicialitzarDades(context);

            //List<Empleat> empleats = context.Empleats.ToList();
            List<Empleat> empleats = context.Empleats.Include(e => e.Dept).ToList();

            drgEmpleats.ItemsSource = empleats;

            //---------------------------------------------------------
            Departament informatica = context.Departaments.Include(d=>d.Empleats).Single(d => d.Nom.Equals("Informatica"));

            drgEmpleatsInformatica.ItemsSource = informatica.Empleats;

            List<Empleat> empleatsInformatica = context.Empleats.Where(e => e.Dept.Id == 10 ).ToList();
            drgEmpleatsInformatica.ItemsSource = empleatsInformatica;


            List<Empleat> polPower = context.Empleats.FromSqlRaw("select * from empleats where Nom='Pol'").ToList();

            var resultat = (from e in context.Empleats
                                           join
                                                 d in context.Departaments on e.Dept equals d
                                           where e.Nom.Equals("Pol")
                                           select new {
                                              e_nom = e.Nom,  
                                              e_salari =  e.Salari,
                                              d_nom = d.Nom
                                                 }
                                            ).ToList();

        }

        private static void inicialitzarDades(EmpresaDBContext context)
        {
            Departament dInfo = new Departament()
            {
                Nom = "Informatica"
            };
            Departament dVendes = new Departament()
            {
                Nom = "Vendes"
            };

            context.Departaments.Add(dInfo);
            context.Departaments.Add(dVendes);

            context.Empleats.Add(new Empleat { Nom = "Pol", DataNaix = DateTime.Now, Salari = 0, Dept = dInfo });
            context.Empleats.Add(new Empleat { Nom = "Alba", DataNaix = DateTime.Now, Salari = 10, Dept = dInfo });
            context.Empleats.Add(new Empleat { Nom = "Manuel", DataNaix = DateTime.Now, Salari = 5, Dept = dInfo });

            context.SaveChanges();
        }
    }
}
