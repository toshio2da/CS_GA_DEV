using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SSCUtility
{
    public static class CriptoUtility
    {
        public static byte[] GetHash(int[] src)
        {
            List<byte> bytes = [];
            src.Select(e => BitConverter.GetBytes(e))
                .ToList()
                .ForEach(e => bytes.AddRange(e));
            return MD5.HashData([.. bytes]);
        }
    }
}
