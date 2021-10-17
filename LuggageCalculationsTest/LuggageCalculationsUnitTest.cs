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

            Assert.AreEqual(14, LC.TotalLuggageWeight);


        }

        [TestMethod]
        public void Calculate1Point5StoneLuggageConversion()
        {


            LuggageCalculator LC = new LuggageCalculator();
            LC.AddLuggageToAircraft(21);

            Assert.AreEqual(21, LC.TotalLuggageWeight);

        }

    }
}
