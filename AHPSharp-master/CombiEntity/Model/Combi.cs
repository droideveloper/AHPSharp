//
// CombiEntity Copyright (C) 2016 Fatih.
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
using System.ComponentModel.DataAnnotations;

namespace CombiEntity {

	public class Combi {

		[Key]
		public int CombiID  { get; set; }

		public string Brand { get; set; }
		public string Model { get; set; }
		public string Type { get; set; }

		public int Price { get; set; }
		public int Power { get; set; }

		public int Area { get; set; }
		public int Warranty { get; set; }

		public string Dimension { get; set; }
		public string Image { get; set; }

		public int Safety { get; set; }

	}
}
