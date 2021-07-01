using AutoMapper;
using mosh_practice.App_Start;
using mosh_practice.Dtos;
using mosh_practice.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mosh_practice.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        private MapperConfiguration config;
        private IMapper iMapper;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
            config = new AutoMapperConfiguration().Configure();
            iMapper = config.CreateMapper();
        }

        //GET/api/movies 查看所有電影
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m=>m.Genre)
                .ToList()
                .Select(iMapper.Map<Movie,MovieDto>);
        }
        //GET/api/movies/1 查看特定電影
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(iMapper.Map<Movie, MovieDto>(movie));
        }
        //POST/api/movies 新增電影
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = iMapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri+"/"+ movieDto.Id),movieDto);
        }
        //PUT/api/movies/1 修改電影
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            iMapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            _context.SaveChanges();
            return Ok();
        }
        //DELETE/api/movies/1 刪除顧客
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
