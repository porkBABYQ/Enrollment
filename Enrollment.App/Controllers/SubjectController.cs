using AutoMapper;
using Enrollment.App.Models;
using Enrollment.App.Models.Repository;
using Enrollment.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Enrollment.App.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepo repo;
        private readonly IMapper mapper;

        public SubjectController(ISubjectRepo repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        // GET: SubjectController
        [HttpGet] // Explicitly state it's a GET request
        public async Task<ActionResult> Index()
        {
            List<SubjectVM> list = mapper.Map<List<SubjectVM>>(await repo.GetAllAsync());
            return View(list);
        }

        // GET: SubjectController/Add (Displays the form to add a new subject)
        // Renamed from 'Add(int id)' to 'Add' and removed the id parameter
        [HttpGet]
        public ActionResult Add()
        {
            return View(new SubjectVM());
        }

        // POST: SubjectController/Add (Handles the form submission to add a new subject)
        [HttpPost]
        [ValidateAntiForgeryToken] // Essential for POST forms
        public async Task<ActionResult> Add(SubjectVM model)
        {
            if (ModelState.IsValid)
            {
                await repo.AddAsync(mapper.Map<Subject>(model));
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        // GET: SubjectController/Delete/5 (Displays a confirmation page before deleting)
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Or RedirectToAction("Index");
            }

            var subject = await repo.GetAsync((int)id);
            if (subject == null)
            {
                return NotFound();
            }

            // Map to VM if you have a specific VM for delete confirmation
            // For simplicity, directly passing the mapped VM or the DataModel entity if your view can handle it.
            return View(mapper.Map<SubjectVM>(subject));
        }


        // POST: SubjectController/Delete/5 (Confirms and performs the deletion)
        // Renamed to DeleteConfirmed to avoid ambiguity with the GET Delete
        // Or keep it as Delete but ensure [ActionName("Delete")] if necessary
        [HttpPost, ActionName("Delete")] // Use ActionName to map to the 'Delete' URL segment
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id) // Changed parameter to non-nullable int
        {
            // You might want to check if the entity exists before attempting to delete
            // var exists = await repo.Exists(id); // If your repo has an Exists method
            // if (!exists) return NotFound();

            await repo.DeleteAsync(id);
            return RedirectToAction("Index");
        }


        // GET: SubjectController/Edit/5 (Displays the form to edit an existing subject)
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                // Better to return NotFound() or a specific error view than just redirect
                return NotFound();
            }
            SubjectVM subject = mapper.Map<SubjectVM>(await repo.GetAsync((int)id));
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: SubjectController/Edit/5 (Handles the form submission for editing)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubjectVM model)
        {
            if (ModelState.IsValid)
            {
                await repo.UpdateAsync(mapper.Map<Subject>(model));
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
    }
}