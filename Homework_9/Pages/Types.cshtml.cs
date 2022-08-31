using Homework_9.Hubs;
using Homework_9.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace Homework_9.Pages {
  public class TypesModel : PageModel {


    private readonly ILogger<TypesModel> _Logger;
    private readonly IHubContext<AppHub> _Hub;
    private readonly IRazorPartialToStringRenderer _Renderer;


    public TypesModel(ILogger<TypesModel> logger, IHubContext<AppHub> hub, IRazorPartialToStringRenderer renderer) {

      _Logger = logger;
      _Hub = hub;
      _Renderer = renderer;

    }

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

    public async Task<IActionResult> OnPostDeleteCardType(int id) {

      var cardType = CardTypes.Instance.Where((i) => i.Id == id).FirstOrDefault();
      CardTypes.Instance.Remove(cardType);

      var renderedViewStr = await _Renderer.RenderPartialToStringAsync("../Pages/_TypeDelete", cardType);

      await _Hub.Clients.All.SendAsync("CardTypeChanged", renderedViewStr);

      return new EmptyResult();

    }


    public async Task<IActionResult> OnPostSaveCardType(int id, string description, bool isvisitible, bool islocationrequired, bool isuseraccount) {
      if (id == 0) {

        if (CardTypes.Instance.Where(i => i.Description == description).FirstOrDefault() != null || String.IsNullOrWhiteSpace(description) == true) {

          throw new Exception("Same description");
        }


        var cardType = new CardType();
        cardType = new CardType { Id = CardTypes.Instance.Count + 1, Name = description, Description = description, IsLocationRequired = islocationrequired, IsUserAccount = isuseraccount, IsVisitible = isvisitible };
        CardTypes.Instance.Add(cardType);

        var renderedViewStr = await _Renderer.RenderPartialToStringAsync("../Pages/_TypeAdd", cardType);

        await _Hub.Clients.All.SendAsync("CardTypeChanged", renderedViewStr);

        return new EmptyResult();

        //Response.ContentType = "text/vnd.turbo-stream.html";
        //return Partial("_TypeAdd", cardType);

      } else {

        var cardType = CardTypes.Instance.Where(i => i.Id == id).FirstOrDefault();

        cardType.Name = description;
        cardType.Description = description;
        cardType.IsVisitible = isvisitible;
        cardType.IsLocationRequired = islocationrequired;
        cardType.IsUserAccount = isuseraccount;

        var renderedViewStr = await _Renderer.RenderPartialToStringAsync("../Pages/_TypeEdit", cardType);

        await _Hub.Clients.All.SendAsync("CardTypeChanged", renderedViewStr);

        return new EmptyResult();

        //Response.ContentType = "text/vnd.turbo-stream.html";
        //return Partial("_TypeEdit", cardType);

      }

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
          for (int i = 1; i <= 20; i++) {
            _Instance.Add(new CardType { Id = i, Name = "Doktor " + i, Description = "Doktor " + i, IsVisitible = true, IsLocationRequired = false, IsUserAccount = false });

          }

        }

        return _Instance;
      }
    }
  }
}
