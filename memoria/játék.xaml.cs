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
using System.Windows.Shapes;

namespace memoria
{
	/// <summary>
	/// Interaction logic for játék.xaml
	/// </summary>
	public partial class játék : Window
	{

		int s = MainWindow.válsztott;
		List<Button> buttons = new List<Button>();
		List<Image> images = new List<Image>();
		List<Image> semmiband=new List<Image>();
		List<Image> band = new List<Image>();

		public játék()
		{
			InitializeComponent();
			greadgeneration();
			imageload();
			shuffle();
		}
		public void greadgeneration()
		{
			for(int i = 0; i < s; i++)
			{
				racs.ColumnDefinitions.Add(new ColumnDefinition());
				
				
				racs.RowDefinitions.Add(new RowDefinition());
				
			}
			int x = 1;
			for(int i = 0;i < s; i++)
			{
				for(int j = 0; j < s; j++)
				{
					Button b=new Button();
					//b.Content = new BitmapImage(new Uri("letöltés.jpg",UriKind.RelativeOrAbsolute));
					Image img = new Image();
					img.Stretch = Stretch.Fill;
					img.Source=new BitmapImage(new Uri("letöltés.jpg", UriKind.RelativeOrAbsolute));
					b.Content = img;
					
					x++;
					Grid.SetColumn(b, j);
					Grid.SetRow(b, i);
					racs.Children.Add(b);
				}
			}
			racs.ShowGridLines = true;
		}
		public void imageload()
		{
			
			for( int i = 1; i < (s*s)/2+1;i++)
			{
				try
				{

				Image s=new Image();
				s.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + i + ".jpg"));
					s.Stretch = Stretch.Fill;
				images.Add(s);
				}
				catch (Exception e)
				{

					Image s = new Image();
					s.Source = new BitmapImage(new Uri("pack://application:,,,/image/" + i + ".png"));
					s.Stretch = Stretch.Fill;
					images.Add(s);
				}

			}
		}
		public void shuffle()
		{
			Random random = new Random();
			foreach(Button s in racs.Children)
			{
				int a=random.Next(1,images.Count);
				int b=random.Next(1,images.Count);
				s.Content = images[random.Next(1,images.Count)];
				Button temp=new Button();
				temp.Content = images[a];
				s.Content=temp;
			}
			
		}
	}
}
