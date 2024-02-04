using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Extensions
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string textValue;
        private ObservableCollection<string> itemsList;

        public MainWindow()
        {
            InitializeComponent();
            itemsList = new ObservableCollection<string>();
            DataContext = this;
        }

        public string TextValue
        {
            get { return textValue; }
            set
            {
                textValue = value;
                OnPropertyChanged(nameof(TextValue));
                OnPropertyChanged(nameof(CharCount));
            }
        }

        public int CharCount
        {
            get { return TextValue?.Length ?? 0; }
        }

        public int ItemsCount
        {
            get { return itemsList.Count; }
        }

        public ObservableCollection<string> ItemsList
        {
            get { return itemsList; }
            set
            {
                itemsList = value;
                OnPropertyChanged(nameof(ItemsList));
                OnPropertyChanged(nameof(ItemsCount));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            string text = TextValue;
            if (!string.IsNullOrWhiteSpace(text))
            {
                itemsList.Add(text);
                TextValue = string.Empty;
                OnPropertyChanged(nameof(ItemsList));
                OnPropertyChanged(nameof(ItemsCount));
                OnPropertyChanged(nameof(TextValue));
            }
        }
    }
}