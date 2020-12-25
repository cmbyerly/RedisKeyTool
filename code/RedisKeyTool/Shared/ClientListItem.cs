namespace RedisKeyTool.Shared
{
    /// <summary>
    /// This is out client list item.
    /// </summary>
    public class ClientListItem
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the idle seconds.
        /// </summary>
        /// <value>
        /// The idle seconds.
        /// </value>
        public string IdleSeconds { get; set; }

        /// <summary>
        /// Gets or sets the length of the transaction command.
        /// </summary>
        /// <value>
        /// The length of the transaction command.
        /// </value>
        public string TransactionCommandLength { get; set; }

        /// <summary>
        /// Gets or sets the subscription count.
        /// </summary>
        /// <value>
        /// The subscription count.
        /// </value>
        public string SubscriptionCount { get; set; }

        /// <summary>
        /// Gets or sets the raw.
        /// </summary>
        /// <value>
        /// The raw.
        /// </value>
        public string Raw { get; set; }

        /// <summary>
        /// Gets or sets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public string Port { get; set; }

        /// <summary>
        /// Gets or sets the pattern subscription count.
        /// </summary>
        /// <value>
        /// The pattern subscription count.
        /// </value>
        public string PatternSubscriptionCount { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last command.
        /// </summary>
        /// <value>
        /// The last command.
        /// </value>
        public string LastCommand { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the flags raw.
        /// </summary>
        /// <value>
        /// The flags raw.
        /// </value>
        public string FlagsRaw { get; set; }

        /// <summary>
        /// Gets or sets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public string Database { get; set; }

        /// <summary>
        /// Gets or sets the age seconds.
        /// </summary>
        /// <value>
        /// The age seconds.
        /// </value>
        public string AgeSeconds { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }
    }
}