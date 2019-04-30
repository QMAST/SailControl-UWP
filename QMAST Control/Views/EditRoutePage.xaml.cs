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
using System.Globalization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QMAST_Control.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditRoutePage : Page
    {
        public string parameter { get; set; }

        public string LatArray;
        public string LongArray;
        // public ObservableCollection<CustomETO_GridResult> resultCoord { get; set; }
        public EditRoutePage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            parameter = (string)e.Parameter;
           
            Debug.WriteLine(parameter);


        }
 
        private void Add_Data(object sender, RoutedEventArgs e)
        {
                using (var db = new RouteContext())
                {

                float LangC = float.Parse(LangCoord.Text, CultureInfo.InvariantCulture.NumberFormat);
                float LongC = float.Parse(LongCoord.Text, CultureInfo.InvariantCulture.NumberFormat);
                Coordinate coord = new Coordinate { Latitude = LangC, Longitude = LongC, RouteId = parameter };
                    db.Coordinates.Add(coord);
                    db.SaveChanges();
            

              var dispCoord = db.Coordinates.Where(a => a.RouteId==parameter).ToList();
                foreach(var result in dispCoord)
                {
                    string tlong = Convert.ToString(result.Longitude);
                    string tlat = Convert.ToString(result.Latitude);
                    
                    //proves that the points are being added to the database--> still need to creatue UI to display it 
                    Debug.WriteLine("= latitude", tlat);
                    Debug.WriteLine("= longitude", tlat);
                }
             
            }
            }
        }

    
}
