using System.Collections.Generic;
using System.Windows;
using Microsoft.Maps.MapControl.WPF;
using System.Windows.Media;

namespace BingMaps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(List<Microsoft.Maps.MapControl.WPF.Location> coordinates, bool userIDSelected)
        {
            InitializeComponent();


            for (int i = 0; i < coordinates.Count; i++)
            {
                Pushpin pushpin = new Pushpin();

                if (userIDSelected && i == coordinates.Count - 1)
                {
                    pushpin.Background = new SolidColorBrush(Colors.Red);
                } 
                else
                {
                    pushpin.Background = new SolidColorBrush(Colors.Blue);
                }

                pushpin.Location = coordinates[i];
                this.bingMap.Children.Add(pushpin);
            }
           
        }
    }
}
