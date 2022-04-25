using Azure.Storage;
using Azure.Storage.Files.DataLake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadScreenshot
{
    class Program
    {
        static void Main(string[] args)
        {
            string storageAccountName = "devtooltelemetrygen23";
            string storageAccountKey = "F5AdAf/qzhJzMc3A9IFLtvSZR9tmD9VsBJzfcWigyWC64vBagDx8ORPUVLKeqJwxQUd3c0GSoyzkRKUpqwQM5w==";
            StorageSharedKeyCredential sharedKeyCredential = new StorageSharedKeyCredential(storageAccountName, storageAccountKey);
            string Path = SubmitMultipleJobsAuto.Json.Readjson("shotPath", null, "screenshotSetting");
            string UploadPath = SubmitMultipleJobsAuto.Json.Readjson("uploadFolder", null, "screenshotSetting") + "\\" + 
                SubmitMultipleJobsAuto.Json.Readjson("shotName", null, "screenshotSetting");

            Uri serviceUri = new Uri("https://devtooltelemetrygen23.blob.core.windows.net/");
            // Create DataLakeServiceClient using StorageSharedKeyCredentials
            DataLakeServiceClient serviceClient = new DataLakeServiceClient(serviceUri, sharedKeyCredential);

            // Create a DataLake Filesystem
            string filesystemName = "scopeautomation";
            DataLakeFileSystemClient fileSystem = serviceClient.GetFileSystemClient(filesystemName);

            DataLakeFileClient fileClient = fileSystem.GetFileClient(UploadPath);
            DataLakeDirectoryClient directory = fileSystem.GetDirectoryClient(UploadPath);
            fileClient.Upload(Path);
            
        }
    }
}
