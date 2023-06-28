﻿namespace AcademyManager.Domain
{
    public class Teacher: BaseEntity
    {
        //public int Id { get; set; }
        public Teacher()
        {
            Subjects = new HashSet<Subject>();
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        //public int AcademyId { get; set; }
        public ICollection<Subject> Subjects { get; set; } 

        //public int SubjectId { get; set; }
        
        //public bool Enabled { get; set; }
    }
}
