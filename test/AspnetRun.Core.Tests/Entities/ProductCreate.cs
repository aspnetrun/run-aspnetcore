using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AspnetRun.Core.Tests.Entities
{
    public class ProductCreate
    {
        private Guid _testProductId = Guid.NewGuid();
        private string _testProductName = "Reason";
        private decimal _testUnitPrice = 1.23m;
        private short _testQuantity = 2;

        [Fact]
        public void CreateProductIfNotPresent()
        {            
            var product = Product.Create(_testProductId, _testProductName, _testUnitPrice, _testQuantity, null, null, false);

            Assert.Equal(_testProductId, product.Id);
            Assert.Equal(_testProductName, product.ProductName);
            Assert.Equal(_testUnitPrice, product.UnitPrice);
            Assert.Equal(_testQuantity, product.UnitsInStock);
        }

    }
}
