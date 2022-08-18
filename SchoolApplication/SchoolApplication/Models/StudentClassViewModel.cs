using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SchoolApplication.Models
{
    public class StudentClassViewModel
    {
        public List<Student> Students { get; set; }
        public SelectList Classes { get; set; }
        public string StudentClass { get; set; }
        public string SearchString { get; set; }

    }
}
