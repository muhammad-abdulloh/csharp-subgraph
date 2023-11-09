using ApolloGraphQL.HotChocolate.Federation.Two;
using HotChocolate;
using HotChocolate.Execution;
using Snapshooter.Xunit;

namespace Server;

public class EntitiesResolverTests
{
    private static async Task<IRequestExecutor> CreateSchemaAsync()
        => await new ServiceCollection()
            .AddSingleton<Data>()
            .AddGraphQL()
            .AddApolloFederationV2(new CustomSchema())
            .AddType<ContactDirectiveType>()
            .AddQueryType<Query>()
            .RegisterService<Data>()
            .BuildRequestExecutorAsync();

    [Fact]
    public async Task Schema_Snapshot()
    {
        var executor = await CreateSchemaAsync();
        executor.Schema.Print().MatchSnapshot();
    }

    [Fact]
    public async Task Thing_By_Id()
    {
        // arrange
        var executor = await CreateSchemaAsync();

        // act
        var result = await executor.ExecuteAsync(
            @"query {
                thing(id: ""1"") {
                    id
                    name
                }
            }");

        // assert
        result.ToJson().MatchSnapshot();
    }
}