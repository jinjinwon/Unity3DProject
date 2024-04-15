using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public Sprite GetSprite(string name)
    {
        // Sprite를 어디에 담고있는지에 따라 달라질 듯 합니다.
        // 1. 스프라이트 아틀라스
        // 2. 기본 스프라이트만 호출

        return null;
    }
}
