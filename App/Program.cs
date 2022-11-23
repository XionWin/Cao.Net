// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var entity = new Domain.Entity() {Id = Guid.NewGuid()};
var world = new Domain.World();
world.Add(entity);
world.Add(entity);
