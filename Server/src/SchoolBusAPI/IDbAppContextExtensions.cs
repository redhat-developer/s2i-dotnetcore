using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchoolBusAPI.Models
{
    public static class IDbAppContextExtensions
    {

        /// <summary>
        /// Returns a district for a given Ministry Id
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id">The Ministry Id</param>
        /// <returns>District</returns>
        public static District GetDistrictByMinistryDistrictId(this IDbAppContext context, int id)
        {
            District district = context.Districts.Where(x => x.MinistryDistrictID == id)
                    .Include(x => x.Region)                    
                    .FirstOrDefault();
            return district;
        }

        /// <summary>
        /// Returns a region for a given Ministry Id
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id">The Ministry Id</param>
        /// <returns>Region</returns>
        public static Region GetRegionByMinistryRegionId(this IDbAppContext context, int id)
        {
            Region region = context.Regions.Where(x => x.MinistryRegionID == id)
                    .FirstOrDefault();
            return region;
        }

        /// <summary>
        /// Returns a service area for a given Ministry Id
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id">The Ministry Id</param>
        /// <returns>Region</returns>
        public static ServiceArea GetServiceAreaByMinistryServiceAreaId(this IDbAppContext context, int id)
        {
            ServiceArea serviceArea = context.ServiceAreas.Where(x => x.MinistryServiceAreaID == id)
                    .Include(x => x.District.Region)
                    .FirstOrDefault();
            return serviceArea;
        }

        public static Role GetRole(this IDbAppContext context, string name)
        {
            Role role = context.Roles.Where(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .Include(r => r.RolePermissions).ThenInclude(p => p.Permission)
                    .FirstOrDefault();
            return role;
        }

        public static Group GetGroup(this IDbAppContext context, string name)
        {
            return context.Groups.FirstOrDefault(x => x.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static User GetUserByGuid(this IDbAppContext context, string guid)
        {
            User user = context.Users.Where(x => x.Guid != null && x.Guid.Equals(guid, StringComparison.OrdinalIgnoreCase))
                    .Include(u => u.UserRoles).ThenInclude(r => r.Role).ThenInclude(rp => rp.RolePermissions).ThenInclude(p => p.Permission)
                    .Include(u => u.GroupMemberships).ThenInclude(gm => gm.Group)
                    .FirstOrDefault();
            return user;
        }

        public static User GetUserBySmUserId(this IDbAppContext context, string smUserId)
        {
            User user = context.Users.Where(x => x.SmUserId != null && x.SmUserId.Equals(smUserId, StringComparison.OrdinalIgnoreCase))
                    .Include(u => u.UserRoles).ThenInclude(r => r.Role).ThenInclude(rp => rp.RolePermissions).ThenInclude(p => p.Permission)
                    .Include(u => u.GroupMemberships).ThenInclude(gm => gm.Group)
                    .FirstOrDefault();
            return user;
        }


        public static CCWJurisdiction GetCCWJurisdictionByCode(this IDbAppContext context, string code)
        {
            CCWJurisdiction item = context.CCWJurisdictions.Where(x => x.Code != null && x.Code.Equals(code, StringComparison.OrdinalIgnoreCase))                    
                    .FirstOrDefault();
            return item;
        }

        

        /// <summary>
        /// Adds initial CCWJurisdictions from a file
        /// </summary>
        /// <param name="context"></param>
        /// <param name="CCWJurisdictionJsonPath"></param>
        public static void AddInitialCCWJurisdictionsFromFile(this IDbAppContext context, string CCWJurisdictionJsonPath)
        {
            if (!string.IsNullOrEmpty(CCWJurisdictionJsonPath) && File.Exists(CCWJurisdictionJsonPath))
            {
                string CCWJurisdictionJson = File.ReadAllText(CCWJurisdictionJsonPath);
                context.AddInitialCCWJurisdictions(CCWJurisdictionJson);
            }
        }

        private static void AddInitialCCWJurisdictions(this IDbAppContext context, string CCWJurisdictionJson)
        {
            List<CCWJurisdiction> CCWJurisdictions = JsonConvert.DeserializeObject<List<CCWJurisdiction>>(CCWJurisdictionJson);
            if (CCWJurisdictions != null)
            {
                context.AddInitialCCWJurisdictions(CCWJurisdictions);
            }
        }

        private static void AddInitialCCWJurisdictions(this IDbAppContext context, List<CCWJurisdiction> CCWJurisdictions)
        {
            CCWJurisdictions.ForEach(u => context.AddInitialCCWJurisdiction(u));
        }

        /// <summary>
        /// Adds a CCWJurisdiction to the system, only if it does not exist.
        /// </summary>
        private static void AddInitialCCWJurisdiction(this IDbAppContext context, CCWJurisdiction initialCCWJurisdiction)
        {
            CCWJurisdiction CCWJurisdiction = context.GetCCWJurisdictionByCode(initialCCWJurisdiction.Code);
            if (CCWJurisdiction != null)
            {
                return;
            }

            CCWJurisdiction = new CCWJurisdiction();
            CCWJurisdiction.ActiveFlag = initialCCWJurisdiction.ActiveFlag;
            CCWJurisdiction.Code = initialCCWJurisdiction.Code;
            CCWJurisdiction.Description = initialCCWJurisdiction.Description;
            CCWJurisdiction.EffectiveDate = initialCCWJurisdiction.EffectiveDate;
            CCWJurisdiction.ExpiryDate = initialCCWJurisdiction.ExpiryDate;

            context.CCWJurisdictions.Add(CCWJurisdiction);
            context.SaveChanges();
        }

        /// <summary>
        /// Adds initial users from a specified file
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userJsonPath"></param>
        public static void AddInitialUsersFromFile(this IDbAppContext context, string userJsonPath)
        {
            if (!string.IsNullOrEmpty(userJsonPath) && File.Exists(userJsonPath))
            {
                string userJson = File.ReadAllText(userJsonPath);
                context.AddInitialUsers(userJson);
            }
        }

        /// <summary>
        /// Adds initial users from a specified json string
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userJson"></param>
        private static void AddInitialUsers(this IDbAppContext context, string userJson)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(userJson);
            if(users != null)
            {
                context.AddInitialUsers(users);
            }
        }

        /// <summary>
        /// Adds initial users from a list of users
        /// </summary>
        /// <param name="context"></param>
        /// <param name="users"></param>
        private static void AddInitialUsers(this IDbAppContext context, List<User> users)
        {
            users.ForEach(u => context.AddInitialUser(u));
        }

        /// <summary>
        /// Adds a user to the system, only if they do not exist.
        /// </summary>
        private static void AddInitialUser(this IDbAppContext context, User initialUser)
        {
            User user = context.GetUserBySmUserId(initialUser.SmUserId);
            if (user != null)
            {
                return;
            }

            user = new User();
            user.Active = true;
            user.Email = initialUser.Email;
            user.GivenName = initialUser.GivenName;
            user.Initials = initialUser.Initials;
            user.SmAuthorizationDirectory = initialUser.SmAuthorizationDirectory;
            user.SmUserId = initialUser.SmUserId;
            user.Surname = initialUser.Surname;

            District district = null;

            if (initialUser.District != null)
            {
                district = context.GetDistrictByMinistryDistrictId(initialUser.District.MinistryDistrictID);
            }

            user.District = district;

            context.Users.Add(user);
            context.SaveChanges();

            string[] userRoles = initialUser.UserRoles.Select(x => x.Role.Name).ToArray();
            if (user.UserRoles == null)
                user.UserRoles = new List<UserRole>();

            foreach (string userRole in userRoles)
            {
                Role role = context.GetRole(userRole);
                if (role != null)
                { 
                    user.UserRoles.Add(
                        new UserRole
                        {
                            EffectiveDate = DateTime.UtcNow,
                            Role = role
                        });
                }
            }

            string[] userGroups = initialUser.GroupMemberships.Select(x => x.Group.Name).ToArray();
            if (user.GroupMemberships == null)
                user.GroupMemberships = new List<GroupMembership>();

            foreach (string userGroup in userGroups)
            {
                Group group = context.GetGroup(userGroup);
                if (group != null)
                {
                    user.GroupMemberships.Add(
                        new GroupMembership
                        {
                            Active = true,
                            Group = group
                        });
                }
            }

            context.Users.Update(user);
            context.SaveChanges();
        }


        public static void AddInitialRegionsFromFile(this IDbAppContext context, string regionJsonPath)
        {
            if (!string.IsNullOrEmpty(regionJsonPath) && File.Exists(regionJsonPath))
            {
                string regionJson = File.ReadAllText(regionJsonPath);
                context.AddInitialRegions(regionJson);
            }
        }

        private static void AddInitialRegions(this IDbAppContext context, string regionJson)
        {
            List<Region> regions = JsonConvert.DeserializeObject<List<Region>>(regionJson);
            if (regions != null)
            {
                context.AddInitialRegions(regions);
            }
        }

        private static void AddInitialRegions(this IDbAppContext context, List<Region> regions)
        {
            regions.ForEach(u => context.AddInitialRegion(u));
        }

        /// <summary>
        /// Adds a region to the system, only if it does not exist.
        /// </summary>
        private static void AddInitialRegion(this IDbAppContext context, Region initialRegion)
        {
            Region region = context.GetRegionByMinistryRegionId(initialRegion.MinistryRegionID);
            if (region != null)
            {
                return;
            }

            region = new Region();
            region.MinistryRegionID = initialRegion.MinistryRegionID;
            region.Name = initialRegion.Name;
            region.StartDate = initialRegion.StartDate;

            context.Regions.Add(region);
            context.SaveChanges();
        }

        /// <summary>
        /// Adds initial districts from a file
        /// </summary>
        /// <param name="context"></param>
        /// <param name="districtJsonPath"></param>
        public static void AddInitialDistrictsFromFile(this IDbAppContext context, string districtJsonPath)
        {
            if (!string.IsNullOrEmpty(districtJsonPath) && File.Exists(districtJsonPath))
            {
                string districtJson = File.ReadAllText(districtJsonPath);
                context.AddInitialDistricts(districtJson);
            }
        }

        private static void AddInitialDistricts(this IDbAppContext context, string districtJson)
        {
            List<District> districts = JsonConvert.DeserializeObject<List<District>>(districtJson);
            if (districts != null)
            {
                context.AddInitialDistricts(districts);
            }
        }

        private static void AddInitialDistricts(this IDbAppContext context, List<District> districts)
        {
            districts.ForEach(u => context.AddInitialDistrict(u));
        }

        /// <summary>
        /// Adds a district to the system, only if it does not exist.
        /// </summary>
        private static void AddInitialDistrict(this IDbAppContext context, District initialDistrict)
        {
            District district = context.GetDistrictByMinistryDistrictId(initialDistrict.MinistryDistrictID);
            if (district != null)
            {
                return;
            }

            district = new District();
            district.MinistryDistrictID = initialDistrict.MinistryDistrictID;
            district.Name = initialDistrict.Name;
            district.StartDate = initialDistrict.StartDate;
            if (initialDistrict.Region != null)
            {
                Region region = context.GetRegionByMinistryRegionId(initialDistrict.Region.MinistryRegionID);
                district.Region = region;
            }
            else
            {
                district.Region = null;
            }            

            context.Districts.Add(district);
            context.SaveChanges();
        }


        public static void AddInitialServiceAreasFromFile(this IDbAppContext context, string districtJsonPath)
        {
            if (!string.IsNullOrEmpty(districtJsonPath) && File.Exists(districtJsonPath))
            {
                string serviceAreaJson = File.ReadAllText(districtJsonPath);
                context.AddInitialServiceAreas(serviceAreaJson);
            }
        }

        private static void AddInitialServiceAreas(this IDbAppContext context, string serviceAreaJson)
        {
            List<ServiceArea> serviceAreas = JsonConvert.DeserializeObject<List<ServiceArea>>(serviceAreaJson);
            if (serviceAreas != null)
            {
                context.AddInitialServiceAreas(serviceAreas);
            }
        }

        private static void AddInitialServiceAreas(this IDbAppContext context, List<ServiceArea> serviceAreas)
        {
            serviceAreas.ForEach(u => context.AddInitialServiceArea(u));
        }

        /// <summary>
        /// Adds a service area to the system, only if it does not exist.
        /// </summary>
        private static void AddInitialServiceArea(this IDbAppContext context, ServiceArea initialServiceArea)
        {
            ServiceArea serviceArea = context.GetServiceAreaByMinistryServiceAreaId(initialServiceArea.MinistryServiceAreaID);
            if (serviceArea != null)
            {
                return;
            }

            serviceArea = new ServiceArea();
            serviceArea.MinistryServiceAreaID = initialServiceArea.MinistryServiceAreaID;
            serviceArea.Name = initialServiceArea.Name;
            serviceArea.StartDate = initialServiceArea.StartDate;
            if (initialServiceArea.District != null)
            {
                District district = context.GetDistrictByMinistryDistrictId(initialServiceArea.District.MinistryDistrictID);
                serviceArea.District = district;
            }
            else
            {
                serviceArea.District = null;
            }

            context.ServiceAreas.Add(serviceArea);
            context.SaveChanges();
        }

        /// <summary>
        /// Update a seed item
        /// </summary>
        /// <param name="context"></param>
        /// <param name="item"></param>
        public static void UpdateSeedCCWJurisdictionInfo(this DbAppContext context, CCWJurisdiction item)
        { 
            CCWJurisdiction ccwjurisdiction = context.GetCCWJurisdictionByCode(item.Code);
            if (ccwjurisdiction == null)
            {
                context.CCWJurisdictions.Add(item);
            }
            else
            {
                ccwjurisdiction.Code = item.Code;
                ccwjurisdiction.ActiveFlag = item.ActiveFlag;
                ccwjurisdiction.Description = item.Description;
                ccwjurisdiction.EffectiveDate = item.EffectiveDate;
                ccwjurisdiction.ExpiryDate = item.ExpiryDate;                
            }
        }

        public static void UpdateSeedDistrictInfo(this DbAppContext context, District districtInfo)
        {
            // Adjust the region.

            int ministry_region_id = districtInfo.Region.MinistryRegionID;
            var exists = context.Regions.Any(a => a.MinistryRegionID == ministry_region_id);
            if (exists)
            {
                Region region = context.Regions.First(a => a.MinistryRegionID == ministry_region_id);
                districtInfo.Region = region;
            }
            else
            {
                districtInfo.Region = null;
            }

            District district = context.GetDistrictByMinistryDistrictId(districtInfo.MinistryDistrictID);
            if (district == null)
            {
                context.Districts.Add(districtInfo);
            }
            else
            {
                district.Name = districtInfo.Name;
                district.Region = districtInfo.Region;
                district.StartDate = districtInfo.StartDate;
            }
        }


        public static void UpdateSeedRegionInfo(this DbAppContext context, Region regionInfo)
        {            

            Region region = context.GetRegionByMinistryRegionId(regionInfo.MinistryRegionID);
            if (region == null)
            {
                context.Regions.Add(regionInfo);
            }
            else
            {
                region.Name = regionInfo.Name;
                region.StartDate = regionInfo.StartDate;
            }
        }

        public static void UpdateSeedServiceAreaInfo(this DbAppContext context, ServiceArea serviceAreaInfo)
        {

            // Adjust the district.

            int ministry_district_id = serviceAreaInfo.District.MinistryDistrictID;
            var exists = context.Districts.Any(a => a.MinistryDistrictID == ministry_district_id);
            if (exists)
            {
                District district = context.Districts.First(a => a.MinistryDistrictID == ministry_district_id);
                serviceAreaInfo.District = district;
            }
            else
            {
                serviceAreaInfo.District = null;
            }

            ServiceArea serviceArea = context.GetServiceAreaByMinistryServiceAreaId(serviceAreaInfo.MinistryServiceAreaID);
            if (serviceArea == null)
            {
                context.ServiceAreas.Add(serviceAreaInfo);
            }
            else
            {
                serviceArea.Name = serviceAreaInfo.Name;
                serviceArea.StartDate = serviceAreaInfo.StartDate;
                serviceArea.District = serviceAreaInfo.District;
            }
        }

        public static void UpdateSeedUserInfo(this DbAppContext context, User userInfo)
        {
            User user = context.GetUserByGuid(userInfo.Guid);            
            if (user == null)
            {
                context.Users.Add(userInfo);
            }
            else
            {
                user.Active = userInfo.Active;
                user.Email = userInfo.Email;
                user.GivenName = userInfo.GivenName;
                // user.Guid = userInfo.Guid;
                user.Initials = userInfo.Initials;
                user.SmAuthorizationDirectory = userInfo.SmAuthorizationDirectory;
                user.SmUserId = userInfo.SmUserId;
                user.Surname = userInfo.Surname;
                user.District = userInfo.District;

                // Sync Roles
                if (user.UserRoles != null)
                {
                    foreach (UserRole item in user.UserRoles)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    foreach (UserRole item in userInfo.UserRoles)
                    {
                        user.UserRoles.Add(item);
                    }
                }

                // Sync Groups
                if (user.GroupMemberships != null)
                {
                    foreach (GroupMembership item in user.GroupMemberships)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    foreach (GroupMembership item in userInfo.GroupMemberships)
                    {
                        user.GroupMemberships.Add(item);
                    }
                }
            }
        }
    }
}
