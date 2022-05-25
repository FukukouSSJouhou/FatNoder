using System.Reflection;

namespace AyanoPluginCommonAPI.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        public class PlugInMethod
        {
            public Type ExeType { get; set; }
            public IList<String> MethodNames { get; set; }
            public PlugInMethod(Type type, IList<String> methods)
            {
                this.ExeType = type;
                this.MethodNames = methods;
            }
        }
        [Test]
        public void Test1()
        {
            var methods = new List< PlugInMethod>();
            var asm=Assembly.GetAssembly(typeof(AyanoPluginCommonAPI.Tests.TestModelClass));
            {
                var clsTypes = asm.GetTypes();
                foreach(var clsType in clsTypes)
                {
                    var typeattrs = clsType.GetCustomAttributes(typeof(Attributes.AyanoNodeModelClassAttribute));
                    if (typeattrs == null || typeattrs.Count() == 0)
                    {
                        continue;
                    }
                    var names = new List<String>();
                    foreach(var typeattr in typeattrs)
                    {
                        var pluginClass = typeattr as Attributes.AyanoNodeModelClassAttribute;
                        if(pluginClass != null)
                        {
                            names.Add(pluginClass.Name);
                        }
                        methods.Add(new PlugInMethod(clsType, names));
                    }
                }
            }
            foreach(var m in methods)
            {
                Console.WriteLine(m.MethodNames);
            }
            Assert.Pass();
        }
    }
}