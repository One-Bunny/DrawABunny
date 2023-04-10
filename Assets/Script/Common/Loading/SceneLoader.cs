using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions.Must;

namespace OneBunny
{
    public class SceneLoader : MonoBehaviour, IProgress<float>
    {
        private void Awake()
        {
            LoadScene(1);
        }

        public void LoadScene(int id)
        {
            gameObject.SetActive(false);
            LoadAsyncScene(id).Forget();
        }

        public void Report(float value)
        {
            // value를 통해서 progress data를 가져옴
        }

        private async UniTaskVoid LoadAsyncScene(int id)
        {
            await SceneManager.LoadSceneAsync(id, LoadSceneMode.Single).ToUniTask(progress: this);
        }
    }

}