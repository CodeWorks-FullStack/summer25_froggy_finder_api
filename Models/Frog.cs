using System.ComponentModel.DataAnnotations;

namespace froggy_finder_api.Models;
//  REVIEW backing model (supports rows of data coming out of sql table)
// your model should support every column that is set up in your sql table that you want to send over the network to clients. Make sure your data types match up. All class members `should` be UpperPascalCased
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