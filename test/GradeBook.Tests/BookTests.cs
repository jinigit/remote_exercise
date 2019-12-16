using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //Arrange //arrange test data. expected test data
            var book = new Book("");
            book.AddGrade(89.5);
            book.AddGrade(90.1);
            book.AddGrade(77.3);
        
            //Act //act invoke test
            var result = book.GetStatistics();
           
            //Assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.1, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
         
        }
    }
}
