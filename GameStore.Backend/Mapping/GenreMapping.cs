using System;
<<<<<<< HEAD
using GameStore.Backend.Dtos;
using GameStore.Backend.Entities;

namespace GameStore.Backend.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
=======

namespace GameStore.Backend.Mapping;

public class GenreMapping
{

>>>>>>> b38010617d266f3304b757b04c08b339e64cae25
}
