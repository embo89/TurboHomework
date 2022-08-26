using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework_9.Pages {
  public class TypesModel : PageModel {


    public void OnGet() {
    }

    public PartialViewResult OnGetAddCardType(int id) {

      var cardType = new CardType { Id = 0, Description = String.Empty };
      return Partial("_TypeAddEdit", cardType);
    }

    public PartialViewResult OnGetEditCardType(int id) {

      var cardType = CardTypes.Instance.Where(i => i.Id == id).FirstOrDefault();
      return Partial("_TypeAddEdit", cardType);
    }


    public IActionResult OnPostSaveCardType(int id, string description, bool isvisitible, bool islocationrequired, bool isuseraccount) {
      if (id == 0) {

        if (CardTypes.Instance.Where(i => i.Description == description).FirstOrDefault() != null || String.IsNullOrWhiteSpace(description) == true) {

          throw new Exception("Same description");
        }

        var cardType = new CardType { Id = CardTypes.Instance.Count + 1, Name = description, Description = description, IsLocationRequired = islocationrequired, IsUserAccount = isuseraccount, IsVisitible = isvisitible };
        CardTypes.Instance.Add(cardType);

        Response.ContentType = "text/vnd.turbo-stream.html";
        return Partial("_TypeAdd", cardType);
        //return RedirectToPage("Types");

      } else {

        var cardType = CardTypes.Instance.Where(i => i.Id == id).FirstOrDefault();

        cardType.Name = description;
        cardType.Description = description;
        cardType.IsVisitible = isvisitible;
        cardType.IsLocationRequired = islocationrequired;
        cardType.IsUserAccount = isuseraccount;

        Response.ContentType = "text/vnd.turbo-stream.html";
        return Partial("_TypeEdit", cardType);

        //return RedirectToPage("Types");
      }

      return RedirectToPage("Types");
    }


    public PartialViewResult OnPostDeleteCancel(int id) {



      return Partial("Types");

    }
  }

  public class CardType {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsVisitible { get; set; }
    public bool IsLocationRequired { get; set; }
    public bool IsUserAccount { get; set; }
  }

  public class CardTypes : List<CardType> {
    private CardTypes() { }
    private static CardTypes _Instance = null;
    public static CardTypes Instance {
      get {
        if (_Instance == null) {
          _Instance = new CardTypes();
          _Instance.Add(new CardType { Id = 1, Name = "Doktor", Description = "Doktor", IsVisitible = true, IsLocationRequired = false, IsUserAccount = false });
          _Instance.Add(new CardType { Id = 2, Name = "Eczacı", Description = "Eczacı", IsVisitible = false, IsLocationRequired = false, IsUserAccount = false });

        }

        return _Instance;
      }
    }
  }
}
