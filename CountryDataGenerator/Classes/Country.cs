using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryDataGenerator.Classes
{
    public class CountryName
    {
        public string common { get; set; }
    }

    public class Country
    {
        public CountryName name { get; set; }
        public string region { get; set; }
        public string subregion { get; set; }
        public float[] latlng { get; set; }
        public float area { get; set; }
        public float population { get; set; }

        public override string ToString()
        {
            return $"region:{region};subregion:{subregion};latng:{string.Join(",",latlng)};area:{area};population:{population};\n";
        }
    }
}
