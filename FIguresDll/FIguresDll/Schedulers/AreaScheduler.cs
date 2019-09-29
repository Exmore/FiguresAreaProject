using FIguresDll.Interfases;
using FIguresDll.Workers;
using System.Collections.Generic;

namespace FIguresDll.Schedulers
{
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
    }
}
