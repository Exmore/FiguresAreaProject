using FIguresDll.Exceptions;
using FIguresDll.Interfases;
using FIguresDll.Models;
using FIguresDll.Workers;
using System.Collections.Generic;
using System.Linq;

namespace FIguresDll.Schedulers
{
    // Это лишь 1 из возможных вариантов.    
    public static class AreaScheduler
    {
        private static Dictionary<AllFigures, IAreaGetter> allGetters = new Dictionary<AllFigures, IAreaGetter>
        {
            [AllFigures.Circle] = new CircleAreaGetter(),
            [AllFigures.Triangle] = new TriangleAreaGetter()
        };

        public static IAreaGetter GetAreaGetter(AllFigures figureType)
        {
            return allGetters[figureType];
        }

        public static AreaResult GetArea(params float[] values)
        {
            var result = new AreaResult();
            var length = values.Length;            

            switch (length)
            {
                case 1:
                    {
                        var currentGetter = GetAreaGetter(AllFigures.Circle);
                        var model = new CircleModel { Radius = values.FirstOrDefault() };                        
                        return currentGetter.GetArea(model);
                    }                    
                case 3:
                    {
                        var currentGetter = GetAreaGetter(AllFigures.Triangle);
                        var model = new TriangleModel { FirstLength = values[0], SecondLength = values[1], ThirdLength = values[2] };
                        return currentGetter.GetArea(model);
                    }                    
                default:
                    {
                        result.Error = new AreaGetterException($"Нет реализации для value с длинной = {length}");
                    }
                    break;
            }

            return result;
        }
    }
}
