using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace KlingAI.Authentication
{
    public class JwtTokenGenerator
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly TimeSpan _defaultTokenLifetime = TimeSpan.FromMinutes(30); // Default to 30 minutes like Java example
        
        public JwtTokenGenerator(string accessKey, string secretKey)
        {
            _accessKey = accessKey ?? throw new ArgumentNullException(nameof(accessKey));
            _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
        }
        
        /// <summary>
        /// Generates a JWT token for KlingAI API authentication with default lifetime (30 minutes)
        /// </summary>
        /// <returns>JWT token string</returns>
        public string GenerateToken()
        {
            return GenerateToken(_defaultTokenLifetime);
        }
        
        /// <summary>
        /// Generates a JWT token for KlingAI API authentication with specified lifetime
        /// </summary>
        /// <param name="tokenLifetime">How long the token should be valid for</param>
        /// <returns>JWT token string</returns>
        public string GenerateToken(TimeSpan tokenLifetime)
        {
            // Create the JWT security token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            
            // Convert the secret key to bytes (directly use the string like in Java example)
            byte[] key = CreateSufficientKeyMaterial(_secretKey);
            
            // Define token headers explicitly (matching Java example)
            var headers = new JwtHeader(
                new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256)
            );
            headers["typ"] = "JWT";
            
            // Get current time
            var now = DateTimeOffset.UtcNow;
            
            // Set "not before" time to 5 seconds in the past to allow for clock skew
            var notBefore = now.AddSeconds(-5);
            
            // Set expiration based on tokenLifetime parameter
            var expiredAt = now.Add(tokenLifetime);
            
            // Create payload with claims (following Java example structure)
            var payload = new JwtPayload();
            payload.Add("iss", _accessKey);
            payload.Add("exp", expiredAt.ToUnixTimeSeconds());
            payload.Add("nbf", notBefore.ToUnixTimeSeconds());
            
            // Create JWT with explicit headers and payload
            var securityToken = new JwtSecurityToken(headers, payload);
            
            // Convert token to string
            return tokenHandler.WriteToken(securityToken);
        }
        
        /// <summary>
        /// Creates a key of sufficient size for the HS256 algorithm
        /// </summary>
        /// <param name="secretKey">Secret key string</param>
        /// <returns>A byte array of sufficient length (32 bytes minimum)</returns>
        private byte[] CreateSufficientKeyMaterial(string secretKey)
        {
            // Convert string to bytes using UTF8 encoding (not hex conversion)
            byte[] originalKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            
            // If key is already 32 bytes (256 bits) or more, use it as is
            if (originalKeyBytes.Length >= 32)
            {
                return originalKeyBytes;
            }
            
            // Otherwise, create a SHA256 hash of the original key to get a 32-byte key
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(originalKeyBytes);
            }
        }
    }
} 