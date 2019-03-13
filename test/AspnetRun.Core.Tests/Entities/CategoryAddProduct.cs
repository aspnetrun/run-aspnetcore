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
        private int _testProductId = 3;   
        private int _testCategoryId = 5;
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
