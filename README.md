<img src="https://github.com/jchristn/LiteGraph/blob/main/assets/favicon.png" width="256" height="256">

# LiteGraph C# SDK

[![NuGet Version](https://img.shields.io/nuget/v/LiteGraph.Sdk.svg?style=flat)](https://www.nuget.org/packages/LiteGraph.Sdk/) [![NuGet](https://img.shields.io/nuget/dt/LiteGraph.Sdk.svg)](https://www.nuget.org/packages/LiteGraph.Sdk) 

LiteGraph is a property graph database with support for graph relationships, tags, labels, metadata, data, and vectors.  LiteGraph is intended to be a unified database for providing persistence and retrieval for knowledge and artificial intelligence applications.

## New in v4.0.x

- Added support for labels on graphs, nodes, edges (string list)
- Added support for vector persistence and search
- Updated SDK, test, and Postman collections accordingly
- Updated GEXF export to support labels and tags
- Internal refactor to reduce code bloat
- Multiple bugfixes and QoL improvements

## Bugs, Feedback, or Enhancement Requests

Please feel free to start an issue or a discussion!

## Example

Refer to the `Test.Sdk` project for a full example.

```csharp
using LiteGraph.Sdk;

LiteGraphSdk sdk = new LiteGraphSdk("http://localhost:8701", "default");
Guid tenantGuid = Guid.Parse("00000000-0000-0000-0000-000000000000");

Graph graph = sdk.CreateGraph(tenantGuid, Guid.NewGuid(), "My graph");
Node node1 = sdk.CreateNode(tenantGuid, graph.GUID, new Node { Name = "My node 1" });
Node node2 = sdk.CreateNode(tenantGuid, graph.GUID, new Node { Name = "My node 2" });
Edge edgeFrom1To2 = sdk.CreateEdge(tenantGuid, graph.GUID, new Edge { From = node1.GUID, To = node2.GUID });
```

## Version History

Please refer to ```CHANGELOG.md``` for version history.

