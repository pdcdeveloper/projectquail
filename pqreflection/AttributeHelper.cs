using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// The methods in this class can be used to retrieve the attributes of a given member (from a class, enum, struct, etc.)
// Assigning default values to generic types:
// <see cref="https://msdn.microsoft.com/en-us/library/xwth0h0d.aspx"/>
namespace pqreflection
{
    public class AttributeHelper
    {
        public FieldInfo GetFieldInfo<T>(T member)
        {
            return member.GetType().GetField(nameof(member));
        }

        public IEnumerable<MemberInfo> GetMemberInfo<T>(T member)
        {
            MemberInfo[] info = member.GetType().GetMember(member.ToString());
            if ((info?.Length ?? 0) > 0)
                return info.AsEnumerable();
            return null;
        }

        public bool TryGetSpecifiedAttribute<T1, T2>(T1 member, out T2 attr)
            where T2 : Attribute
        {
            var info = GetMemberInfo(member);
            if ((info?.Count() ?? 0) > 0)
                foreach (var m in info)
                {
                    var attributes = m.GetCustomAttributes(typeof(T2), false);
                    if ((attributes?.Count() ?? 0) > 0)
                        foreach (var a in attributes)
                            if (a is T2)
                            {
                                attr = a as T2;
                                return true;
                            }
                }
            attr = null;//attr = default(T2);
            return false;
        }

        public PropertyInfo GetPropertyInfo<T>(T member)
        {
            return member.GetType().GetProperty(nameof(member));
        }
    }
}