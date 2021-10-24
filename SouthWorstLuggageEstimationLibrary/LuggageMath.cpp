// MathLibrary.cpp : Defines the exported functions for the DLL.
#include "pch.h" // use stdafx.h in Visual Studio 2017 and earlier
#include <utility>
#include <limits.h>
#include <stdio.h>
#include "LuggageMath.h"


struct LuggageDimensions {
    float Length;
    float Width;
    float Height;
};



// Accept luggage weight in stone and return addition fuel needed in Gil
float CalculateFuelConsumptionInGillFromBaggageInStone(float LuggageItemInStone)
{
    //This is a simple formula, but imagine a propriatary algorithm that 
    //an airline uses to estimate how mass of luggage effects fuel economy.
    return ((LuggageItemInStone) * .5 );
}

/// <summary>
/// Add the luggage dimensions to the total dimensions.
/// </summary>
float CalculateTotalLuggageAreaInChain(float LuggageItemDimensions , float TotalLuggageDimensions)
{
 
    return (LuggageItemDimensions + TotalLuggageDimensions);
}

char* ReturnAnAppendedString(char* OriginalString, char* StringToAppend) { 
    
    strcat_s(OriginalString, sizeof(StringToAppend),StringToAppend);
    return(OriginalString);
}
