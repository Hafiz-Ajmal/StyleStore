
namespace StyleStore.Models;
using System.ComponentModel.DataAnnotations;

public class Category
{
    public int Id {get;set;}

    [Required(ErrorMessage ="Category name is required")]
    public string Name{get;set;}=String.Empty; //not optional required //should not contain null
    public string? Description {get;set;}  //optional ? //means the property is allowed to contain null

    public string? ImageUrl {get;set;}

    public bool IsActive {get;set;}=true;




}