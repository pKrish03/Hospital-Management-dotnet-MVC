using System.Text;
using System.Text.Json;

namespace HospitalManagement.Models
{
    public class FirebaseService
    {
        private readonly string _databaseUrl;
        private readonly HttpClient _httpClient;

        public FirebaseService(IConfiguration configuration)
        {
            _databaseUrl = configuration["Firebase:DatabaseUrl"] ?? "";
            _httpClient = new HttpClient();
            
            // Debug output
            Console.WriteLine("\n========================================");
            Console.WriteLine("FIREBASE SERVICE INITIALIZED");
            Console.WriteLine($"Database URL: {_databaseUrl}");
            Console.WriteLine("========================================\n");
        }

        // Save data to Firebase
        public async Task<bool> SaveAsync<T>(string node, string key, T data)
        {
            try
            {
                var url = $"{_databaseUrl}{node}/{key}.json";
                
                Console.WriteLine("\n========== SAVING DATA ==========");
                Console.WriteLine($"Node: {node}");
                Console.WriteLine($"Key: {key}");
                Console.WriteLine($"Full URL: {url}");
                
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions 
                { 
                    WriteIndented = true 
                });
                Console.WriteLine($"Data to save:\n{json}");
                
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                Console.WriteLine("Sending PUT request to Firebase...");
                var response = await _httpClient.PutAsync(url, content);
                
                var responseBody = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"Response Status Code: {(int)response.StatusCode} {response.StatusCode}");
                Console.WriteLine($"Response Body: {responseBody}");
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("✅ SUCCESS: Data saved successfully!");
                    Console.WriteLine("=================================\n");
                    return true;
                }
                else
                {
                    Console.WriteLine($"❌ FAILED: HTTP {response.StatusCode}");
                    Console.WriteLine($"Response: {responseBody}");
                    Console.WriteLine("=================================\n");
                    return false;
                }
            }
            catch (HttpRequestException httpEx)
            {
                Console.WriteLine("\n❌ HTTP REQUEST EXCEPTION:");
                Console.WriteLine($"Message: {httpEx.Message}");
                Console.WriteLine($"Status Code: {httpEx.StatusCode}");
                Console.WriteLine($"Stack Trace: {httpEx.StackTrace}");
                Console.WriteLine("=================================\n");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n❌ GENERAL EXCEPTION:");
                Console.WriteLine($"Type: {ex.GetType().Name}");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                }
                Console.WriteLine("=================================\n");
                return false;
            }
        }

        // Get all data from Firebase
        public async Task<List<T>> GetAllAsync<T>(string node)
        {
            try
            {
                var url = $"{_databaseUrl}{node}.json";
                
                Console.WriteLine("\n========== GETTING ALL DATA ==========");
                Console.WriteLine($"Node: {node}");
                Console.WriteLine($"Full URL: {url}");
                
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"Response Status: {response.StatusCode}");
                Console.WriteLine($"Response Body Length: {responseBody.Length} characters");
                
                if (response.IsSuccessStatusCode)
                {
                    if (string.IsNullOrEmpty(responseBody) || responseBody == "null")
                    {
                        Console.WriteLine("No data found - returning empty list");
                        Console.WriteLine("======================================\n");
                        return new List<T>();
                    }

                    var dictionary = JsonSerializer.Deserialize<Dictionary<string, T>>(responseBody);
                    var count = dictionary?.Count ?? 0;
                    Console.WriteLine($"✅ SUCCESS: Found {count} records");
                    Console.WriteLine("======================================\n");
                    return dictionary?.Values.ToList() ?? new List<T>();
                }
                
                Console.WriteLine($"❌ FAILED: HTTP {response.StatusCode}");
                Console.WriteLine($"Response: {responseBody}");
                Console.WriteLine("======================================\n");
                return new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ EXCEPTION in GetAllAsync:");
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                Console.WriteLine("======================================\n");
                return new List<T>();
            }
        }

        // Get data by ID from Firebase
        public async Task<T?> GetByIdAsync<T>(string node, string key)
        {
            try
            {
                var url = $"{_databaseUrl}{node}/{key}.json";
                
                Console.WriteLine($"\n========== GETTING DATA BY ID ==========");
                Console.WriteLine($"URL: {url}");
                
                var response = await _httpClient.GetAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"Status: {response.StatusCode}");
                
                if (response.IsSuccessStatusCode)
                {
                    if (string.IsNullOrEmpty(responseBody) || responseBody == "null")
                    {
                        Console.WriteLine("Data not found");
                        Console.WriteLine("========================================\n");
                        return default;
                    }

                    var result = JsonSerializer.Deserialize<T>(responseBody);
                    Console.WriteLine("✅ Data retrieved successfully");
                    Console.WriteLine("========================================\n");
                    return result;
                }
                
                Console.WriteLine($"❌ Failed: {responseBody}");
                Console.WriteLine("========================================\n");
                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception: {ex.Message}");
                Console.WriteLine("========================================\n");
                return default;
            }
        }

        // Update data in Firebase
        public async Task<bool> UpdateAsync<T>(string node, string key, T data)
        {
            try
            {
                var url = $"{_databaseUrl}{node}/{key}.json";
                
                Console.WriteLine($"\n========== UPDATING DATA ==========");
                Console.WriteLine($"URL: {url}");
                
                var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _httpClient.PatchAsync(url, content);
                var responseBody = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"Status: {response.StatusCode}");
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("✅ Updated successfully");
                    Console.WriteLine("===================================\n");
                    return true;
                }
                
                Console.WriteLine($"❌ Failed: {responseBody}");
                Console.WriteLine("===================================\n");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception: {ex.Message}");
                Console.WriteLine("===================================\n");
                return false;
            }
        }

        // Delete data from Firebase
        public async Task<bool> DeleteAsync(string node, string key)
        {
            try
            {
                var url = $"{_databaseUrl}{node}/{key}.json";
                
                Console.WriteLine($"\n========== DELETING DATA ==========");
                Console.WriteLine($"URL: {url}");
                
                var response = await _httpClient.DeleteAsync(url);
                var responseBody = await response.Content.ReadAsStringAsync();
                
                Console.WriteLine($"Status: {response.StatusCode}");
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("✅ Deleted successfully");
                    Console.WriteLine("===================================\n");
                    return true;
                }
                
                Console.WriteLine($"❌ Failed: {responseBody}");
                Console.WriteLine("===================================\n");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Exception: {ex.Message}");
                Console.WriteLine("===================================\n");
                return false;
            }
        }
    }
}