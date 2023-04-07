using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JsonData",menuName ="ScriptableObjects/JsonData",order =1)]
public class JsonData : ScriptableObject
{
    public List<JsonDataEntity> entities = new();
}
