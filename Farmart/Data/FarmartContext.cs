using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farmart.Models;

namespace Farmart.Data
{
    public class FarmartContext : DbContext
    {
        public FarmartContext (DbContextOptions<FarmartContext> options)
            : base(options)
        {
        }

    }
}