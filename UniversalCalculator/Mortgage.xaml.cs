using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	public sealed partial class Mortgage : Page
	{
		public Mortgage()
		{
			this.InitializeComponent();
		}
		private double monthlyinterestcal(double yearlyinterrest)
		{
			double monthlyinterest;

			monthlyinterest = (yearlyinterrest/100)/ 12;

			return monthlyinterest;
		}
		
		private int totalmonthscal(int years, int months)
		{
			int totalmonths;
			totalmonths = months + (years * 12);
			return totalmonths;
		}

		private double repaymentcal(double p, int years, int months, int totalmonths, double monthlyinterest)
		{
			double repayment;
			repayment = p*((monthlyinterest * Math.Pow((1 + monthlyinterest), totalmonths))/(Math.Pow((1 + monthlyinterest), totalmonths)-1));
			return repayment;
		}

		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double p;
			int years;
			int months;
			int totalmonths;
			double yearlyinterest;
			double monthlyinterest;
			double repayment;


			try
			{
				p = double.Parse(principalborrowTextBox.Text);
			}
			catch (Exception theException)
			{
				var dialogMessage = new MessageDialog("Error! Please enter a valid number of Principal Borrow. " + theException.Message);
				await dialogMessage.ShowAsync();
				principalborrowTextBox.Focus(FocusState.Programmatic);
				principalborrowTextBox.SelectAll();
				return;
			}
			try
			{
				years = int.Parse(yearsTextBox.Text);
			}
			catch (Exception theException)
			{
				var dialogMessage = new MessageDialog("Error! Please enter a valid number of years. " + theException.Message);
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}
			try
			{
				months = int.Parse(monthsTextBox.Text);
			}
			catch (Exception theException)
			{
				var dialogMessage = new MessageDialog("Error! Please enter a valid number of months. " + theException.Message);
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}
			try
			{
				yearlyinterest = double.Parse(yearlyinterestrateTextBox.Text);
			}
			catch (Exception theException)
			{
				var dialogMessage = new MessageDialog("Error! Please enter a valid number of Yearly Interest. " + theException.Message);
				await dialogMessage.ShowAsync();
				yearlyinterestrateTextBox.Focus(FocusState.Programmatic);
				yearlyinterestrateTextBox.SelectAll();
				return;
			}

			totalmonths = totalmonthscal(years, months);

			monthlyinterest = monthlyinterestcal(yearlyinterest);

			monthlyinterestrateTextBox.Text = monthlyinterest.ToString();

			repayment = repaymentcal(p, years, months, totalmonths, monthlyinterest);

			monthlyrepaymentTextBox.Text = repayment.ToString();

		}
	}
}
