using System;
using System.Collections.Generic;
using System.Text;
using Tests.Managers;
using Tests.TestData.Model;

namespace Tests.TestData
{
    public static class TestDataSource
    {
        public static IEnumerable<TestCaseData> GetTablesData()
        {
            var testData = TestDataManager.GetInstance().TestData.Tables;
            foreach (var data in testData)
            {
                yield return new TestCaseData(data).SetName($"Tables_{data.User.FirstName}_{data.User.LastName}");
            }
        }
    }
}