// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        // Api Resources

        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
           new ApiResource("ResourceCatolog")
           {
               Scopes = {"CatologFullPermission","CatologReadPermission"}
           },
           new ApiResource("ResourceDiscount")
           {
               Scopes = { "DiscoundFullPermission" }
           },
           new ApiResource("ResourceOrder")
           {
               Scopes = { "OrderFullPermission" }
           },
           new ApiResource("ResourceCargo")
           {
               Scopes = {"CargoFullPermission"}
           },
           new ApiResource("ResourceBasket")
           {
               Scopes = {"BasketFullPermission"}
           },
           new ApiResource(IdentityServerConstants.LocalApi.ScopeName) 
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatologFullPermission","Full Authority for Catolog Operations"),
            new ApiScope("CatologReadPermission","Reading Authority for Catolog Operations"),
            new ApiScope("DiscoundFullPermission","Full Authority for Discount Operations"),
            new ApiScope("OrderFullPermission","Full Authority for Discount Operations"),
            new ApiScope("CargoFullPermission","Full Authority for Cargo Operations"),
            new ApiScope("BasketFullPermission","Full Authority for Basket Operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
        };

        // Clients 

        public static IEnumerable<Client> Clients => new Client[]
        {
            //Visitor Role
            new Client
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "MultiShop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatologReadPermission" }
            },
            // Manager Role
            new Client
            {
                ClientId = "MultiShopManagerId",
                ClientName = "MultiShop Manager User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { "CatologFullPermission" }
            },
             // Admin Role
            new Client
            {
                ClientId = "MultiShopAdminId",
                ClientName = "MultiShop Admin User",
                AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("multishopsecret".Sha256())},
                AllowedScopes = { 
                    "CatologFullPermission", 
                    "CatologReadPermission",
                    "DiscoundFullPermission",
                    "OrderFullPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime=600
            },
        };
    }
}