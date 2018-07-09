using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;



namespace CalculatorService.Server.Controllers
{
  

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public string xid;
        // GET api/values
        [HttpGet]
        public String Geton()
        {
            String help;
            help = @" Parameters to be sended
                        public double Minuend { get; set; }
                        public double Subtrahend { get; set; }
                        public double Dividend { get; set; }
                        public double Divisor { get; set; }
                        public double Sqr { get; set; }
                        public double[] Numbers { get; set; }"; 
          
            return help;
          
        }

        [HttpGet("Metohs")]
        public String Metohs()
        {
            String help;
            help = @" Metohs
                       Addition-Parameters   public double[] Numbers { get; set; }-root:api/values/sum
                       Subtraction-Parameters 
                       Multiply -public double[] Numbers { get; set; }-root:api/values/multiply
                       Division-Parameters 
                       Square root-Parameters- public double Sqr { get; set; } -root:api/values/sqr";
            return help;

        }
        // POST api/values
        [HttpPost("sum")]
        public string PostAddends([FromBody]NumParameters values,int debugoption=0)
        {
            try
            {
               if (debugoption==0) xid = Request.Headers["xid"];
                double sum = values.Numbers.Sum();
                string result = string.Format("Sum={0}", sum);
                if (xid != null)
                    save(xid, result);
                return result;
            }
            catch { return "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support"; }


        }
        // POST api/values
        [HttpPost("multiply")]
        public string PostFactors([FromBody]NumParameters values,int debugoption=0)
        {
            try
            {
               if (debugoption==0) xid = Request.Headers["xid"];
                double multiply = values.Numbers.Aggregate((x, y) => x * y);
                string result = string.Format("Datafile={0}", multiply);
                if (xid != null)
                    save(xid, result);
                return result;
            }
            catch { return "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support"; }
        }
        // POST api/values
        [HttpPost("Sqr")]
        public string PostSqr([FromBody]NumParameters values,int debugoption=0)
        {
            try
            {
                if (debugoption==0) xid = Request.Headers["xid"];
                string result = string.Format("Square={0}", Math.Sqrt(values.Sqr));
                if (xid != null && xid!="")
                    save(xid, result);
                return result;
            }
            catch { return "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support"; }
        }
        [HttpPost("Div")]
        public string PostDiv([FromBody]NumParameters values,int debugoption=0)
        {
            try
            {
               if (debugoption==0) xid = Request.Headers["xid"];
                double Quotient, Remainder;                Quotient = values.Dividend / values.Divisor;
                Remainder = values.Dividend % values.Divisor;
                string result = string.Format("Quotient={0} Remainder={1}", Quotient, Remainder);
                if (xid != null)
                    save(xid, result);
                return result;
            }
            catch { return "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support"; }
        }
        [HttpPost("Sub")]
        public string Postsub([FromBody]NumParameters values,int debugoption=0)
        {
            try
            {
                string result = string.Format("Difference={0}", values.Minuend - values.Subtrahend);
               if (debugoption==0) xid = Request.Headers["xid"];
                if (xid != null)
                    save(xid,result);

                return result;
            }
            catch { return "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support"; }
        }
        [HttpPost("idx")]
        public string Postidx([FromBody]NumParameters values)
        {
            try
            {
            xid = Request.Headers["xid"];
                string historic = "";
             List<Data> allDatafiles = new List<Data>();

                List<string> Datafilelines = System.IO.File.ReadAllLines(@"./bd.txt").ToList();

                //Remove headers
                Datafilelines.RemoveAt(0);

                foreach (string line in Datafilelines)
                {
                    string[] parts = line.Split(';');

                    Data Datafile = new Data();
                    Datafile.id =  parts[0];
                    Datafile.operation = parts[1];
                    Datafile.Date = Convert.ToDateTime( parts[2]);

                    allDatafiles.Add(Datafile);
                }
                List<Data> filteredData = allDatafiles.Where(x => x.id == xid).ToList();

                foreach (Data hist in filteredData)
                {
                    historic= historic + string.Format("id={0} Operation={1} Date={2}", hist.id, hist.operation,hist.Date)+"\n";
                }
                return historic;
            }
            catch { return "An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support"; }
        }
        public void save(string xid, string opp)
        {

            string line = string.Format("\n{0}; {1};{2};", xid, opp, DateTime.Now);
            System.IO.File.AppendAllText(@"./bd.txt", line);

        }
    }
}
