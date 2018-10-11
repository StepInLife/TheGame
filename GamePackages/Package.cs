using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePackages
{
    [Serializable]
    public class Package : IPackage
    {
        public PackageType _packageType { get; set; }
        public byte[] _package { get; set; }
    }
}
