using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Memo.Views.Home
{
    public class Details : PageModel
    {
        public ContentResult AddSong()
        {
            return Content($"flinstons", "text/html");
        }
    }
}
