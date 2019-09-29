using FIguresDll.Models;
using FIguresDll.Schedulers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestsProject
{
    [TestClass]
    public class SchedulerTest
    {

        [DataTestMethod]
        [DataRow(1f)]
        [DataRow(11f)]
        [DataRow(-10f)]
        [DataRow(0f)]
        public void TestCircle(float radius)
        {
            var areaGetter = AreaScheduler.GetAreaGetter(FIguresDll.Interfases.AllFigures.Circle);
            var circleModel = GetCircle(radius);
            var area = areaGetter.GetArea(circleModel);
        }

        private CircleModel GetCircle(float radius)
        {
            return new CircleModel
            {
                Radius = radius
            };
        }

        [DataTestMethod]
        [DataRow(1f, 1f, 1f)]
        [DataRow(11f, 20f, 1f)]
        [DataRow(2f, 2f, 3f)]
        [DataRow(4f, 3f, 5f)]
        public void TestTriangle(float firstSide, float secondSide, float thridSide)
        {
            var areaGetter = AreaScheduler.GetAreaGetter(FIguresDll.Interfases.AllFigures.Triangle);
            var triangleModel = CreateTriangle(firstSide, secondSide, thridSide);
            var area = areaGetter.GetArea(triangleModel);
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
    }
}
