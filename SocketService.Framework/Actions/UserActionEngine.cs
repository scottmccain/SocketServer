﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SocketService.Framework.Util;
using SocketService.Framework.Data.Domain;
using SocketService.Framework.Data;

namespace SocketService.Framework.Actions
{
    public class UserActionEngine : SingletonBase<UserActionEngine>
    {
        public void LogoutUser(Guid clientId)
        {
            User user = UserRepository.Instance.FindUserByClientKey(clientId);
            if (user != null)
            {
                UserRepository.Instance.RemoveUser(user);
            }
        }

        public bool LoginUser(Guid clientId, string loginName)
        {
            // check for duplicates
            User duplicateUser = UserRepository.Instance.FindUserByName(loginName);
            if (duplicateUser != null)
            {
                return false;
            }
            else
            {
                Room room = RoomRepository.Instance.FindByName("");
                if (room == null)
                {
                    // add default room
                    RoomRepository.Instance.AddRoom(new Room() { Name = "" });
                }

                User newUser = new User() { ClientKey = clientId, UserName = loginName, Room = "" };
                UserRepository.Instance.AddUser(newUser);

                return true;
            }
        }

        public void ClientChangeRoom(Guid clientId, string roomName)
        {
            Room room = RoomRepository.Instance.FindByName(roomName);
            if (room == null)
            {
                RoomRepository.Instance.AddRoom(new Room() { Name = roomName });
            }

            User user = UserRepository.Instance.FindUserByClientKey(clientId);
            if (user != null)
            {
                user.Room = roomName;
            }
        }
    }
}