using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Pages
{
    public class AreasModel : PageModel
    {
        private readonly ILogger<AreasModel> _logger;

        public AreasModel(ILogger<AreasModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
