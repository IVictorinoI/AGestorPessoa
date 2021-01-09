using System;
using System.Collections.Generic;
using System.Text;
using Application.Data;

namespace Application.Base
{
    public class Aplic
    {
        protected readonly DataContext Context;
        public Aplic(DataContext context)
        {
            Context = context;
        }
    }
}
