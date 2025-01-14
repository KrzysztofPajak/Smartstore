﻿using System;
using System.Threading.Tasks;
using Smartstore.Domain;

namespace Smartstore.Templating
{
    public class NullTemplateEngine : ITemplateEngine
    {
        private readonly static ITemplateEngine _instance = new NullTemplateEngine();

        public static ITemplateEngine Instance => _instance;

        public ITemplate Compile(string template)
        {
            return new NullTemplate(template);
        }

        public Task<string> RenderAsync(string source, object data, IFormatProvider formatProvider = null)
        {
            return Task.FromResult(source);
        }

        public ITestModel CreateTestModelFor(BaseEntity entity, string modelPrefix)
        {
            return new NullTestModel();
        }

        internal class NullTestModel : ITestModel
        {
            public string ModelName => "TestModel";
        }

        internal class NullTemplate : ITemplate
        {
            private readonly string _source;

            public NullTemplate(string source)
            {
                _source = source;
            }

            public string Source => _source;

            public Task<string> RenderAsync(object data, IFormatProvider formatProvider)
            {
                return Task.FromResult(_source);
            }
        }
    }
}
