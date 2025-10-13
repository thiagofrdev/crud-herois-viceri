namespace Superheroes.Api;

public class Superpoderes
{
    public int Id { get; set; }
    public string Superpoder { get; set; }
    public string Descricao { get; set; }
    public ICollection<Herois> Herois { get; set; }
}
