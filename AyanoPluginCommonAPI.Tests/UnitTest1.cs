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
        public static List<PlugInMethod> Get_PluginModel_Methods()
        {
            var methods = new List<PlugInMethod>();
            var asm = Assembly.GetAssembly(typeof(AyanoPluginCommonAPI.Tests.TestModelClass));
            {
                var clsTypes = asm.GetTypes();
                foreach (var clsType in clsTypes)
                {
                    var typeattrs = clsType.GetCustomAttributes(typeof(Attributes.AyanoNodeModelClassAttribute));
                    if (typeattrs == null || typeattrs.Count() == 0)
                    {
                        continue;
                    }
                    var names = new List<String>();
                    foreach (var typeattr in typeattrs)
                    {
                        var pluginClass = typeattr as Attributes.AyanoNodeModelClassAttribute;
                        if (pluginClass != null)
                        {
                            foreach (var m in clsType.GetMethods())
                            {
                                var tattrs = m.GetCustomAttributes(typeof(Attributes.AyanoNodeModelClassAttribute.InitializerAttribute));
                                if (tattrs == null || tattrs.Count() == 0) continue;
                                var names2 = new List<String>();
                                foreach (var tattr in tattrs)
                                {
                                    var pCls = tattr as Attributes.AyanoNodeModelClassAttribute.InitializerAttribute;
                                    if (pCls != null)
                                    {
                                        if (m.GetGenericArguments().Length != 0) continue;
                                        names.Add(m.Name);
                                    }
                                }
                            }
                        }
                        methods.Add(new PlugInMethod(clsType, names));
                    }
                }
            }
            return methods;

        }
        [Test]
        public void Test1()
        {
            Plugin.events.AyanoNodeModelInitializationEvent evkun = new Plugin.events.AyanoNodeModelInitializationEvent();
            evkun.ModelRegistered += (sender,evar)=>{
                Assert.That(evar.modeltype, Is.EqualTo(typeof(string)));
            };
            foreach(var met in Get_PluginModel_Methods())
            {

            }
            Console.WriteLine("TDN");
            Assert.Pass();
        }
    }
}