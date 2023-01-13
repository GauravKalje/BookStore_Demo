
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksStoreApi.Models;

public class Customer{

    [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]   //it allows pass object Id in form of string
    public string? Id {get;set;}

    [Required]                                  //first name is requird
    [BsonElement("Name")]
    public string CustName {get;set;} = null !;
    
    [Required]
    public int Age{get;set;}
    
    [Required]
    public string Sex{get;set;} = null!;
    [Required]
    public string Department{get;set;} = null !;
}