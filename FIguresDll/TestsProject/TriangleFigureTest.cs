using FIguresDll.Models;
using FIguresDll.Workers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsProject
{
    [TestClass]
    public class TriangleFigureTest
    {
        [DataTestMethod]
        [DataRow(1f, 1f,1f)]
        [DataRow(11f, 20f, 1f)]
        [DataRow(2f, 2f, 3f)]
        [DataRow(4f, 3f, 5f)]
        public void TestMethod(float firstSide, float secondSide, float thridSide)
        {            
            var triangle = CreateTriangle(firstSide, secondSide, thridSide);
            var area = GetArea(triangle);
            var isRight = triangle.IsTriangleRight();
        }

        private TriangleModel CreateTriangle(float firstSide, float secondSide, float thridSide)
        {
            return new TriangleModel
            {
                FirstLength = firstSide,
                SecondLength = secondSide,
                ThirdLength = thridSide
            };
        }

        private float GetArea(TriangleModel triangle)
        {
            var areaGetter = new TriangleAreaGetter();
            var areaResult = areaGetter.GetArea(triangle);

            return areaResult.ResultArea;
        }
    }
}
