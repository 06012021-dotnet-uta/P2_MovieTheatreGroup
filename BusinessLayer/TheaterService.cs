﻿using Microsoft.EntityFrameworkCore;
using ModelsLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
  public class TheaterService : ITheaterService
  {
    private readonly P2Context _context;

    /// <summary>
    /// Initializes an instance of the database models.
    /// </summary>
    /// <param name="context">A DbContext object</param>
    public TheaterService(P2Context context)
    {
      this._context = context;
    }

    /// <summary>
    /// Inserts a theater into the database
    /// </summary>
    /// <param name="theater">The theater object to insert into the database</param>
    public async Task<bool> CreateTheaterAsync(Theater theater)
    {
      await _context.Theaters.AddAsync(theater);
      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException exc)
      {
        // instead of WriteLine use Logging for exception
        Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
        return false;
      }
      catch (DbUpdateException exc)
      {
        Console.WriteLine($"There was a problem updating the Db => {exc.InnerException}");
        return false;
      }

      return true;
    }

    /// <summary>
    /// Removes a theater from the database
    /// </summary>
    /// <param name="theaterId">The ID of the theater to remove</param>
    public async void DeleteTheaterAsync(int theaterId)
    {
      var theaterToDelete = _context.Theaters.Where(th => th.TheaterId == theaterId).FirstOrDefault();
      _context.Theaters.Remove(theaterToDelete);
      await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates some information about a specific theater
    /// </summary>
    /// <param name="theaterId">The ID of the theater to update</param>
    /// <param name="theaterLoc">[optional] The potential change in location of the theater</param>
    /// <param name="theaterName">[optional] The ptential change in name of the theater</param>
    public async void UpdateTheaterAsync(int theaterId, string theaterLoc = "", string theaterName = "")
    {
      if (theaterLoc == "" && theaterName == "") return;
      var theaterToUpdate = _context.Theaters.Where(th => th.TheaterId == theaterId).FirstOrDefault();
      if (theaterLoc != "") theaterToUpdate.TheaterLoc = theaterLoc;
      if (theaterName != "") theaterToUpdate.TheaterName = theaterName;
      _context.Theaters.Update(theaterToUpdate);
      await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Selects all of the theaters from the theaters table
    /// </summary>
    /// <returns>A list of Theater objects representing the theaters in the table</returns>
    public List<Theater> SelectTheaters() 
    { 
      var TheatersTable = _context.Theaters;
      List<Theater> Theaters = new();
      foreach (var th in TheatersTable)
      {
        Theater theater = new() 
        {
          TheaterId = th.TheaterId,
          TheaterLoc = th.TheaterLoc,
          TheaterName = th.TheaterName,
          TheaterMovies = th.TheaterMovies
        };
        Theaters.Add(theater);
      }
      return Theaters;
    }

    /// <summary>
    /// Selects a specific theater
    /// </summary>
    /// <param name="theaterId">The ID of the theater to select</param>
    /// <returns>A Theater object representing the specified theater</returns>
    public Theater SelectTheater(int theaterId)
    {
      var TheatersTable = _context.Theaters;
      var dbResults = TheatersTable.Where(th => th.TheaterId == theaterId).ToList();
      Theater theater = null;
      foreach (var th in TheatersTable)
      {
        theater = new()
        {
          TheaterId = th.TheaterId,
          TheaterLoc = th.TheaterLoc,
          TheaterName = th.TheaterName,
          TheaterMovies = th.TheaterMovies
        };
      }
      return theater;
    }
  }
}


