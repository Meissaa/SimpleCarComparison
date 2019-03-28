using System;
using System.Collections.Generic;
using CarComparison.Business;
using CarComparison.Business.Managers;
using CarComparison.Common.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarComparison.Test
{
    [TestClass]
    public class CarComparisonTest
    {
        private List<Car> _listCars;
        private CarVerifierManager _carVerifierManager;

        [TestInitialize]
        public void Initialize()
        {
            _carVerifierManager = new CarVerifierManager();           
        }

        [TestMethod]
        public void Verify_WithPositive()
        {
            _listCars = new List<Car> { new Car { Name="Ford", Mileage=200.000, Speed=150, Acceleration=15},
                                       new Car { Name="Porshe", Mileage=100.000, Speed=200, Acceleration=3 },
                                       new Car { Name="Fiat", Mileage=100.000, Speed=130, Acceleration=5 }};

            var result = _carVerifierManager.Verify(_listCars);

            Assert.IsNotNull(result);
            Assert.AreEqual("Porshe", result[0].Name);
        }

        [TestMethod]
        public void Verify_WithIsTheSame()
        {
            _listCars = new List<Car> { new Car { Name="Porshe", Mileage=200.000, Speed=150, Acceleration=15},
                                        new Car { Name="Ford", Mileage=200.000, Speed=150, Acceleration=15 },
                                        new Car { Name="Fiat", Mileage=200.000, Speed=150, Acceleration=15 }};

            var result = _carVerifierManager.Verify(_listCars);

            Assert.AreEqual(_listCars, _listCars);
        }
    }

}
