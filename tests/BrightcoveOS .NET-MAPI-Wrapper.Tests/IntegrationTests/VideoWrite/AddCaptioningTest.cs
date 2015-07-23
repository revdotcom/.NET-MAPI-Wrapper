using System.IO;
using BrightcoveMapiWrapper.Api.Connectors;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
    [TestFixture]
    public class AddCaptioningTest : VideoWriteTestBase
    {
        /// <summary>
        /// Sample DFXP found here:
        /// https://s3-us-west-2.amazonaws.com/public-rev/captions/Example.dfxp
        /// </summary>
        private readonly string FileToUpload = @"C:\Temp\Example.dfxp";

        [Test]
        public void AddCaptioning_ExternalUrl_VideoId()
        {
            _api.AddCaptioning(
                "https://s3-us-west-2.amazonaws.com/public-rev/captions/Example.dfxp", 4348957026001,
                "TestFileName.dfxp");
        }

        [Test]
        public void AddCaptioning_FileUploadInfo_VideoId()
        {
            using (FileStream fs = File.OpenRead(FileToUpload))
            {
                var captionFileUplaodInfo = new FileUploadInfo(fs, "TestFileName.dfxp");
                _api.AddCaptioning(captionFileUplaodInfo, 4348957026001, "TestFileName.dfxp");
            }
        }

        //TODO: AddCaptioning_ExternalUrl_VideoRefId
        //TODO: AddCaptioning_FileUploadInfo_VideoRefId
    }
}