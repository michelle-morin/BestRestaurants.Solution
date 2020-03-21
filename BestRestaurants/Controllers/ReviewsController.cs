using Microsoft.AspNetCore.Mvc;
using BestRestaurants.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace BestRestaurants.Controllers
{
  public class ReviewsController : Controller
  {
    private readonly BestRestaurantsContext _db;

    public ReviewsController(BestRestaurantsContext db)
    {
      _db = db;
    } 

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult Create()
    {
      try
      {
        List<Restaurant> existingRestaurants = _db.Restaurants.ToList();
        if (existingRestaurants.Count >= 1)
        {
          ViewBag.RestaurantId = new SelectList(_db.Restaurants, "RestaurantId", "Name");
          return View();
        }
        else
        {
          throw new System.InvalidOperationException("No restaurants available to review.");
        }
      }
      catch (Exception ex)
      {
        return View("Error", ex.Message);
      }
    }

    [HttpPost]
    public ActionResult Create(Review review)
    {
      try
      {
        if (String.IsNullOrWhiteSpace(review.Title) || String.IsNullOrWhiteSpace(review.Description))
        {
          throw new System.InvalidOperationException("invalid input");
        }
        else
        {
          _db.Reviews.Add(review);
          _db.SaveChanges();
          return RedirectToAction("Index");
        }
      }
      catch(Exception ex)
      {
        return View("Error", ex.Message);
      }
    }
  }
}