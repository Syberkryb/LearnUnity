using System;

namespace Lib
{
    [Serializable]
    public struct AuthInfo
    {
        public int Id;
        public string Username;
        public string Password;
    }
}