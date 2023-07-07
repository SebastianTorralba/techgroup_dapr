﻿namespace AcademyManager.Application.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool Enabled { get; set; }
    }
}
