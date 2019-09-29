using FIguresDll.Exceptions;
using FIguresDll.Interfases;
using FIguresDll.Models;
using System;

namespace FIguresDll.Workers
{
    public class TriangleAreaGetter : IAreaGetter
    {
        /// <summary>
        /// Returns triangle area
        /// </summary>
        /// <returns>Triangle area</returns>
        public AreaResult GetArea(IFigureModel figureModel)
        {
            var result = new AreaResult();

            try
            {
                if (figureModel is TriangleModel == false)
                    throw new AreaGetterException("Другая модель.");

                var triangle = figureModel as TriangleModel;
                CheckTriangle(triangle.FirstLength, triangle.SecondLength, triangle.ThirdLength);
                result.SetArea(GetCurrentArea(triangle.FirstLength, triangle.SecondLength, triangle.ThirdLength));
            }
            catch(AreaGetterException ex)
            {
                result.Error = ex;
            }

            return result;
        }


        /// <summary>
        /// Returns triangle area
        /// </summary>
        /// <returns>Triangle area</returns>
        public AreaResult GetArea(TriangleModel triangle)
        {
            var result = new AreaResult();

            try
            {
                if (triangle == null)
                    throw new AreaGetterException("Не инстанциированная модель.");
                
                CheckTriangle(triangle.FirstLength, triangle.SecondLength, triangle.ThirdLength);
                result.SetArea(GetCurrentArea(triangle.FirstLength, triangle.SecondLength, triangle.ThirdLength));
            }
            catch (AreaGetterException ex)
            {
                result.Error = ex;
            }

            return result;
        }


        /// <summary>
        /// Returns triangle area
        /// </summary>
        /// <returns>Triangle area</returns>
        public AreaResult GetArea(float first, float second, float third)
        {
            var result = new AreaResult();

            try
            {
                CheckTriangle(first, second, third);
                result.SetArea(GetCurrentArea(first, second, third));
            }
            catch(AreaGetterException ex)
            {
                result.Error = ex;
            }

            return result;
        }


        private void CheckTriangle(float firstLength, float secondLength, float thirdLength)
        {
            if (firstLength <= 0 || secondLength <= 0 || thirdLength <= 0)
                throw new AreaGetterException("Error. Side length can`t be equels or below zero");

            if (firstLength + secondLength <= thirdLength || firstLength + thirdLength <= secondLength || secondLength + thirdLength <= firstLength)
                throw new AreaGetterException("Error. Wrong side size");
        }


        private float GetCurrentArea(float first, float second, float third)
        {
            var halfPerimeter = (first + second + third) / 2f;

            var firstPart = halfPerimeter - first;
            var secondPart = halfPerimeter - second;
            var thridPart = halfPerimeter - third;

            return (float)Math.Sqrt(halfPerimeter * firstPart * secondPart * thridPart);
        }
    }
}
