using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

using System.Data.Common;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Text;

namespace Company.Function
{
    //Entry Point
    public static class GetResumeCounter
    {
        [FunctionName("GetResumeCounter")]
        public static HttpResponseMessage Run(
    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
    [CosmosDB(
        databaseName: "AzureResume",
        containerName: "Counter",
        Connection = "AzureResumeConnectionString",
        Id = "1",
        PartitionKey = "1")] Counter counter, // Ensure the correct partition key if used
         [CosmosDB(
        databaseName: "AzureResume",
        containerName: "Counter",
        Connection = "AzureResumeConnectionString",
        Id = "1",
        PartitionKey = "1")] out Counter updatedcounter,
    ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

           updatedcounter = counter;
           updatedcounter.Count +=1;

           var JsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent(JsonToReturn, Encoding.UTF8, "application/json")
            };
        }
    }
}