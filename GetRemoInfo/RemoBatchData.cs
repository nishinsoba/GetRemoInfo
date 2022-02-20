using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GetRemoInfo
{
    //DynamoDBのremo_batch_dataテーブルをマッピング
    [DynamoDBTable("remo_batch_data")]
    public class RemoBatchData
    {
        [JsonPropertyName("datetime")]
        public string DateTime { get; set; }
        [JsonPropertyName("is_using_aircon")]
        public int IsUsingAircon { get; set; }
        [JsonPropertyName("outdoor_temperature")]
        public double OutdoorTemperature { get; set; }
        [JsonPropertyName("room_temperature")]
        public double RoomTemperature { get; set; }
        [JsonPropertyName("aircon_mode")]
        public string AirconMode { get; set; }
        [JsonPropertyName("aircon_temperature")]
        public double AirconTemperature { get; set; }
       
    }
}
