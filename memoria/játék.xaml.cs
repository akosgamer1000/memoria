using System;
using System.Collections.Generic;
using System.Globalization;
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
		List<Image> semmiband = new List<Image>();
		List<Image> band = new List<Image>();
		Button felnyittot1 = null;
		Button felnyittot2 = null;
		int cant = 0;
        public játék()
		{
			InitializeComponent();
			greadgeneration();
			imageload();
			shuffle();
		}
		public void greadgeneration()
		{
			for (int i = 0; i < s; i++)
			{
				racs.ColumnDefinitions.Add(new ColumnDefinition());


				racs.RowDefinitions.Add(new RowDefinition());

			}
			int x = 1;
			for (int i = 0; i < s; i++)
			{
				for (int j = 0; j < s; j++)
				{
					Button b = new Button();
					//b.Content = new BitmapImage(new Uri("letöltés.jpg",UriKind.RelativeOrAbsolute));
					Image img = new Image();
					img.Stretch = Stretch.Fill;
					img.Source = new BitmapImage(new Uri("letöltés.jpg", UriKind.RelativeOrAbsolute));
					b.Content = img;
                    b.Click += Button_Click;

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

			for (int i = 1; i < (s * s) / 2 + 1; i++)
			{
				try
				{

					Image s = new Image();
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
			List<Image> imagespair1 = new List<Image>(images); ;
            List<Image> imagespair2 = new List<Image>(images); ;
			int i = 0;
  
            foreach (Button b in racs.Children)
			{
				int ran = random.Next(0, imagespair1.Count);
				if(imagespair1.Count > 0)
				{
					b.Tag = ran;
					imagespair1.RemoveAt(ran);
					i++;
					
				}
				else if(imagespair2.Count > 0) 
				{
                    int ran2 = random.Next(0, imagespair2.Count);
                    b.Tag = ran2;
                    imagespair2.RemoveAt(ran2);
					i++;
                }
				else
				{
					break;
				}
			}
			


        }
        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button clickedButton = sender as Button;
				if (cant==0)
				{
                    
                    felnyittot1 = sender as Button;
					if (felnyittot1 != null)
					{

                    felnyittot1.Visibility = Visibility.Visible;
					}
					cant++;
                    SwitchImage(clickedButton);
                }
				else if(cant==1)
				{
                    felnyittot2 = sender as Button;
                    if (felnyittot2 != null)
					{
						felnyittot2.Visibility = Visibility.Visible;
					}
                    
                    
					cant++;
                    SwitchImage(clickedButton);
                    
                    check();

                }
               
            }
			
        }
		private void SwitchImage(Button button)
{
    if (button.Content is Image)
    {
        Image image = button.Content as Image;
        BitmapImage newSource = null;


				try
				{
					newSource = new BitmapImage(new Uri("pack://application:,,,/image/" +(Convert.ToInt32(  button.Tag)+1) + ".jpg"));
                }
				catch {

                    newSource = new BitmapImage(new Uri("pack://application:,,,/image/" + (Convert.ToInt32(button.Tag) + 1) + ".png"));
                }
   
        
        image.Source = newSource;
    }
}
		public async void check()
		{
			await Task.Delay(1000);
            cant = 0;
			Console.WriteLine(felnyittot1.Tag);
            Console.WriteLine(felnyittot2.Tag);

            if (felnyittot1.Tag.ToString() == felnyittot2.Tag.ToString()) {
                Console.WriteLine("beléptem");
                felnyittot1.Visibility= Visibility.Collapsed;
				felnyittot2.Visibility= Visibility.Collapsed;
			
			}
			else
			{
                Image img = new Image();
                img.Stretch = Stretch.Fill;
                img.Source = new BitmapImage(new Uri("letöltés.jpg", UriKind.RelativeOrAbsolute));
                Image img2 = new Image();
                img2.Stretch = Stretch.Fill;
                img2.Source = new BitmapImage(new Uri("letöltés.jpg", UriKind.RelativeOrAbsolute));
                felnyittot1.Content = img;
				felnyittot2.Content = img2;
				
			}
		}
		

    }
    }
