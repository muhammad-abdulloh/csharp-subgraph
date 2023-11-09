namespace Server;

public class ThingInput
{
    public required string Id { get; set; }

    public string? Name { get; set; }
}


public class Mutation
{
    public Thing? createThing(ThingInput thing, Data repository)
    {
        var newThing = new Thing(thing);
        repository.Things.Add(newThing);
        return newThing;
    }
}
