using System;

namespace Photon
{
    public static class Constants
    {
        public static string BuildName { get; } = (Environment.GetEnvironmentVariable("CONTAINER") == "true") ? "CSharp Orchestration" : "CSharp Local";
        public static string BuildNumber { get; } = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
        public static string BuildId { get; } = BuildName + ": " + BuildNumber;
    }
}