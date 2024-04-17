using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Study_04_17 : MonoBehaviour
{
    // �˰����� ������ �ذ��ϴ� �ɷ��̶�� ���ٷ� ������ �� �ִ�.
    // ���α׷��� ���� ���� ������ �Ϲ������� �Է� -> ó�� -> ����� ������ ��ġ�µ� �� �߿� ó���� �ܰ踦 �˰����� �ܰ�� ���� �ȴ�.

    // �������� �˰����� ������ ��ȣ�� ǥ���� ��

    // �� ������ �˰����� �Թ������� ������ �˰����� ������ ���Դϴ�.

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
    /// �հ� �˰���
    
    public void Main()
    {
        // [1] Input
        int[] scores = {100, 25, 39, 48, 88};

        // [2] Process
        int total = 0;

        // �� Ǯ��
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] >= 80)
                total += scores[i];
        }

        // ���� Ǯ�� 1  (Linq) ���� ��õ�� �� Ǯ���� �ؿ� Ǯ�̴� ����� �Ǽ��� ������ �߻��ϴ� ��찡 ������
        total = scores.Where(s => s >= 80).Sum();

        // ���� Ǯ�� 2 (�������� ���)
        for (int i = 0; i < scores.Length; i++)
        {
            if (scores[i] >= 80)
            {
                total += scores[i];
            }
        }


        // [3] Output
        string strExpain = $"{scores.Length} ���� ���� �� 80�� �̻��� ������ {total}";
        Debug.Log(strExpain);
        StudySingleton.Instance.OnShow(strExpain);
    }
}

public class ArithmmeticSequence
{
    // �������� �˰��� : �����ϴ� �� ���� ���̰� ������ ����

    public void Main()
    {
        // [1] input
        var Sum = 0;

        // [2] process
        
        // �� Ǯ��
        for(int i = 1; i <= 20; i++)
        {
            if (i % 2 == 1)
                Sum += i;
        }

        // ���� Ǯ��
        for (int i = 1; i <= 20; i++)
        {
            if (i % 2 != 0)
            {
                Sum += i;
            }
        }

        // [3] output
        string strExpain = $"1���� 20������ ���� �� Ȧ���� ���� ? {Sum}";
        Debug.Log(strExpain);
        StudySingleton.Instance.OnShow(strExpain);
    }
}
