using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using GameStore.Frontend.Converters;

namespace GameStore.Frontend.Models;

public class GameDetails
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The name field is required and it should not exceed 50 characters.")]
    [StringLength(50)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "The genre field is required.")]
    [JsonConverter(typeof(StringConverter))]
    public string? GenreId { get; set; }

    [Range(1, 100)]
    public decimal Price { get; set; }

    public DateOnly ReleaseDate { get; set; }
}
