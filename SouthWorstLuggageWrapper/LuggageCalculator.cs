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

        //[StructLayout(LayoutKind.Auto)] //Can't do this.
        [StructLayout(LayoutKind.Auto)]
        public struct CargoHoldDimensions
        {
            public float Length;
            public float Width;
            public float Height;
        };

        private static class SouthWorstDLLAdapter
        {


            [DllImport("SouthWorstLuggageEstimationLibrary.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CalculateCargoHoldDimensionsInChain")]
            static extern float CalculateCargoHoldDimensionsInChain(CargoHoldDimensions CargoHold); 

             [DllImport("SouthWorstLuggageEstimationLibrary.dll", EntryPoint = "CalculateFuelConsumptionInGillFromBaggageInStone")]
            static extern float CalculateFuelConsumptionFromBaggage(float LuggageWeightInStone);

            /// <summary>
            /// This reaches out to the unmanaged code.
            /// </summary>
            /// <param name="LuggageWeightInStone"></param>
            /// <param name="TotalWeight"></param>
            /// <returns></returns>
            public static float CalculateLuggageWeight(float LuggageWeightInStone)
            {
                return CalculateFuelConsumptionFromBaggage(LuggageWeightInStone);
            }

            public static float CalculateCargoArea(CargoHoldDimensions CargoHold)
            {
                return CalculateCargoHoldDimensionsInChain(CargoHold);
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

        public float CalculateCargoHold(CargoHoldDimensions CargoHold)
        {
            float CargoHoldDimensions = SouthWorstDLLAdapter.CalculateCargoArea(CargoHold);
            return CargoHoldDimensions;
        }

        #region Conversions
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
        #endregion
    }

}
