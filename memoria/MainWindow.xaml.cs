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

namespace memoria
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static int válsztott;
		public MainWindow()
		{
			InitializeComponent();
			alap();
		}
		private void alap()
		{
			cbox.Items.Add(2);
			cbox.Items.Add(4);
			cbox.Items.Add(6);
			cbox.Items.Add(8);
		}
		private void change(object sender, SelectionChangedEventArgs e)
		{
			válsztott = int.Parse(  cbox.SelectedItem.ToString());
			játék j=new játék();
			j.Show();
			this.Hide();
		}
	}
}
