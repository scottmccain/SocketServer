﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using SocketService.Framework.Messaging;
using SocketService.Framework.ServiceHandlerLib;
using SocketService.Framework.Client.Request;
using SocketService.Framework.Command;

namespace SocketService.Handlers
{
    [Serializable()] 
    [ServiceHandlerType(typeof(GetRoomVariableRequest))]
    public class GetRoomVariableRequestHandler : BaseHandler<GetRoomVariableRequest, Guid>
    {
        public override bool HandleRequest(GetRoomVariableRequest request, Guid state)
        {
            if (request != null)
            {
                string roomName = request.RoomName;

                MSMQQueueWrapper.QueueCommand(
                    new GetRoomVariableCommand(state, request.RoomName, request.VariableName)
                );

                return true;
            }

            return false;
        }
    }
}