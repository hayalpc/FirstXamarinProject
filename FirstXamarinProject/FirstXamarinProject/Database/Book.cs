using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.Database
{
    public class Book : BaseModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public int Page { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
