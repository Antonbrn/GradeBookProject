using System;
using Xunit;

namespace GradeBook.Test
{
    public class TypeTest
    {
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(5, x);
        }

        private int GetInt()
        {
            return 3;
        }

        private int SetInt(ref int z)
        {
            z = 5;
            return z;
        }



        [Fact]
        public void CsharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "new name");

            Assert.Equal("new name", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);

        }

        [Fact]
        public void CsharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "new name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            

        }


        [Fact]
        public void CanSetNameFromReference()
        { 
            var book1 = GetBook("Book 1");
            SetName(book1, "new name");

            Assert.Equal("new name", book1.Name);

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
            
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanRefSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
        }


        private InMemoryBook GetBook(string bookName)
        {
            return new InMemoryBook(bookName);
        }
    }
}
