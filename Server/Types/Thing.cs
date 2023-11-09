using ApolloGraphQL.HotChocolate.Federation;

namespace Server;

[Key("id")]
public class Thing
{
    public Thing(ThingInput thing)
    {
        Id = thing.Id;
        Name = thing.Name;
    }
    public Thing(string id, string? name)
    {
        Id = id;
        Name = name;
    }

    [ID]
    public string Id { get; }

    public string? Name { get; }

    [ReferenceResolver]
    public static Thing? GetThingById(
        string id,
        Data repository)
        => repository.Things.FirstOrDefault(t => t.Id.Equals(id));
}
