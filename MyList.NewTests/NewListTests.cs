using System;
using Xunit;

namespace MyList.Tests
{
    public class NewListTests
    {

        [Fact]
        public void Add_AddsItemToTheList()
        {
            NewList<int> list = new NewList<int> { 5 };
            var result = list.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void Add_NoItemtoTheList()
        {
            NewList<int> list = new NewList<int>();
            var result = list.Count;
            Assert.Equal(0, result);
        }

        [Fact]
        public void Add_AddingOverCapacityExdensArray()
        {
            NewList<int> list = new NewList<int> { };
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            var result = list.NewArray.Length;
            Assert.Equal(8, result);
        }

        [Fact]
        public void Add_AddsStringToTheList()
        {
            NewList<string> list = new NewList<string> { "du" };
            var result = list.Count;
            Assert.Equal(1, result);
        }

        [Fact]
        public void GetEnumerator_CheckReturnedValues()
        {
            NewList<int> list = new NewList<int>
            {
                67,
                5
            };
            var enumerator = list.GetEnumerator();
            enumerator.MoveNext();
            Assert.Equal(67, enumerator.Current);
            enumerator.MoveNext();
            Assert.Equal(5, enumerator.Current);
            Assert.False(enumerator.MoveNext());

        }

        [Fact]
        public void Contains_ReturnTrueIfItemExistsInArray()
        {
            NewList<int> list = new NewList<int> { 1, 2 };
            var result = list.Contains(1);
            Assert.True(result);
        }

        [Fact]
        public void Contains_ReturnFalseIfNoEmelentInArray()
        {
            NewList<int> list = new NewList<int>();
            var result = list.Contains(0);
            Assert.False(result);
        }

        [Fact]
        public void Remove_ItemDeletionAtTheBeginningDoesNotDisturbArraySequence()
        {
            NewList<int> list = new NewList<int> { 1, 2, 3};
            var result = list.Remove(1);
            NewList<int> secondList = new NewList<int> { 2, 3};
            Assert.Equal(secondList, list);
            Assert.True(result);
        }

        [Fact]
        public void Remove_ItemDeletionInTheMiddleDoesNotDisturbArraySequence()
        {
            NewList<int> list = new NewList<int> { 1, 2, 3 };
            var result = list.Remove(2);
            NewList<int> secondList = new NewList<int> { 1, 3 };
            Assert.Equal(secondList, list);
            Assert.True(result);
        }

        [Fact]
        public void Remove_ItemDeletionAtTheEndDoesNotDisturbArraySequence() 
        {
            NewList<int> list = new NewList<int> { 1, 2, 3, 4, 5};
            var result = list.Remove(5);
            NewList<int> secondList = new NewList<int> { 1, 2, 3, 4};
            Assert.Equal(secondList,list);
            Assert.True(result);
        }

        [Fact]
        public void Remove_NoExistingItemToRemove() 
        {
            NewList<string> list = new NewList<string> { "vienas", "vienuolika" };
            var result1 = list.Count;
           var result =  list.Remove("vie");
            var result2 = list.Count;
            Assert.Equal(result1,result2);
            Assert.False(result);
        }

        [Fact]
        public void RemoveAt_ItemDeletionAtTheBeginningDoesNotDisturbArraySequence() 
        {
            NewList<int> list = new NewList<int> { 1, 2, 3, 4};
            list.RemoveAt(0);
            NewList<int> secondList = new NewList<int> { 2, 3, 4 };
            Assert.Equal(secondList,list);
        }

        [Fact]
        public void RemoveAt_ItemDeletionInTheMiddleDoesNotDisturbArraySequence() 
        {
            NewList<int> list = new NewList<int> { 1, 2, 3, 4, 5 };
            list.RemoveAt(2);
            NewList<int> secondList = new NewList<int> { 1, 2, 4, 5 };
            Assert.Equal(secondList,list);
        }

        [Fact]
        public void RemoveAt_ItemDeletionAtTheEndDoesNotDisturbArraySequence() 
        {
            NewList<int> list = new NewList<int> { 1, 2, 3, 4, 5 };
            list.RemoveAt(4);
            NewList<int> secondList = new NewList<int> { 1, 2, 3, 4 };
            Assert.Equal(secondList,list);
        }

        [Fact]
        public void IndexOf_FindsIndexOfItem() 
        {
            NewList<int> list = new NewList<int> { 1, 2, 3 };
            var result = list.IndexOf(2);
            Assert.Equal(1,result);
        }

        [Fact]
        public void IndexOf_ReturnsNegativeOne() 
        {
            NewList<int> list = new NewList<int> { 21, 3 };
            var result = list.IndexOf(1);
            Assert.Equal(-1,result);
        }

        [Fact]
        public void Insert_ItemInsertionInTheMiddleDoesNotChangeSequenceOfArray() 
        {
            NewList<int> list = new NewList<int> { 10, 20, 40 };
            NewList<int> secondList = new NewList<int> { 10, 50, 20, 40 };
            list.Insert(2,50);
            Assert.Equal(secondList,list);
        }

        [Fact]
        public void Insert_ItemInsertionAtBeginningDoesNotChangeSequenceOfArray() 
        {
            NewList<int> list = new NewList<int> { 1, 2, 3 };
            NewList<int> secondList = new NewList<int> { 5, 1, 2, 3 };
            list.Insert(1,5);
            Assert.Equal(secondList,list);
        }

        [Fact]
        public void Insert_ItemInsertionAtTheEndDoesNotChangesSequenceOfArray() 
        {
            NewList<int> list = new NewList<int> { 1, 2, 3 };
            NewList<int> secondList = new NewList<int> { 1, 2, 3, 4 };
            list.Insert(4,4);
            Assert.Equal(secondList, list);
        }

        [Fact]
        public void CopyTo_ListElementsAreInsertedAtTheEnd() 
        {
            NewList<int> list = new NewList<int> { 10, 20, 30, 40, 50, 60, 70 };
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            list.CopyTo(array,2);
            int[] secondArray = new int[] { 1, 2, 10, 20, 30, 40, 50, 60, 70, 10 };
            Assert.Equal(secondArray, array);
        }

        [Fact]
        public void CopyTo_ListElementsAreInsertedAtTheBeginning()
        {
            NewList<int> list = new NewList<int> { 10, 20, 30, 40 };
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            list.CopyTo(array, 0);
            int[] secondArray = new int[] { 10, 20, 30, 40, 5 };
            Assert.Equal(secondArray, array);
        }

        [Fact]
        public void CopyTo_IfArrayLengthTooSmallThrowException() 
        {
            NewList<int> list = new NewList<int> { 10, 20, 30, 40 };
            int[] array = new int[] { 1, 2, 3, 4 };
            Assert.Throws<ArgumentOutOfRangeException>(()=> list.CopyTo(array,1));
        }
    }
}
