using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetRemoInfo
{
    //DynamoDBのremo_batch_dataテーブルをマッピング
    [DynamoDBTable("remo_batch_data")]
    public class RemoBatchData
    {
        public string DateTime { get; set; }

        public int IsUsingAircon { get; set; }
        public double OutdoorTemperature { get; set; }
        public double RoomTemperature { get; set; }

        public string AirconMode { get; set; }
        public double AirconTemperature { get; set; }
       
    }
}
