using System;

namespace UnitsConvertor
{
    class UnitsConversion
    {

        static void Main(string[] args)
        {
            bool correctFromUnit = false;
            bool correctToUnit = false;
            string fromUnit = string.Empty;
            string toUnit = string.Empty;

            Console.WriteLine("Enter the value you want to convert: ");
            string fromValue = Console.ReadLine();

            while (correctFromUnit == false)
            {
                Console.WriteLine("From unit (g, lbs, pood; m, foot; C, F, K): ");
                fromUnit = Console.ReadLine().ToLower();
                correctFromUnit = UnitsCorrectness.IsUnitCorrect(fromUnit);
            }

            while (correctToUnit == false)
            {
                Console.WriteLine("To unit (g, lbs, pood; m, foot; C, F, K): ");
                toUnit = Console.ReadLine().ToLower();
                correctToUnit = UnitsCorrectness.IsUnitCorrect(toUnit);
            }

            FactoryOutput result = new FactoryOutput();
            var resultCalculation = result.RunCorrectUnitConvert(fromValue, fromUnit, toUnit);

            Console.WriteLine("Converted value is: " + resultCalculation);
            Console.ReadLine();
        }
    }


    class UnitsCorrectness 
    {
        //Verifies if entered units can be converted.
        static public bool IsUnitCorrect(string unit)
        {
            bool correctness = false;
            if (unit == "g" || unit == "lbs" || unit == "pood" 
                || unit == "m" || unit == "foot" 
                || unit == "c" || unit == "f" || unit == "k")
            {
                correctness = true;
            }
            else
                correctness = false;
            return correctness;
        }
    }


    public abstract class UnitGroupSelection
    // Gather all methods to select correct one inside each class.
    {
        public abstract string ReturnedValue(string value, string fromUnit, string toUnit);
    }


    class FactoryOutput
    {
        // Decides which class to instantiate.
        public string RunCorrectUnitConvert (string fromValue, string fromUnit, string toUnit)
        {
            string output = string.Empty;
            if (fromUnit == "g" || fromUnit == "lbs" || fromUnit == "pood")
            {
                MassConvertion mass = new MassConvertion();
                return output = mass.ReturnedValue(fromValue, fromUnit, toUnit);
            } 

            if (fromUnit == "m" || fromUnit == "foot")
            {
                LengthConvertion length = new LengthConvertion();
                return output = length.ReturnedValue(fromValue, fromUnit, toUnit);
            }

            if (fromUnit == "c" || fromUnit == "f" || fromUnit == "k")
            {
                TemperatureConversion temperature = new TemperatureConversion();
                return output = temperature.ReturnedValue(fromValue, fromUnit, toUnit);
            }
            else
            return output = "From unit is not found.";
        }
    }

    class MassConvertion : UnitGroupSelection
        //Run correct method in mass units
    {
        public override string ReturnedValue (string value, string fromUnit, string toUnit)
        {
            string outputValue = string.Empty;
            if (fromUnit == "g" && toUnit == "lbs")
                return outputValue = GramToPound(value);
            if (fromUnit == "g" && toUnit == "pood")
                return outputValue = GramToPood(value);
            if (fromUnit == "lbs" && toUnit == "g")
                return outputValue = PoundToGram(value);
            if (fromUnit == "lbs" && toUnit == "pood")
                return outputValue = PoundToPood(value);
            if (fromUnit == "pood" && toUnit == "g")
                return outputValue = PoodToGram(value);
            if (fromUnit == "pood" && toUnit == "pound")
                return outputValue = PoodToPound(value);
            else
                return outputValue = "From unit can't be converted in To unit";
        }

        private string GramToPound(string input)
        {
            const float multiplayer = 0.00220462F;
            float gramvalue = float.Parse(input);
            float poundvalue = multiplayer * gramvalue;
            string output = poundvalue.ToString();
            return output;
        }

        private string GramToPood(string input)
        {
            const float multiplayer = 16380.4964F;
            float gramvalue = float.Parse(input);
            float poodvalue = gramvalue / multiplayer;
            string output = poodvalue.ToString();
            return output;
        }

        public string PoodToPound(string input)
        {
            const float multiplayer = 40F;
            float poodvalue = float.Parse(input);
            float poundvalue = multiplayer * poodvalue;
            string output = poundvalue.ToString();
            return output;
        }

        public string PoodToGram(string input)
        {
            const float multiplayer = 16380.4964F;
            float poodvalue = float.Parse(input);
            float gramvalue = multiplayer * poodvalue;
            string output = gramvalue.ToString();
            return output;
        }

        public string PoundToPood(string input)
        {
            const float multiplayer = 40F;
            float poundvalue = float.Parse(input);
            float poodvalue = poundvalue / multiplayer;
            string output = poodvalue.ToString();
            return output;
        }

        public string PoundToGram(string input)
        {
            const float multiplayer = 453.59183F;
            float poundvalue = float.Parse(input);
            float gramvalue = multiplayer * poundvalue;
            string output = gramvalue.ToString();
            return output;
        }

    }

    class LengthConvertion : UnitGroupSelection
    {
        // Contains methods to convert length units each other.
        public override string ReturnedValue(string value, string fromUnit, string toUnit)

        {
            string outputValue = string.Empty;
            if (fromUnit == "m" && toUnit == "foot")
                return outputValue = MeterToFoot(value);
            if (fromUnit == "foot" && toUnit == "m")
                return outputValue = FootToMeter(value);
            else
                return outputValue = "From unit can't be converted in To unit";
        }

        private string MeterToFoot(string input)
        {
            const float multiplayer = 3.28084F;
            float metrvalue = float.Parse(input);
            float footvalue = multiplayer * metrvalue;
            string output = footvalue.ToString();
            return output;
        }

        private string FootToMeter(string input)
        {
            const float multiplayer = 3.28084F;
            float footvalue = float.Parse(input);
            float metrvalue = footvalue / multiplayer;
            string output = metrvalue.ToString();
            return output;
        }
    }

    class TemperatureConversion : UnitGroupSelection
    {
        // Contains methods to convert temperature units each other.
        public override string ReturnedValue(string value, string fromUnit, string toUnit)
        {
            string outputValue = string.Empty;
            if (fromUnit == "c" && toUnit == "k")
                return outputValue = CelsiusToKelvin(value);
            if (fromUnit == "c" && toUnit == "f")
                return outputValue = CelsiusToFahrenheit(value);
            if (fromUnit == "f" && toUnit == "k")
                return outputValue = FahrenheitToKelvin(value);
            if (fromUnit == "f" && toUnit == "c")
                return outputValue = FahrenheitToCelsius(value);
            if (fromUnit == "k" && toUnit == "f")
                return outputValue = KelvinToFahrenheit(value);
            if (fromUnit == "k" && toUnit == "c")
                return outputValue = KelvinToCelsius(value);
            else
                return outputValue = "From unit can't be converted in To unit";
        }

        private string CelsiusToFahrenheit(string input)
        {
            float celsiusvalue = float.Parse(input);
            float fahrenheitvalue = (celsiusvalue * 9 / 5) + 32;
            string output = fahrenheitvalue.ToString();
            return output;
        }

        private string CelsiusToKelvin(string input)
        {
            float celsiusvalue = float.Parse(input);
            float kelvinvalue = 273.15F + celsiusvalue;
            string output = kelvinvalue.ToString();
            return output;
        }

        private string KelvinToCelsius(string input)
        {
            float kelvinvalue = float.Parse(input);
            float celsiusvalue = kelvinvalue - 273.15F;
            string output = celsiusvalue.ToString();
            return output;
        }

        private string KelvinToFahrenheit(string input)
        {
            float kelvinvalue = float.Parse(input);
            float fahrenheitvalue = (1.8F * (kelvinvalue - 273)) + 32;
            string output = fahrenheitvalue.ToString();
            return output;
        }

        private string FahrenheitToCelsius(string input)
        {
            float fahrenheitvalue = float.Parse(input);
            float celsiusvalue = (fahrenheitvalue - 32) * 5 / 9;
            string output = celsiusvalue.ToString();
            return output;
        }

        private string FahrenheitToKelvin(string input)
        {
            float fahrenheitvalue = float.Parse(input);
            float kelvinvalue = ((fahrenheitvalue - 32) / 1.8F) + 273;
            string output = kelvinvalue.ToString();
            return output;
        }
    }

}
