using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KinectBuf
{
	[ProtoContract]
	public class Kinect1Frame
	{
		[ProtoMember(1)]
		public int FrameNumber { get; set; }

		[ProtoMember(2)]
		public long Timestamp { get; set; }

		[ProtoMember(3)]
		public int SkeletonId { get; set; }

		[ProtoMember(4)]
		public List<Vec3> JointPositions { get; set; }

		[ProtoMember(5)]
		public List<Vec4> JointRotationsAbsolute { get; set; }

		[ProtoMember(6)]
		public List<Vec4> JointRotationsHierarchical { get; set; }

		public void Print()
		{
			Console.WriteLine("FrameNo: " + FrameNumber);
			Console.WriteLine("TimeStamp: " + Timestamp);
			Console.WriteLine("SkeletonId: " + SkeletonId);

			Console.WriteLine("Joint Positions: ");

			foreach (var jointPosition in JointPositions)
			{
				jointPosition.Print();
			}

		}

	}

	[ProtoContract]
	public class Vec3
	{
		private const string Sep = " , ";

		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

		public Vec3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public void Print()
		{
			Console.WriteLine("X: " + X + Sep + "Y: " + Y + Sep + "Z: " + Z);
		}
	}

	[ProtoContract]
	public class Vec4
	{
		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

		[ProtoMember(4)]
		public float W { get; set; }

		public Vec4(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}
	}
}