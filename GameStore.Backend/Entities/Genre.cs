using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Backend.Entities;

public class Genre
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

}
