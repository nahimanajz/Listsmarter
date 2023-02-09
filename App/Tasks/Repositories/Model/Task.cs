﻿using CSharp_intro_1.People.Repositories.Modal;
using CSharp_intro_1.Repositories.Models;

namespace CSharp_intro_1.Repositories.Models
{
    public class Task
    {
       public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; } 
        public Person Person { get; set; }
        public Guid PersonId { get; set; }
        public Bucket Bucket { get; set; }
        public Guid BucketId { get; set; }
    }
}
