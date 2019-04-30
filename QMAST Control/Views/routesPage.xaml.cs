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
using RoutePage.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QMAST_Control.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class routesPage : Page
    {
        public routesPage()
        {
            this.InitializeComponent();

            using (var db = new RouteContext())
            {
                db.Database.Migrate();
            }
        }
            private void Page_Loaded(object sender, RoutedEventArgs e)
            {
            //Debug.Print("entered routes page loaded");
            using (var db = new RouteContext())
                {
                    Routes.ItemsSource = db.Routes.ToList();
                }
            }

            private void Add_Click(object sender, RoutedEventArgs e)
            {
                using (var db = new RouteContext())
                {
                    var route = new Route { RouteId = NewRoute.Text };
                    db.Routes.Add(route);
                    db.SaveChanges();

                    Routes.ItemsSource = db.Routes.ToList();
                }
            }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button TempButton = sender as Button;
            string Route_Id = TempButton.Content as string;
            Debug.Print(Route_Id);
            MyFrame.Navigate(typeof(EditRoutePage), Route_Id);
        }

    }
}
