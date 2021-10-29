using LuggageWrapperExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace LuggageCalculationsTest
{
    [TestClass]
    public class LuggageCalculationsUnitTest
    {
        [TestMethod]
        public void Calculate1StoneLuggageConversion()
        {


            LuggageCalculator LC = new LuggageCalculator();
            LC.AddLuggageToAircraft(14);

            Assert.AreEqual(0.015625, LC.ExtraFuelConsumption);


        }

        [TestMethod]
        public void Calculate1Point5StoneLuggageConversion()
        {


            LuggageCalculator LC = new LuggageCalculator();
            LC.AddLuggageToAircraft(21);

            Assert.AreEqual(0.0234375, LC.ExtraFuelConsumption);

        }

        [TestMethod]
        public void CalculateAreaWithStructure()
        {
            LuggageCalculator.CargoHoldDimensions holdDimensions = new LuggageCalculator.CargoHoldDimensions();
            holdDimensions.Length = 7;
            holdDimensions.Width = 5;
            holdDimensions.Height = 3;
            

            LuggageCalculator LC = new LuggageCalculator();
            float CargoHoldArea = LC.CalculateCargoHold(holdDimensions);
            Assert.AreEqual(105, CargoHoldArea);

        }

    }
}
