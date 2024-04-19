using JJW_Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

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
    private AverageAlgorithm averageAlgorithm;
    private AverageCountAlgorithm averageCountAlgorithm;
    private ArraySumAverageAlgorithm arraySumAverageAlgorithm;
    private MaxAlgorithm maxAlgorithm;
    private MinAlgorithm minAlgorithm;
    private AverageExceptMaxAndMinAlgorithm averageExceptMaxAndMinAlgorithm;

    private void Awake()
    {
        sumAlgorithm = new SumAlgorithm();
        arithmmeticSequence = new ArithmmeticSequence();
        countAlgorithm = new CountAlgorithm();
        primeNumberAlgorithm = new PrimeNumberAlgorithm();
        primeNumberCountAlgorithm = new PrimeNumberCountAlgorithm();
        perfectNumberAlgorithm = new PerfectNumberAlgorithm();
        averageAlgorithm = new AverageAlgorithm();
        averageCountAlgorithm = new AverageCountAlgorithm();
        arraySumAverageAlgorithm = new ArraySumAverageAlgorithm();
        maxAlgorithm = new MaxAlgorithm();
        minAlgorithm = new MinAlgorithm();
        averageExceptMaxAndMinAlgorithm = new AverageExceptMaxAndMinAlgorithm();
    }

    private void Start()
    {
        sumAlgorithm?.Main(false);
        arithmmeticSequence?.Main(false);
        countAlgorithm?.Main(false);
        primeNumberAlgorithm?.Main(false);
        primeNumberCountAlgorithm?.Main(false);
        perfectNumberAlgorithm?.Main(false);
        averageAlgorithm?.Main(false);
        averageCountAlgorithm?.Main(false);
        arraySumAverageAlgorithm?.Main(false);
        maxAlgorithm?.Main(false);
        minAlgorithm?.Main(false);
        averageExceptMaxAndMinAlgorithm?.Main(true);
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
        if (play == false) return;

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

public class AverageAlgorithm : Algorithm
{
    // ��� �˰���

    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[] data = { 90, 65, 78, 50, 95};

        int cnt = 0;
        int total = 0;
        float average = 0;

        // [2] process

        // �� Ǯ��
        for(int i = 0; i < data.Length; i++)
        {
            if (80 <= data[i] && data[i] <= 95)
            {
                cnt++;
                total += data[i];
            }
        }

        average = (float)total / cnt;

        // ���� Ǯ�� 1 (Linq ���)
        var averageTemp = data.Where(d => d >= 80 && 95 >= d).Average();

        // ���� Ǯ�� 2 (Linq ��� X)
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] >= 80 && data[i] <= 95)
            {
                total += data[i];
                cnt++;
            }
        }

        double avg = total / (double)cnt;

        // [3] output
        string strExpain = $"80�� �̻� 95�� ������ ������ ����� {average}�̸� �л� ���� {cnt}�� �Դϴ�.";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        UnityEngine.Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class AverageCountAlgorithm : Algorithm
{
    // ��� �̻� ���� ���ϱ� �˰���
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[] data = { 91, 80, 88, 25, 75 };
        int sum = 0;
        int cnt = 0;
        double average = 0;

        // [2] process

        // �� Ǯ��
        for(int i = 0; i < data.Length; i++)
        {
            sum += data[i];
        }

        average = sum / (double)data.Length;

        for(int i = 0; i < data.Length; i++)
        {
            if(average <= data[i])
            {
                cnt++;
            }
        }

        // ���� Ǯ��
        var resultcount = 0;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i];
            cnt++;
        }

        if (sum != 0 && cnt != 0)
            average = sum / (double)data.Length;

        for (int i = 0; i < data.Length; i++)
        {
            if (average <= data[i])
            {
                resultcount++;
            }
        }

        // [3] output
        string strExpain = $"��ü 5���� �л��� ����� {average}�̸� ����� ���� �л��� ���� {cnt}�� �Դϴ�.";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class ArraySumAverageAlgorithm : Algorithm
{
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[,] score = new int[,] 
        {
            {90,100,0,0},
            {80,90,0,0},
            {100,80,0,0}
        };

        // [2] process

        // �� Ǯ�� (�и� ù �κп����� 2�� for�� ����϶��ؼ� ���µ� ���� �ٽ� Ʋ��� ���� �ٲ��;)
        int sum = 0;
        for(int i = 0; i < score.GetLength(0); i++)
        {
            sum = 0;
            for(int j = 0; j < score.GetLength(1); j++)
            {
                if(j < 2)
                {
                    sum += score[i,j];
                }
                else if (j == 2)
                {
                    score[i, j] = sum;
                }
                else
                {
                    score[i, j] = sum / 2;
                }
            }
        }

        // ���� Ǯ��
        for(int i = 0; i < 3; i++)
        {
            score[i,2] = score[i,0] + score[i,1];
            score[i, 3] = score[i, 2] / 2;
        }

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                Debug.Log($"{score[i, j],4}\n");
            }
        }

        // [3] output
        string strExpain = $"";

        for(int i = 0; i < score.GetLength(0); i++)
        {
            strExpain += $"{i + 1}��° �л��� �հ�� {score[i,2]} �̸� ����� {score[i,3]} �Դϴ�.\n";
        }
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class MaxAlgorithm : Algorithm
{
    // �ִ밪 �˰���
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] initialzie
        int maxValueMine = int.MinValue;

        // [2] input
        int[] numbers = { -2, -5, -3, -7, -1 };

        // [3] process
        // �� Ǯ��
        for(int i = 0; i < numbers.Length; i++)
        {
            if (maxValueMine < numbers[i])
            {
                maxValueMine = numbers[i];
            }
        }

        // ���� Ǯ�� 1 (Linq ���)
        int maxValue = numbers.Max();

        // ���� Ǯ�� 2 (Linq �̻��)
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > maxValueMine)
            {
                maxValueMine = numbers[i];
            }
        }

        // [4] output
        string strExpain = $"���� ū ���� {maxValueMine} �Դϴ�.";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class MinAlgorithm : Algorithm
{
    // �ּҰ� �˰���
    public override void Main(bool play)
    {
       if(play == false) return;

        // [1] initialzie
        int minValueMine = int.MaxValue;

        // [2] input
        int[] numbers = { -2, -5, -3, -7, -1 };

        // [3] process
        // �� Ǯ��
        for (int i = 0; i < numbers.Length; i++)
        {
            if (minValueMine > numbers[i])
            {
                minValueMine = numbers[i];
            }
        }

        // ���� Ǯ�� 1 (Linq ���)
        int maxValue = numbers.Min();

        // ���� Ǯ�� 2 (Linq �̻��)
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < minValueMine)
            {
                minValueMine = numbers[i];
            }
        }

        // [4] output
        string strExpain = $"���� ���� �ּҰ��� {minValueMine} �Դϴ�.";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class AverageExceptMaxAndMinAlgorithm : Algorithm
{
    // �ִ밪�� �ּҰ��� ������ ��հ� ���ϱ�
    public override void Main(bool play)
    {
        if(!play) return;

        // [1] initialzie
        int maxvalue = int.MinValue;
        int minvalue = int.MaxValue;

        // [2] input
        int[] scores = { 10, 20, 30, 40, 50 };
        var sum = 0;
        double average;
        var cnt = 0;

        // [3] process
        // �� Ǯ��
        maxvalue = scores.Max();
        minvalue = scores.Min();

        for(int i = 0; i < scores.Length; i++)
        {
            if (scores[i] == maxvalue || scores[i] == minvalue)
            {
                continue;
            }
            else
            {
                sum += scores[i];
                cnt++;
            }
        }

        average = sum / (double)cnt;

        // ���� Ǯ��
        var max = Int32.MinValue;
        var min = Int32.MaxValue;
        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
            if (scores[i] > max)
            {
                max = scores[i];
            }
            if (scores[i] < min)
            {
                min = scores[i];
            }
        }

        average = (sum - max - min) / (double)(scores.Length - 2);

        // [4] output
        string strExapin = $"�ִ밪�� {maxvalue} �̸� �ּҰ��� {minvalue} �Դϴ�. �̸� ������ ����� ������ {average} �Դϴ�.";
        OnShow(strExapin);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}
