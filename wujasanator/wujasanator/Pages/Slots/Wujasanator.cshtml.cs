using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace wujasanator.Pages.Slots
{
    public class WujasanatorModel : PageModel
    {
        public void OnGet()
        {
        }

        int[] possibleRolls = Enumerable.Range(0, 8).ToArray();

        public ContentResult OnGetSpin(decimal? cost){
            // TODO: subtract cost value here, abort if cost exceeds available funds

            int[,] tileMatrix = new int[5,3];
                
            for(int i = 0; i < tileMatrix.GetLength(0); i++) // iterate columns
            {
                for(int j = 0; j < tileMatrix.GetLength(1); j++) // iterate rows
                    tileMatrix[i,j] = possibleRolls[Random.Shared.Next(possibleRolls.Count())]; 
            }

            // TODO: bonus/wild logic here

            decimal reward = cost ?? (decimal)0.0; // TODO: reward logic here - calculate reward according to drawn tiles, bonuses and cost parameter

            return Content // can't return JsonResult, because it would serialize twice
                (
                    JsonConvert.SerializeObject( // serialize with Newtonsoft.Json - JsonResult() can't serialize 2d array
                        new SpinOutcome
                        (
                            tileMatrix,
                            reward
                            // TODO: send info about bonuses to display animations
                        )
                    ),
                    "application/json"
                );
        }

        internal record SpinOutcome(int[,] tileMatrix, decimal reward/*, IEnumerable bonusList*/)
{
}
    }
}
