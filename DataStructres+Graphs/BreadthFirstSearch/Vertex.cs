﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreadthFirstSearch
{
    internal class Vertex
    {
        public String name;
        public int state;

        public Vertex(String name)
        {
            this.name = name;
        }
    }
}