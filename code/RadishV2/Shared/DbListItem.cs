namespace RadishV2.Shared
{
    /// <summary>
    /// Db List Item
    /// </summary>
    public class DbListItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbListItem"/> class.
        /// </summary>
        public DbListItem() { }

        /// <summary>
        /// The constructor for the DB list item
        /// </summary>
        /// <param name="dbNumber">The DB number</param>
        public DbListItem(int dbNumber)
        {
            DbNumber = dbNumber;
            DbDisplay = "DB-" + DbNumber;
        }

        /// <summary>
        /// The DB number
        /// </summary>
        /// <value>The DB number</value>
        public int DbNumber { get; set; }

        /// <summary>
        /// The DB Display
        /// </summary>
        /// <value>The DB Display</value>
        public string DbDisplay { get; set; }
    }
}