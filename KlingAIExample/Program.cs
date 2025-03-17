using System;
using System.IO;
using System.Threading.Tasks;
using KlingAI;
using KlingAI.Models;

namespace KlingAIExample
{
    class Program
    {
        // Read credentials from environment variables
        private static readonly string AccessKey = Environment.GetEnvironmentVariable("KLING_ACCESS_KEY");
        private static readonly string SecretKey = Environment.GetEnvironmentVariable("KLING_SECRET_KEY");
        
        static async Task Main(string[] args)
        {
            Console.WriteLine("KlingAI Video Generation Example");
            Console.WriteLine("--------------------------------");
            
            try
            {
                // Verify that credentials are available
                if (string.IsNullOrEmpty(AccessKey) || string.IsNullOrEmpty(SecretKey))
                {
                    Console.WriteLine("Error: KlingAI credentials not found in environment variables.");
                    Console.WriteLine("Please set the following environment variables:");
                    Console.WriteLine("  KLING_ACCESS_KEY - Your KlingAI access key");
                    Console.WriteLine("  KLING_SECRET_KEY - Your KlingAI secret key");
                    
                    // Provide instructions for setting environment variables
                    Console.WriteLine("\nTo set environment variables:");
                    Console.WriteLine("Windows command prompt: SET KLING_ACCESS_KEY=your_access_key");
                    Console.WriteLine("PowerShell: $env:KLING_ACCESS_KEY=\"your_access_key\"");
                    Console.WriteLine("Linux/macOS: export KLING_ACCESS_KEY=your_access_key");
                    
                    return; // Exit the program
                }
                
                // Initialize the client with JWT authentication and custom token lifetime
                Console.WriteLine("Initializing KlingAI client with JWT authentication...");
                Console.WriteLine("Select token lifetime:");
                Console.WriteLine("1. Default (1 hour)");
                Console.WriteLine("2. Short-lived (5 minutes)");
                Console.WriteLine("3. Long-lived (24 hours)");
                
                var choice = Console.ReadLine();
                KlingAIClient client;
                
                switch (choice)
                {
                    case "2":
                        Console.WriteLine("Using 5-minute token lifetime");
                        client = new KlingAIClient(AccessKey, SecretKey, TimeSpan.FromMinutes(5));
                        break;
                    case "3":
                        Console.WriteLine("Using 24-hour token lifetime");
                        client = new KlingAIClient(AccessKey, SecretKey, TimeSpan.FromHours(24));
                        break;
                    default:
                        Console.WriteLine("Using default token lifetime (1 hour)");
                        client = new KlingAIClient(AccessKey, SecretKey);
                        break;
                }
                
                // Generate a video and retrieve the result
                await GenerateVideo(client);
            }
            catch (KlingAIException ex)
            {
                Console.WriteLine($"KlingAI API Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        static async Task GenerateVideo(KlingAIClient client)
        {
            Console.WriteLine("\nGenerating a video...");
            
            // Create the video generation request
            var request = new TextToVideoRequest
            {
                Prompt = "A person walking through a forest, cinematic lighting",
                NegativePrompt = "blurry, low quality, distorted",
                AspectRatio = "16:9",
                Duration = "5",
                Mode = "std"
            };
            
            // Submit the request and get the task ID
            var response = await client.Videos.CreateTextToVideoTaskAsync(request);
            Console.WriteLine($"Video generation task created with ID: {response.Data.TaskId}");
            
            // Poll the status until complete
            Console.WriteLine("Checking status (this may take several minutes)...");
            
            string taskId = response.Data.TaskId;
            VideoTaskDetailResponse taskDetail;
            bool completed = false;
            
            do
            {
                // Wait 15 seconds between status checks (video generation takes longer)
                await Task.Delay(15000);
                
                // Check the current status
                taskDetail = await client.Videos.GetTextToVideoTaskAsync(taskId);
                Console.WriteLine($"Current status: {taskDetail.Data.TaskStatus}");
                
                completed = taskDetail.Data.TaskStatus == "succeed" || taskDetail.Data.TaskStatus == "failed";
            } while (!completed);
            
            // Display the results
            if (taskDetail.Data.TaskStatus == "succeed" && taskDetail.Data.TaskResult?.Videos?.Count > 0)
            {
                Console.WriteLine("Video generated successfully!");
                foreach (var video in taskDetail.Data.TaskResult.Videos)
                {
                    Console.WriteLine($"Video ID: {video.Id}");
                    Console.WriteLine($"URL: {video.Url}");
                    Console.WriteLine($"Duration: {video.Duration} seconds");
                    
                    // Optional: Download the video
                    Console.WriteLine("Would you like to download this video? (y/n)");
                    if (Console.ReadLine()?.ToLower() == "y")
                    {
                        await DownloadVideo(video.Url, $"video_{video.Id}.mp4");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Video generation failed: {taskDetail.Data.TaskStatusMsg}");
            }
        }
        
        // Helper method to download a video file
        static async Task DownloadVideo(string url, string fileName)
        {
            Console.WriteLine($"Downloading video to {fileName}...");
            
            try
            {
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    
                    using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }
                }
                
                Console.WriteLine("Download complete!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error downloading video: {ex.Message}");
            }
        }
        
        // Helper method to convert a local image to a base64 string for API uploads
        static string ImageToBase64(string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            return Convert.ToBase64String(imageBytes);
        }
    }
}