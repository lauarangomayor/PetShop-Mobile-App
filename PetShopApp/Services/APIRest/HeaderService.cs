﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PetShopApp.Services.ApiRest
{
    public class HeaderService
    {
        #region Properties

        public Dictionary<string, string> Headers { get; set; }

        #endregion
        #region Initialize
        public HeaderService()
        {
            Headers.Add("content-type", "application/json");
        }
        #endregion
        #region Methods

        public HttpRequestMessage AddHeader(HttpRequestMessage requestMessage)
        {
            foreach (var header in Headers)
            {
                requestMessage.Headers.Add(header.Key, header.Value);
            }
            return requestMessage; 
        }

        #endregion
    }
}
