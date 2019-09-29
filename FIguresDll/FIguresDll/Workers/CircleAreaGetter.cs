using FIguresDll.Exceptions;
using FIguresDll.Interfases;
using FIguresDll.Models;
using System;

namespace FIguresDll.Workers
{
    public class CircleAreaGetter : IAreaGetter
    {
        /// <summary>
        /// Return Circle area
        /// </summary>
        /// <returns>Circle area</returns>
        public AreaResult GetArea(float radius)
        {
            var result = new AreaResult();

            if (radius < 0)
            {
                result.Error = new AreaGetterException("Радиус не может быть меньше 0.");
                return result;
            }

            result.SetArea((float)(Math.PI * radius * radius));
            return result;
        }


        /// <summary>
        /// Return Circle area
        /// </summary>
        /// <returns>Circle area</returns>
        public AreaResult GetArea(CircleModel circle)
        {
            if (circle == null)
            {
                return new AreaResult
                {
                    Error = new AreaGetterException("Не инстанциированная модель.")
                };
            }            

            return GetArea(circle.Radius);
        }


        /// <summary>
        /// Return Circle area
        /// </summary>
        /// <returns>Circle area</returns>
        public AreaResult GetArea(IFigureModel figureModel)
        {
            if (figureModel is CircleModel == false)
            {
                return new AreaResult
                {
                    Error = new AreaGetterException("Другая модель.")
                };
            }

            var circle = figureModel as CircleModel;
            return GetArea(circle.Radius);
        }        
    }
}
