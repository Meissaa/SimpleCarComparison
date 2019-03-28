using CarComparison.Common.Data;
using CarComparison.Common.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using CarComparison.Common.Exceptions;

namespace CarComparison.Business.Managers
{
    public class CarVerifierManager : ICarVerifierManger
    {
        static ILog _log;

        public CarVerifierManager()
        {
            _log = LogManager.GetLogger(this.GetType().FullName);
        }

        public List<string> GetCarNames() {

            _log.Info("begin GetNamesCars");

            List<string> listCars = new List<string> {
                "Opel","Ford","Porshe","Toyota","Mercedes","Fiat"
            };

            return listCars;
        }

        public IList<Car> Verify(IList<Car> cars) {

            _log.Info("begin Verify");

            List<Car> resultVerifier = null;

            if (cars == null || cars.Count < 2)
            {
                _log.Error("cars not added");
                throw new VerifierException("cars not added");
            }

            var carFirst = (from b in cars
                            orderby b.Mileage, b.Acceleration, b.Speed descending /*, b.Acceleration descending*/
                            select b).First();

            resultVerifier = cars.Where(c => c.Mileage == carFirst.Mileage
                                 && c.Speed == carFirst.Speed && c.Acceleration == carFirst.Acceleration).ToList();

            return resultVerifier;
        }
    }
}
