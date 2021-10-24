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

    }
}
