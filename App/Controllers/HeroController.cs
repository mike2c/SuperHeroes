using App.Models;
using Data.Exceptions;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class HeroController : Controller
    {        
        private readonly IHeroRepository Repository;

        public HeroController(IHeroRepository Repository)
        {
            this.Repository = Repository;
        }

        [HttpGet]        
        public async Task<IActionResult> Index(string search)
        {            
            HttpContext.Session.SetString("Search", search ?? string.Empty);
            
            if (search != null)
            {
                try
                {
                    var heroes = await Repository.GetByNameAsync(search);
                    return View(heroes);
                }
                catch(ApiErrorException e)
                {
                    ViewBag.Error = e.Message;
                    return View();
                }
                catch(Exception e)
                {
                    ViewBag.Error = e.Message;
                    return View();
                }
                
            }
            
            return View();
        }

        [HttpGet]
        [Route("Character/{heroid}")]
        public async Task<IActionResult> Character(int heroId)
        {
            try
            {
                var hero = await Repository.GetAsync(heroId);
                return View(hero);
                
            }
            catch (ApiErrorException e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
            catch (InvalidIdException e)
            {
                return Redirect("error/404");
            }
            catch (Exception e)
            {
                ViewBag.Error = e.Message;
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
