using System.Collections.Generic;
using System.IO;
using ProtoBuf;

namespace KinectBuf
{
	[ProtoContract]
	public class Kinect1Contract
	{
		[ProtoMember(1)] public List<Kinect1Frame> Kinect1Frames;

		public Kinect1Contract(List<Kinect1Frame> kinect1Frames)
		{
			Kinect1Frames = kinect1Frames;
		}

		public void Serialize(string fileName)
		{
			using (var file = File.Create(fileName))
			{
				Serializer.Serialize(file, Kinect1Frames);
			}
		}
	}
}