using FIguresDll.Models;
using FIguresDll.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsProject
{
    [TestClass]
    public class CircleFigureTest
    {       
        [DataTestMethod]
        [DataRow(1f)]
        [DataRow(11f)]
        [DataRow(-10f)]
        [DataRow(0f)]
        public void TestMethod(float radius)
        {
            var circle = CreateCircle(radius);            
            var area = GetArea(circle);
        }

        [DataTestMethod]
        [DataRow(1f, 3.14159274f)]
        public void CheckValue(float radius, float area)
        {
            var circle = CreateCircle(radius);
            var areValue = GetArea(circle);
            Assert.AreEqual(areValue, area);
        }

        [DataTestMethod]
        [DataRow(-100f, -1f)]
        public void ChecWrongkValue(float radius, float area)
        {
            var circle = CreateCircle(radius);
            var areValue = GetArea(circle);
            Assert.AreEqual(areValue, area);
        }

        private CircleModel CreateCircle(float radius)
        {
            return new CircleModel { Radius = radius };
        }

        private float GetArea(CircleModel circle)
        {
            var areaGetter = new CircleAreaGetter();
            var areaResult = areaGetter.GetArea(circle);

            return areaResult.ResultArea;
        }
    }
}
