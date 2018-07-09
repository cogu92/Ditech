using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorService.Server.Controllers
{

   public class NumParameters
    {
        public double Minuend { get; set; }
        public double Subtrahend { get; set; }
        public double Dividend { get; set; }
        public double Divisor { get; set; }
        public double Sqr { get; set; }
        public double[] Numbers { get; set; }
    
    }
}