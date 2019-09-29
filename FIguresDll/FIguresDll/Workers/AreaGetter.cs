using FIguresDll.Interfases;
using FIguresDll.Models;

namespace FIguresDll.Workers
{
    public class AreaGetter : IAreaGetter
    {
        public AreaResult GetArea(IFigureModel figureModel)
        {
            var result = new AreaResult();
            return result;
        }
    }
}
