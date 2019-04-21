using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.Tests.Builders
{
    public class CategoryBuilder
    {
        private Category _category;
        public int TestCategoryId => 123;
        public string TestCategoryName => "CategoryX";

        public CategoryBuilder()
        {
            _category = WithDefaultValues();
        }

        public Category WithDefaultValues()
        {
            return Category.Create(TestCategoryId, TestCategoryName);
        }
    }
}
