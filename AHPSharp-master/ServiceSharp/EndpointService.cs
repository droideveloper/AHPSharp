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
using System.Linq;
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
      List<CombiEntity.Combi> combies = null;
      if(filter != null) {
        combies = dbContext.Combies
                           .Where(x => x.Price >= filter.priceMore && x.Power >= filter.powerMore)
                           .ToList();
        if(filter.type != null) {
          combies = combies.Where(x => x.Type.Contains(filter.type))
                           .ToList();
        }
      } else {
        combies = dbContext.Combies
                           .ToList();
      }

      if(combies != null) {
        return success(Combi.fromEntity(combies));
      } else {
        return error<List<Combi>>(404, "Failed", null);
      }
		}

    public Response<List<Combi>> queryBest(Selection priority) {    
       List<CombiEntity.Combi> entity = new List<CombiEntity.Combi>();
       for(int i = 0; i < 7; i++) {
         var c =  dbContext.Combies.Where(e => !entity.Contains(e))
                    .MinBy(y =>  (y.Area - priority.square) >= 0 ? (y.Area - priority.square) : Int32.MaxValue);
         if(c != null) {
           entity.Add(c);
         }
            
       }
       if(entity.Count > 0) {
         return success(Combi.fromEntity(entity));
       } else {
         return error<List<Combi>>(404, "failed", null);
       }  
    }

		public Response<int> version() {
			return success(1);
		}

		private Response<T> success<T>(T data) {
			return new Response<T>() {
				code = 200,
				message = "Successfull",
				data = data
			};
		}

		private Response<T> error<T>(int code, string message, T data) {
			return new Response<T>() {
				code = code,
				message = message,
				data = data
			};
		}
  }
}
