﻿using System;
using System.Collections.Generic;
using DevelopmentInProgress.DipCore;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Service.Test
{
    public class AuthorisationManagerServiceTest : IAuthorisationManagerService
    {
        private readonly List<Activity> activities;
        private readonly List<Role> roles;
        private readonly List<UserAuthorisation> usersAuthorisations;

        public AuthorisationManagerServiceTest()
        {
            var activity1 = new Activity() { Id = 0, Name = "Read", ActivityCode = "READ" };
            var activity2 = new Activity() { Id = 1, Name = "Write", ActivityCode = "WRITE" };
            
            activities = new List<Activity>(new[] { activity1, activity2 });
            
            var role1 = new Role() { Id = 0, Name = "Reader", RoleCode = "READER" };
            role1.Activities.Add(activities[0]);

            var role2 = new Role() { Id = 1, Name = "Writer", RoleCode = "WRITER" };
            role1.Activities.Add(activities[0]);
            role2.Activities.Add(activities[1]);

            roles = new List<Role>(new[] {role1, role2});

            var user1 = new UserAuthorisation("jbloggs") { DisplayName = "Joe Bloggs" };
            user1.Roles.Add(roles[0]);

            var user2 = new UserAuthorisation("jmasters") { DisplayName = "Jane Masters" };
            user2.Roles.Add(roles[1]);

            usersAuthorisations = new List<UserAuthorisation>(new[] { user1, user2 });
        }

        public string GetActivities()
        {
            var json = Serializer.SerializeToJson(activities);
            return json;
        }

        public string GetRoles()
        {
            var json = Serializer.SerializeToJson(roles);
            return json;
        }

        public string GetUserAuthorisations()
        {
            var json = Serializer.SerializeToJson(usersAuthorisations);
            return json;
        }
    }
}
