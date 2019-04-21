using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AspnetRun.Core.Tests.Entities
{
    public class ProductTests
    {
        // USE CASE :  Add_ShoppingCartItem
        // USE CASE :  Add_ShoppingCartItem_Increment_Quantity
        // USE CASE :  Add_ShoppingCartItem_Increment_UnitPrice
        // USE CASE :  Add_2_ShoppingCartItem
        // USE CASE :  Update_ShoppingCartItem_Quantity
        // USE CASE :  Remove_ShoppingCartItem


        private int _testProductId = 2;
        private int _testCategoryId = 3;
        private string _testProductName = "Reason";
        private decimal _testUnitPrice = 1.23m;
        private short _testQuantity = 2;

        [Fact]
        public void Create_Product()
        {
            var product = Product.Create(_testProductId, _testCategoryId, _testProductName, _testUnitPrice, _testQuantity, null, null, false);

            Assert.Equal(_testProductId, product.Id);
            Assert.Equal(_testCategoryId, product.CategoryId);
            Assert.Equal(_testProductName, product.ProductName);
            Assert.Equal(_testUnitPrice, product.UnitPrice);
            Assert.Equal(_testQuantity, product.UnitsInStock);
        }



    }
}
