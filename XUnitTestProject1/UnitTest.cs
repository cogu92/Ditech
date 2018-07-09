using CalculatorService.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestCalculator
{
    public class UnitTest
    {

        [Fact]
        public void TestPostAddends()
        {
            double[] array = { 2, 2, 3 };
            var controller = new ValuesController();
            NumParameters parameter = new NumParameters();
            parameter.Numbers = array;
            string response = controller.PostAddends(parameter, 1);
            Assert.Equal("Sum=7", response);
        }
        [Fact]
        public void  TestPostFactors()
        {
            double[] array = { 2, 2, 3 };
            var controller = new ValuesController();
            NumParameters parameter = new NumParameters();
            parameter.Numbers = array;
            string response = controller.PostFactors(parameter, 1);
            Assert.Equal("Datafile=12", response);

        }
        [Fact]
        public void  TestPostSqr()
        {
            var controller = new ValuesController();
            NumParameters parameter = new NumParameters();
            parameter.Sqr = 16;
            string response = controller.PostSqr(parameter, 1);
            Assert.Equal("Square=4", response);
        }
        [Fact]
        public void  TestPostDiv()
        {
            var controller = new ValuesController();
            NumParameters parameter = new NumParameters();
            parameter.Dividend = 6;
            parameter.Divisor = 2;
            string response = controller.PostDiv(parameter, 1);
            Assert.Equal("Quotient=3 Remainder=0", response);
        }

   
        [Fact]
        public void  TestPostsub()
        {
            var controller = new ValuesController();
            NumParameters parameter = new NumParameters();
            parameter.Minuend = 7;
            parameter.Subtrahend = 3;

            string response = controller.Postsub(parameter, 1);
            Assert.Equal("Difference=4", response);

        }
        
    }
}
