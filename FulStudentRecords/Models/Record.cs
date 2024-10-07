using System;
using System.Collections.Generic;

namespace FulStudentRecords.Models;

public partial class Record
{
    public string Name { get; set; } = null!;

    public string Maths { get; set; } = null!;

    public string Physics { get; set; } = null!;

    public string Chemistry { get; set; } = null!;

    public string Biology { get; set; } = null!;

    public string English { get; set; } = null!;

    public string Grade { get; set; } = null!;

    public int Id { get; set; }

    public int? Total { get; set; }
}
