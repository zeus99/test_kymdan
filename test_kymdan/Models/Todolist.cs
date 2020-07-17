using System;
using System.Collections.Generic;

namespace test_kymdan.Models
{
    public partial class Todolist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? Duedate { get; set; }
        public int CategoryId { get; set; }
        public bool? Complete { get; set; }
    }
}
