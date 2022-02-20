using System;
using System.Collections.Generic;
using System.Text;

namespace GetRemoInfo
{
    public class Response
    {
        //処理結果メッセージ
        public string ResultMessage { get; set; }
        //DynamoDBから取得したデータ
        public List<RemoBatchData> RemoData { get; set; }
        //データの開始日時
        public string StartDateTime { get; set; }
        //データの終了日時
        public string EndDateTime { get; set; }
        //取得したデータの室内気温の平均
        public string AverageRoomTemperature { get; set; }
        //取得したデータの外気温の平均
        public string AverageOutdoorTemperature { get; set; }

    }
}
