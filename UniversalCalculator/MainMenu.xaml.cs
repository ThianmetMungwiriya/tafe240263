﻿using System;
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
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		private void mortagecalButton_Click(object sender, RoutedEventArgs e)
		{
			Mortgage MortgagePage = new Mortgage();
			this.Content = MortgagePage;
		}

		private void mathcalButton_Click(object sender, RoutedEventArgs e)
		{
			MainPage MainPagePage = new MainPage();
			this.Content = MainPagePage;
		}

		private void currencyButton_Click(object sender, RoutedEventArgs e)
		{
			currency currencyPage = new currency();
			this.Content = currencyPage;
		}
	}
}
