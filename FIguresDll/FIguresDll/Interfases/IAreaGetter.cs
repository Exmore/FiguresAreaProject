using FIguresDll.Models;

namespace FIguresDll.Interfases
{
    public interface IAreaGetter
    {
        AreaResult GetArea(IFigureModel figureModel);
    }
}
