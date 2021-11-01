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
        //If you want to see the test fail, switch the below LayoutKind to Auto.
        [StructLayout(LayoutKind.Sequential)]
        public struct CargoHoldDimensions
        {
            public float Length;
            public float Width;
            public float Height;
        };

        private static class SouthWorstDLLAdapter
        {


            [DllImport("SouthWorstLuggageEstimationLibrary.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "CalculateCargoHoldDimensionsInChain")]
            public static extern float CalculateCargoHoldDimensionsInChain(CargoHoldDimensions CargoHold); 

             [DllImport("SouthWorstLuggageEstimationLibrary.dll", EntryPoint = "CalculateFuelConsumptionInGillFromBaggageInStone")]
            public static extern float CalculateFuelConsumptionInGillFromBaggageInStone(float LuggageWeightInStone);



        }


        public LuggageCalculator()
        {
            _ExtraFuelConsumptionInGallons = 0;
        }

        public void AddLuggageToAircraft(float luggageWeightInPounds)
        {
            //perform the baggage conversions
            float LuggageInStone = ConvertPoundsToStone(luggageWeightInPounds);

            float ExtraFuelConsumption = SouthWorstDLLAdapter.CalculateFuelConsumptionInGillFromBaggageInStone(LuggageInStone);


            _ExtraFuelConsumptionInGallons = ConvertGillToGallons(ExtraFuelConsumption);
                
        }

        public float CalculateCargoHold(CargoHoldDimensions CargoHold)
        {
            float CargoHoldDimensions = SouthWorstDLLAdapter.CalculateCargoHoldDimensionsInChain(CargoHold);
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
