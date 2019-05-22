using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class WorkCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Work> Works { get; set; }
    }

    public class Work
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public virtual List<WorkCategory> Categories { get; set; }
    }
}
