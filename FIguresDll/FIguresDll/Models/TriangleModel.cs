using FIguresDll.Exceptions;
using FIguresDll.Interfases;
using System;

namespace FIguresDll.Models
{
    public class TriangleModel: IFigureModel
    {        
        public float FirstLength { get; set; }
        public float SecondLength { get; set; }
        public float ThirdLength { get; set; }


        private float GetAngle(float fLength, float sLenght, float tLength)
        {
            var radiantValue = 57.2958;
            return (float)Math.Round((Math.Acos((sLenght * sLenght + tLength * tLength - fLength * fLength) / (2 * sLenght * tLength)) * radiantValue));
        }


        /// <summary>
        /// Returns true if triangle is right
        /// </summary>
        /// <returns></returns>
        public bool IsTriangleRight()
        {
            try
            {                
                var firstAngle = GetAngle(FirstLength, SecondLength, ThirdLength);
                var secondAngle = GetAngle(SecondLength, FirstLength, ThirdLength);
                var thridAngle = GetAngle(ThirdLength, FirstLength, SecondLength);

                if (firstAngle == 90 || secondAngle == 90 || thridAngle == 90)
                    return true;
            }
            catch (Exception ex)
            {
                throw new AreaGetterException(ex.Message);
            }

            return false;
        }
    }
}
