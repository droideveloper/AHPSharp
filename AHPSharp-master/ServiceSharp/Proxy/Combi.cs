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
using System.Linq;
using System.Collections.Generic;
//can be any thing
using Entity = CombiEntity.Combi;


namespace ServiceSharp {

	public class Combi {

		public string brand { get; set; }
		public string model { get; set; }
		public string type { get; set; }


		public int price { get; set; }
		public int power { get; set; }

		public int area { get; set; }
		public int warranty { get; set; }

		public Dimension dimension { get; set; }

		public string image { get; set; }

		public int safety { get; set; }

    public static List<Combi> fromEntity(List<Entity> array) { 
      return array.Select(x => new Combi() {
          brand = x.Brand,
          model = x.Model,
          type = x.Type,
          price = x.Price,
          power = x.Power,
          area = x.Area,
          safety = x.Safety,
          image = x.Image,
          dimension = new Dimension() {
            depth = Int32.Parse(x.Dimension.Split('x')[2].Trim()),
            height = Int32.Parse(x.Dimension.Split('x')[0].Trim()),
            width = Int32.Parse(x.Dimension.Split('x')[1].Trim())
          },
          warranty = x.Warranty
        }).ToList();
      }

    public static Dimension fromStr(string d) {
      int[] xyz = d.Split('x').Select(x => x.Trim()).Select(x => Int32.Parse(x)).ToArray();
      return new Dimension() {
         height = xyz[0],
         width = xyz[1],
         depth = xyz[2]
      };
    }
	} 
}
