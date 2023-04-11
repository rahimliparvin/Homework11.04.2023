using FronttoBack.Data;
using FronttoBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FronttoBack.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            Slider? sliders = await _context.Sliders.Where(m => !m.SoftDelete).FirstOrDefaultAsync();

			return View(sliders);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (slider == null) return NotFound();

            return View(slider);

        }

        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            Slider? slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (slider == null) return NotFound();


            return View(slider);
        }
    }
}

