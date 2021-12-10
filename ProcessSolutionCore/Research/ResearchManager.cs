using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProcessSolution
{
    public class ResearchManager
    {

        public Research StartResearch(ResearchModel model)
        {
            Research r = new Research();
            r.Model = model;



            return r;
        }



    }
}