using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace OneBunny
{
    [Serializable]
    internal struct PoolData
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public GameObject CopyObject { get; set; }
        [field: SerializeField] public int Size { get; set; }
        [field: SerializeField] public Transform Container { get; set; }
    }

    public class ObjectPoolManager : MonoBehaviour
    {
        // ObjectPool을 사용할 오브젝트를 보관하는 곳.
        [SerializeField] private List<PoolData> _poolDataList;

        private Dictionary<string, List<GameObject>> _objectPoolDic;
        
        private void Awake()
        {
            _objectPoolDic = new Dictionary<string, List<GameObject>>();
            
            if (_poolDataList.Count <= 0)
            {
                PoolLog("Pool List에 아무것도 존재하지 않습니다.");
                throw new Exception("No Prefab");
            }

            SetUp();
        }

        #region StaticField
        
        // obj 오브젝트를 Pool에 추가한다.
        public static void ReturnToPool(string objName)
        {
            // objName에서 분리
            var splitData = objName.Split(" ");
            var key = splitData[0];
            var index = Int32.Parse(splitData[1]);
            
            var isHave = Singleton.Instance.poolManager.HaveKeyCheck(key);

            if (!isHave)
            {
                return;
            }

            // Key가 존재할 경우.
            var pool = Singleton.Instance.poolManager._objectPoolDic[key];
            pool[index - 1].SetActive(false);
        }

        public static GameObject Get(string key)
        {
            return Singleton.Instance.poolManager.SpawnToPool(key);
        }
        

        private static void PoolLog(string text)
        {
            Debug.Log($"[Object Pool Manager] {text}");
        }

        #endregion
        
        #region NotStaticField
        
        public GameObject SpawnToPool(string key)
        {
            var poolObjList = Singleton.Instance.poolManager._poolDataList;
            var poolDic = Singleton.Instance.poolManager._objectPoolDic;
            GameObject obj;
            
            if (!HaveKeyCheck(key))
            {
                PoolLog($"Spawn을 할 수 없습니다.");
            }
            
            // 현재까지 왔다는 것은 해당 key가 있다는 것임.
            
            // key에 해당하는 Pool과 Copy Prefab을 가져옴.
            var keyObj = poolObjList.Find(x => x.Name == key);
            var pool = poolDic[key];

            // 정해둔 Size를 Pool이 초과하지 않았다면. -> Update에서 쓰일 수 있으므로 방어적 프로그래밍.
            if (keyObj.Size >= pool.Count)
            {
                obj = CreateObject(keyObj.Container, keyObj.CopyObject);

                pool.Add(obj);
                obj.name = String.Concat($"{keyObj.Name} ", pool.Count.ToString());
            }
            else
            {
                PoolLog("Pool Size가 정해둔 Size를 초과합니다.");
                throw new Exception("Pool Size Over");
            }

            return obj;
        }

        private GameObject CreateObject(Transform parent, GameObject prefabObj)
        {
            var obj = Instantiate(prefabObj, parent);
            obj.SetActive(false);
            
            return obj;
        }
        
        public bool HaveKeyCheck(string key)
        {
            var poolObjList = Singleton.Instance.poolManager._poolDataList;
            // 매개로 전달 받은 Key가 있는 지 확인.
            foreach (var poolObj in poolObjList)
            {
                if (poolObj.Name.Contains(key))
                {
                    return true;
                }
            }
            PoolLog($"전달받은 Key인 {key}가 존재하지 않습니다.");
            throw new Exception("No Key");
        }

        public void SetUp()
        {
            if (_poolDataList.Count > 0)
            {
                foreach (var poolData in _poolDataList)
                {
                    _objectPoolDic.Add(poolData.Name, new List<GameObject>());
                }
            }
        }
        
        #endregion
    }
}