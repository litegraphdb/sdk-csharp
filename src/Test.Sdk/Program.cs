namespace Test.Sdk
{
    using System;
    using System.Collections.Specialized;
    using ExpressionTree;
    using GetSomeInput;
    using LiteGraph.Sdk;

    public static class Program
    {
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning disable CS8603 // Possible null reference return.

        private static bool _Debug = true;
        private static bool _RunForever = true;
        private static string _Endpoint = "http://localhost:8701";
        private static string _BearerToken = "litegraphadmin";
        private static Guid _Tenant = Guid.Parse("00000000-0000-0000-0000-000000000000");
        private static Guid _Graph = Guid.Parse("00000000-0000-0000-0000-000000000000");
        private static LiteGraphSdk _Sdk = null;

        public static void Main(string[] args)
        {
            _Sdk = new LiteGraphSdk(
                Inputty.GetString("Endpoint     :", _Endpoint, false),
                Inputty.GetString("Bearer token :", _BearerToken, false));

            _Tenant = Inputty.GetGuid("Tenant GUID  :", _Tenant);

            if (_Debug) _Sdk.Logger = Logger;

            while (_RunForever)
            {
                string userInput = Inputty.GetString("Command [?/help]:", null, false);

                switch (userInput)
                {
                    case "?":
                        Menu();
                        break;
                    case "q":
                        _RunForever = false;
                        break;
                    case "cls":
                        Console.Clear();
                        break;

                    case "conn":
                        ValidateConnectivity();
                        break;

                    case "backup":
                        BackupDatabase();
                        break;

                    case "flush":
                        FlushDatabase();
                        break;

                    case "tenant":
                        SetTenant();
                        break;
                    case "graph":
                        SetGraph();
                        break;

                    case "tenant exists":
                        TenantExists();
                        break;
                    case "tenant create":
                        TenantCreate();
                        break;
                    case "tenant update":
                        TenantUpdate();
                        break;
                    case "tenant all":
                        TenantAll();
                        break;
                    case "tenant read":
                        TenantRead();
                        break;
                    case "tenant enum":
                        TenantEnumerate();
                        break;
                    case "tenant stats":
                        TenantStats();
                        break;
                    case "tenant delete":
                        TenantDelete();
                        break;

                    case "user exists":
                        UserExists();
                        break;
                    case "user create":
                        UserCreate();
                        break;
                    case "user update":
                        UserUpdate();
                        break;
                    case "user all":
                        UserAll();
                        break;
                    case "user read":
                        UserRead();
                        break;
                    case "user enum":
                        UserEnumerate();
                        break;
                    case "user delete":
                        UserDelete();
                        break;

                    case "cred exists":
                        CredentialExists();
                        break;
                    case "cred create":
                        CredentialCreate();
                        break;
                    case "cred update":
                        CredentialUpdate();
                        break;
                    case "cred all":
                        CredentialAll();
                        break;
                    case "cred read":
                        CredentialRead();
                        break;
                    case "cred enum":
                        CredentialEnumerate();
                        break;
                    case "cred delete":
                        CredentialDelete();
                        break;

                    case "label exists":
                        LabelExists();
                        break;
                    case "label create":
                        LabelCreate();
                        break;
                    case "label update":
                        LabelUpdate();
                        break;
                    case "label all":
                        LabelAll();
                        break;
                    case "label read":
                        LabelRead();
                        break;
                    case "label enum":
                        LabelEnumerate();
                        break;
                    case "label delete":
                        LabelDelete();
                        break;

                    case "tag exists":
                        TagExists();
                        break;
                    case "tag create":
                        TagCreate();
                        break;
                    case "tag update":
                        TagUpdate();
                        break;
                    case "tag all":
                        TagAll();
                        break;
                    case "tag read":
                        TagRead();
                        break;
                    case "tag enum":
                        TagEnumerate();
                        break;
                    case "tag delete":
                        TagDelete();
                        break;

                    case "vector exists":
                        VectorExists();
                        break;
                    case "vector create":
                        VectorCreate();
                        break;
                    case "vector update":
                        VectorUpdate();
                        break;
                    case "vector all":
                        VectorAll();
                        break;
                    case "vector read":
                        VectorRead();
                        break;
                    case "vector enum":
                        VectorEnumerate();
                        break;
                    case "vector delete":
                        VectorDelete();
                        break;

                    case "graph exists":
                        GraphExists();
                        break;
                    case "graph create":
                        GraphCreate();
                        break;
                    case "graph update":
                        GraphUpdate();
                        break;
                    case "graph all":
                        GraphAll();
                        break;
                    case "graph read":
                        GraphRead();
                        break;
                    case "graph enum":
                        GraphEnumerate();
                        break;
                    case "graph stats":
                        GraphStats();
                        break;
                    case "graph delete":
                        GraphDelete();
                        break;
                    case "graph search":
                        GraphSearch();
                        break;
                    case "graph enable index":
                        GraphEnableVectorIndex();
                        break;
                    case "graph rebuild index":
                        GraphRebuildVectorIndex();
                        break;
                    case "graph delete index":
                        GraphDeleteVectorIndex();
                        break;
                    case "graph read index config":
                        GraphReadVectorIndexConfig();
                        break;
                    case "graph index stats":
                        GraphVectorIndexStats();
                        break;

                    case "node exists":
                        NodeExists();
                        break;
                    case "node create":
                        NodeCreate();
                        break;
                    case "node update":
                        NodeUpdate();
                        break;
                    case "node all":
                        NodeAll();
                        break;
                    case "node read":
                        NodeRead();
                        break;
                    case "node enum":
                        NodeEnumerate();
                        break;
                    case "node delete":
                        NodeDelete();
                        break;
                    case "node search":
                        NodeSearch();
                        break;

                    case "node edges":
                        NodeEdges();
                        break;
                    case "node parents":
                        NodeParents();
                        break;
                    case "node children":
                        NodeChildren();
                        break;

                    case "edge exists":
                        EdgeExists();
                        break;
                    case "edge create":
                        EdgeCreate();
                        break;
                    case "edge update":
                        EdgeUpdate();
                        break;
                    case "edge all":
                        EdgeAll();
                        break;
                    case "edge read":
                        EdgeRead();
                        break;
                    case "edge enum":
                        EdgeEnumerate();
                        break;
                    case "edge delete":
                        EdgeDelete();
                        break;
                    case "edge search":
                        EdgeSearch();
                        break;

                    case "edges from":
                        EdgesFrom();
                        break;
                    case "edges to":
                        EdgesTo();
                        break;
                    case "edges between":
                        EdgesBetween();
                        break;

                    case "route":
                        Route();
                        break;

                    case "vsearch":
                        VectorSearch();
                        break;
                }

                Console.WriteLine("");
            }
        }

        private static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("Available commands:");
            Console.WriteLine("  ?               help, this menu");
            Console.WriteLine("  q               quit");
            Console.WriteLine("  cls             clear the screen");
            Console.WriteLine("  conn            validate connectivity");
            Console.WriteLine("  backup          create a database backup");
            Console.WriteLine("  tenant          set the tenant GUID (currently " + _Tenant + ")");
            Console.WriteLine("  graph           set the graph GUID (currently " + _Graph + ")");
            Console.WriteLine("");
            Console.WriteLine("Administrative commands (requires administrative bearer token):");
            Console.WriteLine("  Tenants       : tenant [create|update|all|read|enum|stats|delete|exists]");
            Console.WriteLine("  Users         : user [create|update|all|read|enum|delete|exists]");
            Console.WriteLine("  Credentials   : cred [create|update|all|read|enum|delete|exists]");
            Console.WriteLine("  Labels        : label [create|update|all|read|enum|delete|exists]");
            Console.WriteLine("  Tags          : tag [create|update|all|read|enum|delete|exists]");
            Console.WriteLine("  Vectors       : vector [create|update|all|read|enum|delete|exists]");
            Console.WriteLine("");
            Console.WriteLine("User commands:");
            Console.WriteLine("  Graphs        : graph [create|update|all|read|enum|stats|delete|exists|search|enable index|rebuild index|delete index|read index config|index stats]");
            Console.WriteLine("  Nodes         : node [create|update|all|read|enum|delete|exists|search|edges|parents|children]");
            Console.WriteLine("  Edges         : edge [create|update|all|read|enum|delete|exists|from|to|search|between]");
            Console.WriteLine("  Vector search : vsearch");
            Console.WriteLine("");
            Console.WriteLine("Routing commands:");
            Console.WriteLine("  route");
            Console.WriteLine("");
        }

        private static void Logger(SeverityEnum sev, string msg)
        {
            Console.WriteLine(sev.ToString() + " " + msg);
        }

        private static void SetTenant()
        {
            _Tenant = Inputty.GetGuid("Tenant GUID:", _Tenant);
        }

        private static void SetGraph()
        {
            _Graph = Inputty.GetGuid("Graph GUID:", _Graph);
        }

        private static string GetName()
        {
            return Inputty.GetString("Name:", null, false);
        }

        private static List<string> GetLabels()
        {
            string val = GetJson("Labels JSON:");
            if (!String.IsNullOrEmpty(val)) return Serializer.DeserializeJson<List<string>>(val);
            return null;
        }

        private static NameValueCollection GetTags()
        {
            string val = GetJson("Tags JSON:");
            if (!String.IsNullOrEmpty(val)) return Serializer.DeserializeJson<NameValueCollection>(val);
            return null;
        }

        private static object GetData()
        {
            string val = GetJson("Data JSON:");
            if (!String.IsNullOrEmpty(val)) return Serializer.DeserializeJson<object>(val);
            return null;
        }

        private static List<VectorMetadata> GetVectors()
        {
            string val = GetJson("Vectors JSON:");
            if (!String.IsNullOrEmpty(val)) return Serializer.DeserializeJson<List<VectorMetadata>>(val);
            return null;
        }

        private static List<float> GetEmbeddings()
        {
            string val = GetJson("Embeddings JSON:");
            if (!String.IsNullOrEmpty(val)) return Serializer.DeserializeJson<List<float>>(val);
            return null;
        }

        private static string GetJson(string prompt)
        {
            return Inputty.GetString(prompt, null, true);
        }

        private static Guid GetGuid(string prompt, Guid? guid = null)
        {
            if (guid == null) return Inputty.GetGuid(prompt, default(Guid));
            else return Inputty.GetGuid(prompt, guid.Value);
        }

        private static bool GetBoolean(string prompt)
        {
            return Inputty.GetBoolean(prompt, true);
        }

        private static SearchRequest BuildSearchRequest(bool includeGraphGuid)
        {
            List<string> labels = GetLabels();
            NameValueCollection nvc = BuildNameValueCollection();
            Expr expr = BuildExpression();

            SearchRequest req = new SearchRequest();
            req.TenantGUID = Inputty.GetGuid("Tenant GUID:", _Tenant);
            if (includeGraphGuid) req.GraphGUID = Inputty.GetGuid("Graph GUID:", _Graph);
            req.Labels = labels;
            req.Tags = nvc;
            req.Expr = expr;
            return req;
        }

        private static VectorSearchRequest BuildVectorSearchRequest()
        {
            List<string> labels = GetLabels();
            NameValueCollection nvc = BuildNameValueCollection();
            Expr expr = BuildExpression();
            List<float> embeddings = GetEmbeddings();

            VectorSearchRequest req = new VectorSearchRequest();
            req.TenantGUID = Inputty.GetGuid("Tenant GUID:", _Tenant);
            string graphGuid = Inputty.GetString("Graph GUID:", null, true);
            string domain = Inputty.GetString("Domain [Graph|Node|Edge]:", "Node", false);
            string searchType = Inputty.GetString("Search type [CosineSimilarity|CosineDistance|EuclidianSimilarity|EuclidianDistance|DotProduct]:", "CosineSimilarity", false);

            if (!String.IsNullOrEmpty(graphGuid)) req.GraphGUID = Guid.Parse(graphGuid);
            req.Domain = (VectorSearchDomainEnum)(Enum.Parse(typeof(VectorSearchDomainEnum), domain));
            req.SearchType = (VectorSearchTypeEnum)(Enum.Parse(typeof(VectorSearchTypeEnum), searchType));
            req.Labels = GetLabels();
            req.Tags = nvc;
            req.Expr = expr;
            req.Embeddings = embeddings;
            return req;
        }

        private static NameValueCollection BuildNameValueCollection()
        {
            Console.WriteLine("");
            Console.WriteLine("Add keys and values to build a name value collection");
            Console.WriteLine("Press ENTER on a key to end");

            NameValueCollection ret = new NameValueCollection(StringComparer.InvariantCultureIgnoreCase);

            while (true)
            {
                string key = Inputty.GetString("Key   :", null, true);
                if (String.IsNullOrEmpty(key)) break;

                string val = Inputty.GetString("Value :", null, true);
                ret.Add(key, val);
            }

            return ret;
        }

        private static Expr BuildExpression()
        {
            Console.WriteLine("");
            Console.WriteLine("Add JSON values to build an expression");
            Console.WriteLine("Example expressions:");

            Expr e1 = new Expr("Age", OperatorEnum.GreaterThan, 38);
            e1.PrependAnd("Hobby.Name", OperatorEnum.Equals, "BJJ");
            Console.WriteLine(Serializer.SerializeJson(e1, false));

            Expr e2 = new Expr("Mbps", OperatorEnum.GreaterThan, 250);
            Console.WriteLine(Serializer.SerializeJson(e2, false));
            Console.WriteLine("");

            string json = Inputty.GetString("JSON:", null, true);
            if (String.IsNullOrEmpty(json)) return null;

            Expr expr = Serializer.DeserializeJson<Expr>(json);
            Console.WriteLine("");
            Console.WriteLine("Using expression: " + expr.ToString());
            Console.WriteLine("");
            return expr;
        }
         
        private static EnumerationRequest BuildEnumerationQuery()
        {
            return new EnumerationRequest
            {
                TenantGUID = _Tenant,
                GraphGUID = _Graph
            };
        }

        private static void EnumerateResult(object obj)
        {
            Console.WriteLine("");
            Console.Write("Result: ");
            if (obj == null) Console.WriteLine("(null)");
            else Console.WriteLine(Environment.NewLine + Serializer.SerializeJson(obj, true));
            Console.WriteLine("");
        }

        private static void ValidateConnectivity()
        {
            Console.WriteLine("Connected: " + _Sdk.ValidateConnectivity().Result);
        }

        #region Admin

        private static void BackupDatabase()
        {
            string filename = Inputty.GetString("Backup filename:", null, true);
            if (String.IsNullOrEmpty(filename)) return;
            _Sdk.Admin.Backup(filename).Wait();
        }

        private static void FlushDatabase()
        {
            _Sdk.Admin.FlushDatabase().Wait();
        }

        #endregion

        #region Tenant

        private static void ShowSampleTenant()
        {
            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new TenantMetadata
            {
                GUID = Guid.NewGuid(),
                Name = "My tenant"
            }, false));
        }

        private static void TenantExists()
        {
            EnumerateResult(_Sdk.Tenant.ExistsByGuid(
                GetGuid("GUID:", _Tenant)).Result);
        }

        private static void TenantCreate()
        {
            EnumerateResult(_Sdk.Tenant.Create(Serializer.DeserializeJson<TenantMetadata>(GetJson("Tenant JSON:"))).Result);
        }

        private static void TenantUpdate()
        {
            ShowSampleTenant();
            EnumerateResult(_Sdk.Tenant.Update(
                Serializer.DeserializeJson<TenantMetadata>(GetJson("Tenant JSON:"))).Result);
        }

        private static void TenantAll()
        {
            EnumerateResult(_Sdk.Tenant.ReadMany().Result);
        }

        private static void TenantRead()
        {
            EnumerateResult(_Sdk.Tenant.ReadByGuid(
                GetGuid("GUID:", _Tenant)).Result);
        }

        private static void TenantEnumerate()
        {
            EnumerateResult(_Sdk.Tenant.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void TenantStats()
        {
            EnumerateResult(_Sdk.Tenant.GetStatistics().Result);
        }

        private static void TenantDelete()
        {
            _Sdk.Tenant.DeleteByGuid(
                GetGuid("GUID:", _Tenant),
                GetBoolean("Force:")).Wait();
        }

        #endregion

        #region User

        private static void ShowSampleUser()
        {
            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new UserMaster
            {
                GUID = Guid.NewGuid(),
                FirstName = "First",
                LastName = "Last",
                Email = "first@last.com",
                Password = "password"
            }, false));
        }

        private static void UserExists()
        {
            EnumerateResult(_Sdk.User.ExistsByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void UserCreate()
        {
            ShowSampleUser();
            EnumerateResult(_Sdk.User.Create(Serializer.DeserializeJson<UserMaster>(GetJson("User JSON:"))).Result);
        }

        private static void UserAll()
        {
            EnumerateResult(_Sdk.User.ReadMany(GetGuid("Tenant GUID:", _Tenant)).Result);
        }

        private static void UserRead()
        {
            EnumerateResult(_Sdk.User.ReadByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void UserEnumerate()
        {
            EnumerateResult(_Sdk.User.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void UserUpdate()
        {
            ShowSampleUser();
            EnumerateResult(_Sdk.User.Update(Serializer.DeserializeJson<UserMaster>(GetJson("User JSON:"))).Result);
        }

        private static void UserDelete()
        {
            _Sdk.User.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Wait();
        }

        #endregion

        #region Credential

        private static void ShowSampleCredential()
        {
            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new Credential
            {
                Name = "My credential"
            }, false));
        }

        private static void CredentialExists()
        {
            EnumerateResult(_Sdk.Credential.ExistsByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void CredentialCreate()
        {
            ShowSampleCredential();
            EnumerateResult(_Sdk.Credential.Create(Serializer.DeserializeJson<Credential>(GetJson("Credential JSON:"))).Result);
        }

        private static void CredentialAll()
        {
            EnumerateResult(_Sdk.Credential.ReadMany(GetGuid("Tenant GUID:", _Tenant)).Result);
        }

        private static void CredentialRead()
        {
            EnumerateResult(_Sdk.Credential.ReadByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void CredentialEnumerate()
        {
            EnumerateResult(_Sdk.Credential.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void CredentialUpdate()
        {
            ShowSampleCredential();
            EnumerateResult(_Sdk.Credential.Update(Serializer.DeserializeJson<Credential>(GetJson("Credential JSON:"))).Result);
        }

        private static void CredentialDelete()
        {
            _Sdk.Credential.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Wait();
        }

        #endregion

        #region Label

        private static void ShowSampleLabel()
        {
            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new LabelMetadata
            {
                Label = "label"
            }, false));
        }

        private static void LabelExists()
        {
            EnumerateResult(_Sdk.Label.ExistsByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void LabelCreate()
        {
            ShowSampleLabel();
            EnumerateResult(_Sdk.Label.Create(Serializer.DeserializeJson<LabelMetadata>(GetJson("Label JSON:"))).Result);
        }

        private static void LabelAll()
        {
            EnumerateResult(_Sdk.Label.ReadMany(GetGuid("Tenant GUID:", _Tenant)).Result);
        }

        private static void LabelRead()
        {
            EnumerateResult(_Sdk.Label.ReadByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void LabelEnumerate()
        {
            EnumerateResult(_Sdk.Label.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void LabelUpdate()
        {
            ShowSampleLabel();
            EnumerateResult(_Sdk.Label.Update(Serializer.DeserializeJson<LabelMetadata>(GetJson("Label JSON:"))).Result);
        }

        private static void LabelDelete()
        {
            _Sdk.Label.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Wait();
        }

        #endregion

        #region Tag

        private static void ShowSampleTag()
        {
            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new TagMetadata
            {
                Key = "foo",
                Value = "bar"
            }, false));
        }

        private static void TagExists()
        {
            EnumerateResult(_Sdk.Tag.ExistsByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void TagCreate()
        {
            ShowSampleTag();
            EnumerateResult(_Sdk.Tag.Create(Serializer.DeserializeJson<TagMetadata>(GetJson("Tag JSON:"))).Result);
        }

        private static void TagAll()
        {
            EnumerateResult(_Sdk.Tag.ReadMany(GetGuid("Tenant GUID:", _Tenant), null, null, null).Result);
        }

        private static void TagRead()
        {
            EnumerateResult(_Sdk.Tag.ReadByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void TagEnumerate()
        {
            EnumerateResult(_Sdk.Tag.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void TagUpdate()
        {
            ShowSampleTag();
            EnumerateResult(_Sdk.Tag.Update(Serializer.DeserializeJson<TagMetadata>(GetJson("Tag JSON:"))).Result);
        }

        private static void TagDelete()
        {
            _Sdk.Tag.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Wait();
        }

        #endregion

        #region Vector

        private static void ShowSampleVector()
        {
            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new VectorMetadata
            {
                TenantGUID = _Tenant,
                GraphGUID = default(Guid),
                NodeGUID = default(Guid),
                EdgeGUID = default(Guid),
                Model = "test",
                Dimensionality = 384,
                Content = "content",
                Vectors = new List<float> { 0.1f, 0.2f, 0.3f }
            }, false));
        }

        private static void VectorExists()
        {
            EnumerateResult(_Sdk.Vector.ExistsByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void VectorCreate()
        {
            ShowSampleVector();
            EnumerateResult(_Sdk.Vector.Create(Serializer.DeserializeJson<VectorMetadata>(GetJson("Vector JSON:"))).Result);
        }

        private static void VectorAll()
        {
            EnumerateResult(_Sdk.Vector.ReadMany(GetGuid("Tenant GUID:", _Tenant)).Result);
        }

        private static void VectorRead()
        {
            EnumerateResult(_Sdk.Vector.ReadByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void VectorEnumerate()
        {
            EnumerateResult(_Sdk.Vector.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void VectorUpdate()
        {
            ShowSampleVector();
            EnumerateResult(_Sdk.Vector.Update(Serializer.DeserializeJson<VectorMetadata>(GetJson("Vector JSON:"))).Result);
        }

        private static void VectorDelete()
        {
            _Sdk.Vector.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Wait();
        }

        #endregion

        #region Graph

        private static void ShowSampleGraph()
        {
            List<string> labels = new List<string>();
            labels.Add("test");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("key", "value");

            NameValueCollection tags = new NameValueCollection();
            tags.Add("key", "value");

            List<VectorMetadata> vectors = new List<VectorMetadata>
            {
                new VectorMetadata
                {
                    TenantGUID = default(Guid),
                    GraphGUID = default(Guid),
                    Model = "test model",
                    Dimensionality = 3,
                    Content = "test data",
                    Vectors = new List<float> { 0.1f, 0.2f, 0.3f }
                }
            };

            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new Graph
            {
                TenantGUID = _Tenant,
                Name = "Test graph",
                Labels = labels,
                Tags = tags,
                Data = data,
                Vectors = vectors
            }, false));
        }

        private static void GraphExists()
        {
            EnumerateResult(_Sdk.Graph.ExistsByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:")).Result);
        }

        private static void GraphCreate()
        {
            ShowSampleGraph();
            EnumerateResult(_Sdk.Graph.Create(Serializer.DeserializeJson<Graph>(GetJson("Graph JSON:"))).Result);
        }

        private static void GraphAll()
        {
            EnumerateResult(_Sdk.Graph.ReadMany(GetGuid("Tenant GUID:", _Tenant)).Result);
        }

        private static void GraphRead()
        {
            EnumerateResult(_Sdk.Graph.ReadByGuid(
                GetGuid("Tenant GUID:", _Tenant), 
                GetGuid("GUID:", _Graph)).Result);
        }

        private static void GraphEnumerate()
        {
            EnumerateResult(_Sdk.Graph.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void GraphUpdate()
        {
            ShowSampleGraph();
            EnumerateResult(_Sdk.Graph.Update(Serializer.DeserializeJson<Graph>(GetJson("Graph JSON:"))).Result);
        }

        private static void GraphStats()
        {
            EnumerateResult(_Sdk.Graph.GetStatistics(_Tenant).Result);
        }

        private static void GraphDelete()
        {
            _Sdk.Graph.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("GUID:", _Graph), 
                GetBoolean("Force:")).Wait();
        }

        private static void GraphSearch()
        {
            SearchRequest req = BuildSearchRequest(false);
            if (req == null) return;
            EnumerateResult(_Sdk.Graph.Search(req).Result);
        }

        private static void ShowSampleVectorIndexConfig()
        {
            Console.WriteLine("Sample JSON:");
            Console.WriteLine(Serializer.SerializeJson(new VectorIndexConfiguration
            {
                VectorIndexType = VectorIndexTypeEnum.HnswSqlite,
                VectorIndexFile = "graph-00000000-0000-0000-0000-000000000000-hnsw.db",
                VectorIndexThreshold = null,
                VectorDimensionality = 384,
                VectorIndexM = 16,
                VectorIndexEf = 50,
                VectorIndexEfConstruction = 200
            }, false));
        }

        private static void GraphEnableVectorIndex()
        {
            ShowSampleVectorIndexConfig();
            Guid tenantGuid = GetGuid("Tenant GUID:", _Tenant);
            Guid graphGuid = GetGuid("Graph GUID:", _Graph);
            string json = GetJson("Vector Index Configuration JSON:");
            if (String.IsNullOrEmpty(json)) return;
            
            VectorIndexConfiguration config = Serializer.DeserializeJson<VectorIndexConfiguration>(json);
            _Sdk.Graph.EnableVectorIndexing(tenantGuid, graphGuid, config).Wait();
            Console.WriteLine("Vector indexing enabled successfully.");
        }

        private static void GraphRebuildVectorIndex()
        {
            Guid tenantGuid = GetGuid("Tenant GUID:", _Tenant);
            Guid graphGuid = GetGuid("Graph GUID:", _Graph);
            _Sdk.Graph.RebuildVectorIndex(tenantGuid, graphGuid).Wait();
            Console.WriteLine("Vector index rebuild initiated successfully.");
        }

        private static void GraphDeleteVectorIndex()
        {
            Guid tenantGuid = GetGuid("Tenant GUID:", _Tenant);
            Guid graphGuid = GetGuid("Graph GUID:", _Graph);
            _Sdk.Graph.DeleteVectorIndex(tenantGuid, graphGuid).Wait();
            Console.WriteLine("Vector index deleted successfully.");
        }

        private static void GraphReadVectorIndexConfig()
        {
            Guid tenantGuid = GetGuid("Tenant GUID:", _Tenant);
            Guid graphGuid = GetGuid("Graph GUID:", _Graph);
            EnumerateResult(_Sdk.Graph.ReadVectorIndexConfig(tenantGuid, graphGuid).Result);
        }

        private static void GraphVectorIndexStats()
        {
            Guid tenantGuid = GetGuid("Tenant GUID:", _Tenant);
            Guid graphGuid = GetGuid("Graph GUID:", _Graph);
            EnumerateResult(_Sdk.Graph.GetVectorIndexStatistics(tenantGuid, graphGuid).Result);
        }

        #endregion

        #region Node

        private static void ShowSampleNode()
        {
            List<string> labels = new List<string>();
            labels.Add("test");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("key", "value");

            NameValueCollection tags = new NameValueCollection();
            tags.Add("key", "value");

            List<VectorMetadata> vectors = new List<VectorMetadata>
            {
                new VectorMetadata
                {
                    TenantGUID = default(Guid),
                    GraphGUID = default(Guid),
                    NodeGUID = default(Guid),
                    Model = "test model",
                    Dimensionality = 3,
                    Content = "test data",
                    Vectors = new List<float> { 0.1f, 0.2f, 0.3f }
                }
            };

            Console.WriteLine("Sample JSON:");

            Console.WriteLine(Serializer.SerializeJson(new Node
            {
                TenantGUID = _Tenant,
                GraphGUID = _Graph,
                Name = "My node",
                Labels = labels,
                Tags = tags,
                Data = data,
                Vectors = vectors
            }, false));
        }

        private static void NodeExists()
        {
            EnumerateResult(
                _Sdk.Node.ExistsByGuid(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:", _Graph),
                    GetGuid("Node GUID:")
                )
                .Result);
        }

        private static void NodeCreate()
        {
            new Node
            {
                Name = "My node 1",

            };
            ShowSampleNode();
            EnumerateResult(
                _Sdk.Node.Create(Serializer.DeserializeJson<Node>(GetJson("Node JSON:")))
                .Result);
        }

        private static void NodeAll()
        {
            EnumerateResult(_Sdk.Node.ReadMany(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("Graph GUID:", _Graph)).Result);
        }

        private static void NodeRead()
        {
            EnumerateResult(
                _Sdk.Node.ReadByGuid(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:", _Graph),
                    GetGuid("Node GUID:")
                )
                .Result);
        }

        private static void NodeEnumerate()
        {
            EnumerateResult(_Sdk.Node.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void NodeUpdate()
        {
            ShowSampleNode();
            EnumerateResult(_Sdk.Node.Update(Serializer.DeserializeJson<Node>(GetJson("Node JSON:"))).Result);
        }

        private static void NodeDelete()
        {
            _Sdk.Node.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("Graph GUID:", _Graph), 
                GetGuid("Node GUID:")
                )
                .Wait();
        }
        
        private static void NodeSearch()
        {
            SearchRequest req = BuildSearchRequest(true);
            if (req == null) return;
            EnumerateResult(_Sdk.Node.Search(req).Result);
        }

        private static void NodeEdges()
        {
            EnumerateResult(
                _Sdk.Edge.ReadNodeEdges(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:"),
                    GetGuid("Node GUID:")
                )
                .Result);
        }

        private static void NodeParents()
        {
            EnumerateResult(
                _Sdk.Node.ReadParents(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:"),
                    GetGuid("Node GUID:")
                )
                .Result);
        }

        private static void NodeChildren()
        {
            EnumerateResult(
                _Sdk.Node.ReadChildren(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:"),
                    GetGuid("Node GUID:")
                )
                .Result);
        }

        #endregion

        #region Edge

        private static void ShowSampleEdge()
        {
            List<string> labels = new List<string>();
            labels.Add("test");

            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("key", "value");

            NameValueCollection tags = new NameValueCollection();
            tags.Add("key", "value");

            List<VectorMetadata> vectors = new List<VectorMetadata>
            {
                new VectorMetadata
                {
                    TenantGUID = default(Guid),
                    GraphGUID = default(Guid),
                    EdgeGUID = default(Guid),
                    Model = "test model",
                    Dimensionality = 3,
                    Content = "test data",
                    Vectors = new List<float> { 0.1f, 0.2f, 0.3f }
                }
            };

            Console.WriteLine("Sample JSON:");

            Console.WriteLine(Serializer.SerializeJson(new Edge
            {
                TenantGUID = _Tenant,
                GUID = _Graph,
                From = Guid.NewGuid(),
                To = Guid.NewGuid(),
                Name = "My edge",
                Labels = labels,
                Tags = tags,
                Data = data,
                Vectors = vectors
            }, false));
        }

        private static void EdgeExists()
        {
            EnumerateResult(
                _Sdk.Edge.ExistsByGuid(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:", _Graph),
                    GetGuid("Edge GUID:")
                )
                .Result);
        }

        private static void EdgeCreate()
        {
            ShowSampleEdge();
            EnumerateResult(_Sdk.Edge.Create(Serializer.DeserializeJson<Edge>(GetJson("Edge JSON:"))).Result);
        }

        private static void EdgeAll()
        {
            EnumerateResult(
                _Sdk.Edge.ReadMany(
                    GetGuid("Tenant GUID:", _Tenant), 
                    GetGuid("Graph GUID:", _Graph)).Result);
        }

        private static void EdgeRead()
        {
            EnumerateResult(
                _Sdk.Edge.ReadByGuid(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:", _Graph),
                    GetGuid("Edge GUID:")
                )
                .Result);
        }

        private static void EdgeEnumerate()
        {
            EnumerateResult(_Sdk.Edge.Enumerate(BuildEnumerationQuery()).Result);
        }

        private static void EdgeUpdate()
        {
            ShowSampleEdge();
            EnumerateResult(_Sdk.Edge.Update(Serializer.DeserializeJson<Edge>(GetJson("Edge JSON:"))).Result);
        }

        private static void EdgeDelete()
        {
            _Sdk.Edge.DeleteByGuid(
                GetGuid("Tenant GUID:", _Tenant),
                GetGuid("Graph GUID:", _Graph),
                GetGuid("Edge GUID:")
                )
                .Wait();
        }

        private static void EdgeSearch()
        {
            SearchRequest req = BuildSearchRequest(true);
            if (req == null) return;
            EnumerateResult(_Sdk.Edge.Search(req).Result);
        }

        private static void EdgesFrom()
        {
            EnumerateResult(
                _Sdk.Edge.ReadEdgesFromNode(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:", _Graph),
                    GetGuid("Node GUID:")
                )
                .Result);
        }

        private static void EdgesTo()
        {
            EnumerateResult(
                _Sdk.Edge.ReadEdgesToNode(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:", _Graph),
                    GetGuid("Edge GUID:")
                )
                .Result);
        }

        private static void EdgesBetween()
        {
            EnumerateResult(
                _Sdk.Edge.ReadEdgesBetweenNodes(
                    GetGuid("Tenant GUID:", _Tenant),
                    GetGuid("Graph GUID:", _Graph),
                    GetGuid("From GUID :"),
                    GetGuid("To GUID   :")
                )
                .Result);
        }

        #endregion

        #region Route

        private static void Route()
        {
            EnumerateResult(
                _Sdk.Node.ReadRoutes(
                    SearchTypeEnum.DepthFirstSearch,
                    GetGuid("Tenant GUID    :", _Tenant),
                    GetGuid("Graph GUID     :", _Graph),
                    GetGuid("From node GUID :"),
                    GetGuid("To node GUID   :")
                )
                .Result);
        }

        #endregion

        #region Vector

        private static void VectorSearch()
        {
            VectorSearchRequest req = BuildVectorSearchRequest();
            EnumerateResult(
                _Sdk.Vector.SearchVectors(
                    req.TenantGUID,
                    req.GraphGUID,
                    req)
                .Result);
        }

        #endregion

#pragma warning restore CS8603 // Possible null reference return.
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
#pragma warning restore IDE0051 // Remove unused private members
#pragma warning restore IDE0044 // Add readonly modifier
    }
}