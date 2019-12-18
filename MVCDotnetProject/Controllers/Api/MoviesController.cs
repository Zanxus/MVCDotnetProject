﻿using AutoMapper;
using MVCDotnetProject.Dtos;
using MVCDotnetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;

namespace MVCDotnetProject.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<MovieDto> GetMovies() {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public IHttpActionResult GetMovie(int id)
        {
           var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
               return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                BadRequest();
            Movie movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                NotFound();
            }
            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }

        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInBd = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInBd == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movieInBd);
            _context.SaveChanges();
            return Ok();
        }

    }
}