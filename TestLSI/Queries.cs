using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLSI
{
    public class Queries
    {
        public string GenerateQueryReport(string location, DateTime from, DateTime to)
        {
            var basicQuery = "SELECT * FROM Export" +
                " WHERE Location = '" + location + "' AND Date <= '" + to.ToString("yyyy-MM-dd") +
                "' AND Date >= '" + from.ToString("yyyy-MM-dd") + "';";
            return basicQuery;
        }
    }
}
