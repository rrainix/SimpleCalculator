using SimpleCalculator;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        private DataTable DataTable = new DataTable();
        private string SavePath = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            FileManager.Initialize();

            SavePath = System.IO.Path.Combine(FileManager.AppDataPath, "SimpleCalculator", "Meta.txt");

            Display.Text = FileManager.LoadString(SavePath);
            RegisterButtonEvents();
            this.Closing += MainWindow_OnClosing;
        }

        private void MainWindow_OnClosing(object sender, CancelEventArgs e)
        {
            UnRegisterButtonEvents();
            FileManager.SaveString(SavePath, Display.Text);
        }

        private void RegisterButtonEvents()
        {
            BtnZero.Click += BtnZero_OnClick;
            BtnOne.Click += BtnOne_OnClick;
            BtnTwo.Click += BtnTwo_OnClick;
            BtnThree.Click += BtnThree_OnClick;
            BtnFour.Click += BtnFour_OnClick;
            BtnFive.Click += BtnFive_OnClick;
            BtnSix.Click += BtnSix_OnClick;
            BtnSeven.Click += BtnSeven_OnClick;
            BtnEight.Click += BtnEight_OnClick;
            BtnNine.Click += BtnNine_OnClick;

            BtnPlus.Click += BtnPlus_OnClick;
            BtnMinus.Click += BtnMinus_OnClick;
            BtnMultiply.Click += BtnMultiply_OnClick;
            BtnDivide.Click += BtnDivide_OnClick;
            BtnModulo.Click += BtnModulo_OnClick;

            BtnClear.Click += BtnClear_OnClick;
            BtnDelete.Click += BtnDelete_OnClick;
            BtnCalculate.Click += BtnCalculate_OnClick;
        }
        private void UnRegisterButtonEvents()
        {
            BtnZero.Click -= BtnZero_OnClick;
            BtnOne.Click -= BtnOne_OnClick;
            BtnTwo.Click -= BtnTwo_OnClick;
            BtnThree.Click -= BtnThree_OnClick;
            BtnFour.Click -= BtnFour_OnClick;
            BtnFive.Click -= BtnFive_OnClick;
            BtnSix.Click -= BtnSix_OnClick;
            BtnSeven.Click -= BtnSeven_OnClick;
            BtnEight.Click -= BtnEight_OnClick;
            BtnNine.Click -= BtnNine_OnClick;

            BtnPlus.Click -= BtnPlus_OnClick;
            BtnMinus.Click -= BtnMinus_OnClick;
            BtnMultiply.Click -= BtnMultiply_OnClick;
            BtnDivide.Click -= BtnDivide_OnClick;
            BtnModulo.Click -= BtnModulo_OnClick;

            BtnClear.Click -= BtnClear_OnClick;
            BtnDelete.Click -= BtnDelete_OnClick;
            BtnCalculate.Click -= BtnCalculate_OnClick;
        }

        private void AddDisplayText<T>(T obj) // Note: Generic function for adding the numbers and operators to the display text
        {
            Display.Text += obj?.ToString() ?? "";
        }

        private void BtnCalculate_OnClick(object sender, RoutedEventArgs e)
        {
            Display.Text = DataTable.Compute(Display.Text, null).ToString(); // Warning: this function may not be 100% DOS safe
        }

        private void BtnClear_OnClick(object sender, RoutedEventArgs e)
        {
            Display.Text = string.Empty;
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            string text = Display.Text;
            int count = text[text.Length - 1] == ' ' ? 3 : 1;
            int startIndex = text.Length - count;
            Display.Text = Display.Text.Remove(startIndex, count);
        }

        #region Operator Button Events
        private void BtnPlus_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(" + ");
        }
        private void BtnMinus_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(" - ");
        }
        private void BtnMultiply_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(" * ");
        }
        private void BtnDivide_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(" / ");
        }

        private void BtnModulo_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(" % ");
        }
        #endregion

        #region Number Button Events
        private void BtnZero_OnClick( object sender, RoutedEventArgs e)
        {
            AddDisplayText(0);
        }
        private void BtnOne_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(1);
        }
        private void BtnTwo_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(2);
        }
        private void BtnThree_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(3);
        }
        private void BtnFour_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(4);
        }
        private void BtnFive_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(5);
        }
        private void BtnSix_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(6);
        }
        private void BtnSeven_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(7);
        }
        private void BtnEight_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(8);
        }
        private void BtnNine_OnClick(object sender, RoutedEventArgs e)
        {
            AddDisplayText(9);
        }
        #endregion
    }
}