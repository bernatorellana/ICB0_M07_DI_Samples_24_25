using DemoMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DemoMVVM.View.transformers
{
    internal class Sexe2RadioTransform: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            SexeEnum s;
            switch((string) parameter)
            {
                case "D": s = SexeEnum.DONA;break;
                case "H": s = SexeEnum.HOME;break;
                default: s = SexeEnum.NO_DEFINIT;break;
            }
            return ((SexeEnum)value)==s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            SexeEnum s;
            switch ((string)parameter)
            {
                case "D": s = SexeEnum.DONA; break;
                case "H": s = SexeEnum.HOME; break;
                default: s = SexeEnum.NO_DEFINIT; break;
            }
            // En aquest cas value és IsChecked ( boolean )
            if ((bool?)value == true)
            {
                // Si el radiobutton es selecciona, canviem el sexe.
                return s;
            } else
            {
                // Si el radiobutton es deselecciona, no cal fer res.
                return DependencyProperty.UnsetValue;
            }
            
        }
    }
}
