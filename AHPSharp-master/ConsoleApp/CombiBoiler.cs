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
using System;

namespace ConsoleApp {
	
	public class CombiBoiler {

		public string Brand;
		public string Model;
		public string Type;

		public int Power;
		public int Price;

		public int Warranty;
		public int Area;

		public Dimention Dimention;
		public string ImageUrl;

		public int Safety;
	}

	public class Dimention {
		public int Width;
		public int Height;
		public int Depth;
	}
}
