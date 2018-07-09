using System;
using Flurl.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestOperations
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async System.Threading.Tasks.Task testPostFactorsAsync()
        {

            var responseString = await "http://localhost:50889/api/values/sqr".PostUrlEncodedAsync(new { Sqr=16}).ReceiveString();
            Int32 a = 0;
        }
        [TestMethod]
        public void TestPostAddends()
        {
     
        }
        [TestMethod]
        public void TestPostFactors()
        {

        }
        [TestMethod]
        public void TestPostSqr()
        {

        }
        [TestMethod]
        public void TestPostDiv()
        {
      
        }
        [TestMethod]
        public void TestPostsub()
        {
          
  }
        [TestMethod]
        public void TestPostidx()
        {
            
        }
    }
}
