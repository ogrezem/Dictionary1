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

namespace TestTriggers1 {
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window {

		private int currentRowNumber = 1;
		private bool editMode;
		TextBox newWordField;
		TextBox newTranslateField;
		Button okButton;

		public MainWindow() {
			newWordField = new TextBox() {
				Height = 20,
				MinWidth = 100,
				Margin = new Thickness(0, 0, 10, 0)
			};
			newTranslateField = new TextBox() {
				 Height = 20,
				 MinWidth = 100,
			};
			okButton = new Button() {
				Background = Brushes.DarkGreen,
				Height = 20,
				Width = 70,
				Content = "Готово",
				Margin = new Thickness(10, 0, 0, 0)
			};
			okButton.Click += OkButtonClicked;
			InitializeComponent();
		}

		private void AddingButtonClick(object sender, RoutedEventArgs e) {
			if(!editMode) {
				editMode = true;
				dictGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
				TextBlock rowNumberText = new TextBlock() {
					Text = currentRowNumber.ToString(),
					FontSize = 16,
					Margin = new Thickness(2, 2, 10, 0)
				};
				Grid.SetColumn(rowNumberText, 0);
				Grid.SetRow(rowNumberText, currentRowNumber);
				dictGrid.Children.Add(rowNumberText);
				Grid.SetColumn(newWordField, 1);
				Grid.SetRow(newWordField, currentRowNumber);
				dictGrid.Children.Add(newWordField);
				Grid.SetColumn(newTranslateField, 2);
				Grid.SetRow(newTranslateField, currentRowNumber);
				dictGrid.Children.Add(newTranslateField);
				Grid.SetColumn(okButton, 3);
				Grid.SetRow(okButton, currentRowNumber);
				dictGrid.Children.Add(okButton);
			}
		}
		private void OkButtonClicked(object sender, RoutedEventArgs e) {
			dictGrid.Children.Remove(newWordField);
			dictGrid.Children.Remove(newTranslateField);
			dictGrid.Children.Remove(okButton);
			TextBlock wordText = new TextBlock() {
				Text = newWordField.Text,
				Margin = new Thickness(0, 3, 0, 0),
				FontSize = 16,
			};
			newWordField.Text = "";
			Grid.SetColumn(wordText, 1);
			Grid.SetRow(wordText, currentRowNumber);
			dictGrid.Children.Add(wordText);
			TextBlock translateText = new TextBlock {
				Text = newTranslateField.Text,
				Margin = new Thickness(10, 3, 0, 0),
				FontSize = 16,
			};
			newTranslateField.Text = "";
			Grid.SetColumn(translateText, 2);
			Grid.SetRow(translateText, currentRowNumber);
			dictGrid.Children.Add(translateText);
			currentRowNumber++;
			editMode = false;
		}
		/*
			TextBlock tb1 = new TextBlock() { Text = "няня" };
			tb1.Margin = new Thickness(5, 0, 0, 0);
			tb1.Foreground = Brushes.White;
			WrapPanel wr1 = new WrapPanel();
			wr1.Children.Add(tb1);
			rowsStack.Children.Add(wr1);
		 */
	}
}
