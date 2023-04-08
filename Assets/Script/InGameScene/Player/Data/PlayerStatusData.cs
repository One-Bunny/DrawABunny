using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatusData", menuName = "Scriptable Object/Player Status Data", order = int.MaxValue)]
public class PlayerStatusData : ScriptableObject
{
    public float moveSpeed;
    public float jumpPower;
}
