using ECommerceWebRazor_temp.Data;
using ECommerceWebRazor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ECommerceWebRazor_temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
            private readonly ApplicationDbContext _db;
            public Category Category { get; set; }

            public EditModel(ApplicationDbContext db)
            {
                _db = db;
            }
            public void OnGet(int? id)
            {
                if (id != null && id != 0)
                {
                    Category = _db.Categories.Find(id);
                }
            }

            public IActionResult OnPost()
            {

                if (ModelState.IsValid)
                {
                    _db.Categories.Update(Category);
                    _db.SaveChanges();
                    TempData["success"] = "Category updated successfully";
                    return RedirectToPage("Index");
                }
                return Page();
            }
        }
    }

