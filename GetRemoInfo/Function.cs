using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Lambda.Core;
using TimeZoneConverter;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace GetRemoInfo
{
    public class Function
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        public Response FunctionHandler(Request request, ILambdaContext context)
        {
            string format = "yyyyMMddHHmmss";
            CultureInfo ci = CultureInfo.CurrentCulture;
            DateTimeStyles dts = DateTimeStyles.None;

            // URLのクエリからマッピングされたパラメータが形式に則っているか確認
            DateTime from;
            if (!DateTime.TryParseExact(request.From, format, ci, dts, out from))
            {
                var response = new Response();
                response.ResultMessage = "Invalid Request";
                return response;
            }

            DateTime to;
            if (!DateTime.TryParseExact(request.To, format, ci, dts, out to))
            {
                var response = new Response();
                response.ResultMessage = "Invalid Request";
                return response;
            }

            return GetTemperatureRecords(from,to);
        }


        private Response GetTemperatureRecords(DateTime from, DateTime to)
        {
            var jstZoneInfo = TZConvert.GetTimeZoneInfo("Tokyo Standard Time");
            string fromStr = from.ToString("yyyy/MM/dd HH:mm:ss");
            string toStr = to.ToString("yyyy/MM/dd HH:mm:ss");
            //DynamoDBから取得
            DynamoDBContext context = new DynamoDBContext(client);
            List<ScanCondition> conditions = new List<ScanCondition>();
            var condition = new ScanCondition("DateTime", ScanOperator.Between, fromStr, toStr);
            conditions.Add(condition);
            var results = context.ScanAsync<RemoBatchData>(conditions).GetRemainingAsync().Result;
            //日付の昇順にソート
            var sortedResult = results.OrderBy(x => x.DateTime).ToList();

            var response = new Response();
            response.ResultMessage = "SUCCESS";
            response.RemoData = sortedResult;
            response.StartDateTime = sortedResult.First().DateTime;
            response.EndDateTime = sortedResult.Last().DateTime;
            response.AverageOutdoorTemperature = sortedResult.Average(x => x.OutdoorTemperature).ToString();
            response.AverageRoomTemperature = sortedResult.Average(x => x.RoomTemperature).ToString();

            return response;
        }
    }

}
