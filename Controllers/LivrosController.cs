using MeusLivrosAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeusLivrosAPI.Controllers;

[ApiController]
[Route("Controler")]
public class LivrosController : Controller
{

    private static List<Livro> Livros = new();


    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    // GET: LivrosController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: LivrosController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: LivrosController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([FromBody] Livro livro)
    {
        try
        {
            Livros.Add(livro);
            return BadRequest(); 
        }
        catch
        {
            return Ok();
        }
    }

    // GET: LivrosController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: LivrosController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: LivrosController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: LivrosController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
