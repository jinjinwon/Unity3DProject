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
    // 알고리즘은 문제를 해결하는 능력이라고 한줄로 정의할 수 있다.
    // 프로그램의 가장 작은 단위는 일반적으로 입력 -> 처리 -> 출력의 과정을 거치는데 이 중에 처리의 단계를 알고리즘의 단계로 보면 된다.

    // 순서도는 알고리즘을 정해진 기호로 표시한 것

    // 이 정리는 알고리즘의 입문용으로 간단한 알고리즘을 정리할 것입니다.

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
    private NearAlgorithm nearAlgorithm;
    private NearAllAlgorithm nearAllAlgorithm;
    private RankAlgorithm rankAlgorithm;
    private SortAlgorithm sortAlgorithm;
    private SearchAlgorithm searchAlgorithm;

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
        nearAlgorithm = new NearAlgorithm();    
        nearAllAlgorithm = new NearAllAlgorithm();
        rankAlgorithm = new RankAlgorithm();
        sortAlgorithm   = new SortAlgorithm();
        searchAlgorithm = new SearchAlgorithm();      
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
        averageExceptMaxAndMinAlgorithm?.Main(false);
        nearAlgorithm?.Main(false);
        nearAllAlgorithm?.Main(false);
        rankAlgorithm?.Main(false);
        sortAlgorithm?.Main(false);
        searchAlgorithm?.Main(true);
    }
}

public class SumAlgorithm : Algorithm
{
    /// 합계 알고리즘 
    public override void Main(bool play)
    {
        if (play == false)
            return;

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
    // 등차수열 알고리즘 : 연속하는 두 수의 차이가 일정한 수열

    public override void Main(bool play)
    {
        if (play == false)
            return;

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
    // 개수 알고리즘
    public override void Main(bool play)
    {
        if (play == false)
            return;

        // [1] input
        int icount = 0;

        // [2] process

        // 내 풀이
        for(int i = 1; i <= 1000; i++)
        {
            if (i % 13 == 0)
                icount++;
        }

        // _ -> 구분용으로 넣음
        // 1_000 = 1000 1000 = 1000 1____000 = 1000 모두 똑같음

        // 강사 풀이 1 (Linq 사용 Where 사용)
        var numbers = Enumerable.Range(1, 1_000).ToArray().Where(n => n % 13 == 0).Count();     // 1부터 1~1000개의 배열을 생성

        // 강사 풀이 2 (Linq 사용 Where 미사용)
        var numbers2 = Enumerable.Range(1, 1_000).ToArray().Count(n => n % 13 == 0);

        // 강사 풀이 3 (Linq 미사용)
        var numbers3 = Enumerable.Range(1, 1_000).ToArray();

        for(int i = numbers3.Min(); i < numbers3.Max(); i++)
        {
            if (numbers3[i] % 13 == 0)
            {
                icount++;
            }
        }

        // [3] output
        string strExpain = $"1부터 1000까지의 정수 중 13의 배수의 개수는 ? {icount}";
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
    // 소수 알고리즘
    public override void Main(bool play)
    {
        if (play == false) 
            return;

        // [1] input 2 3 5 7 11 13 17 19 23 29 ...
        int input = 2;
        bool result = false;

        // [2] process

        // 내 풀이 (약수로 계산)
        result = Prime(input);

        // 강사 풀이(2부터 n까지 나누어 떨어지는 수가 발생할 때까지 반복)
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
        string strexpain2 = result == true ? "맞습니다." : "아닙니다.";
        string streExpain = $"입력한 숫자인 {input}은 소수가 {strexpain2}";
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
    // 소수의 개수를 구하는 알고리즘
    public override void Main(bool play)
    {
        if(play == false) return;

        // [1] input
        int input = 100;
        List<int> list_primeNumber = new List<int>();

        // 강사 input
        var count = 0;  // 소수 개수
        var sw = true;  // 소수인지를 확인하는 스위치 변수

        // [2] process

        // 내 풀이
        list_primeNumber = PrimeList(input);

        // 강사 풀이
        for (int i = 2; i < input; i++)
        {
            sw = true; // 일단은 모든 반복마다 소수로 놓고 시작

            // 2부터 현재수(i) - 1 까지 나누었을 때 나누어 떨어지면 소수가 아니다.
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
    // 완전수 알고리즘
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int sum = 0; // 약수의 합계
        int cnt = 0; // 완전수의 개수
        int max = 0; // 완전수 중 가장 큰 값 (가장 큰 약수)
        int rem = 0; // 나머지 값 임시 보관

        // [2] process

        // 내 풀이
        for(int i = 1; i <= 10000; i++)
        {
            sum = 0;

            // 절반 초과의 값은 약수가 될 수 없음 ㅇㅇ;
            for (int j = 1; j <= i / 2; j++)
            {
                if (i % j == 0)
                {
                    sum+=j;
                }
            }

            // 완전수가 되려면 약수인 j의 값을 전부 더한 경우에 값이 같아야 함 ㅇㅇ;
            if(i == sum)
            {
                cnt++;

                if(max < i)
                    max = i;
            }           
        }

        // 강사 풀이
        for (int q = 1; q < 10000; q++)
        {
            sum = 0;     // 매 반복마다 초기화
            max = q / 2; // 모든 짝수를 2로 나누면 가장 큰 약수

            for (int w = 1; w <= max; w++)
            {
                rem = q - (q / w) * w; // 원본 수 / 약수
                if(rem == 0)
                {
                    sum += w; // 약수의 합계
                }
            }

            if(q == sum) // 자신 == 약수의 합계 (완전수)
            {
                cnt++;
            }
        }

        // [3] output (강사 풀이로하면 가장 큰 값이 4999로 나옴 ㅇㅇ 멈추는게 없어서 계속 돌다가 마지막 수를 보여준다)
        string strExpain = $"완전수의 개수는 {cnt} \n 완전수 중 가장 큰 값은 {max}";
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
    // 평균 알고리즘

    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[] data = { 90, 65, 78, 50, 95};

        int cnt = 0;
        int total = 0;
        float average = 0;

        // [2] process

        // 내 풀이
        for(int i = 0; i < data.Length; i++)
        {
            if (80 <= data[i] && data[i] <= 95)
            {
                cnt++;
                total += data[i];
            }
        }

        average = (float)total / cnt;

        // 강사 풀이 1 (Linq 사용)
        var averageTemp = data.Where(d => d >= 80 && 95 >= d).Average();

        // 강사 풀이 2 (Linq 사용 X)
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
        string strExpain = $"80점 이상 95점 이하인 점수의 평균은 {average}이며 학생 수는 {cnt}명 입니다.";
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
    // 평균 이상 개수 구하기 알고리즘
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[] data = { 91, 80, 88, 25, 75 };
        int sum = 0;
        int cnt = 0;
        double average = 0;

        // [2] process

        // 내 풀이
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

        // 강사 풀이
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
        string strExpain = $"전체 5명의 학생중 평균은 {average}이며 평균을 넘은 학생의 수는 {cnt}명 입니다.";
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

        // 내 풀이 (분명 첫 부분에서는 2중 for문 사용하라해서 썻는데 영상 다시 틀어보니 말이 바뀜요;)
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

        // 강사 풀이
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
            strExpain += $"{i + 1}번째 학생의 합계는 {score[i,2]} 이며 평균은 {score[i,3]} 입니다.\n";
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
    // 최대값 알고리즘
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] initialzie
        int maxValueMine = int.MinValue;

        // [2] input
        int[] numbers = { -2, -5, -3, -7, -1 };

        // [3] process
        // 내 풀이
        for(int i = 0; i < numbers.Length; i++)
        {
            if (maxValueMine < numbers[i])
            {
                maxValueMine = numbers[i];
            }
        }

        // 강사 풀이 1 (Linq 사용)
        int maxValue = numbers.Max();

        // 강사 풀이 2 (Linq 미사용)
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > maxValueMine)
            {
                maxValueMine = numbers[i];
            }
        }

        // [4] output
        string strExpain = $"가장 큰 값은 {maxValueMine} 입니다.";
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
    // 최소값 알고리즘
    public override void Main(bool play)
    {
       if(play == false) return;

        // [1] initialzie
        int minValueMine = int.MaxValue;

        // [2] input
        int[] numbers = { -2, -5, -3, -7, -1 };

        // [3] process
        // 내 풀이
        for (int i = 0; i < numbers.Length; i++)
        {
            if (minValueMine > numbers[i])
            {
                minValueMine = numbers[i];
            }
        }

        // 강사 풀이 1 (Linq 사용)
        int maxValue = numbers.Min();

        // 강사 풀이 2 (Linq 미사용)
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < minValueMine)
            {
                minValueMine = numbers[i];
            }
        }

        // [4] output
        string strExpain = $"가장 작은 최소값은 {minValueMine} 입니다.";
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
    // 최대값과 최소값을 제외한 평균값 구하기
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
        // 내 풀이
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

        // 강사 풀이
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
        string strExapin = $"최대값은 {maxvalue} 이며 최소값은 {minvalue} 입니다. 이를 제외한 평균의 점수는 {average} 입니다.";
        OnShow(strExapin);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class NearAlgorithm : Algorithm
{
    // 근삿값 알고리즘
    // 차잇값의 절대값의 최솟값

    public override void Main(bool play)
    {
        if (play == false) return;

        // 절대값 구하기 로컬함수 (Math.Abs 함수와 동일한 기능임)
        int Abs(int num) => (num < 0) ? -num : num;

        // [0] initialize
        int min = int.MaxValue;

        // [1] input
        int[] numbers = { 10, 20, 30, 27,17 };
        int target = 25;
        int array = 0;
        int absValue = 0;
        int arrayvalue = 0;

        // [2] process

        // 내 풀이
        for(int i = 0; i < numbers.Length; i++)
        {
            absValue = Math.Abs(target - numbers[i]);

            if(min > absValue)
            {
                min = absValue;
                array = i;
            }
        }

        // 강사 풀이 1 (Linq 1)
        var minimum = numbers.Min(x => Math.Abs(x - target));               // 차잇값의 최솟값
        var closest = numbers.First(x => Math.Abs(target - x) == minimum);  // 근삿값

        // 강사 풀이 2 (Linq 2)
        var temp = numbers.First(x => Math.Abs(target - x) == numbers.Min(x => Math.Abs(x - target)));

        // 강사 풀이 3 (Linq X)
        for(int i = 0; i< numbers.Length; i++)
        {
            int abs = Abs(numbers[i] - target);
            if(abs < min)
            {
                min = abs;
                arrayvalue = numbers[i];
            }
        }

        // [3] output
        string strExpain = $"{target}과 가장 가까운 값은 : {numbers[array]} 이며 차이를 절대값으로 변환한 경우는 {min} 입니다.";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class NearAllAlgorithm : Algorithm
{
    // 가까운 값 모두 구하기 알고리즘 (동일한 최솟값을 가진 숫자들 모두 구하기인듯;)

    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[] data = { 10, 20, 23, 27, 17 };
        int target = 25;
        List<int> nears = new List<int>();
        int min = int.MaxValue;

        // [2] process
        for (int i = 0; i < data.Length; i++)
        {
            if (Math.Abs(data[i] - target) < min)
            {
                min = Math.Abs(data[i] - target);
            }
        }

        // 동일한 값이 들어온 경우에 다시 돌면서 넣어줌
        for (int i = 0; i < data.Length; i++)
        {
            if (Math.Abs(data[i] - target) == min)
            {
                nears.Add(i);
            }
        }

        // [3] output
        string strExpain = $"차이의 최솟값은 {min} 같은 최솟값을 가진 숫자의 개수는 {nears.Count} 입니다.";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log($"{str}");
        StudySingleton.Instance.OnShow(str);
    }
}

public class RankAlgorithm : Algorithm
{
    // 순위 알고리즘

    public override void Main(bool play)
    {
        if(play == false) return;

        // [1] input
        int[] scores = { 90, 87, 100, 95, 80 };
        int[] rankings = Enumerable.Repeat(1,5).ToArray();

        // [2] process

        // 내 풀이
        for(int i = 0; i < scores.Length; i++)
        {
            rankings[i] = 1;
            for (int j = 0; j < scores.Length; j++)
            {
                if (scores[i] < scores[j])
                {
                    rankings[i]++;
                }
            }
        }

        // 강사 풀이 1 (Linq 사용)
        var ranking = scores.Select(x => scores.Where(y => y > x).Count() + 1).ToArray();

        // 강사 풀이 2 (Linq 미사용)
        // 내 풀이랑 거의 같아서 넘어갔음

        // [3] output
        string strExpain = $"";

        for(int i = 0; i < rankings.Length; i++)
        {
            strExpain += $"{scores[i],3}점 : {rankings[i],3} 등";
        }

        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log($"RankAlgorithm: {str}");
        StudySingleton.Instance.OnShow(str);
    }
}

public class SortAlgorithm : Algorithm
{
    // 정렬 알고리즘
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[] data = { 3, 2, 1, 4, 5 };

        // [2] process

        // 내 풀이 (내림차 순)
        List<int> sort = data.ToList();
        sort.Sort(new Comparison<int>((n1, n2) => n2.CompareTo(n1)));

        // 내 풀이 (오름차 순)
        sort.Sort();

        // 강사 풀이 1 (오름차 순)
        var sortTeacher = data.OrderBy(x => x).ToArray();

        // 강사 풀이 2 (내림차 순)
        sortTeacher = data.OrderByDescending(x => x).ToArray();

        // 강사 풀이 3
        int N = data.Length;
        for (int i = 0; i < N; i++)
        {
            for(int j = i+1; j < N; j++)
            {
                // > : 오름차순
                // < : 내림차순
                if (data[i] > data[j])
                {
                    int temp = data[i];
                    data[i] = data[j];
                    data[j] = temp; 
                }
            }
        }

        // [3] output
        string strExpain = $"";

        for(int i = 0; i < data.Length; i++)
        {
            strExpain += data[i].ToString();
        }

        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}

public class SearchAlgorithm : Algorithm
{
    // 검색 알고리즘
    public override void Main(bool play)
    {
        if (play == false) return;

        // [1] input
        int[] data = { 1, 3, 5, 7, 9 }; // 오름차순으로 정렬되었다고 가정
        int search = 3; // 검색한 값
        bool find = false;
        int index = -1; // 찾은 위치

        // [2] process 이진 검색(BinarySearch) : FullScan -> Index Scan

        // 내 풀이 (이진 검색을 사용하지 않음 ㅠ)
        for(int i = 0; i< data.Length; i++)
        {
            if (data[i] == search)
            {
                index = i;
                break;
            }
            else
            {
                index = -1;
            }
        }

        // 강사 풀이 1 (Linq)
        var result = data.ToList().BinarySearch(9); // 찾을 데이터가 없으면 -로 반환
       
        // 이런식으로도 사용 가능
        if(Array.BinarySearch(data,3) >= 0)
        {

        }
        else
        {
            // -1인 경우는 찾지 못한 경우이니 return
            return;
        }

        // 강사 풀이 2 (Linq 사용 X)
        int low = 0;
        int high = data.Length - 1;

        int mid = 0;
        while(low <= high)
        {
            mid = (low + high) / 2; // 중간 인덱스 구하기

            // 중간값이 내가 찾는값이야?
            if (data[mid] == search)
            {
                find = true;
                index = mid;
                break;
            }

            if (data[mid] > search)
            {
                high = mid -1; // 찾을 데이터가 작으면 high 위치 변경
            }
            else
            {
                low = mid + 1; // 찾을 데이터가 크면 low 위치 변경
            }
        }

        // [3] output
        string strExpain = find == true ? $"{search}를 {index}위치에서 찾았습니다." : $"찾지 못하였습니다.";
        OnShow(strExpain);
    }

    public override void OnShow(string str)
    {
        Debug.Log(str);
        StudySingleton.Instance.OnShow(str);
    }
}