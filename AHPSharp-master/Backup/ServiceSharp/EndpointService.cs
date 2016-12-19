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
using System.Collections.Generic;
using AHPSharp;
using CombiEntity;
using System.Data.Entity.Infrastructure;

namespace ServiceSharp {

	public class EndpointService : IEndpointService {

		private AhpContext dbContext = new AhpContext();

		public Response<Comparison> pairwiseCompare(Matrix matrix) {
			PairwiseComparison pairwise = new PairwiseComparison() {
				N = matrix.n,
				Matrix = matrix.matrix
			};

			return success(new Comparison() {
				consistency = pairwise.isConsistency,//if it's consistent
				vector = pairwise.isConsistency ? pairwise.EigenVector : null//if so we get its gloabal 
			});
		}

		//filter data from database in here
		public Response<List<Combi>> queryCombies(Filter filter) {
			throw new NotImplementedException();
		}

		public Response<int> version() {
			return success(1);
		}

		Response<T> success<T>(T data) {
			return new Response<T>() {
				code = 200,
				message = "Successfull",
				data = data
			};
		}

		Response<T> error<T>(int code, string message, T data) {
			return new Response<T>() {
				code = code,
				message = message,
				data = data
			};
		}
	}
}
