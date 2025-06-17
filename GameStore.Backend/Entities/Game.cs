using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Backend.Entities;

public class Game
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    public int GenreId { get; set; }

    public Genre? Genre { get; set; }

    public decimal Price { get; set; }
    
    public DateOnly ReleaseDate { get; set; }
}
