using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace GetRemoInfo
{
    public class Response
    {
        //処理結果メッセージ
        [JsonPropertyName("result_message")]
        public string ResultMessage { get; set; }
        //DynamoDBから取得したデータ
        [JsonPropertyName("remo_data")]
        public List<RemoBatchData> RemoData { get; set; }
        //データの開始日時
        [JsonPropertyName("start_date_time")]
        public string StartDateTime { get; set; }
        //データの終了日時
        [JsonPropertyName("end_date_time")]
        public string EndDateTime { get; set; }
        //取得したデータの室内気温の平均
        [JsonPropertyName("average_room_temperature")]
        public string AverageRoomTemperature { get; set; }
        //取得したデータの外気温の平均
        [JsonPropertyName("average_outdoor_temperature")]
        public string AverageOutdoorTemperature { get; set; }

    }
}
