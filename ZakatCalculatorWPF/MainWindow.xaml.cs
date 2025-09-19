using System;
using System.Windows;

namespace ZakatCalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateZakat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Read inputs
                float cash = float.Parse(CashInput.Text == "" ? "0" : CashInput.Text);
                float gold = float.Parse(GoldInput.Text == "" ? "0" : GoldInput.Text);
                float silver = float.Parse(SilverInput.Text == "" ? "0" : SilverInput.Text);
                float future = float.Parse(FutureAssetsInput.Text == "" ? "0" : FutureAssetsInput.Text);
                float invest = float.Parse(InvestmentsInput.Text == "" ? "0" : InvestmentsInput.Text);
                float borrow = float.Parse(BorrowedAmountInput.Text == "" ? "0" : BorrowedAmountInput.Text);
                float wages = float.Parse(UnpaidWagesInput.Text == "" ? "0" : UnpaidWagesInput.Text);
                float tax = float.Parse(AssetsInput.Text == "" ? "0" : AssetsInput.Text);

                // Calculate
                float totalAssets = cash + gold + silver + future + invest;
                float liabilities = borrow + wages + tax;
                float total = totalAssets - liabilities;

                if (total >= 478) // Nisab threshold
                {
                    float zakatAmount = total * 0.025f;
                    ResultText.Text = $"Zakat: {zakatAmount:C}";
                    EligibilityText.Text = "";
                }
                else
                {
                    ResultText.Text = "Zakat: 0";
                    EligibilityText.Text = "You are not eligible to pay zakat.";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter valid numbers in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
