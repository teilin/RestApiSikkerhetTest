using System;

namespace RestApi.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonEncryptAttribute : Attribute
    {
    }
}
