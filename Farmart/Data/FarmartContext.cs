using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class FarmartContext : DbContext
    {
        public FarmartContext (DbContextOptions<FarmartContext> options)
            : base(options)
        {
        }

    }
}