using System;
using System.Collections.Generic;

namespace JDMallen.CryptSandbox
{
	public class MathUtil
	{
		public static long EuclidGcd(long a, long b)
		{
			var smaller = Math.Min(a, b);
			var remainder = Math.Max(a, b) % smaller;
			return remainder == 0
				? smaller
				: EuclidGcd(smaller, remainder);
		}

		public static bool IsPrime(long n)
		{
			if (n < 2)
			{
				return false;
			}

			if (n % 2 == 0)
			{
				return n == 2;
			}

			var root = (int) Math.Sqrt(n);

			for (var i = 3; i <= root; i += 2)
			{
				if (n % i == 0)
				{
					return false;
				}
			}

			return true;
		}

		public static long EulerTotient(long n)
		{
			if (IsPrime(n))
			{
				return n - 1;
			}

			var result = 0;
			for (var i = 1; i < n; i++)
			{
				if (EuclidGcd(i, n) == 1)
				{
					result++;
				}
			}

			return result;
		}

		public static long MultiplicativeOrder(long a, long n)
		{
			var exp = 1;

			while ((long)Math.Pow(a, exp) % n != 1)
			{
				exp++;
			}

			return exp;
		}

		public static IEnumerable<long> PrimitiveRootsModuloN(long n)
		{
			var roots = new List<long>();

			for (var i = 2; i < n; i++)
			{
				var order = MultiplicativeOrder(i, n);
				var totient = EulerTotient(n);
				if (order == totient)
				{
					roots.Add(i);
				}
			}

			return roots;
		}
	}
}
