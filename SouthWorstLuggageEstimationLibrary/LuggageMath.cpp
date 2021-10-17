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



// Add the luggage item to the total luggage weight in stone.
float CalculateTotalLuggageWeightInStone(float LuggageItemInStone, float TotalLuggageInStone)
{
    return (LuggageItemInStone + TotalLuggageInStone);

}

/// <summary>
/// Add the luggage dimensions to the total dimensions.
/// </summary>
float CalculateTotalLuggageAreaInChain(float LuggageItemDimensions , float TotalLuggageDimensions)
{
 
    return (LuggageItemDimensions + TotalLuggageDimensions);
}
