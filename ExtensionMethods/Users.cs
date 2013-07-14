using System.Collections.Generic;
using System.Linq;
using umbraco.BusinessLogic;

namespace Umbraco.Community.ExtensionMethods
{
    public static class Users
    {
        /// <summary>
        /// Gets all the users 
        /// </summary>
        public static IEnumerable<User> GetAllUsers()
        {
            var currentUserTypes = UserType.GetAllUserTypes();
            return User.getAll().Where(u => currentUserTypes.Contains(u.UserType));
        }

        /// <summary>
        /// Gets all the users by a specific user type id
        /// </summary>
        /// <param name="userTypeId"></param>
        public static IEnumerable<User> GetUsersByType(int userTypeId)
        {
            return User.getAll().Where(u => u.UserType.Id == userTypeId);
        }

        /// <summary>
        /// Get all the users by a specific user type alias
        /// </summary>
        /// <param name="typeAlias"></param>
        public static IEnumerable<User> GetUsersByType(string typeAlias)
        {
            var currentUserType = UserType.GetAllUserTypes().FirstOrDefault(t => t.Alias == typeAlias);
            return currentUserType == null ? null : User.getAll().Where(u => u.UserType == currentUserType && !string.IsNullOrWhiteSpace(u.Email) && !u.Disabled);
        }

        /// <summary>
        /// Gets all current user types
        /// </summary>
        public static IEnumerable<UserType> GetCurrentUserTypes()
        {
            return UserType.GetAllUserTypes();
        }

        /// <summary>
        /// Gets the current user
        /// </summary>
        /// <returns></returns>
        public static User GetCurrentUser()
        {
            return User.GetCurrent();
        }
    }
}
