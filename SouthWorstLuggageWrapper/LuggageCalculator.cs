using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LuggageWrapperExample
{
    public class LuggageCalculator
    {

        float _ExtraFuelConsumptionInGallons;

        const float StoneWeight = 14; /// make this a constant in case it ever changes.

        public float ExtraFuelConsumption { get { return _ExtraFuelConsumptionInGallons; } }

        private static class SouthWorstDLLAdapter
        {


            [DllImport("SouthWorstLuggageEstimationLibrary.dll", EntryPoint = "CalculateFuelConsumptionInGillFromBaggageInStone")]
            static extern float CalculateFuelConsumptionFromBaggage(float LuggageWeightInStone);

            /// <summary>
            /// This reaches out ti the 
            /// </summary>
            /// <param name="LuggageWeightInStone"></param>
            /// <param name="TotalWeight"></param>
            /// <returns></returns>
            public static float CalculateLuggageWeight(float LuggageWeightInStone)
            {
                return CalculateFuelConsumptionFromBaggage(LuggageWeightInStone);
            }

        }


        public LuggageCalculator()
        {
            _ExtraFuelConsumptionInGallons = 0;
        }

        public void AddLuggageToAircraft(float luggageWeightInPounds)
        {
            //perform the baggage conversions
            float LuggageInStone = ConvertPoundsToStone(luggageWeightInPounds);

            float ExtraFuelConsumption = SouthWorstDLLAdapter.CalculateLuggageWeight(LuggageInStone);


            _ExtraFuelConsumptionInGallons = ConvertGillToGallons(ExtraFuelConsumption);
                
        }
        private float ConvertPoundsToStone(float pounds)
        {
            return (pounds / StoneWeight);
        }

        private float ConvertStoneToPounds(float stone)
        {
            return (stone * 14);
        }

        private float ConvertGallonsToGill(float Gallons)
        {
            return (Gallons * 32);
        }

        private float ConvertGillToGallons(float Gill)
        {
            return (Gill /32);
        }

    }

}
