using System;


namespace R5T.Pictia
{
    /// <summary>
    /// Provides an <see cref="SftpClientWrapper"/>, internally performing all necessary work using all necessary dependencies.
    /// </summary>
    public interface ISftpClientWrapperProvider
    {
        SftpClientWrapper Provide();
    }
}
