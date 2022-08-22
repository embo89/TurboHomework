using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Homework_9.Pages {
  public class IndexModel : PageModel {
    private readonly ILogger<IndexModel> _logger;



    [BindProperty(SupportsGet = true)]
    public string UserName { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Password { get; set; }

    public IndexModel(ILogger<IndexModel> logger) {
      _logger = logger;
    }




    public void OnGet() {


    }

    //public PartialViewResult OnPostLogin(string username, string password) {


    //  if (String.IsNullOrEmpty(password) == true) {

    //    throw new Exception("Password can not be null or empty");
    //    //ErrorMessage = "Password can not be null or empty";
    //    //return Partial("_UserError", this);
    //  } else

    //    throw new Exception("Password can not be null or empty");

    //  return Partial("Types");
    //}


    public IActionResult OnPostLogin(string username, string password) {
      
      
      
      if (String.IsNullOrEmpty(password)) {

        return RedirectToPage("Index");
      }
      else
      return RedirectToPage("Main");
    }






  }

 



}
