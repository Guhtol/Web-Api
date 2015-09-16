using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Api.Model
{
    public class Geometry
    {
        public Location geometry;
    }
    public class Location
    {
        public Distancia location;
    }
    public class Distancia
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
