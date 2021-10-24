// MathLibrary.h - Contains declarations of math functions
#pragma once

#ifdef MATHLIBRARY_EXPORTS
#define MATHLIBRARY_API __declspec(dllexport)
#else
#define MATHLIBRARY_API __declspec(dllimport)
#endif

// SouthWorst Luggage Calculations Copyright(c) 1984


// Add the baggage item to the total baggage weight in stone.
extern "C" MATHLIBRARY_API float CalculateFuelConsumptionInGillFromBaggageInStone(float BaggageItemInStone);

///Add the baggage dimensions to the total baggage area.
extern "C" MATHLIBRARY_API float CalculateTotalLuggageAreaInChain(float BagArea, float TotalLuggageDimensions);

