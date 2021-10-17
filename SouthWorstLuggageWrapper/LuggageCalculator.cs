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

        float _TotalLuggageWeightInPounds;

        const float StoneWeight = 14; /// make this a constant in case it ever changes.

        public float TotalLuggageWeight { get { return _TotalLuggageWeightInPounds; } }

        private static class SouthWorstDLLAdapter
        {


            [DllImport("SouthWorstLuggageEstimationLibrary.dll", EntryPoint = "CalculateTotalLuggageWeightInStone")]
            static extern float CalculateTotalLuggageWeightInStone(float one, float two);

            /// <summary>
            /// This reaches out ti the 
            /// </summary>
            /// <param name="LuggageWeightInStone"></param>
            /// <param name="TotalWeight"></param>
            /// <returns></returns>
            public static float CalculateLuggageWeight(float LuggageWeightInStone, float TotalWeightInStone)
            {
                return CalculateTotalLuggageWeightInStone(LuggageWeightInStone, TotalWeightInStone);
            }

        }


        public LuggageCalculator()
        {
            _TotalLuggageWeightInPounds = 0;
        }

        public void AddLuggageToAircraft(float luggageWeightInPounds)
        {
            float LuggageInStone = ConvertPoundsToStone(luggageWeightInPounds);
            float TotalLuggageInStone = ConvertPoundsToStone(_TotalLuggageWeightInPounds);
            float NewTotalLuggageInStone = SouthWorstDLLAdapter.CalculateLuggageWeight(LuggageInStone, TotalLuggageWeight);
            _TotalLuggageWeightInPounds = ConvertStoneToPounds(NewTotalLuggageInStone);
                
        }
        private float ConvertPoundsToStone(float pounds)
        {
            return (pounds / StoneWeight);
        }

        private float ConvertStoneToPounds(float stone)
        {
            return (stone * 14);
        }

    }

}
