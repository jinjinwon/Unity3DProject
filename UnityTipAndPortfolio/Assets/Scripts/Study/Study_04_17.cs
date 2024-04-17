using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Study_04_17 : MonoBehaviour
{
    // 알고리즘은 문제를 해결하는 능력이라고 한줄로 정의할 수 있다.
    // 프로그램의 가장 작은 단위는 일반적으로 입력 -> 처리 -> 출력의 과정을 거치는데 이 중에 처리의 단계를 알고리즘의 단계로 보면 된다.

    // 순서도는 알고리즘을 정해진 기호로 표시한 것

    // 이 정리는 알고리즘의 입문용으로 간단한 알고리즘을 정리할 것입니다.

    private SumAlgorithm sumAlgorithm;
    private ArithmmeticSequence arithmmeticSequence;

    private void Awake()
    {
        //sumAlgorithm = new SumAlgorithm();
        arithmmeticSequence = new ArithmmeticSequence();
    }

    private void Start()
    {
        if (sumAlgorithm != null) sumAlgorithm.Main();
        if (arithmmeticSequence != null) arithmmeticSequence.Main();
    }
}

public class SumAlgorithm
{
    /// 합계 알고리즘
    
    public void Main()
    {
        // [1] Input
        int[] scores = {100, 25, 39, 48, 88};

        // [2] Process
        int total = 0;

        // 내 풀이
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] >= 80)
                total += scores[i];
        }

        // 강사 풀이 1  (Linq) 강사 추천은 이 풀이임 밑에 풀이는 사용자 실수로 오류가 발생하는 경우가 많다함
        total = scores.Where(s => s >= 80).Sum();

        // 강사 풀이 2 (전통적인 방식)
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] >= 80)
            {
                total += scores[i];
            }
        }


        // [3] Output
        string strExpain = $"{scores.Length} 명의 점수 중 80점 이상의 총점은 {total}";
        Debug.Log(strExpain);
        StudySingleton.Instance.OnShow(strExpain);
    }
}

public class ArithmmeticSequence
{
    // 등차수열 알고리즘 : 연속하는 두 수의 차이가 일정한 수열

    public void Main()
    {
        // [1] input
        var Sum = 0;

        // [2] process
        
        // 내 풀이
        for(int i = 1; i <= 20; i++)
        {
            if (i % 2 == 1)
                Sum += i;
        }

        // 강사 풀이
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 != 0)
            {
                Sum += i;
            }
        }

        // [3] output
        string strExpain = $"1부터 20까지의 정수 중 홀수의 합은 ? {Sum}";
        Debug.Log(strExpain);
        StudySingleton.Instance.OnShow(strExpain);
    }
}
