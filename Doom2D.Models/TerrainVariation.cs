namespace Doom2D.Models
{
    public enum TerrainVariation
    {
        LargePatch = 0,
        SmallPatch = 3,
        InnerCornerNW = 1,
        InnerCornerNE = 2,
        InnerCornerSW = 4,
        InnerCornerSE = 5,
        OuterCornerNW = 6,
        OuterCornerNE = 8,
        OuterCornerSW = 12,
        OuterCornerSE = 14,
        BorderN = 7,
        BorderW = 9,
        BorderS = 13,
        BorderE = 11,
        RegularEmpty = 10,
        RegularDetailedLow = 17,
        RegularDetailedMedium = 16,
        RegularDetailedHigh = 15
    }
}
