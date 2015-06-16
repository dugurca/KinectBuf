using System.Collections.Generic;

namespace KinectBuf
{
	static class Utils
	{
		public static bool CheckDanceDataConsistency(List<int> frameNumbers, List<long> timestamps,
			List<List<Vec3>> jointPositions, List<float> jointRotationsAbsolute, List<float> jointRotationsHierarchical)
		{
			int q = frameNumbers.Count;
			int n = timestamps.Count;
			int m = jointPositions.Count;
			int k = jointRotationsAbsolute.Count;
			int l = jointRotationsHierarchical.Count;

			List<int> lst = new List<int>
			{
				q, n, m, l, k,
			};

			int x = lst[0];
			for (int i = 1; i < lst.Count; i++)
			{
				if (lst[i] != x) return false;
			}
			return true;
		}
		
	}
}
