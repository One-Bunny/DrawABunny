using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CSVConverter : MonoBehaviour
{
    public List<TextAsset> csvFiles;
    private string _jsonFilePath;

    private List<string> _jsons = new();
    private List<string> _jsonNames = new();

    private void Start()
    {
        if (csvFiles.Count == 0)
        {
            return;
        }

        ConvertCSVToJson();
        JsonToScriptableObject();
    }

    private void ConvertCSVToJson()
    {
        for (int i = 0; i < csvFiles.Count; i++)
        {
            _jsonFilePath = Application.dataPath + "/Data/JsonData/" + csvFiles[i].name + ".json";
            _jsonNames.Add(csvFiles[i].name);
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
            _jsons.Add(json);

            File.WriteAllText(_jsonFilePath, json);
        }
    }

    private void JsonToScriptableObject()
    {

        for (int i = 0; i < _jsons.Count; i++)
        {
            string json = _jsons[i];
            JsonData jsonData = new JsonData();

            JArray jArray = JArray.Parse(json);

            for (int j=0; j<jArray.Count; j++)
            {
                JObject jObject = jArray[j] as JObject;
                JsonDataEntity jsonDataEntity = new();

                jsonDataEntity.index = (int)jObject["Index"];
                jsonDataEntity.name = jObject["Name"].ToString();
                jsonDataEntity.log = jObject["Log"].ToString();

                Debug.Log(jObject);

                jsonData.entities.Add(jsonDataEntity);
            }

            AssetDatabase.CreateAsset(jsonData, "Assets/Data/ConvertedData/"+_jsonNames[i]+".asset");
            AssetDatabase.SaveAssets();
        }
    }
}
