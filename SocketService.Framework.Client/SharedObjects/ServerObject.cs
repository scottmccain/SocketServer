﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SocketService.Framework.Client.SharedObjects
{
    [Serializable]
    public class ServerObject
    {
        private Hashtable data = new Hashtable();

        /// <summary>
        /// Gets the read only copy.
        /// </summary>
        /// <returns></returns>
        public ServerObjectRO GetReadOnlyCopy()
        {
            return new ServerObjectRO(data);
        }

        /// <summary>
        /// Sets the element value.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="value">The value.</param>
        /// <param name="dataType">Type of the data.</param>
        public void SetElementValue(string elementName, object value, ServerObjectDataType dataType)
        {
            if (!data.ContainsKey(elementName))
            {
                data.Add(elementName, new ServerObjectDataHolder());
            }

            (data[elementName] as ServerObjectDataHolder).Value = value;

            (data[elementName] as ServerObjectDataHolder).DataType = dataType;

        }


        /// <summary>
        /// Gets the value for element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns></returns>
        public object GetValueForElement(string elementName)
        {
            object value = null;
            if (data.ContainsKey(elementName))
            {
                value = (data[elementName] as ServerObjectDataHolder).Value;
            }

            return value;
        }

        /// <summary>
        /// Gets the data type for element.
        /// </summary>
        /// <param name="elementName">Name of the element.</param>
        /// <returns></returns>
        public ServerObjectDataType GetDataTypeForElement(string elementName)
        {
            if( !data.ContainsKey(elementName) )
            {
                throw new ArgumentException();
            }

            return (data[elementName] as ServerObjectDataHolder).DataType;
        }
    }
}
