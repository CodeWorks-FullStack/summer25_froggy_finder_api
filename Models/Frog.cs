using System.ComponentModel.DataAnnotations;

namespace froggy_finder_api.Models;
// backing model
public class Frog
{
  public int Id { get; set; }
  [MinLength(3)] public string Name { get; set; }
  public string Color { get; set; }
  public string Species { get; set; }
  public bool IsPoisonous { get; set; }
  public int NumberOfToes { get; set; }
  public bool IsSingle { get; set; }
}