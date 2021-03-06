﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketService.Framework.Client.Data.Domain;

namespace SocketService.Framework.Client.Data
{
    public class UserRepository
    {
        private object _listLock = new object();
        private List<User> _userList = new List<User>();

        private static UserRepository _instance = new UserRepository();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static UserRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserRepository();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Finds the users by room.
        /// </summary>
        /// <param name="roomname">The roomname.</param>
        /// <returns></returns>
        public List<User> FindUsersByRoom(string roomname)
        {
            lock (_listLock)
            {
                var query = from user in _userList
                            where user.Room != null && user.Room.Name == roomname
                            select user;

                return query.ToList();
            }
        }

        public List<Guid> FindClientKeysByRoomFiltered(string roomname, Guid filteredClient)
        {
            lock (_listLock)
            {
                var query = from user in _userList
                            where user.Room != null && user.Room.Name == roomname && user.ClientKey != filteredClient
                            select user.ClientKey;

                return query.ToList();
            }
        }

        /// <summary>
        /// Finds the name of the user by.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        public User FindUserByName(string username)
        {
            lock (_listLock)
            {
                var query = from user in _userList
                            where user.UserName == username
                            select user;

                return query.FirstOrDefault();
            }
        }

        /// <summary>
        /// Finds the user by client key.
        /// </summary>
        /// <param name="clientKey">The client key.</param>
        /// <returns></returns>
        public User FindUserByClientKey(Guid clientKey)
        {
            lock (_listLock)
            {
                var query = from user in _userList
                            where user.ClientKey == clientKey
                            select user;

                return query.FirstOrDefault();
            }
        }

        /// <summary>
        /// Adds the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void AddUser(User user)
        {
            lock (_listLock)
            {
                _userList.Add(user);
            }
        }

        /// <summary>
        /// Removes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        public void RemoveUser(User user)
        {
            lock (_listLock)
            {
                _userList.Remove(user);
            }
        }
    }
}
