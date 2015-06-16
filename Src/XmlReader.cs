using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace KinectBuf
{
	public static class XmlReader
	{
		public const string JointName = "/Joint";
		private static readonly XmlDocument XmlDocument = new XmlDocument();

		public static XmlNodeList GetNodes(string file, string nodeName)
		{
			Debug.Assert(File.Exists(file));
			if (XmlDocument.FirstChild == null)
			{
				XmlDocument.Load(file);
			}
			Debug.Assert(XmlDocument.DocumentElement != null);
			return XmlDocument.DocumentElement.SelectNodes(nodeName);
		}

		public static List<Kinect1Frame> GetKinect1Frames(string fileName, string frameName)
		{
			var nodes = GetNodes(fileName, frameName);

			List<Kinect1Frame> res = new List<Kinect1Frame>();

			foreach (XmlNode node in nodes)
			{
				Kinect1Frame kinect1Frame = new Kinect1Frame();

				var frame = node["Frame"];
				int frameNumber = int.Parse(frame.Attributes[0].InnerText);
				long timeStamp = long.Parse(frame.Attributes[1].InnerText);

				var skeleton = node["Skeleton"];
				int skeletonId = int.Parse(skeleton.Attributes[0].InnerText);

				List<Vec3> jointPositions = GetVec3(skeleton, "JointPositions");
				List<Vec4> jointRotationsAbsolute = GetVec4(skeleton, "JointRotationsAbsolute");
				List<Vec4> jointRotationsHierarchical = GetVec4(skeleton, "JointRotationsHierarchical");

				kinect1Frame.FrameNumber = frameNumber;
				kinect1Frame.Timestamp = timeStamp;
				kinect1Frame.SkeletonId = skeletonId;
				kinect1Frame.JointPositions = jointPositions;
				kinect1Frame.JointRotationsAbsolute = jointRotationsAbsolute;
				kinect1Frame.JointRotationsHierarchical = jointRotationsHierarchical;

				res.Add(kinect1Frame);
			}
			return res;
		}

		private static List<Vec3> GetVec3(XmlNode node, string nameStr)
		{
			List<Vec3> res = new List<Vec3>();

			var children = node.SelectNodes(nameStr + JointName);
			Debug.Assert(children != null);

			foreach (XmlNode child in children)
			{
				float x = float.Parse(child.Attributes[0].InnerText);
				float y = float.Parse(child.Attributes[1].InnerText);
				float z = float.Parse(child.Attributes[2].InnerText);
				res.Add(new Vec3(x, y, z));
			}

			return res;
		}

		private static List<Vec4> GetVec4(XmlNode node, string nameStr)
		{
			List<Vec4> res = new List<Vec4>();
			var children = node.SelectNodes(nameStr + JointName);
			Debug.Assert(children != null);

			foreach (XmlNode child in children)
			{
				float x = float.Parse(child.Attributes[0].InnerText);
				float y = float.Parse(child.Attributes[1].InnerText);
				float z = float.Parse(child.Attributes[2].InnerText);
				float w = float.Parse(child.Attributes[3].InnerText);
				res.Add(new Vec4(x, y, z, w));
			}
			return res;
		}
	}
}