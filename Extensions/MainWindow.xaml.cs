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

namespace Extensions
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddToList_Click(object sender, RoutedEventArgs e)
        {
            string textValue = textBox.Text.Trim();
            if (!string.IsNullOrEmpty(textValue))
            {
                listBox.Items.Add(textValue);
                textBox.Clear();
                UpdateCounts();
            }
        }

        private void UpdateCounts()
        {
            int charCount = textBox.Text.Length;
            int listCount = listBox.Items.Count;
            charCountTextBlock.Text = $"Символов введено: {charCount}";
            listCountTextBlock.Text = $"Элементов в списке: {listCount}";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCounts();
        }
    }
}
