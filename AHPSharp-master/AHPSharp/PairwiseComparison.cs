//
// AHPSharp Copyright (C) 2016 Fatih.
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

namespace AHPSharp {

	public class PairwiseComparison {

		//this RI table 
		static readonly double[] RI = { 0, 0, 0.58, 0.90, 1.12, 1.24, 1.32, 1.41, 1.45, 1.49, 1.51, 1.48, 1.56, 1.57, 1.59 };

		double[] matrixSum;
		double[] normalizedMatrix;
		double[] eigenVector;
		double[] ax;
		double[] lamdaX;

		public int N { get; set; }

		public double[] Matrix { get; set; }

		public double[] NormalizedMatrix {
			get {
				if(normalizedMatrix == null) {
					normalizedMatrix =  Enumerable.Range(0, N * N)
					                              .Select(position => Matrix[position] / MatrixSum[position % N])
													 							.ToArray();
				}
				return normalizedMatrix;
			}
		}

		public double[] MatrixSum { 
			get {
				if(matrixSum == null) {
					matrixSum = Enumerable.Range(0, N)
					                      .Select(y => {
																	return Enumerable.Range(0, N)
							                                     .Select(x => Matrix[x * N + y])
							                                     .Sum();
																})
					                      .ToArray();
				}
				return matrixSum;
			}
		}

		public double[] EigenVector { 
			get {
				if(eigenVector == null) {
					eigenVector = Enumerable.Range(0, N)
					                        .Select(y => { 
																			return Enumerable.Range(0, N)						                                                    
							                                         .Select(x => NormalizedMatrix[y * N + x])
						                                           .Average(); 
																	})
					                        .ToArray();
				}
				return eigenVector;
			}
		}

		public double[] Ax { 
			get {
				if(ax == null) {
					ax = Enumerable.Range(0, N)
					               .Select(y => { 
														return Enumerable.Range(0, N)
							                               .Select(x => EigenVector[x] * Matrix[y * N + x])
							                               .Sum(); 
												 })
												 .ToArray();
				}
				return ax;
			}
		}

		public double[] LamdaX {
			get {
				if(lamdaX == null) {
					lamdaX = Enumerable.Range(0, N)
													 .Select(y => Ax[y] / EigenVector[y])
													 .ToArray();
				}
				return lamdaX;
			}
		}

		public double LamdaMax { 
			get { 
				return LamdaX.Average();
			}
		}

		public double CI { 
			get {
				return (LamdaMax - N) / (N - 1);
			}
		}

		public double CR { 
			get {
				return CI / RI[N - 1];//this one is n - 1 because array is 0 based.
			}
		}

		public bool isConsistency { 
			get {
				return CR < 0.1;
			}
		}
	}
}
