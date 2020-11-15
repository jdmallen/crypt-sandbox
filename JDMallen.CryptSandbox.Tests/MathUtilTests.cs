using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace JDMallen.CryptSandbox.Tests
{
	public class MathUtilTests
	{
		[Fact]
		public void EuclidGcd()
		{
			const int num1 = 1071;
			const int num2 = 462;
			const int expected = 21;
			var actual = MathUtil.EuclidGcd(num1, num2);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void EulerTotient()
		{
			const long n1 = 7; // 1, 2, 3, 4, 5, 6
			const long expected1 = 6;
			var actual1 = MathUtil.EulerTotient(n1);
			Assert.Equal(expected1, actual1);

			const long n2 = 8; // 1, 2, 3, 4, 5, 6, 7
			const long expected2 = 4;
			var actual2 = MathUtil.EulerTotient(n2);
			Assert.Equal(expected2, actual2);
		}

		[Fact]
		public void MultiplicativeOrder()
		{
			const int a1 = 4;
			const int n1 = 7;
			const int expected1 = 3;
			var actual1 = MathUtil.MultiplicativeOrder(a1, n1);
			Assert.Equal(expected1, actual1);
		}

		[Fact]
		public void PrimitiveRootsModuloN()
		{
			const int n1 = 7;
			var expected = (IEnumerable<long>) new long[] {3, 5};
			var actual = MathUtil.PrimitiveRootsModuloN(n1);
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void IsPrime()
		{
			var testValues = Enumerable.Range(0, 100);
			var primeValues = new HashSet<long>
			{
				2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59,
				61, 67, 71, 73, 79, 83, 89, 97
			};
			var actualValues = testValues.Where(i => MathUtil.IsPrime(i))
				.Select(value => (long) value)
				.ToHashSet();
			Assert.Equal(primeValues, actualValues);
		}
	}
}
