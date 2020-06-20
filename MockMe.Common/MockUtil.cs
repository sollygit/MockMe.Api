using Bogus;
using MockMe.Model;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MockMe.Common
{
    public static class MockUtil
    {
        public static List<Product> Products(int count)
        {
            var products = new Faker<Product>()
                .RuleFor(o => o.Id, f => f.IndexFaker + 1)
                .RuleFor(o => o.Name, f => f.Name.FullName())
                .RuleFor(o => o.Description, f => f.Random.Words(5))
                .RuleFor(o => o.Price, f => decimal.Parse(f.Random.Decimal(1000).ToString("0.00")))
                .RuleFor(o => o.ImageUrl, f => f.Image.PicsumUrl())
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10000))
                .Generate(count);
            return products;
        }
    }
}
