using CarComparison.Common.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarComparison.Common.Managers
{
    public interface ICarVerifierManger
    {
        IList<Car> Verify(IList<Car> cars);
        List<string> GetCarNames();
    }
}
