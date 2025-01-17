﻿using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IMovieService
    {
        Task<List<Movie>> MovieListAsync(); // MovieList
        Movie Movie(string id);

    }

}
