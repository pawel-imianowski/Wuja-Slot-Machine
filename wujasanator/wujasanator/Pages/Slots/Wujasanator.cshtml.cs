using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wujasanator.Pages.Slots
{
    public class WujasanatorModel : PageModel
    {
        public WujasanatorModel(IWujasanatorService service)
        {
            this.service = service;
        }

        internal IWujasanatorService service { get; set; }

        public void OnGet()
        {
        }

        public ContentResult OnPostSpin([FromBody] decimal spinCost)
        {
            // TODO: subtract cost value here, abort if cost exceeds available funds

            return Content // can't return JsonResult, because it would serialize twice
                (
                    JsonConvert.SerializeObject( // serialize with Newtonsoft.Json - JsonResult() can't serialize 2d array
                        service.GetSpinOutcome(spinCost)
                    ),
                    "application/json"
                );
        }
    }
}
