using ConsoleAppFramework;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Utf8Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ConsoleAppFrameworkSample
{
    public class ParamTestApp : ConsoleAppBase
    {
        private ILogger<ParamTestApp> Logger { get; }

        public ParamTestApp(ILogger<ParamTestApp> _logger)
        {
            Logger = _logger;
        }

        [Command("bool")]
        public void BoolParam([Option("x", "説明")]bool x)
        {
            Console.WriteLine(x.ToString());
            Environment.ExitCode = 0;
        }

        public enum MyEnum
        {
            Enum1,
            Enum2
        }

        [Command("enum")]
        public void EnumParam([Option("x", "説明")]MyEnum x)
        {
            Console.WriteLine(Enum.GetName(typeof(MyEnum), x));
            Environment.ExitCode = 0;
        }

        [Command("listString")]
        public void ListStringParam([Option("x", "説明")]List<string> x)
        {
            x.ForEach(item => Console.WriteLine(item));
            Environment.ExitCode = 0;
        }

        [Command("listDouble")]
        public void ListDoubleParam([Option("x", "説明")]List<double> x)
        {
            x.ForEach(item => Console.WriteLine(item));
            Environment.ExitCode = 0;
        }

        [Command("listInt")]
        public void ListIntParam([Option("x", "説明")]List<int> x)
        {
            x.ForEach(item => Console.WriteLine(item));
            Environment.ExitCode = 0;
        }

        public class FooBar
        {
            public int foo { get; set; }

            public string bar { get; set; }
        }

        [Command("myClass")]
        public void MyClassParam([Option("x", "説明")]FooBar x)
        {
            Console.WriteLine(x.foo.ToString());
            Console.WriteLine(x.bar.ToString());
            Environment.ExitCode = 0;
        }

        public class FooBarBaz
        {
            [JsonPropertyName("foobar")]
            public FooBar FooBarProperty { get; set; }

            [JsonPropertyName("baz")]
            public string BazProperty { get; set; }
        }

         [Command("myClass2")]
       public void MyClassParam2([Option("x", "説明")]FooBarBaz x)
        {
            Console.WriteLine(x.FooBarProperty.foo);
            Console.WriteLine(x.FooBarProperty.bar);
            Console.WriteLine(x.BazProperty);
            Environment.ExitCode = 0;
        }
    }
}