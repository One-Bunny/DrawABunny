using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVToJson : MonoBehaviour
{
    public TextAsset csvFile;
    public List<TextAsset> csvFiles;

    private string csvToJsonFilePath;

    private void Start()
    {
        ConvertMultipleCSVToJson();
    }

    private void ConvertCSVToJson()
    {
        csvToJsonFilePath = Application.dataPath + "/Data/CSVToJsonData/" + csvFile.name + ".json";
        string[] csvData = csvFile.text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);

        // 키 값: CSV파일의 첫 줄
        string[] keys = csvData[0].Split(',');
        var records = new List<Dictionary<string, string>>();

        // 마지막 줄이 빈 줄인 경우 배열 크기 -1
        int rowCount = csvData.Length - (csvData[^1] == "" ? 1 : 0);

        for (int i = 1; i < rowCount; i++)
        {
            string[] values = csvData[i].Split(',');

            var record = new Dictionary<string, string>();

            for (int j = 0; j < keys.Length; j++)
            {
                record[keys[j]] = values[j];
            }

            records.Add(record);
        }

        string json = JsonConvert.SerializeObject(records, Formatting.Indented);

        File.WriteAllText(csvToJsonFilePath, json);
    }

    private void ConvertMultipleCSVToJson()
    {

        for (int i = 0; i < csvFiles.Count; i++)
        {
            csvToJsonFilePath = Application.dataPath + "/Data/CSVToJsonData/" + csvFiles[i].name + ".json";

            string[] csvData = csvFiles[i].text.Split(new[] { "\r\n", "\n" }, System.StringSplitOptions.None);
            string[] keys = csvData[0].Split(',');

            var records = new List<Dictionary<string, string>>();

            int rowCount = csvData.Length - (csvData[^1] == "" ? 1 : 0);

            for (int j = 1; j < rowCount; j++)
            {
                string[] values = csvData[j].Split(',');

                var record = new Dictionary<string, string>();

                for (int k = 0; k < keys.Length; k++)
                {
                    record[keys[k]] = values[k];
                }

                records.Add(record);
            }

            string json = JsonConvert.SerializeObject(records, Formatting.Indented);

            File.WriteAllText(csvToJsonFilePath, json);
        }
    }
}
