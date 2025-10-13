﻿namespace Superheroes.Api.Entities;

public class Herois
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeHeroi { get; set; }
    public DateTime DataNascimento { get; set; }
    public float Altura { get; set; }
    public float Peso { get; set; }
    public ICollection<Superpoderes> Superpoderes { get; set; }
}
