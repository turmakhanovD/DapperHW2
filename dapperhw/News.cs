using System;
using System.Collections.Generic;

namespace NewsApp
{
    public class News : Entity
    {
        public string Article { get; set; }
        public string Text { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
