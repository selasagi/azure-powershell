﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.Network.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Network
{
    [Cmdlet(VerbsCommon.Get, "AzureRmApplicationGatewayUrlPathMapConfig"),
        OutputType(typeof(PSApplicationGatewayUrlPathMap), typeof(IEnumerable<PSApplicationGatewayUrlPathMap>))]
    [CliCommandAlias("applicationgateway;url;path;map;config;ls")]
    public class GetAzureApplicationGatewayUrlPathMapConfigCommand : NetworkBaseCmdlet
    {
        [Parameter(
            Mandatory = false,
            HelpMessage = "The name of the application gateway URL path map")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        
        [Parameter(
             Mandatory = true,
             ValueFromPipeline = true,
             HelpMessage = "The applicationGateway")]
        public PSApplicationGateway ApplicationGateway { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            
            if (!string.IsNullOrEmpty(this.Name))
            {
                var urlPathMap =
                    this.ApplicationGateway.UrlPathMaps.First(
                        resource =>
                            string.Equals(resource.Name, this.Name, System.StringComparison.CurrentCultureIgnoreCase));

                WriteObject(urlPathMap);
            }
            else
            {
                var urlPathMaps = this.ApplicationGateway.UrlPathMaps;
                WriteObject(urlPathMaps, true);
            }            
        }
    }
}
