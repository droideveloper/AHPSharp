//
// ServiceSharp Copyright (C) 2016 Fatih.
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
using System;
using System.Web.Services.Description;
using System.ServiceModel.Web;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Web.Script.Services;
using System.Collections.Generic;

namespace ServiceSharp {

	[ServiceContract]
	public interface IEndpointService {

		[OperationContract]
		[WebInvoke(Method = "POST",
							 RequestFormat = WebMessageFormat.Json,
							 ResponseFormat = WebMessageFormat.Json,
							 BodyStyle = WebMessageBodyStyle.Bare,
							 UriTemplate = "/filter")]
		Response<List<Combi>> queryCombies(Filter filter);

		[OperationContract]
		[WebInvoke(Method = "POST",
					 RequestFormat = WebMessageFormat.Json,
					 ResponseFormat = WebMessageFormat.Json,
					 BodyStyle = WebMessageBodyStyle.Bare,
					 UriTemplate = "/filter")]
		Response<Comparison> pairwiseCompare(Matrix matrix);

		[OperationContract]
		[WebInvoke(Method = "GET",
					 RequestFormat = WebMessageFormat.Json,
					 ResponseFormat = WebMessageFormat.Json,
					 BodyStyle = WebMessageBodyStyle.Bare,
					 UriTemplate = "/version")]
		Response<int> version();

	}
}
