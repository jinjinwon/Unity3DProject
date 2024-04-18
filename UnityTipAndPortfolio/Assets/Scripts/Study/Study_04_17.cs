using JJW_Utils;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Algorithm
{
    public abstract void Main(bool play);
    public abstract void OnShow(string str);
}

public class Study_04_17 : MonoBehaviour
{
    // �˰����� ������ �ذ��ϴ� �ɷ��̶�� ���ٷ� ������ �� �ִ�.
    // ���α׷��� ���� ���� ������ �Ϲ������� �Է� -> ó�� -> ����� ������ ��ġ�µ� �� �߿� ó���� �ܰ踦 �˰����� �ܰ�� ���� �ȴ�.

    // �������� �˰����� ������ ��ȣ�� ǥ���� ��

    // �� ������ �˰����� �Թ������� ������ �˰����� ������ ���Դϴ�.

    private SumAlgorithm sumAlgorithm;
    private ArithmmeticSequence arithmmeticSequence;
    private CountAlgorithm countAlgorithm;
    private PrimeNumberAlgorithm primeNumberAlgorithm;
    private PrimeNumberCountAlgorithm primeNumberCountAlgorithm;
    private PerfectNumberAlgorithm perfectNumberAlgorithm;

    private void Awake()
    {
        sumAlgorithm = new SumAlgorithm();
        arithmmeticSequence = new ArithmmeticSequence();
        countAlgorithm = new CountAlgorithm();
        primeNumberAlgorithm = new PrimeNumberAlgorithm();
        primeNumberCountAlgorithm = new PrimeNumberCountAlgorithm();
        perfectNumberAlgorithm = new PerfectNumberAlgorithm();
    }

    private void Start()
    {
        sumAlgorithm?.Main(false);
        arithmmeticSequence?.Main(false);
        countAlgorithm?.Main(false);
        primeNumberAlgorithm?.Main(false);
        primeNumberCountAlgorithm?.Main(false);
        perfectNumberAlgorithm?.Main(true);
    }
}

public class SumAlgorithm : Algorithm
{
    /// �հ� �˰��� 
    public override void Main(bool play)
    {
        if (play == false)
            return;

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
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        UnityEngine.Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class ArithmmeticSequence : Algorithm
{
    // �������� �˰��� : �����ϴ� �� ���� ���̰� ������ ����

    public override void Main(bool play)
    {
        if (play == false)
            return;

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
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        UnityEngine.Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class CountAlgorithm : Algorithm
{
    // ���� �˰���
    public override void Main(bool play)
    {
        if (play == false)
            return;

        // [1] input
        int icount = 0;

        // [2] process

        // �� Ǯ��
        for(int i = 1; i <= 1000; i++)
        {
            if (i % 13 == 0)
                icount++;
        }

        // _ -> ���п����� ����
        // 1_000 = 1000 1000 = 1000 1____000 = 1000 ��� �Ȱ���

        // ���� Ǯ�� 1 (Linq ��� Where ���)
        var numbers = Enumerable.Range(1, 1_000).ToArray().Where(n => n % 13 == 0).Count();     // 1���� 1~1000���� �迭�� ����

        // ���� Ǯ�� 2 (Linq ��� Where �̻��)
        var numbers2 = Enumerable.Range(1, 1_000).ToArray().Count(n => n % 13 == 0);

        // ���� Ǯ�� 3 (Linq �̻��)
        var numbers3 = Enumerable.Range(1, 1_000).ToArray();

        for(int i = numbers3.Min(); i < numbers3.Max(); i++)
        {
            if (numbers3[i] % 13 == 0)
            {
                icount++;
            }
        }

        // [3] output
        string strExpain = $"1���� 1000������ ���� �� 13�� ����� ������ ? {icount}";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        UnityEngine.Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class PrimeNumberAlgorithm : Algorithm
{
    // �Ҽ� �˰���
    public override void Main(bool play)
    {
        if (play == false) 
            return;

        // [1] input 2 3 5 7 11 13 17 19 23 29 ...
        int input = 2;
        bool result = false;

        // [2] process

        // �� Ǯ�� (����� ���)
        result = Prime(input);

        // ���� Ǯ��(2���� n���� ������ �������� ���� �߻��� ������ �ݺ�)
        var i = 1;
        do
        {
            i++;
        }
        while (input % i != 0);

        if (input == i)
            result = true;
        else
            result = false;

        // [3] output
        string strexpain2 = result == true ? "�½��ϴ�." : "�ƴմϴ�.";
        string streExpain = $"�Է��� ������ {input}�� �Ҽ��� {strexpain2}";
        OnShow(streExpain);
    }

    private bool Prime(int input)
    {
        if (input == 1)
            return false;

        for (int q = 2; q * q <= input; q++)
        {
            if (input % q == 0)
            {
                return false;
            }
        }
        return true;
    }

    public override void OnShow(string str)
    {
        UnityEngine.Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class PrimeNumberCountAlgorithm : Algorithm
{
    // �Ҽ��� ������ ���ϴ� �˰���
    public override void Main(bool play)
    {
        if(play == false) return;

        // [1] input
        int input = 100;
        List<int> list_primeNumber = new List<int>();

        // ���� input
        var count = 0;  // �Ҽ� ����
        var sw = true;  // �Ҽ������� Ȯ���ϴ� ����ġ ����

        // [2] process

        // �� Ǯ��
        list_primeNumber = PrimeList(input);

        // ���� Ǯ��
        for (int i = 2; i < input; i++)
        {
            sw = true; // �ϴ��� ��� �ݺ����� �Ҽ��� ���� ����

            // 2���� �����(i) - 1 ���� �������� �� ������ �������� �Ҽ��� �ƴϴ�.
            for (int j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    sw = false;
                    break;
                }
            }

            if (sw == true)
            {
                list_primeNumber.Add(i);
                count++;
            }
        }

        // [3] output
        string strExpain = "";

        for(int p = 0; p < list_primeNumber.Count; p++)
        {
            strExpain += list_primeNumber[p] + ",";
        }
        OnShow(strExpain);
    }

    private List<int> PrimeList(int input)
    {
        List<int> list_primenumber = new List<int>();

        for(int i = 1; i <= input; i++)
        {
            if(Prime(i) == true)
            {
                list_primenumber.Add(i);
            }
        }
        return list_primenumber;
    }

    private bool Prime(int input)
    {
        if (input == 1)
            return false;

        for (int q = 2; q * q <= input; q++)
        {
            if (input % q == 0)
            {
                return false;
            }
        }
        return true;
    }

    public override void OnShow(string str)
    {
        UnityEngine.Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class PerfectNumberAlgorithm : Algorithm
{
    // ������ �˰���
    public override void Main(bool play)
    {
        // [1] input
        int sum = 0; // ����� �հ�
        int cnt = 0; // �������� ����
        int max = 0; // ������ �� ���� ū �� (���� ū ���)
        int rem = 0; // ������ �� �ӽ� ����

        // [2] process

        // �� Ǯ��
        for(int i = 1; i <= 10000; i++)
        {
            sum = 0;

            // ���� �ʰ��� ���� ����� �� �� ���� ����;
            for (int j = 1; j <= i / 2; j++)
            {
                if (i % j == 0)
                {
                    sum+=j;
                }
            }

            // �������� �Ƿ��� ����� j�� ���� ���� ���� ��쿡 ���� ���ƾ� �� ����;
            if(i == sum)
            {
                cnt++;

                if(max < i)
                    max = i;
            }           
        }

        // ���� Ǯ��
        for (int q = 1; q < 10000; q++)
        {
            sum = 0;     // �� �ݺ����� �ʱ�ȭ
            max = q / 2; // ��� ¦���� 2�� ������ ���� ū ���

            for (int w = 1; w <= max; w++)
            {
                rem = q - (q / w) * w; // ���� �� / ���
                if(rem == 0)
                {
                    sum += w; // ����� �հ�
                }
            }

            if(q == sum) // �ڽ� == ����� �հ� (������)
            {
                cnt++;
            }
        }

        // [3] output (���� Ǯ�̷��ϸ� ���� ū ���� 4999�� ���� ���� ���ߴ°� ��� ��� ���ٰ� ������ ���� �����ش�)
        string strExpain = $"�������� ������ {cnt} \n ������ �� ���� ū ���� {max}";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        UnityEngine.Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}
