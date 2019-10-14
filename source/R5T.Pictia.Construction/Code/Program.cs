using System;

using Microsoft.Extensions.Configuration;

using R5T.AWS.EC2;
using R5T.AWS.EC2.Configuration;

using NetStandardSftpClientWrapper = R5T.NetStandard.SSH.SftpClientWrapper;


namespace R5T.Pictia.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            Construction.SubMain();

            //Program.SubMain();
        }

        private static void SubMain()
        {
            Console.WriteLine("Hello World!");
        }

        public static NetStandardSftpClientWrapper GetSftpClientWrapper()
        {
            var serverSecrets = Program.GetAwsEc2ServerSecrets();

            var clientWrapper = serverSecrets.GetSftpClientWrapper();
            return clientWrapper;
        }

        public static AwsEc2ServerSecrets GetAwsEc2ServerSecrets()
        {
            var configuration = Program.GetConfiguration();

            var awsEc2ServerSecrets = configuration.GetSection(nameof(AwsEc2ServerSecrets)).Get<AwsEc2ServerSecrets>();
            return awsEc2ServerSecrets;
        }

        public static IConfiguration GetConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .AddAwsEc2ServerSecretsJsonFile()
                .Build();

            return configuration;
        }
    }
}
