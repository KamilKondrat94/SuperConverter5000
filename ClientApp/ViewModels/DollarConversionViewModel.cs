using ClientApp.ConversionService;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClientApp.ViewModels
{
    public partial class DollarConversionViewModel : Window, INotifyPropertyChanged
    {
        public string EnteredValue { get; set; }
        public string ConvertedValue { get; set; }

        private readonly IConvertDollarNumericToText ConversionClient;

        public ICommand RunConversionCommand { get; set; }
        public ICommand ClearFormCommand { get; set; }

        public DollarConversionViewModel()
        {
            InitializeComponent();
            DataContext = this;

            ConversionClient = new ConvertDollarNumericToTextClient();
            RunConversionCommand = new DelegateCommand(RunConversionAction);
            ClearFormCommand = new DelegateCommand(ClearFormAction);
        }

        private void ClearFormAction(object obj)
        {
            EnteredValue = string.Empty;
            ConvertedValue = string.Empty;
            OnPropertyChanged(nameof(EnteredValue));
            OnPropertyChanged(nameof(ConvertedValue));
        }

        private void RunConversionAction()
        {
            if (string.IsNullOrEmpty(EnteredValue))
                return;
            try
            {
                ConvertedValue = ConversionClient.Convert(EnteredValue);
            }
            catch(ProtocolException e)
            {
                ConvertedValue = $"Exception occured!\n{e.Message}";
            }
            finally
            {
                OnPropertyChanged(nameof(ConvertedValue));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            var tb = sender as TextBox;
            string currentText = tb.Text.Insert(tb.SelectionStart, e.Text);
            Regex regex = new Regex("^[0-9]{1,9}(,[0-9]{0,2})?$");
            e.Handled = !regex.IsMatch(currentText);
        }
    }
}
