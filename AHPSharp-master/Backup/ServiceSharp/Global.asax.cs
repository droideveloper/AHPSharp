//
// ConsoleApp Copyright (C) 2016 Fatih.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace ServiceSharp {
	public class Global : HttpApplication {
		protected void Application_Start() {
			//.Configure(WebApiConfig.Register);
			register(RouteTable.Routes);
		}

		private void register(RouteCollection routes) { 
			//routes.Add(new ServiceRoute("v1/endpointService", new WebServiceHostFactory(), typeof(EndpointService));
		}
	}
}
