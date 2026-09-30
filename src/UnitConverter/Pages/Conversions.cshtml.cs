using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic.CompilerServices;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    [BindProperty (SupportsGet =  true)]
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;

    [BindProperty (SupportsGet =  true)]
    public string ConversionType { get; set; } = string.Empty;

    public void OnGet(string conversionType, string input)
    {
        try
        {
            ConversionType = conversionType;
            Input = input;
        }
        catch (NullReferenceException ex)
        {
            ViewData["ErrorMessage"] = "Please provide input.";
        }

        try
        {
            Convert.ToDouble(Input);
        }
        catch (Exception ex)
        {
            ViewData["ErrorMessage"] = "Input must be a valid number.";
        }

        switch (ConversionType)
        {
            case "MilesToKilometers":
                UnitOf.Length a = new UnitOf.Length().FromMiles(Convert.ToDouble(Input));
                double b = a.ToKilometers();
                Output = Convert.ToString(b);
                break;
            case "KilometersToMiles":
                UnitOf.Length c = new UnitOf.Length().FromKilometers(Convert.ToDouble(Input));
                double d = c.ToMiles();
                Output = Convert.ToString(d);
                break;
            case "FahrenheitToCelsius":
                UnitOf.Temperature e = new UnitOf.Temperature().FromFahrenheit(Convert.ToDouble(Input));
                double f = e.ToCelsius();
                Output = Convert.ToString(f);
                break;
            case "CelsiusToFahrenheit":
                UnitOf.Temperature g = new UnitOf.Temperature().FromCelsius(Convert.ToDouble(Input));
                double h = g.ToFahrenheit();
                Output = Convert.ToString(h);
                break;
            case "PoundstoKilograms":
                UnitOf.Mass i = new UnitOf.Mass().FromPounds(Convert.ToDouble(Input));
                double  k = i.ToKilograms();
                Output = Convert.ToString(k);
                break;
            case "KilogramsToPounds":
                UnitOf.Mass j = new UnitOf.Mass().FromKilograms(Convert.ToDouble(Input));
                double l = j.ToPounds();
                Output = Convert.ToString(l);
                break;
            case "InchesToFeet":
                UnitOf.Length m = new UnitOf.Length().FromInches(Convert.ToDouble(Input));
                double n = m.ToFeet();
                Output = Convert.ToString(n);
                break;
            case "FeetToInches":
                UnitOf.Length o = new UnitOf.Length().FromFeet(Convert.ToDouble(Input));
                double p = o.ToInches();
                Output = Convert.ToString(p);
                break;
            default:
                ViewData["ErrorMessage"] = "Unknown conversion type";
                break;
        }
    }


}
