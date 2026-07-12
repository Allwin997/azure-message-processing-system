using Azure.Storage.Blobs;
using AzureMessageProcessing.Shared.Interfaces;
using AzureMessageProcessing.Shared.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AzureMessageProcessing.Function.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobStorageService(IConfiguration configuration)
        {
            var connectionString = configuration["BlobStorageConnection"];
            var containerName = configuration["BlobContainerName"];

            var blobServiceClient = new BlobServiceClient(connectionString);

            _containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        }

        public async Task UploadAsync(OrderMessage message)
        {
            var fileName =
                $"orders/{DateTime.UtcNow:yyyy/MM/dd}/{message.OrderId}.json";

            var blobClient = _containerClient.GetBlobClient(fileName);

            var json = JsonSerializer.Serialize(message, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(json));

            await blobClient.UploadAsync(stream, overwrite: true);
        }
    }
}
