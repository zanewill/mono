// Author: Dwivedi, Ajay kumar
//            Adwiv@Yahoo.com
using System;
using System.Xml.Serialization;

namespace System.Xml.Schema
{
	/// <summary>
	/// Summary description for XmlSchemaSimpleContent.
	/// </summary>
	public class XmlSchemaSimpleContent : XmlSchemaContentModel
	{
		private XmlSchemaContent content;

		public XmlSchemaSimpleContent()
		{
		}

		[XmlElement("restriction",typeof(XmlSchemaSimpleContentRestriction),Namespace="http://www.w3.org/2001/XMLSchema")]
		[XmlElement("extension",typeof(XmlSchemaSimpleContentExtension),Namespace="http://www.w3.org/2001/XMLSchema")]
		public override XmlSchemaContent Content 
		{
			get{ return  content; } 
			set{ content = value; }
		}
	}
}
