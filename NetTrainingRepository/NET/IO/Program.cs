using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    class Program
    {
        static  void Main(string[] args)
        {
            using (var ms = new MemoryStream())
            {
                ms.Write(new byte[] {}, 0, 1024);
            }
            
            GZipStream gZipStream = new GZipStream(Stream.Null, CompressionLevel.Fastest);
        }
    }
}
