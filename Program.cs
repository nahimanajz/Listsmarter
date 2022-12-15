

using CSharp_intro_1.Repositories;

Console.WriteLine("Hello, World!");
var pr = new PersonRepository();
var items = pr.GetAll();
foreach (var item in items)
{
    Console.WriteLine(item.FirstName);
}
var person = pr.GetById(2);
Console.WriteLine($"id: {person.Id} FirstName: {person.LastName}");