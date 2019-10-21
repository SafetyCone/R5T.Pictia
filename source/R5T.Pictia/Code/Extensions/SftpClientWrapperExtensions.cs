using System;


namespace R5T.Pictia.Extensions
{
    public static class SftpClientWrapperExtensions
    {
        public static SshClientWrapper GetSshClientWrapperUnconnected(this SftpClientWrapper sftpClientWrapper)
        {
            var sshClientWrapper = new SshClientWrapper(sftpClientWrapper.SftpClient.ConnectionInfo);
            return sshClientWrapper;
        }

        public static SshClientWrapper GetSshClientWrapperConnected(this SftpClientWrapper sftpClientWrapper)
        {
            var sshClientWrapper = sftpClientWrapper.GetSshClientWrapperUnconnected();

            sshClientWrapper.SshClient.Connect();

            return sshClientWrapper;
        }

        /// <summary>
        /// Returns a connected SSH client.
        /// Uses <see cref="SftpClientWrapperExtensions.GetSshClientWrapperConnected(SftpClientWrapper)"/>.
        /// </summary>
        public static SshClientWrapper GetSshClientWrapper(this SftpClientWrapper sftpClientWrapper)
        {
            var sshClientWrapper = sftpClientWrapper.GetSshClientWrapperConnected();
            return sshClientWrapper;
        }
    }
}
