using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShotOutServer.ViewModel
{
    interface IPackage
    {
        PackageType _packageType { get; set; }
        byte[] _package { get; set; }
    }
}
