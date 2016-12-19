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
using AHPSharp;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
namespace ConsoleApp {
	public class Program {
		
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		public static void Main(string[] args) {
			/*
			int N = 5;

			double[] Matrix = new double[] { 1, 0.333, 0.555, 0.167, 2, 3, 1, 2, 0.5, 4, 2, 0.5, 1, 0.333, 3, 6, 2, 3, 1, 7, 0.5, 0.25, 0.333, 0.143, 1 };


			double[] sum = Enumerable.Range(0, N)
												 .Select(y => Enumerable.Range(0, N).Select(x => Matrix[x * N + y]).Sum())
												 .ToArray();

			foreach(double x in sum) { 
				Console.WriteLine("{0}", x);
			}*/

			/*
				PairwiseComparison comparison = new PairwiseComparison() {
					N = 5,
					Matrix = new double[] { 1, 0.333, 0.5, 0.167, 2, 3, 1, 2, 0.5, 4, 2, 0.5, 1, 0.333, 3, 6, 2, 3, 1, 7, 0.5, 0.25, 0.333, 0.143, 1 }
				};

			

				Console.WriteLine(comparison.isConsistency);
				Console.WriteLine("xxx end xxx");*/


			string[] lines = System.IO.File.ReadAllLines("/Users/Fatih/KombiDatav5.txt", Encoding.UTF8);
			foreach(string line in lines) {
				string[] data = line.Split(',');
				string print = "";
				foreach(string x in data) {
					print += x + "\t";
				}
				Console.WriteLine("{0}\n", print);
			}
		}
	}
}
