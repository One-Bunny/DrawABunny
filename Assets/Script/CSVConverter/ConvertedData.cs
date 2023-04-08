using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JsonData",menuName ="ScriptableObjects/JsonData",order =1)]
public class ConvertedData : ScriptableObject
{
    public List<ConvertedDataEntity> entities = new();
}
