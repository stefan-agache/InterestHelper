using System;
using System.Linq;
using System.Threading.Tasks;
using InterestHelper.WebDataAccessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InterestHelper.IntegrationTests
{
    [TestClass]
    public class WebInputDataTests
    {
        [TestMethod]
        public void GetRawData_WhenCalled_DoesntGetsSomething()
        {
            // Arrange
            var webInputData = new WebInputDataProvider();
            
            // Act
            var result = Task.Run(() => webInputData.GetRawDataAsync(DateTime.Now.AddDays(-7), DateTime.Now)).Result;

            // Assert
            Assert.IsTrue(result.Any());
        }
    }
}
