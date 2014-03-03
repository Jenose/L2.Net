﻿namespace L2.Net.Network
{
    /// <summary>
    /// Base class for remote service settings.
    /// </summary>
    public class RemoteServiceSettings
    {
        /// <summary>
        /// Remote service unique id.
        /// </summary>
        public byte ServiceUniqueID;

        /// <summary>
        /// Writes service settings to provided <see cref="Packet"/> struct.
        /// </summary>
        /// <param name="p"><see cref="Packet"/> to write settings in.</param>
        public virtual void Write( ref Packet p ) { }

        /// <summary>
        /// Reads remote service settings from provided <see cref="Packet"/> struct.
        /// </summary>
        /// <param name="p"><see cref="Packet"/> to read settings from.</param>
        public virtual void Read( Packet p ) { }
    }

    /// <summary>
    /// Remote login service settings.
    /// </summary>
    public sealed class LoginServiceSettings : RemoteServiceSettings
    {
        /// <summary>
        /// Indicates if cache service can create non-existent user accounts automatically.
        /// </summary>
        public bool AutoCreateUser;

        /// <summary>
        /// Access level, given to newer created users by default.
        /// </summary>
        public byte DefaultAccessLevel;

        /// <summary>
        /// Initializes new instance of <see cref="LoginServiceSettings"/> class.
        /// </summary>
        /// <param name="serviceID">Service unique id.</param>
        /// <param name="autoCreateAccounts">True, if cache server may create users automatically.</param>
        /// <param name="defaultAccessLevel">Default access level for newer created user.</param>
        public LoginServiceSettings( byte serviceID, bool autoCreateAccounts, byte defaultAccessLevel )
        {
            ServiceUniqueID = serviceID;
            AutoCreateUser = autoCreateAccounts;
            DefaultAccessLevel = defaultAccessLevel;
        }

        /// <summary>
        /// Writes login service settings to provided <see cref="Packet"/>.
        /// </summary>
        /// <param name="p"><see cref="Packet"/> to write settings in.</param>
        public override void Write( ref Packet p )
        {
            p.WriteByte(ServiceUniqueID);
            p.InternalWriteBool(AutoCreateUser);
            p.WriteByte(DefaultAccessLevel);
        }

        /// <summary>
        /// Reads login service settings from <see cref="Packet"/>.
        /// </summary>
        /// <param name="p"><see cref="Packet"/> to read settings from.</param>
        public override void Read( Packet p )
        {
            ServiceUniqueID = p.ReadByte();
            AutoCreateUser = p.InternalReadBool();
            DefaultAccessLevel = p.ReadByte();
        }
    }
}