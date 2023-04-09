using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CSVConverter : EditorWindow
{

    public List<TextAsset> csvFiles;
    private string _filePath;

    private List<string> _jsons = new();

    private SerializedObject so;

    [MenuItem("Window/CSVConverter")]
    public static void Open()
    {
        GetWindow<CSVConverter>().titleContent = new GUIContent("CSVConverter");
    }

    private void OnEnable()
    {
        ScriptableObject target = this;
        so = new(target);
    }

    private void OnGUI()
    {
        GUILayout.Label("---------------------------------\n\n" +
            "Press Button [Convert] to Convert CSV files to Scriptable Object."
            +"\n\n--------------------------------\n");

        so.Update();
        SerializedProperty sp = so.FindProperty("csvFiles");

        EditorGUILayout.PropertyField(sp, true);
        so.ApplyModifiedProperties();

        if (GUILayout.Button("Convert"))
        {
            if (csvFiles.Count == 0)
            {
                return;
            }

            ConvertCSVToJson();
            JsonToScriptableObject();
        }
    }

    private void ConvertCSVToJson()
    {
        for (int i = 0; i < csvFiles.Count; i++)
        {           
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
        }
    }

    private void JsonToScriptableObject()
    {

        for (int i = 0; i < _jsons.Count; i++)
        {
            string json = _jsons[i];
            ConvertedData convertedData = new ConvertedData();

            JArray jArray = JArray.Parse(json);

            for (int j=0; j<jArray.Count; j++)
            {
                JObject jObject = jArray[j] as JObject;
                ConvertedDataEntity convertedDataEntity = new();

                convertedDataEntity.index = (int)jObject["Index"];
                convertedDataEntity.name = jObject["Name"].ToString();
                convertedDataEntity.log = jObject["Log"].ToString();

                Debug.Log(jObject);

                convertedData.entities.Add(convertedDataEntity);
            }

            _filePath = "Assets/Data/ConvertedData/" + csvFiles[i].name + ".asset";

            AssetDatabase.CreateAsset(convertedData, _filePath);
            AssetDatabase.SaveAssets();
        }
    }
}
