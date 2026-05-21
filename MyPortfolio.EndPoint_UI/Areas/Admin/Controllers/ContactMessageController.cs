using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Application.Services.ContactMessage;

[Area("Admin")]
public class ContactMessageController : Controller
{
    private readonly IContactMessageService _contactMessageService;



    public ContactMessageController(IContactMessageService contactMessageService)
    {
        _contactMessageService = contactMessageService;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        int pageSize = 10;

        var result = await _contactMessageService
            .GetPagedMessageAsync(page, pageSize);

        return View(result);
    }
}
