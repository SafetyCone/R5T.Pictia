using System;
using System.Collections.Generic;

using Renci.SshNet;
using Renci.SshNet.Sftp;

using R5T.Magyar.IO;


namespace R5T.Pictia.Extensions
{
    public static class SftpClientExtensions
    {
        public static IEnumerable<SftpFile> ListDirectoryEntriesOnly(this SftpClient sftpClient, string directoryPath, bool showHidden = false)
        {
            var allSftpFiles = sftpClient.ListDirectory(directoryPath);
            foreach (var sftpFile in allSftpFiles)
            {
                // If the entry is a directory, and it's one of the relative directory names (i.e. "." or ".."), don't return it.
                if(sftpFile.IsDirectory)
                {
                    var isRelativeDirectoryName = DirectoryNameHelper.IsRelativeDirectoryName(sftpFile.Name);
                    if(isRelativeDirectoryName)
                    {
                        continue;
                    }
                }

                // If the entry is hidden-indicated, and we are not showing hidden entries, don't return it.
                if(PathPartNameHelper.IsHiddenIndicated(sftpFile.Name) && !showHidden)
                {
                    continue;
                }

                // After all exceptions, return the entry.
                yield return sftpFile; // OK, just return!
            }
        }
    }
}
