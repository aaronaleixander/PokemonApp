using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonApp.Models
{
    public static class UnitConversionHelper
    {
        public static string DecimetersToFeetAndInches(int decimeters)
        {
            const double InchesPerDecimeter = 3.937;
            const int InchesPerFoot = 12;

            double totalInches = decimeters * InchesPerDecimeter;
            int feet = (int) totalInches / InchesPerFoot;
            int inchesRemaining =  (int) Math.Round(totalInches % InchesPerFoot);

            return $@"{feet}' {inchesRemaining}""";
        }

        // TODO: Convert Hectograms to Pounds
    }
}
