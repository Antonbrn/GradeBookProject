﻿using System;
using Xunit;

namespace GradeBook.Test
{
    public class BookTest
    {
        [Fact]
        public void test1()
        {
            Book book = new Book("");

            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            var result = book.GetStatistics();

            Assert.Equal(85.6, result.Average, 1 );
            Assert.Equal(90.5, result.High,1);
            Assert.Equal(77.3, result.Low,1);
            
        }
    }
}
