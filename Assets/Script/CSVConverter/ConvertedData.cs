using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConvertedData",menuName ="ScriptableObjects/ConvertData",order =1)]
public class ConvertedData : ScriptableObject
{
    public List<ConvertedDataEntity> entities = new();
}
