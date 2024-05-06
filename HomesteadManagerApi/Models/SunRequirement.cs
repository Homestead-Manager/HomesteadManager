namespace HomesteadManagerApi.Models
{
    public enum SunRequirement
    {
        FullSun,        // Typically 6 or more hours of direct sun per day.
        PartialSun,     // About 3 to 6 hours of direct sun per day.
        PartialShade,   // Around 3 to 6 hours of sun per day, but needs protection from intense mid-day sun.
        FullShade,      // Less than 3 hours of direct sun per day, or filtered sunlight.
        DappledSun      // Sunlight filtered through the canopy of trees, similar to partial shade.
    }
}