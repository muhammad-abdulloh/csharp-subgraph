# .NET HotChocolate Federated GraphQL Subgraph

[![Deploy on Railway](https://railway.app/button.svg)](https://railway.app/template/cJcDcc?referralCode=neALOu)

This is an example application template that can be used to create Federated GraphQL subgraph using [HotChocolate](https://chillicream.com/docs/hotchocolate/v13). You can use this template from [Rover](https://www.apollographql.com/docs/rover/commands/template/) with `rover template use --template subgraph-csharp-hotchocolate-annotation`.

This example application implements following GraphQL schema:

```graphql
extend schema
  @link(url: "https://specs.apollo.dev/federation/v2.5", import: ["@key"])

type Query {
  thing(id: ID!): Thing
}

type Mutation {
  createThing(thing: CreateThing!): Thing
}

type Thing @key(fields: "id") {
  id: ID!
  name: String
}

input CreateThing {
  id: ID!
  name: String
}
```

## Build

This project uses [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/) and requires .NET 7.0+ runtime. In order to build the project locally run

```shell
dotnet build
```

To test the project run

```shell
dotnet test
```

### Continuous Integration

This project comes with some example build actions that will trigger on PR requests and commits to the main branch.

## Run

To start the GraphQL server:

```shell script
# from root directory
dotnet run --project Server

# from Server directory
dotnet run
```

Once the app has started you can explore the example schema by opening the Banana Cake Pop IDE at http://localhost:4001/ or http://localhost:4001/graphql and begin developing your supergraph with `rover dev --url http://localhost:4001/graphql --name my-subgraph`.

## Debug in VS Code

There is a launch configuration for both the Server project and the Tests project that you can debug with VS Code. Open up the debug panel in VS Code and press the play button.

## GraphOS Integration

1. Set these secrets in GitHub Actions:
   1. APOLLO_KEY: An Apollo Studio API key for the supergraph to enable schema checks and publishing of the
      subgraph.
   2. APOLLO_GRAPH_REF: The name of the supergraph in Apollo Studio.
   3. PRODUCTION_URL: The URL of the deployed subgraph that the supergraph gateway will route to.
2. Set `SUBGRAPH_NAME` in .github/workflows/checks.yaml and .github/workflows/deploy.yaml
3. Remove the `if: false` lines from `.github/workflows/checks.yaml` and `.github/workflows/deploy.yaml` to enable schema checks and publishing.
4. Write your custom deploy logic in `.github/workflows/deploy.yaml`.
5. Send the `Router-Authorization` header [from your Cloud router](https://www.apollographql.com/docs/graphos/routing/cloud-configuration#managing-secrets) and set the `ROUTER_SECRET` environment variable wherever you deploy this to.

## Additional Resources

- [HotChocolate documentation](https://chillicream.com/docs/hotchocolate/v13)
- [.NET SDL documentation](https://learn.microsoft.com/en-us/dotnet/core/sdk)
- [.NET CLI documentation](https://learn.microsoft.com/en-us/dotnet/core/tools/)
