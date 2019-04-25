using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp
{
    public class Comment : Entity
    {
        public string Text { get; set; }
        public Guid NewsId { get; set; }
        public News news { get; set; }
    }
}
