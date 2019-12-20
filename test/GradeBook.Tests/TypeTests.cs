using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
         [Fact]
        public void Test1()
        {
            //Arrange //arrange test data. expected test data
            var book1 = GetBook("book1");
           
        
            //Act //act invoke test
            GetBookSetName(book1, "New Name");
           
            //Assert   
            Assert.Equal("book1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name){
            book = new InMemoryBook(name);
            book.Name = name;
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //Arrange //arrange test data. expected test data
            var book1 = GetBook("book1");
        
            //Act //act invoke test
            SetName(book1, "New Names");
           
            //Assert   
            Assert.Equal("New Names", book1.Name);
        }
        private void SetName(InMemoryBook book, string name){
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Arrange //arrange test data. expected test data
            var book1 = GetBook("book1");
            var book2 = GetBook("book2");
        
            //Act //act invoke test
           
           
            //Assert   
            Assert.Equal("book1", book1.Name);
            Assert.Equal("book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        InMemoryBook GetBook(string name){
            return new InMemoryBook(name);
        }


         [Fact]
        public void TwoVarsCanReferenceSameObjects()
        {
            //Arrange //arrange test data. expected test data
            var book1 = GetBook("book1");
            var book2 = book1;
        
            //Act //act invoke test
           
           
            //Assert   
            Assert.Equal("book1", book1.Name);
            Assert.Equal("book1", book2.Name);
            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }
    }
}
