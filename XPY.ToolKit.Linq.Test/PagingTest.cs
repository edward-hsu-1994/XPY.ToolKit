using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using XPY.ToolKit;
using XPY.ToolKit.Linq.Paging;

namespace XPY.ToolKit.Linq.Test
{
    public class PagingTest
    {
        [Fact(DisplayName = "分頁測試")]
        public void PagingTestCase()
        {
            Assert.Equal(Enumerable.Range(1, 10), Enumerable.Range(1, 100).AsPaging().Result);

            var paging = Enumerable.Range(1, 100).AsPaging();
            paging.MovePage(1);

            Assert.Equal(Enumerable.Range(11, 10), paging.Result);
            paging.MoveToPage(3);

            Assert.Equal(Enumerable.Range(31, 10), paging.Result);
            paging.Reset();

            Assert.Equal(Enumerable.Range(1, 10), paging.Result);

            Assert.True(paging.HasNextPage);
            Assert.False(paging.HasPreviousPage);

            paging.MoveToPage(9);

            Assert.True(paging.HasPreviousPage);
            Assert.False(paging.HasNextPage);

            paging.Reset();

            Assert.Equal(Enumerable.Range(11, 10), paging.GetMovePage(1).Result);
            Assert.Equal(Enumerable.Range(91, 10), paging.GetMoveToPage(9).Result);
        }
    }
}
