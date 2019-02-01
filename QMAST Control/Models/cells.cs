using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QMAST_Control.Models
{
    public class cells
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }

    public class cellManager
    {
        public static List<cells> GetCells()
        {
            var cell = new List<cells>();

            cell.Add(new cells { Title = "Sensors", Description = "Sensor data" });
            cell.Add(new cells { Title = "Weather", Description = "Weather data" });
            cell.Add(new cells { Title = "Coordinates", Description = "Coordinate data" });

            return cell;
        }
    }



}
