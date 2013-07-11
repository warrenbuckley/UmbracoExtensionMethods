using System;
using System.Xml.Linq;

namespace Umbraco.Community.ExtensionMethods.Linq.Xml.ExtensionMethods {
    
    public static class LinqXmlExtensionMethods {

        public static string GetAttributeValue(this XElement xElement, string name) {
            if (xElement == null) return null;
            XAttribute attr = xElement.Attribute(name);
            return attr == null ? null : attr.Value;
        }

        public static T GetAttributeValue<T>(this XElement xElement, string name) {
            if (xElement == null) return default(T);
            XAttribute attr = xElement.Attribute(name);
            return attr == null ? default(T) : (T) Convert.ChangeType(attr.Value, typeof(T));
        }

        public static string GetElementValue(this XElement xElement, XName name) {
            if (xElement == null) return null;
            XElement child = xElement.Element(name);
            return child == null ? null : child.Value;
        }

        public static T GetElementValue<T>(this XElement xElement, XName name) {
            if (xElement == null) return default(T);
            XElement child = xElement.Element(name);
            return child == null ? default(T) : (T) Convert.ChangeType(child.Value, typeof(T));
        }

    }

}