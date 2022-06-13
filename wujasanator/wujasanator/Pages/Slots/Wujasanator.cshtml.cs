using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wujasanator.Pages.Slots
{
    public class WujasanatorModel : PageModel
    {
        public void OnGet()
        {
        }

        public ContentResult OnGetSpin(decimal cost){
            // TODO: subtract cost value here, abort if cost exceeds available funds

            IWujasanatorService wujasanatorService = new WujasanatorService();

            return Content // can't return JsonResult, because it would serialize twice
                (
                    JsonConvert.SerializeObject( // serialize with Newtonsoft.Json - JsonResult() can't serialize 2d array
                        wujasanatorService.GetSpinOutcome(cost)
                    ),
                    "application/json"
                );
        }
    }
}
