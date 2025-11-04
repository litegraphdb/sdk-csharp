namespace LiteGraph.Sdk
{
    /// <summary>
    /// Configuration for vector indexing.
    /// </summary>
    public class VectorIndexConfiguration
    {
        #region Public-Members

        /// <summary>
        /// Type of vector indexing to use.
        /// </summary>
        public VectorIndexTypeEnum VectorIndexType { get; set; } = VectorIndexTypeEnum.HnswRam;

        /// <summary>
        /// When vector indexing is enabled, the name of the file used to hold the index.
        /// Required for SQLite-based indices.
        /// </summary>
        public string VectorIndexFile { get; set; } = null;

        /// <summary>
        /// When vector indexing is enabled, the number of vectors required to use the index.
        /// Brute force computation is often faster than use of an index for smaller batches of vectors.
        /// Default is null. When set, the minimum value is 1.
        /// </summary>
        public int? VectorIndexThreshold { get; set; } = null;

        /// <summary>
        /// When vector indexing is enabled, the dimensionality of vectors that will be stored in this graph.
        /// Required for vector indexing. When set, the minimum value is 1.
        /// </summary>
        public int? VectorDimensionality { get; set; } = null;

        /// <summary>
        /// HNSW M parameter - number of bi-directional links created for each new element during construction.
        /// Higher values lead to better recall but higher memory consumption and slower insertion.
        /// Default is 16. Valid range is 2-100.
        /// </summary>
        public int? VectorIndexM { get; set; } = 16;

        /// <summary>
        /// HNSW Ef parameter - size of the dynamic list used during k-NN search.
        /// Higher values lead to better recall but slower search.
        /// Default is 50. Valid range is 1 to 10000.
        /// </summary>
        public int? VectorIndexEf { get; set; } = 50;

        /// <summary>
        /// HNSW EfConstruction parameter - size of the dynamic list used during index construction.
        /// Higher values lead to better index quality but slower construction.
        /// Default is 200. Valid range is 1 to 10000.
        /// </summary>
        public int? VectorIndexEfConstruction { get; set; } = 200;

        #endregion

        #region Private-Members

        #endregion

        #region Constructors-and-Factories

        /// <summary>
        /// Instantiate the object.
        /// </summary>
        public VectorIndexConfiguration()
        {
        }

        #endregion

        #region Public-Methods

        #endregion

        #region Private-Methods

        #endregion
    }
}