using IdentityServer4.Models;
using System.Collections.Generic;

namespace test_kymdan
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),

        };
        }
        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
        {
            new ApiResource("admin", "My API"),
            new ApiResource("application", "My API")

        };
        }
        public static IEnumerable<Client> GetClients()
        {
            // client credentials client

            return new List<Client>
        {
            new Client
            {
                ClientId = "client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes = { "admin", "application","openid", "profile", "email"}
            },
        };
        }
    }
}
