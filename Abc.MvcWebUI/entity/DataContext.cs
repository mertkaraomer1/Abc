﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("dataConnection")
        {

        }
        public DbSet<product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}