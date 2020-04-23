using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestGzipMultipartForm
{
    public class GzipMultipartContent : MultipartFormDataContent
    {
        public GzipMultipartContent()
        {
           Headers.ContentEncoding.Add("gzip");
        }

        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                using (var gzip = new GZipStream(stream, CompressionMode.Compress, true))
                    base.SerializeToStreamAsync(gzip, context);
            });
        }
    }
}
