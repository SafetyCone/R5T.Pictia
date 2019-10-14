using System;

using R5T.Pictia;


namespace R5T.Pictia.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            Construction.CreateDirectory();
            //Construction.GetConnectedSftpClient();
        }

        private static void CreateDirectory()
        {
            using (var clientWrapper = Program.GetSftpClientWrapper())
            {
                var directoryPath = clientWrapper.SftpClient.WorkingDirectory + "/" + "TestDir";

                clientWrapper.SftpClient.CreateDirectory(directoryPath);
            }
        }

        private static void GetConnectedSftpClient()
        {
            var client = Program.GetSftpClientWrapper();

            Console.WriteLine($"Is connected: {client.SftpClient.IsConnected}");
        }
    }
}
