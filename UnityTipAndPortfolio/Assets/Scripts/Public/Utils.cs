using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace JJW_Utils
{
    /// <summary>
    /// CSV 관련 함수를 정리한 클래스입니다.
    /// </summary>
    public class CSV_Utils
    {
        private static readonly string ColumnToIgnoreKey = "BlankField";
        private static ArrayList IgnoreColumn = new ArrayList();

        #region 특정 열을 처리하지 않는 예시
        /// <summary>
        /// 특정 열이 몇번째 행에 존재하는지 찾는 함수입니다.
        /// </summary>
        /// <param name="_StrHeader">
        /// 찾으려고 하는 문서의 첫번째 행을 넣어주세요.
        /// </param>
        /// <returns>
        /// 제외해야 하는 열의 순서를 기억하는 어레이리스트를 넘겨줍니다.
        /// </returns>
        public static void Return_IgnoreKey(string[] _StrHeader)
        {
            IgnoreColumn.Clear();

            for (int i = 0; i < _StrHeader.Length; i++)
            {
                if (_StrHeader[i].Trim() == ColumnToIgnoreKey)
                {
                    IgnoreColumn.Add(i);
                }
            }
        }

        /// <summary>
        /// 제외해야 하는 열을 찾아 배열을 다시 만들어주는 함수입니다.
        /// </summary>
        /// <param name="_StrArray">
        /// 문서의 배열값을 넣어줍니다.
        /// </param>
        /// <param name="arrayList"></param>
        /// <returns>
        /// 제외해야 하는 열을 제외한 어레이 리스트를 string[]에 넣어준 뒤 다시 반환해줍니다.
        /// </returns>
        public static string[] Return_lgnoreArray(string[] _StrArray)
        {
            ArrayList TempArray = new ArrayList();

            for (int i = 0; i < _StrArray.Length; i++)
            {
                if (IgnoreColumn.Contains(i) == false)
                    TempArray.Add(_StrArray[i]);
            }
            _StrArray = TempArray.ToArray(typeof(string)) as string[];
            return _StrArray;
        }
        #endregion

        #region 행에서 특정 열을 처리하지 않는 예시
        /// <summary>
        /// 행에서 특정 행을 찾아 읽지 않는 함수입니다.
        /// </summary>
        /// <param name="_StrArray">
        /// 문서의 배열 값을 넣어줍니다.
        /// </param>
        /// <param name="_StrKey">
        /// 특정 행을 찾을 키워드입니다.
        /// </param>
        /// <returns></returns>
        public static String[] Delete_Column_From_Row(String[] _StrArray, string _StrKey)
        {
            /// Where() -> 각 요소를 순회하면서 주어진 조건을 만족하는 요소들만 반환
            /// !item.Contains("/T") -> 각 요소를 순회하면서 "/T" 가 포함하지 않는 요소들을 반환
            /// ToArray() -> 새로운 배열 생성

            return _StrArray = _StrArray.Where(item => !item.Contains(_StrKey)).ToArray();
        }
        #endregion

        /// <summary>
        /// CSV 파일을 읽을 때 특정 기호를 사용하여 파싱하는 상황에서 int 값을 받아올 때 string 함수인 .Split()을 쉽게 사용하기 위해 만든 함수
        /// </summary>
        /// <param name="strArray">
        /// 문서에서 읽어 올 문자값입니다.
        /// </param>
        /// <param name="bSkip">
        /// true 일 때 문서에서 0은 읽지 않습니다.
        /// </param>
        /// <param name="delimiter">
        /// 파싱할 때 사용할 특정 기호입니다.
        /// </param>
        /// <returns>
        /// </returns>
        public static List<int> ParseIntList(string strArray, bool bSkip = false, char delimiter = '/')
        {
            List<int> List_Temp = new List<int>();
            string[] InsideStrArray = strArray.Split(delimiter);

            if (InsideStrArray != null && InsideStrArray.Length != 0)
            {
                for (int i = 0; i < InsideStrArray.Length; i++)
                {
                    int i32DetailNum = Convert.ToInt32(InsideStrArray[i]);
                    if (bSkip)
                    {
                        if (i32DetailNum == 0)
                            continue;
                    }
                    List_Temp.Add(i32DetailNum);
                }
            }
            return List_Temp;
        }
    }

    /// <summary>
    /// UI 관련 함수를 정리한 클래스입니다.
    /// </summary>
    public class UI_Utils
    {
        /// <summary>
        /// 아이콘이 추가된 경우에 리스트 사이즈를 늘려주는 함수입니다.
        /// </summary>
        /// <param name="rect_1">
        /// 아이콘의 리스트 입니다.
        /// </param>
        /// <param name="rect_2">
        /// 아이콘을 자식으로 가지고있는 부모 오브젝트입니다.
        /// </param>
        /// <param name="iMaxCount">
        /// 현재 'rect'의 자식으로 들어갈 수 있는 아이콘의 최대 개수입니다.
        /// </param>
        /// <param name="iOrignHeight">
        /// 'rect'의 원래 Height 값입니다.
        /// </param>
        /// <param name="iPlusHeight">
        /// 아이콘이 추가되여 줄이 늘어나야 할 때 필요한 높이값입니다.
        /// </param>
        public static void ListIconSizeCheck(RectTransform rect_1, RectTransform rect_2, int iMaxCount, int iOrignHeight, int iPlusHeight)
        {
            int iActiveCnt = 0;

            // 자식으로 있는 오브젝트 중에서 활성화가 된 오브젝트를 찾습니다.
            for (int i = 0; i < rect_1.childCount; i++)
            {
                if (rect_1.GetChild(i).gameObject.activeSelf)
                {
                    iActiveCnt++;
                }
            }

            // 제한한 개수보다 많다면
            if (iMaxCount < iActiveCnt)
            {
                int iPlusCnt = 0;

                // 기존개수를 빼주고
                iActiveCnt -= iMaxCount;

                // 개수 구하기
                iPlusCnt += iActiveCnt / 5;

                if (iActiveCnt % 5 != 0)
                {
                    iPlusCnt++;
                }

                // 기존 사이즈로 변경해주고
                rect_2.sizeDelta = new Vector2(rect_2.sizeDelta.x, iOrignHeight);

                // 바꿔준다.
                rect_2.sizeDelta = new Vector2(rect_2.sizeDelta.x, rect_2.sizeDelta.y + (iPlusHeight * iPlusCnt));
            }
            // 아니라면
            else
            {
                // 바뀐 상태라면
                if (iOrignHeight < rect_2.sizeDelta.y)
                {
                    rect_2.sizeDelta = new Vector2(rect_2.sizeDelta.x, iOrignHeight);
                }
                else
                    return;
            }
        }

        /// <summary>
        /// 이미지의 클릭한 곳에 도트값이 A값을 반환해주는 함수
        /// </summary>
        /// <param name="image">
        /// 조건에 들어갈 이미지 컴포넌트
        /// </param>
        /// <param name="fLimitAlpha">
        /// 제한할 알파 값
        /// </param>
        /// <returns>
        /// 조건에 따른 반환
        /// </returns>
        public static bool ImageAlphaCheck(UnityEngine.UI.Image image, float fLimitAlpha)
        {
            Vector2 mousePosition = Input.mousePosition;
            RectTransform imageRect = image.rectTransform;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imageRect, mousePosition, null, out Vector2 localPoint))
            {
                // 이미지의 로컬 좌표를 정규화 좌표로 변환
                Vector2 normalizedPoint = new Vector2((localPoint.x + imageRect.rect.width / 2) / imageRect.rect.width,
                                                      (localPoint.y + imageRect.rect.height / 2) / imageRect.rect.height);

                // 텍스처 좌표로 변환
                Vector2 textureCoord = new Vector2(normalizedPoint.x * image.sprite.texture.width,
                                                   normalizedPoint.y * image.sprite.texture.height);

                // 텍스처 좌표에서 픽셀 값을 가져옴
                Color pixelColor = image.sprite.texture.GetPixel((int)textureCoord.x, (int)textureCoord.y);

                // Alpha 값을 반환
                float alphaValue = pixelColor.a;

                Debug.Log("Clicked Pixel Alpha Value: " + alphaValue);

                if (alphaValue < fLimitAlpha)
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 시간 관련 함수를 정리한 클래스입니다.
    /// </summary>
    public class Time_Utils
    {
        /// <summary>
        /// 시간 표시 타입
        /// </summary>
        public enum TimeFormat
        {
            /// <summary>
            /// 기본적인 시간 표시 방식입니다. (예: '일','시간','분','초')
            /// </summary>
            BASIC = 0,

            /// <summary>
            /// 기본적인 시간 표시 방식에서 '시간' -> '시'로 바뀐 방식입니다.  (예: '일','시','분','초')
            /// </summary>
            BASIC_SHORT,

            /// <summary>
            /// 전체 날짜 표시를 나타냅니다. (예: "yyyy년 m월 d일 h시 m분 s초")
            /// </summary>
            FULLDATA,

            /// <summary>
            /// 전체 날짜 표시를 일까지만 표시해줍니다. (예: "yyyy년 - m월 - d일")
            /// </summary>
            FULLDATA_DAY_UNTIL,

            /// <summary>
            /// 전체 날짜 표시를 시까지만 표시해줍니다. (예: "yyyy년 - m월 - d일 - h시")
            /// </summary>
            FULLDATA_HOUR_UNTIL,

            /// <summary>
            /// 전체 날짜 표시를 분까지만 표시해줍니다. (예: "yyyy년 - m월 - d일 - h시 m분")
            /// </summary>
            FULLDATA_MINUTES_UNTIL,

            /// <summary>
            /// 레이드나 공성전 같은 경우의 남은 시간을 보여주는 방식입니다. (예: "hh : mm")
            /// </summary>
            REMAIN_TIMER
        }

        /// <summary>
        /// ToString() 표현 타입
        /// </summary>
        public enum ToStringFormat
        {
            /// <summary>
            /// 아무런 방식도 사용하지 않습니다. (예 : ToString(""))
            /// </summary>
            NONE,

            /// <summary>
            /// 0 한개를 붙입니다. (예 : ToString("0"))
            /// </summary>
            One_Digit_Zero,

            /// <summary>
            /// 0 두개를 붙입니다. (예 : ToString("00"))
            /// </summary>
            Two_Digit_Zero,
        }

        /// <summary>
        /// 번역 문서의 키 값을 가져올 때 필요한 enum 값 입니다.
        /// </summary>
        public enum TimeLocKey
        {
            _DAYS,
            _TOTALHOURS,
            _HOURS,
            _MINUTES,
            _SECOND,
        }

        private static int iDifferTimeStamp;

        #region 시간 간격 계산 함수
        /// <summary>
        /// 서버와의 시간차를 저장하는 함수입니다.
        /// </summary>
        /// <param name="_i32DifferTimeStamp">
        /// 서버와의 시간차의 값을 넣는 부분입니다. (CreateMyCharacter_New(),SM_TIMESTAMP 패킷,SM_TIMESTAMP_REQUEST 패킷) 사용 중
        /// </param>
        public static void GetDifferTimeStamp(int _i32DifferTimeStamp)
        {
            iDifferTimeStamp = _i32DifferTimeStamp;
        }

        /// <summary>
        /// 한국 표준시(KST, Korean Standard Time) 기준으로 현재 날짜와 시간을 반환하는 함수
        /// </summary>
        /// <returns>
        /// 현재 시스템 시간에 서버와의 시간차인 32400초(9시간)를 더한 값을 기준으로 한국 시간을 계산하여 반환
        /// </returns>
        public static DateTime GetDateTime_ByKor()
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(GetTimestampNow_ByServer() + 32400);
            return dtDateTime;
        }

        /// <summary>
        /// UNIX Epoch 시간(1970년 1월 1일 0시 0분 0초 UTC부터 경과된 시간을 초로 나타낸 값)을 입력받아 해당 시간을 한국 표준시(KST)로 변환하여 반환하는 함수
        /// </summary>
        /// <param name="TimeStamp">
        /// 지금 구하려는 타임 스탬프 값
        /// </param>
        /// <returns>
        /// 입력으로 주어진 TimeStamp에 32400초(9시간)를 더한 값을 기준으로 한국 시간을 계산하여 반환
        /// </returns>
        public static DateTime GetDateTime_ByKor(uint TimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(TimeStamp + 32400);
            return dtDateTime;
        }

        /// <summary>
        /// UNIX Epoch 시간(1970년 1월 1일 0시 0분 0초 UTC부터 경과된 시간을 초로 나타낸 값)을 입력받아 해당 시간을 UTC 기준으로 변환하여 반환하는 함수
        /// </summary>
        /// <param name="TimeStamp">
        /// 지금 구하려는 타임 스탬프 값
        /// </param>
        /// <returns>
        /// 입력으로 주어진 TimeStamp를 초 단위로 해석하여 UTC 시간으로 변환하고 이를 ToLocalTime() 메서드를 사용하여 현지 시간으로 변환
        /// </returns>
        public static DateTime GetDateTime(uint TimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(TimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// 주어진 DateTime 객체를 기준으로, 해당 시간부터 1970년 1월 1일 0시 0분 0초 UTC까지의 경과 시간을 초로 나타낸 값을 반환하는 함수
        /// </summary>
        /// <param name="dateTime">
        /// 기준이 될 detaTime 입니다
        /// </param>
        public static uint GetTimestamp(DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return Convert.ToUInt32(timeSpan.TotalSeconds);
        }

        /// <summary>
        /// 현재 시스템 시간을 UTC 기준으로 계산하여, 해당 시간부터 1970년 1월 1일 0시 0분 0초 UTC까지의 경과 시간을 초로 나타낸 값을 반환하는 함수
        /// </summary>
        public static uint GetTimestampNow()
        {
            return GetTimestamp(DateTime.Now.ToLocalTime());
        }


        /// <summary>
        /// GetTimestampNow() 함수를 호출하여 현재 시스템 시간을 UTC 기준으로 계산한 뒤, 서버와의 시간차인 iDifferTimeStamp 값을 더하여 최종적인 시간 값을 반환하는 함수
        /// </summary>
        public static uint GetTimestampNow_ByServer()
        {
            return (uint)(GetTimestamp(DateTime.Now.ToLocalTime()) + iDifferTimeStamp);
        }

        /// <summary>
        /// 현재 시스템 시간을 기준으로 현재 시간부터 1970년 1월 1일 0시 0분 0초 UTC까지의 경과 시간을 밀리초(ms)로 나타내는 값을 반환하는 함수
        /// 이 함수는 DateTime.Now.ToLocalTime()을 호출하여 현재 시스템 시간을 로컬 시간으로 변환한 뒤, 이를 입력으로 하여 GetTimestampM(DateTime dateTime) 함수를 호출합니다.
        /// </summary>
        public static double GetTimestampNowM()
        {
            return GetTimestampM(DateTime.Now.ToLocalTime());
        }

        /// <summary>
        /// 주어진 DateTime 객체를 기준으로 해당 시간부터 1970년 1월 1일 0시 0분 0초 UTC까지의 경과 시간을 밀리초(ms)로 나타내는 값을 반환하는 함수
        /// </summary>
        /// <param name="dateTime">
        /// DateTime 객체를 기준으로 TimeSpan 구조체를 사용하여 dateTime과 1970년 1월 1일 0시 0분 0초 UTC 간의 시간 간격을 계산합니다.
        /// </param>
        /// <returns>
        /// 해당 시간 간격을 밀리초로 변환하여 반환
        /// </returns>
        public static double GetTimestampM(DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return timeSpan.TotalMilliseconds;
        }

        /// <summary>
        /// 현재시간이 시작 TimeStamp를 지났는지 True/False 로 반환하는 함수 
        /// <para>
        /// 종료 TimeStamp까지 넣는다면 현재 시간이 시작과 종료 TimeStamp 사이인지 True/False 반환
        /// </para>
        /// </summary>
        /// <param name="startTime">
        /// 시작 기준 TimeStamp 입니다.
        /// </param>
        /// <param name="endTime">
        /// 종료 기준 TimeStamp 입니다.
        /// </param>
        /// <returns>
        /// 현재 시간이 조건에 부합하는지 True/False 반환
        /// </returns>
        public static bool GetBetweenTimeStamp(uint startTime, uint endTime = 0)
        {
            uint timeStampNow = 0;//GameMain.instance.GetTimestampNow_ByServer();

            if (endTime != 0)
            {
                if (timeStampNow > startTime && timeStampNow < endTime)
                    return true;
            }

            else if (timeStampNow > startTime)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 시간 표시 함수

        /// <summary>
        /// 현재 시간을 string 으로 반환해주는 함수입니다.
        /// </summary>
        /// <param name="uTime">
        /// 보여줘야 할 시간 값
        /// </param>
        /// <param name="timeFormat">
        /// 시간 표현 방식
        /// </param>
        /// <param name="toStringFormat">
        /// ToString() 표현 방식
        /// </param>
        /// <param name="bShort">
        /// 단축 여부 (예 : hh시 mm분 -> hh - mm)
        /// <param name="bUseDay">
        /// '일'의 표시 여부
        /// </param>
        /// <returns>
        /// 각 타입에 맞는 시간 값을 사용자가 지정한 표기 방식과 매개 변수의 방식을 보고 string으로 반환합니다.
        /// </returns>
        public static string GetTimeStr_Remain_Basic(uint uTime, TimeFormat timeFormat, ToStringFormat toStringFormat = ToStringFormat.NONE, bool bShort = false, bool bRemain = false, bool bUseDay = false)
        {
            string strReturn = "";

            // 키를 만들어주는 부분입니다.
            // ex) "SYSTEM_TIME_KEY_BASIC_SHORT_REMAIN_DAYS
            string strLocKey = "SYSTEM_TIME_KEY_";

            TimeSpan timeSpan = TimeSpan.FromSeconds((double)uTime);

            strLocKey += timeFormat.ToString();
            if (bShort) strLocKey += "_SHORT";
            if (bRemain) strLocKey += "_REMAIN";

            if (bUseDay && 0 < (int)timeSpan.TotalDays)
            {
                strLocKey += GetDateTimeKey(TimeLocKey._DAYS);
                //strReturn = GameMain.GetTranslationFile(strLocKey, out bool bhasdata, true, timeSpan);
            }
            else if (0 < (int)timeSpan.TotalHours)
            {
                strLocKey += GetDateTimeKey(TimeLocKey._TOTALHOURS);
                //strReturn = GameMain.GetTranslationFile(strLocKey, out bool bhasdata, true, timeSpan);
            }
            else if (0 < (int)timeSpan.TotalMinutes)
            {
                strLocKey += GetDateTimeKey(TimeLocKey._MINUTES);
                //strReturn = GameMain.GetTranslationFile(strLocKey, out bool bhasdata, true, timeSpan);
            }
            else
            {
                strLocKey += GetDateTimeKey(TimeLocKey._SECOND);
                //strReturn = GameMain.GetTranslationFile(strLocKey, out bool bhasdata, true, timeSpan);
            }
            return strReturn;
        }

        private static string GetDateTimeKey(TimeLocKey key)
        {
            return key.ToString();
        }

        #endregion
    }

    /// <summary>
    /// 비트 계산 관련 함수를 정리한 클래스입니다.
    /// </summary>
    public class Bit_Utils
    {
        /// <summary>
        /// 비트를 최우측 기준으로 구해오는 함수입니다.
        /// </summary>
        /// <param name="targetVar">
        /// 비트를 계산할 값을 넣어줍니다.
        /// </param>
        /// <param name="initVar">
        /// 몇 비트를 사용하는지에 대해 넣어주시면 됩니다.
        /// <para>
        /// ex) 0000 = 0, 0001 = 1, 0010 = 2, 0011 = 3....
        /// </para>
        /// </param>
        /// <param name="shift">
        /// 어떤 위치의 값을 가져오려고 하는지에 대해 넣어주시면 됩니다.
        /// </param>
        /// <returns>
        /// 원하는 자리에 비트값을 반환해줍니다.
        /// </returns>
        public static uint GetOut_InBits(uint targetVar, uint initVar, int shift)  //  대상, 자릿수, 위치
        {
            uint uVar = initVar; // uVar = 1
            uVar = uVar << shift; //   = 1 << 6
            uVar = targetVar & uVar;  //0100 0000
            uVar = uVar >> shift; //   
            return uVar;        // 0
        }


        /// <summary>
        /// 비트를 밀어서 넣어주는 함수입니다.
        /// </summary>
        /// <typeparam name="T">
        /// PushValue에 대한 자료형을 넣어줍니다.
        /// </typeparam>
        /// <param name="BaseValue">
        /// 밀려고 하는 값을 넣어줍니다.
        /// </param>
        /// <param name="Power">
        /// 얼만큼 밀려는지에 대한 값을 넣어줍니다.
        /// </param>
        /// <param name="Pushvalue">
        /// 밀어줄 비트의 값을 넣어줍니다.
        /// </param>
        /// <returns>
        /// 밀어주고 난 뒤에 비트값을 반환해줍니다.
        /// </returns>
        public static uint Pushbit<T>(uint BaseValue, int Power, T Pushvalue)
        {
            BaseValue = BaseValue << Power;
            BaseValue = BaseValue | Convert.ToUInt32(Pushvalue);
            return BaseValue;
        }

        /// <summary>
        /// 위치를 이동시키며 비트를 구해오는 함수입니다.
        /// </summary>
        /// <param name="src">
        /// 비트를 계산하기 위한 값을 넣어줍니다.
        /// </param>
        /// <param name="start">
        /// 몇비트만큼 오른쪽으로 시프트 시킬지에 대한 변수입니다.
        /// </param>
        /// <param name="size">
        /// 왼쪽,오른쪽으로 비트를 시프트 시킬지에 대한 변수입니다.
        /// </param>
        /// <returns>
        /// 원하는 자리에 비트값을 반환해줍니다.
        /// </returns>
        public uint BitSplitter_Right(uint src, int start, int size)  //  대상, 자릿수, 위치
        {
            src = src >> start;
            src = src << 32 - size;
            return src >> 32 - size;
        }

        /// <summary>
        /// 비트의 값을 바꿔주는 함수
        /// </summary>
        /// <param name="targetVar">
        /// 바꿔줄 대상 값
        /// </param>
        /// <param name="controlVar">
        /// 바꿔줄 값
        /// </param>
        /// <param name="shift">
        /// 바꿔줄 위치
        /// </param>
        /// <param name="bit">
        /// 바꿔줄 자리수
        /// </param>
        /// <returns></returns>
        public uint SetSettingVar_InBits(uint targetVar, uint controlVar, int shift, int bit)   //  대상, 값, 위치, 자릿수
        {
            uint uVar;
            uint uInitVar = 1;

            switch (bit)
            {
                case 1: uInitVar = 1; break;
                case 2: uInitVar = 3; break;
                case 3: uInitVar = 7; break;
                case 4: uInitVar = 15; break;
                case 5: uInitVar = 31; break;
                case 6: uInitVar = 63; break;
                case 7: uInitVar = 127; break;
                case 8: uInitVar = 255; break;
                case 16: uInitVar = 65535; break;
            }

            #region 예시
            //0000 0000 0000 0000 0000 0000 1111 0000   //  비울 위치만큼 민다
            //1111 1111 1111 1111 1111 1111 1111 1111   //  4294967295
            //1111 1111 1111 1111 1111 1111 0000 1111   //  uInitVar 를 만든다        
            //1010 1010 1010 1010 1010 1010 0000 1010   //  저장될 위치를 비운다      
            //0000 0000 0000 0000 0000 0000 1010 0000   //  저장할값을 위치만큼 민다
            //1010 1010 1010 1010 1010 1010 0000 1010   //  복사
            //1010 1010 1010 1010 1010 1010 1010 1010   //  결과
            #endregion

            // 비울 위치만큼 민다
            uInitVar = uInitVar << shift;

            //  uInitVar 를 만든다
            uInitVar = 4294967295 ^ uInitVar;

            // ^  = XOR 연산
            uVar = targetVar & uInitVar;

            // 바꿔줄 값을 위치만큼 민다
            controlVar = controlVar << shift;

            // | = OR 연산
            uVar = uVar | controlVar;
            return uVar;
        }
    }

    /// <summary>
    /// 컬러 변경 관련 함수를 정리한 클래스입니다.
    /// </summary>
    public class Color_Utils
    {
        /// <summary>
        /// 각 상황에 쓰일 컬러값들을 미리 정의합니다.
        /// </summary>
        public enum TextColorType
        {
            White = 0,
            Red,
            Yellow,
            Green,
            Gray,
            Jeongpa,
        }

        /// <summary>
        /// 헥사코드를 받고 컬러값을 반환해주는 함수입니다.
        /// </summary>
        /// <param name="hexadecimalColor">
        /// 헥사코드
        /// </param>
        /// <returns>
        /// 헥사코드에 따른 컬러값 반환
        /// </returns>
        public static Color GetColorByHexadecimal(string hexadecimalColor)
        {
            // SetTextColor 사용 부분 GetColorByHexadecimal()이걸로 교체 및 Get_TextColorType(textColor) 매개 변수 요거 호출

            Color _color;
            ColorUtility.TryParseHtmlString(hexadecimalColor, out _color);
            return _color;
        }

        /// <summary>
        /// TextColorType 타입에 따른 헥사코드를 반환해주는 함수입니다.
        /// </summary>
        /// <param name="color">
        /// TextColorType를 넣어줍니다.
        /// </param>
        /// <returns>
        /// TextColorType에 따른 헥사코드값 반환
        /// </returns>
        public static string Get_TextColorType(TextColorType color)
        {
            string strReturn = "";
            switch (color)
            {
                case TextColorType.White:
                    strReturn = "#FFFFFF";
                    break;
                case TextColorType.Red:
                    strReturn = "#FF0000";
                    break;
                case TextColorType.Yellow:
                    strReturn = "#FFE872";
                    break;
                case TextColorType.Green:
                    strReturn = "#5AFF32";
                    break;
                case TextColorType.Gray:
                    strReturn = "#787878";
                    break;              
                default:
                    strReturn = "#FFFFFF";
                    break;
            }
            return strReturn;
        }

        /// <summary>
        /// 등급에 따른 컬러값을 받아오기 위한 함수입니다.
        /// </summary>
        /// <param name="Rank">
        /// 등급
        /// </param>
        /// <returns>
        /// 등급에 따른 enum값 반환
        /// </returns>
        //public static TextColorType Get_TextColorType_Rank(int Rank)
        //{
        //    //TextColorType Value = TextColorType.Null;
        //    //switch (Rank)
        //    //{
        //    //    case 0: Value = TextColorType.Rank_0; break;
        //    //    case 1: Value = TextColorType.Rank_1; break;
        //    //    case 2: Value = TextColorType.Rank_2; break;
        //    //    case 3: Value = TextColorType.Rank_3; break;
        //    //    case 4: Value = TextColorType.Rank_4; break;
        //    //    case 5: Value = TextColorType.Rank_5; break;
        //    //}
        //    //return Value;
        //}

        /// <summary>
        /// enum으로 받은 값들을 리치텍스트형식으로 변환해서 반환해줍니다.
        /// </summary>
        /// <param name="color">
        /// 바꿔줄 컬러 값
        /// </param>
        /// <param name="text">
        /// 바꿔줄 문자
        /// </param>
        /// <returns>
        /// 컬러 값이 들어간 리치텍스트형식으로 반환해줍니다.
        /// </returns>
        public static string RichTextColor(TextColorType color, string text)
        {
            return RichTextColor(Get_TextColorType(color), text);
        }

        private static string RichTextColor(string ColorHexCode, string text)
        {
            string strReturn = "";
            strReturn = "<color=" + ColorHexCode + ">";

            strReturn += text + "</color>";

            return strReturn;
        }
    }

    /// <summary>
    /// 버전 관리 함수를 정리한 클래스 입니다.
    /// </summary>
    public class Version_Utils
    {

    }

    /// <summary>
    /// 각종 함수를 정리한 클래스 입니다.
    /// </summary>
    public class ETC
    {
        #region Exception
        /// <summary>
        /// 게임 플레이 도중에 Exception 때문에 원치 않는 동작이 나오는 현상을 막기 위한 함수입니다.
        /// </summary>
        public static void ExceptionCheck(Action action)
        {
            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Error Func : ").Append(action.Method.Name);
                stringBuilder.Append("\n Error 발생 : ").Append(e.Message);
                stringBuilder.Append("\n StackTrace : ").Append(e.StackTrace);
                stringBuilder.Append("\n HelpLink : ").Append(e.HelpLink);
                stringBuilder.Append("\n Source : ").Append(e.Source);
                Debug.LogError(stringBuilder.ToString());
            }
            finally
            {
                // 구현이 필요한 경우에 구현합니다. 
            }
        }
        #endregion

        /// <summary>
        /// 현재 메모리 체크 함수
        /// </summary>
        public static void GetMemory()
        {
            Debug.Log("Cur Memory : " + GC.GetTotalMemory(false));
        }
    }

    /// <summary>
    /// 알고리즘이 필요한 경우에 사용하도록 함수로 정리한 클래스입니다.
    /// </summary>
    public class Algorithm_Utils
    {

    }
}
