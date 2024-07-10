using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POO_Examen3.Models;

namespace POO_Examen3.Controllers
{
    public class RolController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolController(ApplicationDbContext context, RoleManager<IdentityRole> roleManager)
        {
            this._context = context;
            this._roleManager = roleManager;
        }

        public async Task<IActionResult> RolList()
        {
            var list =  await _context.Roles
            .Select(r => new RolModel()
            {
                Id = new Guid(r.Id),
                Name = r.Name
            })
            .ToListAsync();
            
            return View(list);
        }

        public IActionResult RolAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RolAdd(RolModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityRole entity = new IdentityRole()
            {
                Name = model.Name
            };

            var result = await _roleManager.CreateAsync(entity);

            if (result.Succeeded)
            {
                return RedirectToAction("RolList", "Rol");
            }

            foreach (IdentityError error in result.Errors) 
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }
          public IActionResult RolEdit(Guid Id)
        {
            var rol = _context.Roles.FirstOrDefault(r => r.Id == Id.ToString());
            if (rol == null)
            {
                return RedirectToAction("RolList");
            }

            var model = new RolModel
            {
                Id = new Guid(rol.Id),
                Name = rol.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RolEdit(RolModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var x =  this._context.Roles
            .FirstOrDefault(r => r.Id == model.Id.ToString());

            x.Name = model.Name;

            var result = await _roleManager.UpdateAsync(x);

            if (result.Succeeded)
            {
                return RedirectToAction("RolList", "Rol");
            }

            foreach (IdentityError error in result.Errors) 
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }

         public IActionResult RolDeleted(Guid Id)
        {
            var model = new RolModel();

            var entity = _context.Roles
            .FirstOrDefault(r => r.Id == Id.ToString());

            model.Id = new Guid(entity.Id);
            model.Name = entity.Name;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RolDeleted(RolModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity =  this._context.Roles
            .FirstOrDefault(r => r.Id == model.Id.ToString());

            var result = await _roleManager.DeleteAsync(entity);

            if (result.Succeeded)
            {
                return RedirectToAction("RolList", "Rol");
            }

            foreach (IdentityError error in result.Errors) 
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);

        }



    }
}