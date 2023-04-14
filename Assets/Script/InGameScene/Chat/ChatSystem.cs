using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChatSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent OnInit;
    [SerializeField] private UnityEvent OnStart;

    private List<Chat> chatData;

    private Chat currentChat;
    private Chat nextChat;

    private void Awake()
    {
        OnInit?.Invoke();
    }

    private void Update()
    {
        
    }

    private void StartProcess()
    {
        OnStart?.Invoke();
        
        ChangeInput();
        PrintChat();
    }
    
    // Chat System에서 Start Process가 진행이 된다면?
    // 카메라 Zoom In을 Event에 추가한다.
    // E, Mouse Left Click -> Next Chat
    // 조건에 맞게 Text를 출력한다.

    private void ChangeInput()
    {
        // Input Data를 변경한다.
    }

    private void PrintChat()
    {
        
    }

    private void NextChat()
    {
        if (nextChat is null)
        {
            return;
        } 
        
        // currentChat이 현재 진행중이라면, 모든 Chat을 다 보인다.
        // 그것이 아니라면, NextChat을 실행한다.
    }
}