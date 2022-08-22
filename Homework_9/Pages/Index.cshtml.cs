using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Homework_9.Pages {
  public class IndexModel : PageModel {
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger) {
      _logger = logger;
    }


    [BindProperty]
    public string ErrorMessage { get; set; } = String.Empty;

    [BindProperty]
    public string UserName { get; set; } = String.Empty;
    [Required]
    [BindProperty]    
    public string Password { get; set; } = String.Empty;
    public void OnGet() {


    }



  }

}
