using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace BestRestaurants.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public CuisinesController(BestRestaurantsContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      model.Sort((x, y) => string.Compare(x.Type, y.Type));
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(cuisine.Type))
        {
          throw new System.InvalidOperationException("invalid input");
        }
        else
        {
          _db.Cuisines.Add(cuisine);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch(Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      thisCuisine.Restaurants = _db.Restaurants.Where(restaurant => restaurant.CuisineId == id).ToList();
      return View(thisCuisine);
    }

    public ActionResult Edit(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost]
    public ActionResult Edit(Cuisine cuisine)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(cuisine.Type))
        {
          throw new System.InvalidOperationException("invalid input");
        }
        else
        {
          _db.Entry(cuisine).State = EntityState.Modified;
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch(Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    public ActionResult Delete(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Cuisine thisCuisine = _db.Cuisines.FirstOrDefault(cuisine => cuisine.CuisineId == id);
      thisCuisine.Restaurants = _db.Restaurants.Where(restaurants => restaurants.CuisineId == id).ToList();
      foreach (Restaurant restaurant in thisCuisine.Restaurants)
      {
        _db.Restaurants.Remove(restaurant);
      }
      _db.Cuisines.Remove(thisCuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}