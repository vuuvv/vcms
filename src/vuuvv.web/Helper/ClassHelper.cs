using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace vuuvv.web.Helper
{
    public static class ClassHelper
    {
        public static T Call<T>(object obj, string method, params object[] args)
        {
            Type t = obj.GetType();
            return (T)t.GetMethod(method).Invoke(obj, args);
        }

        public static T StaticCall<T>(object obj, string method, params object[] args)
        {
            Type t = obj.GetType();
            return (T)t.GetMethod(method).Invoke(null, args);
        }

        public static T Field<T>(object obj, string name)
        {
            Type t = obj.GetType();
            return (T)t.GetField(name).GetValue(obj);
        }

        public static void Field(object obj, string name, object value)
        {
            Type t = obj.GetType();
            t.GetField(name).SetValue(obj, value);
        }

        public static T StaticField<T>(object obj, string name)
        {
            Type t = obj.GetType();
            return (T)t.GetField(name).GetValue(null);
        }

        public static void StaticField(object obj, string name, object value) 
        {
            Type t = obj.GetType();
            t.GetField(name).SetValue(null, value);
        }

        public static object Property(object obj, string name)
        {
            Type t = obj.GetType();
            return t.GetProperty(name).GetValue(obj, null);
        }

        public static T Property<T>(object obj, string name)
        {
            return (T)Property(obj, name);
        }

        public static void Property(object obj, string name, object value)
        {
            Type t = obj.GetType();
            t.GetProperty(name).SetValue(obj, value, null);
        }

        public static T StaticProperty<T>(object obj, string name)
        {
            Type t = obj.GetType();
            return (T)t.GetProperty(name).GetValue(null, null);
        }

        public static void StaticProperty(object obj, string name, object value)
        {
            Type t = obj.GetType();
            t.GetProperty(name).SetValue(null, value, null);
        }

        public static Dictionary<string, object> ToDictionary(object obj, params string[] properties)
        {
            var ret = new Dictionary<string, object>();
            foreach (var prop in properties)
            {
                ret.Add(prop, Property(obj, prop));
            }
            return ret;
        }

        public static List<Dictionary<string, object>> ToJsonableList(List<object> objs, params string[] properties)
        {
            var ret = new List<Dictionary<string, object>>();
            foreach (var obj in objs)
            {
                ret.Add(ToDictionary(obj, properties));
            }
            return ret;
        }

        public static Type[] GetAllSubClass(Type t, bool concret = true, bool containSelf=false)
        {
            var types = from a in AppDomain.CurrentDomain.GetAssemblies()
                        from sub in a.GetTypes()
                        where t.IsAssignableFrom(sub) && (concret ? !sub.IsAbstract : true) && (containSelf ? true : sub == t)
                        select sub;
            return types.ToArray();
        }
    }
}
