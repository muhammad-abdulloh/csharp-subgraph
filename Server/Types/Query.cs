namespace Server;

public class Query
{
    public Thing? Thing([ID] string id, Data repository)
        => repository.Things.FirstOrDefault(t => t.Id.Equals(id));
}
