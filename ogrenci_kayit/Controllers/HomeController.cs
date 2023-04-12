using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ogrenci_kayit.Models;

namespace ogrenci_kayit.Controllers
{
	public class HomeController : Controller
	{
        StudentContext context = new StudentContext();

        public async Task<IActionResult> Index()
		{
			return View(await context.Students.ToListAsync());
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentName,StudentSurname,Department,Age,StudentNumber")] Student student)
        {
            if (ModelState.IsValid)
            {
                context.Add(student);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public async Task<IActionResult> Update(int? ID)
        {
            if (ID == null || context.Students == null)
            {
                return NotFound();
            }

            var student = await context.Students.FindAsync(ID);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int ID, [Bind("StudentID,StudentName,StudentSurname,Department,Age,StudentNumber")] Student student)
        {
            if (ID != student.StudentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(student);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        private bool StudentExists(int ID)
        {
            return context.Students.Any(e => e.StudentID == ID);
        }

        public async Task<IActionResult> Delete(int? ID)
        {
            if (ID == null || context.Students == null)
            {
                return NotFound();
            }

            var student = await context.Students.FirstOrDefaultAsync(m => m.StudentID == ID);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ID)
        {
            if (context.Students == null)
            {
                return Problem("Entity set 'context.Students'  is null.");
            }
            var student = await context.Students.FindAsync(ID);
            if (student != null)
            {
                context.Students.Remove(student);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
