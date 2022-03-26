using Exiled.API.Interfaces;

namespace CustomPermissions
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool IsDebugged { get; set; } = true;
    }
}