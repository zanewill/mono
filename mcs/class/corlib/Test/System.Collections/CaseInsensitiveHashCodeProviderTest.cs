//
// CaseInsensitiveHashCodeProviderTest
//
// Copyright (C) 2005 Novell, Inc (http://www.novell.com)
//

using System;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using NUnit.Framework;

namespace MonoTests.System.Collections {

	[TestFixture]
	public class CaseInsensitiveHashCodeProviderTest {

		[Test]
		public void DefaultInstance ()
		{
			// Make sure the instance returned by Default
			// is really a CaseInsensitiveHashCodeProvider.
			Assert.IsTrue ((CaseInsensitiveHashCodeProvider.Default
				as CaseInsensitiveHashCodeProvider) != null);
		}

		[Test]
		public void HashCode ()
		{
			CaseInsensitiveHashCodeProvider cih = new CaseInsensitiveHashCodeProvider ();
			int h1 = cih.GetHashCode ("Test String");
			int h2 = cih.GetHashCode ("test string");
			int h3 = cih.GetHashCode ("TEST STRING");

			Assert.IsTrue (h1 == h2, "Mixed Case != lower case");
			Assert.IsTrue (h1 == h3, "Mixed Case != UPPER CASE");

			h1 = cih.GetHashCode ("one");
			h2 = cih.GetHashCode ("another");
			// Actually this is quite possible.
			Assert.IsFalse (h1 == h2);
		}

		[Test]
		public void DefaultCtor ()
		{
			CaseInsensitiveHashCodeProvider cihcp = new CaseInsensitiveHashCodeProvider ();
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, cihcp);
			byte[] def = ms.ToArray ();

			cihcp = new CaseInsensitiveHashCodeProvider (CultureInfo.CurrentCulture);
			ms = new MemoryStream ();
			bf.Serialize (ms, cihcp);
			byte[] current = ms.ToArray ();

			Assert.AreEqual (def, current, "default=current");
		}

		private static byte[] serialized_en_us = new byte[] {
#if NET_2_0
			0x00, 0x01, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00, 0x32, 0x53, 0x79, 0x73, 
			0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 
			0x43, 0x61, 0x73, 0x65, 0x49, 0x6E, 0x73, 0x65, 0x6E, 0x73, 0x69, 0x74, 0x69, 0x76, 0x65, 0x48, 
			0x61, 0x73, 0x68, 0x43, 0x6F, 0x64, 0x65, 0x50, 0x72, 0x6F, 0x76, 0x69, 0x64, 0x65, 0x72, 0x01, 
			0x00, 0x00, 0x00, 0x06, 0x6D, 0x5F, 0x74, 0x65, 0x78, 0x74, 0x03, 0x1D, 0x53, 0x79, 0x73, 0x74,
			0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 0x62, 0x61, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E,
			0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 0x6E, 0x66, 0x6F, 0x09, 0x02, 0x00, 0x00, 0x00, 0x04, 0x02,
			0x00, 0x00, 0x00, 0x1D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 0x62, 0x61,
			0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 0x6E, 0x66,
			0x6F, 0x06, 0x00, 0x00, 0x00, 0x0F, 0x6D, 0x5F, 0x6C, 0x69, 0x73, 0x74, 0x53, 0x65, 0x70, 0x61,
			0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x6D, 0x5F, 0x69, 0x73, 0x52, 0x65, 0x61, 0x64, 0x4F, 0x6E,
			0x6C, 0x79, 0x11, 0x63, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65,
			0x4E, 0x61, 0x6D, 0x65, 0x0B, 0x6D, 0x5F, 0x6E, 0x44, 0x61, 0x74, 0x61, 0x49, 0x74, 0x65, 0x6D,
			0x11, 0x6D, 0x5F, 0x75, 0x73, 0x65, 0x55, 0x73, 0x65, 0x72, 0x4F, 0x76, 0x65, 0x72, 0x72, 0x69,
			0x64, 0x65, 0x0D, 0x6D, 0x5F, 0x77, 0x69, 0x6E, 0x33, 0x32, 0x4C, 0x61, 0x6E, 0x67, 0x49, 0x44,
			0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x08, 0x01, 0x08, 0x0A, 0x00, 0x0A, 0x29, 0x00, 0x00,
			0x00, 0x01, 0x09, 0x04, 0x00, 0x00, 0x0B 
#else
			0x00, 0x01, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
			0x00, 0x04, 0x01, 0x00, 0x00, 0x00, 0x32, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 
			0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x43, 0x61, 0x73, 0x65, 0x49, 0x6E, 
			0x73, 0x65, 0x6E, 0x73, 0x69, 0x74, 0x69, 0x76, 0x65, 0x48, 0x61, 0x73, 0x68, 0x43, 0x6F, 0x64, 
			0x65, 0x50, 0x72, 0x6F, 0x76, 0x69, 0x64, 0x65, 0x72, 0x01, 0x00, 0x00, 0x00, 0x06, 0x6D, 0x5F, 
			0x74, 0x65, 0x78, 0x74, 0x03, 0x1D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 
			0x62, 0x61, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 
			0x6E, 0x66, 0x6F, 0x09, 0x02, 0x00, 0x00, 0x00, 0x04, 0x02, 0x00, 0x00, 0x00, 0x1D, 0x53, 0x79, 
			0x73, 0x74, 0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 0x62, 0x61, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 
			0x6F, 0x6E, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 0x6E, 0x66, 0x6F, 0x03, 0x00, 0x00, 0x00, 0x0B, 
			0x6D, 0x5F, 0x6E, 0x44, 0x61, 0x74, 0x61, 0x49, 0x74, 0x65, 0x6D, 0x11, 0x6D, 0x5F, 0x75, 0x73, 
			0x65, 0x55, 0x73, 0x65, 0x72, 0x4F, 0x76, 0x65, 0x72, 0x72, 0x69, 0x64, 0x65, 0x0D, 0x6D, 0x5F, 
			0x77, 0x69, 0x6E, 0x33, 0x32, 0x4C, 0x61, 0x6E, 0x67, 0x49, 0x44, 0x00, 0x00, 0x00, 0x08, 0x01, 
			0x08, 0x29, 0x00, 0x00, 0x00, 0x01, 0x09, 0x04, 0x00, 0x00, 0x0B
#endif
		};

		private static byte[] serialized_fr_ca = new byte[] {
#if NET_2_0
			0x00, 0x01, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 
			0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x01, 0x00, 0x00, 0x00, 0x32, 0x53, 0x79, 0x73, 
			0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 
			0x43, 0x61, 0x73, 0x65, 0x49, 0x6E, 0x73, 0x65, 0x6E, 0x73, 0x69, 0x74, 0x69, 0x76, 0x65, 0x48, 
			0x61, 0x73, 0x68, 0x43, 0x6F, 0x64, 0x65, 0x50, 0x72, 0x6F, 0x76, 0x69, 0x64, 0x65, 0x72, 0x01, 
			0x00, 0x00, 0x00, 0x06, 0x6D, 0x5F, 0x74, 0x65, 0x78, 0x74, 0x03, 0x1D, 0x53, 0x79, 0x73, 0x74, 
			0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 0x62, 0x61, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 
			0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 0x6E, 0x66, 0x6F, 0x09, 0x02, 0x00, 0x00, 0x00, 0x04, 0x02, 
			0x00, 0x00, 0x00, 0x1D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 0x62, 0x61, 
			0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 0x6E, 0x66, 
			0x6F, 0x06, 0x00, 0x00, 0x00, 0x0F, 0x6D, 0x5F, 0x6C, 0x69, 0x73, 0x74, 0x53, 0x65, 0x70, 0x61, 
			0x72, 0x61, 0x74, 0x6F, 0x72, 0x0C, 0x6D, 0x5F, 0x69, 0x73, 0x52, 0x65, 0x61, 0x64, 0x4F, 0x6E, 
			0x6C, 0x79, 0x11, 0x63, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x43, 0x75, 0x6C, 0x74, 0x75, 0x72, 0x65, 
			0x4E, 0x61, 0x6D, 0x65, 0x0B, 0x6D, 0x5F, 0x6E, 0x44, 0x61, 0x74, 0x61, 0x49, 0x74, 0x65, 0x6D, 
			0x11, 0x6D, 0x5F, 0x75, 0x73, 0x65, 0x55, 0x73, 0x65, 0x72, 0x4F, 0x76, 0x65, 0x72, 0x72, 0x69, 
			0x64, 0x65, 0x0D, 0x6D, 0x5F, 0x77, 0x69, 0x6E, 0x33, 0x32, 0x4C, 0x61, 0x6E, 0x67, 0x49, 0x44, 
			0x01, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x08, 0x01, 0x08, 0x0A, 0x00, 0x0A, 0x50, 0x00, 0x00, 
			0x00, 0x01, 0x0C, 0x0C, 0x00, 0x00, 0x0B 
#else
			0x00, 0x01, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
			0x00, 0x04, 0x01, 0x00, 0x00, 0x00, 0x32, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x43, 0x6F, 
			0x6C, 0x6C, 0x65, 0x63, 0x74, 0x69, 0x6F, 0x6E, 0x73, 0x2E, 0x43, 0x61, 0x73, 0x65, 0x49, 0x6E, 
			0x73, 0x65, 0x6E, 0x73, 0x69, 0x74, 0x69, 0x76, 0x65, 0x48, 0x61, 0x73, 0x68, 0x43, 0x6F, 0x64, 
			0x65, 0x50, 0x72, 0x6F, 0x76, 0x69, 0x64, 0x65, 0x72, 0x01, 0x00, 0x00, 0x00, 0x06, 0x6D, 0x5F, 
			0x74, 0x65, 0x78, 0x74, 0x03, 0x1D, 0x53, 0x79, 0x73, 0x74, 0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 
			0x62, 0x61, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 0x6F, 0x6E, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 
			0x6E, 0x66, 0x6F, 0x09, 0x02, 0x00, 0x00, 0x00, 0x04, 0x02, 0x00, 0x00, 0x00, 0x1D, 0x53, 0x79, 
			0x73, 0x74, 0x65, 0x6D, 0x2E, 0x47, 0x6C, 0x6F, 0x62, 0x61, 0x6C, 0x69, 0x7A, 0x61, 0x74, 0x69, 
			0x6F, 0x6E, 0x2E, 0x54, 0x65, 0x78, 0x74, 0x49, 0x6E, 0x66, 0x6F, 0x03, 0x00, 0x00, 0x00, 0x0B, 
			0x6D, 0x5F, 0x6E, 0x44, 0x61, 0x74, 0x61, 0x49, 0x74, 0x65, 0x6D, 0x11, 0x6D, 0x5F, 0x75, 0x73, 
			0x65, 0x55, 0x73, 0x65, 0x72, 0x4F, 0x76, 0x65, 0x72, 0x72, 0x69, 0x64, 0x65, 0x0D, 0x6D, 0x5F, 
			0x77, 0x69, 0x6E, 0x33, 0x32, 0x4C, 0x61, 0x6E, 0x67, 0x49, 0x44, 0x00, 0x00, 0x00, 0x08, 0x01, 
			0x08, 0x50, 0x00, 0x00, 0x00, 0x01, 0x0C, 0x0C, 0x00, 0x00, 0x0B
#endif
		};

		[Test]
		public void SerializationRoundtrip ()
		{
			CaseInsensitiveHashCodeProvider enus = new CaseInsensitiveHashCodeProvider (new CultureInfo ("en-US"));
			BinaryFormatter bf = new BinaryFormatter ();
			MemoryStream ms = new MemoryStream ();
			bf.Serialize (ms, enus);

			ms.Position = 0;
			CaseInsensitiveHashCodeProvider clone = (CaseInsensitiveHashCodeProvider) bf.Deserialize (ms);
			Assert.AreEqual (enus.GetHashCode (String.Empty), clone.GetHashCode (String.Empty), "GetHashCode(string)");
			Assert.AreEqual (enus.GetHashCode (Int32.MinValue), clone.GetHashCode (Int32.MinValue), "GetHashCode(int)");
		}

		[Test]
		public void Deserialize ()
		{
#if TARGET_JVM
			BinaryFormatter bf = (BinaryFormatter)vmw.@internal.remoting.BinaryFormatterUtils.CreateBinaryFormatter (false);
#else
			BinaryFormatter bf = new BinaryFormatter ();
#endif // TARGET_JVM

			MemoryStream ms = new MemoryStream (serialized_en_us);
			CaseInsensitiveHashCodeProvider enus = (CaseInsensitiveHashCodeProvider) bf.Deserialize (ms);
			Assert.IsNotNull (enus, "en-US");

			ms = new MemoryStream (serialized_fr_ca);
			CaseInsensitiveHashCodeProvider frca = (CaseInsensitiveHashCodeProvider) bf.Deserialize (ms);
			Assert.IsNotNull (frca, "fr-CA");
		}
	}
}
