using System;
using System.Collections.Generic;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class currency : Page
    {
        public currency()
        {
            this.InitializeComponent();
        }

		double currencyAmount, finalAmount;

		private (double finalAmount, double rate, double reverseRate) Conversion(double currencyAmount)
		{
			currencyAmount = double.Parse(amountTextBox.Text);
			double rate = 0;
			double reverseRate = 0;
			var conversionCurrency = fromComboBox.SelectedItem.ToString();
			var resultCurrency = toComboBox.SelectedItem.ToString();

			if (conversionCurrency == "USD-US Dollar" && resultCurrency == "GBP-British Pound")
			{
				rate = 0.72872436;
				reverseRate = 1.371907;
			}
			else if (conversionCurrency == "GBP-British Pound" && resultCurrency == "USD-US Dollar")
			{
				rate = 1.371907;
				reverseRate = 0.72872436;
			}
			else if (conversionCurrency == "USD-US Dollar" && resultCurrency == "EUR-Euro")
			{
				rate = 0.85189982;
				reverseRate = 1.1739732;
			}
			else if (conversionCurrency == "EUR-Euro" && resultCurrency == "USD-US Dollar")
			{
				rate = 1.1739732;
				reverseRate = 0.85189982;
			}
			else if (conversionCurrency == "USD-US Dollar" && resultCurrency == "INR-India Rupee")
			{
				rate = 74.257327;
				reverseRate = 0.011492628;
			}
			else if (conversionCurrency == "INR-India Rupee" && resultCurrency == "USD-US Dollar")
			{
				rate = 0.011492628;
				reverseRate = 74.257327;
			}
			else if (conversionCurrency == "GBP-British Pound" && resultCurrency == "EUR-Euro")
			{
				rate = 1.1686692;
				reverseRate = 0.8556672;
			}
			else if (conversionCurrency == "EUR-Euro" && resultCurrency == "GBP-British Pound")
			{
				rate = 0.8556672;
				reverseRate = 1.1686692;
			}
			else if (conversionCurrency == "GBP-British Pound" && resultCurrency == "INR-India Rupee")
			{
				rate = 101.68635;
				reverseRate = 0.0098339397;
			}
			else if (conversionCurrency == "INR-India Rupee" && resultCurrency == "GBP-British Pound")
			{
				rate = 0.0098339397;
				reverseRate = 101.68635;
			}
			else if (conversionCurrency == "EUR-Euro" && resultCurrency == "INR-India Rupee")
			{
				rate = 87.00755;
				reverseRate = 0.013492774;
			}
			else if (conversionCurrency == "INR-India Rupee" && resultCurrency == "EUR-Euro")
			{
				rate = 0.013492774;
				reverseRate = 87.00755;
			}
			else if (conversionCurrency == resultCurrency)
			{
				rate = 1;
				reverseRate = 1;
			}

			finalAmount = rate * currencyAmount;

			return (finalAmount, rate, reverseRate);
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			MainMenu MainMenuPage = new MainMenu();
			this.Content = MainMenuPage;
		}

		private void conversionButton_Click(object sender, RoutedEventArgs e)
		{
			var conversionCurrency = fromComboBox.SelectedItem.ToString();
			var resultCurrency = toComboBox.SelectedItem.ToString();
			(double finalAmount, double rate, double reverseRate) = Conversion(currencyAmount);

			outputTextBlock.Text = amountTextBox.Text + " " + conversionCurrency + "=\n" +
				$"{finalAmount.ToString()}" + " " + resultCurrency + "\n" +
				$" 1 {conversionCurrency} = {rate} {resultCurrency}\n" +
				$" 1 {resultCurrency} = {reverseRate} {conversionCurrency}\n";
			outputTextBlock.FontSize = 30;
		}
	}
}
