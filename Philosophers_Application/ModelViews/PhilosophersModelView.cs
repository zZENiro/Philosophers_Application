using Microsoft.AspNetCore.Mvc.Rendering;
using Philosophers_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Philosophers_Application.ModelViews
{
    public class PhilosophersModelView
    { 
        public List<Philosopher> Philosophers { get; set; }

        public SelectList Names { get; set; }
    }
}
