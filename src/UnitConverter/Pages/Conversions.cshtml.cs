using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public string Input { get; set; } = string.Empty;
    public string Output { get; set; } = string.Empty;

    public void OnGet()
    {
        Input = "3.1415";
        ViewData.Add("ConversionType", "Miles to Kilometers");
        ViewData.Add("Title", "Conversions");
        UnitOf.Length unit = new UnitOf.Length().FromMiles(Convert.ToDouble(Input));
        double x = unit.ToKilometers();
        Output = Convert.ToString(x);
    }
}
