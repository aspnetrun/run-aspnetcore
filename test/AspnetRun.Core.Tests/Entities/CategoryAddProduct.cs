using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AspnetRun.Core.Tests.Entities
{
    public class CategoryAddProduct
    {
        private Guid _testProductId = Guid.NewGuid();   
        private Guid _testCategoryId = Guid.NewGuid();
        private string _testProductName = "Reason";
        private decimal _testUnitPrice = 1.23m;
        private short _testQuantity = 2;

        [Fact]
        public void AddsProductIfNotPresent()
        {
            var category = Category.Create(_testCategoryId, "newCategory");
            category.AddProduct(_testProductId, _testProductName);

            var firstItem = category.Products.Single();
            Assert.Equal(_testCategoryId, category.Id);
            Assert.Equal(_testProductId, firstItem.Id);
        }


    }
}
