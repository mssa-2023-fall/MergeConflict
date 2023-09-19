using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace MssaExtensionsNS {
    public static class MssaExtensions {
        public enum StringFormat {
            Base64,
            Hex
        }

        public static string GetSHAString(this FileInfo _file, StringFormat format = StringFormat.Hex) {
            var sha1 = SHA1.Create();

            var fileHash = sha1.ComputeHash(_file.OpenRead());

            return format switch {
                StringFormat.Base64 => Convert.ToBase64String(fileHash),

                StringFormat.Hex => Convert.ToHexString(fileHash),

                _ => Convert.ToHexString(fileHash)
            };

        }

        public static T Median<T>(this IEnumerable<T> _intAry) {
            var sorted = _intAry.OrderBy(x => x).ToList();
            return (sorted.Count % 2 == 1) ? sorted[sorted.Count / 2] : (sorted[sorted.Count / 2 - 1] + sorted[sorted.Count / 2]) / 2.0;
        }
    }
}