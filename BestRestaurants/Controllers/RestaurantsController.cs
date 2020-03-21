using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BestRestaurants.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public RestaurantsController(BestRestaurantsContext db)
    {
      _db = db;
    } 

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants.Include(restaurants => restaurants.Cuisine).ToList();
      model.Sort((x, y) => string.Compare(x.Name, y.Name));
      return View(model);
    }

    public ActionResult Create()
    {
      try
      {
        List<Cuisine> cuisines = _db.Cuisines.ToList();
        if (cuisines.Count >= 1)
        {
          ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
          return View();
        }
        else
        {
          throw new System.InvalidOperationException("No cuisines available. Please add a cuisine before adding a restaurant.");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(restaurant.Name) || String.IsNullOrWhiteSpace(restaurant.PriceRange))
        {
          throw new System.InvalidOperationException("invalid input");
        }
        else
        {
          _db.Restaurants.Add(restaurant);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    public ActionResult Details(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      thisRestaurant.Reviews = _db.Reviews.Where(review => review.RestaurantId == id).ToList();
      return View(thisRestaurant);
    }

    public ActionResult Edit(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "Type");
      return View(thisRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(restaurant.Name) || String.IsNullOrWhiteSpace(restaurant.PriceRange))
        {
          throw new System.InvalidOperationException("invalid input");
        }
        else
        {
          _db.Entry(restaurant).State = EntityState.Modified;
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurants => restaurants.RestaurantId == id);
      thisRestaurant.Reviews = _db.Reviews.Where(reviews => reviews.RestaurantId == id).ToList();
      foreach(Review review in thisRestaurant.Reviews)
      {
        _db.Reviews.Remove(review);
      }
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}