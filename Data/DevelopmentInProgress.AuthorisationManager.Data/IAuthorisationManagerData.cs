﻿using System.Collections.Generic;
using DevelopmentInProgress.DipSecure;

namespace DevelopmentInProgress.AuthorisationManager.Data
{
    public interface IAuthorisationManagerData
    {
        IList<Activity> GetActivities();
        IList<Role> GetRoles(IList<Activity> activities);
        IList<UserAuthorisation> GetUserAuthorisations(IList<Role> roles);
        Activity SaveActivity(Activity activity);
        Role SaveRole(Role role);
        UserAuthorisation SaveUserAuthorisation(UserAuthorisation userAuthorisation);
        bool DeleteActivity(int id);
        bool DeleteRole(int id);
        bool DeleteUserAuthorisation(int id);
        bool RemoveActivityFromActivity(int activityId, int parentId);
        bool RemoveActivityFromRole(int activityId, int roleId);
        bool RemoveRoleFromRole(int roleId, int parentId);
        bool RemoveRoleFromUser(int roleId, int userId);
        bool AddActivityToRole(int roleId, int activityId);
        bool AddActivityToActivity(int parentActivityId, int activityId);
        bool AddRoleToUser(int userId, int roleId);
        bool AddRoleToRole(int parentRoleId, int roleId);
    }
}