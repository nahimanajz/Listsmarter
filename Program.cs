

using CSharp_intro_1.Repositories;
using CSharp_intro_1.Repositories.Models;


Console.WriteLine("Hello, World!");
var pr = new PersonRepository();
pr.Create(new Person
{
    Id = 4,
    FirstName = "Foo",
    LastName = "Bar",
});
var p = new Person
{
    Id = 4,
    FirstName = "mwiriwe",
    LastName = "dlaksdj",
};

pr.Update(p);

var items = pr.GetAll();
foreach (var item in items)
{
    Console.WriteLine(item.FirstName);
}
var person = pr.GetById(1);
Console.WriteLine($"id: {person.Id} FirstName: {person.LastName}");