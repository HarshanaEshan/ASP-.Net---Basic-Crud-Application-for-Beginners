using System;
using System.Collections.Generic;

namespace Student_Registration_Crud_Application.Models;

public partial class StudentsTable
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }
}
