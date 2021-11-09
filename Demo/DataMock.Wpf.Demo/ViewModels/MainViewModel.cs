using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace DataMock.Wpf.Demo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {

        }

        public int Id
        {
            get
            {
                return GetValue<int>();
            }
            set
            {
                SetValue(value);
            }
        }

        public string Name
        {
            get
            {
                return GetValue<string>();
            }
            set
            {
                SetValue(value);
            }
        }


        public Brush Color
        {
            get
            {
                return GetValue<Brush>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool HamburgerEnabled
        {
            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool SendEnabled
        {
            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
        }

        public bool ToggleEnabled
        {
            get
            {
                return GetValue<bool>();
            }
            set
            {
                SetValue(value);
            }
        }

        public PackIconKind Icon1
        {
            get
            {
                return GetValue<PackIconKind>();
            }
            set
            {
                SetValue(value);
            }
        }

        public ObservableCollection<string> ComboList
        {
            get
            {
                return GetValue<ObservableCollection<string>>();
            }
            set
            {
                SetValue(value);
            }
        }

        public ObservableCollection<Product> Products
        {
            get
            {
                return GetValue<ObservableCollection<Product>>();
            }
            set
            {
                SetValue(value);
            }
        }
    }
}
