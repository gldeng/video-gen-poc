using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using MiniMax.Client;
using MiniMax.Client.Models;

class Program
{
    // Your MiniMax API credentials from environment variables
    private static string ApiKey => Environment.GetEnvironmentVariable("MINIMAX_API_KEY") ?? 
        throw new InvalidOperationException("MINIMAX_API_KEY environment variable is not set");
    private static string GroupId => Environment.GetEnvironmentVariable("MINIMAX_GROUP_ID") ?? 
        throw new InvalidOperationException("MINIMAX_GROUP_ID environment variable is not set");

    static async Task Main(string[] args)
    {
        try
        {
            // Initialize the MiniMax client
            var client = new MiniMaxClient(ApiKey, GroupId);
            
            Console.WriteLine("Creating video generation task...");
            
            // Create a video generation request
            var videoRequest = new VideoGenerationRequest
            {
                Model = "T2V-01", // Text to Video model
                Prompt = "A beautiful mountain landscape with a flowing river, sunlight filtering through trees, cinematic lighting, high detail",
                // Optional parameters
                Duration = 5, // Duration in seconds
                Quality = "high" // Quality setting
            };
            
            // Submit the video generation task
            var taskResponse = await client.CreateVideoGenerationTaskAsync(videoRequest);
            Console.WriteLine($"Task created successfully. Task ID: {taskResponse.TaskId}");
            
            // Poll for task completion
            string fileId = null;
            while (true)
            {
                Console.WriteLine("Checking video generation status...");
                var statusResponse = await client.GetVideoGenerationStatusAsync(taskResponse.TaskId);

                switch (statusResponse.Status)
                {
                    case "Preparing":
                        Console.WriteLine("Video generation is preparing...");
                        break;
                    case "Queueing":
                        Console.WriteLine("Video generation is in queue...");
                        break;
                    case "Processing":
                        Console.WriteLine("Video is being generated...");
                        break;
                    case "Success":
                        Console.WriteLine("Video generation completed successfully!");
                        fileId = statusResponse.FileId;
                        break;
                    case "Fail":
                        throw new Exception("Video generation failed!");
                    default:
                        Console.WriteLine($"Unknown status: {statusResponse.Status}");
                        break;
                }
                
                if (fileId != null)
                    break;
                
                // Wait before polling again
                Console.WriteLine("Waiting 10 seconds before checking again...");
                await Task.Delay(10000);
            }
            
            // Retrieve the video file
            Console.WriteLine($"Retrieving video file with ID: {fileId}");
            var fileResponse = await client.RetrieveFileAsync(fileId);
            
            // Download the video file
            string outputPath = Path.Combine(Environment.CurrentDirectory, $"minimax_video_{DateTime.Now:yyyyMMdd_HHmmss}.mp4");
            Console.WriteLine($"Downloading video to: {outputPath}");
            
            using (var httpClient = new HttpClient())
            {
                var videoBytes = await httpClient.GetByteArrayAsync(fileResponse.File.DownloadUrl);
                await File.WriteAllBytesAsync(outputPath, videoBytes);
            }
            
            Console.WriteLine("Video downloaded successfully!");
            Console.WriteLine($"Video file size: {fileResponse.File.Bytes} bytes");
            Console.WriteLine($"Video file path: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine(ex.StackTrace);
        }
    }
}