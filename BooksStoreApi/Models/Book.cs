
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BooksStoreApi.Models;

public class Book{
   [BsonId]
   [BsonRepresentation(BsonType.ObjectId)]   //it allows pass object Id in form of string
    public string? Id {get;set;}

    [Required]                                  //first name is requird
    [BsonElement("Name")]
    public string BookName {get;set;}
    
    [Required]
    public decimal Price{get;set;}
    
    [Required]
    public string Category{get;set;}
    [Required]
    public string Author{get;set;}
}