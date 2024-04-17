using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

namespace JJW_Utils
{
    /// <summary>
    /// CSV ���� �Լ��� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class CSV_Utils
    {
        private static readonly string ColumnToIgnoreKey = "BlankField";
        private static ArrayList IgnoreColumn = new ArrayList();

        #region Ư�� ���� ó������ �ʴ� ����
        /// <summary>
        /// Ư�� ���� ���° �࿡ �����ϴ��� ã�� �Լ��Դϴ�.
        /// </summary>
        /// <param name="_StrHeader">
        /// ã������ �ϴ� ������ ù��° ���� �־��ּ���.
        /// </param>
        /// <returns>
        /// �����ؾ� �ϴ� ���� ������ ����ϴ� ��̸���Ʈ�� �Ѱ��ݴϴ�.
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
        /// �����ؾ� �ϴ� ���� ã�� �迭�� �ٽ� ������ִ� �Լ��Դϴ�.
        /// </summary>
        /// <param name="_StrArray">
        /// ������ �迭���� �־��ݴϴ�.
        /// </param>
        /// <param name="arrayList"></param>
        /// <returns>
        /// �����ؾ� �ϴ� ���� ������ ��� ����Ʈ�� string[]�� �־��� �� �ٽ� ��ȯ���ݴϴ�.
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

        #region �࿡�� Ư�� ���� ó������ �ʴ� ����
        /// <summary>
        /// �࿡�� Ư�� ���� ã�� ���� �ʴ� �Լ��Դϴ�.
        /// </summary>
        /// <param name="_StrArray">
        /// ������ �迭 ���� �־��ݴϴ�.
        /// </param>
        /// <param name="_StrKey">
        /// Ư�� ���� ã�� Ű�����Դϴ�.
        /// </param>
        /// <returns></returns>
        public static String[] Delete_Column_From_Row(String[] _StrArray, string _StrKey)
        {
            /// Where() -> �� ��Ҹ� ��ȸ�ϸ鼭 �־��� ������ �����ϴ� ��ҵ鸸 ��ȯ
            /// !item.Contains("/T") -> �� ��Ҹ� ��ȸ�ϸ鼭 "/T" �� �������� �ʴ� ��ҵ��� ��ȯ
            /// ToArray() -> ���ο� �迭 ����

            return _StrArray = _StrArray.Where(item => !item.Contains(_StrKey)).ToArray();
        }
        #endregion

        /// <summary>
        /// CSV ������ ���� �� Ư�� ��ȣ�� ����Ͽ� �Ľ��ϴ� ��Ȳ���� int ���� �޾ƿ� �� string �Լ��� .Split()�� ���� ����ϱ� ���� ���� �Լ�
        /// </summary>
        /// <param name="strArray">
        /// �������� �о� �� ���ڰ��Դϴ�.
        /// </param>
        /// <param name="bSkip">
        /// true �� �� �������� 0�� ���� �ʽ��ϴ�.
        /// </param>
        /// <param name="delimiter">
        /// �Ľ��� �� ����� Ư�� ��ȣ�Դϴ�.
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
    /// UI ���� �Լ��� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class UI_Utils
    {
        /// <summary>
        /// �������� �߰��� ��쿡 ����Ʈ ����� �÷��ִ� �Լ��Դϴ�.
        /// </summary>
        /// <param name="rect_1">
        /// �������� ����Ʈ �Դϴ�.
        /// </param>
        /// <param name="rect_2">
        /// �������� �ڽ����� �������ִ� �θ� ������Ʈ�Դϴ�.
        /// </param>
        /// <param name="iMaxCount">
        /// ���� 'rect'�� �ڽ����� �� �� �ִ� �������� �ִ� �����Դϴ�.
        /// </param>
        /// <param name="iOrignHeight">
        /// 'rect'�� ���� Height ���Դϴ�.
        /// </param>
        /// <param name="iPlusHeight">
        /// �������� �߰��ǿ� ���� �þ�� �� �� �ʿ��� ���̰��Դϴ�.
        /// </param>
        public static void ListIconSizeCheck(RectTransform rect_1, RectTransform rect_2, int iMaxCount, int iOrignHeight, int iPlusHeight)
        {
            int iActiveCnt = 0;

            // �ڽ����� �ִ� ������Ʈ �߿��� Ȱ��ȭ�� �� ������Ʈ�� ã���ϴ�.
            for (int i = 0; i < rect_1.childCount; i++)
            {
                if (rect_1.GetChild(i).gameObject.activeSelf)
                {
                    iActiveCnt++;
                }
            }

            // ������ �������� ���ٸ�
            if (iMaxCount < iActiveCnt)
            {
                int iPlusCnt = 0;

                // ���������� ���ְ�
                iActiveCnt -= iMaxCount;

                // ���� ���ϱ�
                iPlusCnt += iActiveCnt / 5;

                if (iActiveCnt % 5 != 0)
                {
                    iPlusCnt++;
                }

                // ���� ������� �������ְ�
                rect_2.sizeDelta = new Vector2(rect_2.sizeDelta.x, iOrignHeight);

                // �ٲ��ش�.
                rect_2.sizeDelta = new Vector2(rect_2.sizeDelta.x, rect_2.sizeDelta.y + (iPlusHeight * iPlusCnt));
            }
            // �ƴ϶��
            else
            {
                // �ٲ� ���¶��
                if (iOrignHeight < rect_2.sizeDelta.y)
                {
                    rect_2.sizeDelta = new Vector2(rect_2.sizeDelta.x, iOrignHeight);
                }
                else
                    return;
            }
        }

        /// <summary>
        /// �̹����� Ŭ���� ���� ��Ʈ���� A���� ��ȯ���ִ� �Լ�
        /// </summary>
        /// <param name="image">
        /// ���ǿ� �� �̹��� ������Ʈ
        /// </param>
        /// <param name="fLimitAlpha">
        /// ������ ���� ��
        /// </param>
        /// <returns>
        /// ���ǿ� ���� ��ȯ
        /// </returns>
        public static bool ImageAlphaCheck(UnityEngine.UI.Image image, float fLimitAlpha)
        {
            Vector2 mousePosition = Input.mousePosition;
            RectTransform imageRect = image.rectTransform;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(imageRect, mousePosition, null, out Vector2 localPoint))
            {
                // �̹����� ���� ��ǥ�� ����ȭ ��ǥ�� ��ȯ
                Vector2 normalizedPoint = new Vector2((localPoint.x + imageRect.rect.width / 2) / imageRect.rect.width,
                                                      (localPoint.y + imageRect.rect.height / 2) / imageRect.rect.height);

                // �ؽ�ó ��ǥ�� ��ȯ
                Vector2 textureCoord = new Vector2(normalizedPoint.x * image.sprite.texture.width,
                                                   normalizedPoint.y * image.sprite.texture.height);

                // �ؽ�ó ��ǥ���� �ȼ� ���� ������
                Color pixelColor = image.sprite.texture.GetPixel((int)textureCoord.x, (int)textureCoord.y);

                // Alpha ���� ��ȯ
                float alphaValue = pixelColor.a;

                Debug.Log("Clicked Pixel Alpha Value: " + alphaValue);

                if (alphaValue < fLimitAlpha)
                    return true;
            }
            return false;
        }
    }

    /// <summary>
    /// �ð� ���� �Լ��� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class Time_Utils
    {
        /// <summary>
        /// �ð� ǥ�� Ÿ��
        /// </summary>
        public enum TimeFormat
        {
            /// <summary>
            /// �⺻���� �ð� ǥ�� ����Դϴ�. (��: '��','�ð�','��','��')
            /// </summary>
            BASIC = 0,

            /// <summary>
            /// �⺻���� �ð� ǥ�� ��Ŀ��� '�ð�' -> '��'�� �ٲ� ����Դϴ�.  (��: '��','��','��','��')
            /// </summary>
            BASIC_SHORT,

            /// <summary>
            /// ��ü ��¥ ǥ�ø� ��Ÿ���ϴ�. (��: "yyyy�� m�� d�� h�� m�� s��")
            /// </summary>
            FULLDATA,

            /// <summary>
            /// ��ü ��¥ ǥ�ø� �ϱ����� ǥ�����ݴϴ�. (��: "yyyy�� - m�� - d��")
            /// </summary>
            FULLDATA_DAY_UNTIL,

            /// <summary>
            /// ��ü ��¥ ǥ�ø� �ñ����� ǥ�����ݴϴ�. (��: "yyyy�� - m�� - d�� - h��")
            /// </summary>
            FULLDATA_HOUR_UNTIL,

            /// <summary>
            /// ��ü ��¥ ǥ�ø� �б����� ǥ�����ݴϴ�. (��: "yyyy�� - m�� - d�� - h�� m��")
            /// </summary>
            FULLDATA_MINUTES_UNTIL,

            /// <summary>
            /// ���̵峪 ������ ���� ����� ���� �ð��� �����ִ� ����Դϴ�. (��: "hh : mm")
            /// </summary>
            REMAIN_TIMER
        }

        /// <summary>
        /// ToString() ǥ�� Ÿ��
        /// </summary>
        public enum ToStringFormat
        {
            /// <summary>
            /// �ƹ��� ��ĵ� ������� �ʽ��ϴ�. (�� : ToString(""))
            /// </summary>
            NONE,

            /// <summary>
            /// 0 �Ѱ��� ���Դϴ�. (�� : ToString("0"))
            /// </summary>
            One_Digit_Zero,

            /// <summary>
            /// 0 �ΰ��� ���Դϴ�. (�� : ToString("00"))
            /// </summary>
            Two_Digit_Zero,
        }

        /// <summary>
        /// ���� ������ Ű ���� ������ �� �ʿ��� enum �� �Դϴ�.
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

        #region �ð� ���� ��� �Լ�
        /// <summary>
        /// �������� �ð����� �����ϴ� �Լ��Դϴ�.
        /// </summary>
        /// <param name="_i32DifferTimeStamp">
        /// �������� �ð����� ���� �ִ� �κ��Դϴ�. (CreateMyCharacter_New(),SM_TIMESTAMP ��Ŷ,SM_TIMESTAMP_REQUEST ��Ŷ) ��� ��
        /// </param>
        public static void GetDifferTimeStamp(int _i32DifferTimeStamp)
        {
            iDifferTimeStamp = _i32DifferTimeStamp;
        }

        /// <summary>
        /// �ѱ� ǥ�ؽ�(KST, Korean Standard Time) �������� ���� ��¥�� �ð��� ��ȯ�ϴ� �Լ�
        /// </summary>
        /// <returns>
        /// ���� �ý��� �ð��� �������� �ð����� 32400��(9�ð�)�� ���� ���� �������� �ѱ� �ð��� ����Ͽ� ��ȯ
        /// </returns>
        public static DateTime GetDateTime_ByKor()
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(GetTimestampNow_ByServer() + 32400);
            return dtDateTime;
        }

        /// <summary>
        /// UNIX Epoch �ð�(1970�� 1�� 1�� 0�� 0�� 0�� UTC���� ����� �ð��� �ʷ� ��Ÿ�� ��)�� �Է¹޾� �ش� �ð��� �ѱ� ǥ�ؽ�(KST)�� ��ȯ�Ͽ� ��ȯ�ϴ� �Լ�
        /// </summary>
        /// <param name="TimeStamp">
        /// ���� ���Ϸ��� Ÿ�� ������ ��
        /// </param>
        /// <returns>
        /// �Է����� �־��� TimeStamp�� 32400��(9�ð�)�� ���� ���� �������� �ѱ� �ð��� ����Ͽ� ��ȯ
        /// </returns>
        public static DateTime GetDateTime_ByKor(uint TimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(TimeStamp + 32400);
            return dtDateTime;
        }

        /// <summary>
        /// UNIX Epoch �ð�(1970�� 1�� 1�� 0�� 0�� 0�� UTC���� ����� �ð��� �ʷ� ��Ÿ�� ��)�� �Է¹޾� �ش� �ð��� UTC �������� ��ȯ�Ͽ� ��ȯ�ϴ� �Լ�
        /// </summary>
        /// <param name="TimeStamp">
        /// ���� ���Ϸ��� Ÿ�� ������ ��
        /// </param>
        /// <returns>
        /// �Է����� �־��� TimeStamp�� �� ������ �ؼ��Ͽ� UTC �ð����� ��ȯ�ϰ� �̸� ToLocalTime() �޼��带 ����Ͽ� ���� �ð����� ��ȯ
        /// </returns>
        public static DateTime GetDateTime(uint TimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(TimeStamp).ToLocalTime();
            return dtDateTime;
        }

        /// <summary>
        /// �־��� DateTime ��ü�� ��������, �ش� �ð����� 1970�� 1�� 1�� 0�� 0�� 0�� UTC������ ��� �ð��� �ʷ� ��Ÿ�� ���� ��ȯ�ϴ� �Լ�
        /// </summary>
        /// <param name="dateTime">
        /// ������ �� detaTime �Դϴ�
        /// </param>
        public static uint GetTimestamp(DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return Convert.ToUInt32(timeSpan.TotalSeconds);
        }

        /// <summary>
        /// ���� �ý��� �ð��� UTC �������� ����Ͽ�, �ش� �ð����� 1970�� 1�� 1�� 0�� 0�� 0�� UTC������ ��� �ð��� �ʷ� ��Ÿ�� ���� ��ȯ�ϴ� �Լ�
        /// </summary>
        public static uint GetTimestampNow()
        {
            return GetTimestamp(DateTime.Now.ToLocalTime());
        }


        /// <summary>
        /// GetTimestampNow() �Լ��� ȣ���Ͽ� ���� �ý��� �ð��� UTC �������� ����� ��, �������� �ð����� iDifferTimeStamp ���� ���Ͽ� �������� �ð� ���� ��ȯ�ϴ� �Լ�
        /// </summary>
        public static uint GetTimestampNow_ByServer()
        {
            return (uint)(GetTimestamp(DateTime.Now.ToLocalTime()) + iDifferTimeStamp);
        }

        /// <summary>
        /// ���� �ý��� �ð��� �������� ���� �ð����� 1970�� 1�� 1�� 0�� 0�� 0�� UTC������ ��� �ð��� �и���(ms)�� ��Ÿ���� ���� ��ȯ�ϴ� �Լ�
        /// �� �Լ��� DateTime.Now.ToLocalTime()�� ȣ���Ͽ� ���� �ý��� �ð��� ���� �ð����� ��ȯ�� ��, �̸� �Է����� �Ͽ� GetTimestampM(DateTime dateTime) �Լ��� ȣ���մϴ�.
        /// </summary>
        public static double GetTimestampNowM()
        {
            return GetTimestampM(DateTime.Now.ToLocalTime());
        }

        /// <summary>
        /// �־��� DateTime ��ü�� �������� �ش� �ð����� 1970�� 1�� 1�� 0�� 0�� 0�� UTC������ ��� �ð��� �и���(ms)�� ��Ÿ���� ���� ��ȯ�ϴ� �Լ�
        /// </summary>
        /// <param name="dateTime">
        /// DateTime ��ü�� �������� TimeSpan ����ü�� ����Ͽ� dateTime�� 1970�� 1�� 1�� 0�� 0�� 0�� UTC ���� �ð� ������ ����մϴ�.
        /// </param>
        /// <returns>
        /// �ش� �ð� ������ �и��ʷ� ��ȯ�Ͽ� ��ȯ
        /// </returns>
        public static double GetTimestampM(DateTime dateTime)
        {
            TimeSpan timeSpan = dateTime - new DateTime(1970, 1, 1, 0, 0, 0, 0).ToLocalTime();
            return timeSpan.TotalMilliseconds;
        }

        /// <summary>
        /// ����ð��� ���� TimeStamp�� �������� True/False �� ��ȯ�ϴ� �Լ� 
        /// <para>
        /// ���� TimeStamp���� �ִ´ٸ� ���� �ð��� ���۰� ���� TimeStamp �������� True/False ��ȯ
        /// </para>
        /// </summary>
        /// <param name="startTime">
        /// ���� ���� TimeStamp �Դϴ�.
        /// </param>
        /// <param name="endTime">
        /// ���� ���� TimeStamp �Դϴ�.
        /// </param>
        /// <returns>
        /// ���� �ð��� ���ǿ� �����ϴ��� True/False ��ȯ
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

        #region �ð� ǥ�� �Լ�

        /// <summary>
        /// ���� �ð��� string ���� ��ȯ���ִ� �Լ��Դϴ�.
        /// </summary>
        /// <param name="uTime">
        /// ������� �� �ð� ��
        /// </param>
        /// <param name="timeFormat">
        /// �ð� ǥ�� ���
        /// </param>
        /// <param name="toStringFormat">
        /// ToString() ǥ�� ���
        /// </param>
        /// <param name="bShort">
        /// ���� ���� (�� : hh�� mm�� -> hh - mm)
        /// <param name="bUseDay">
        /// '��'�� ǥ�� ����
        /// </param>
        /// <returns>
        /// �� Ÿ�Կ� �´� �ð� ���� ����ڰ� ������ ǥ�� ��İ� �Ű� ������ ����� ���� string���� ��ȯ�մϴ�.
        /// </returns>
        public static string GetTimeStr_Remain_Basic(uint uTime, TimeFormat timeFormat, ToStringFormat toStringFormat = ToStringFormat.NONE, bool bShort = false, bool bRemain = false, bool bUseDay = false)
        {
            string strReturn = "";

            // Ű�� ������ִ� �κ��Դϴ�.
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
    /// ��Ʈ ��� ���� �Լ��� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class Bit_Utils
    {
        /// <summary>
        /// ��Ʈ�� �ֿ��� �������� ���ؿ��� �Լ��Դϴ�.
        /// </summary>
        /// <param name="targetVar">
        /// ��Ʈ�� ����� ���� �־��ݴϴ�.
        /// </param>
        /// <param name="initVar">
        /// �� ��Ʈ�� ����ϴ����� ���� �־��ֽø� �˴ϴ�.
        /// <para>
        /// ex) 0000 = 0, 0001 = 1, 0010 = 2, 0011 = 3....
        /// </para>
        /// </param>
        /// <param name="shift">
        /// � ��ġ�� ���� ���������� �ϴ����� ���� �־��ֽø� �˴ϴ�.
        /// </param>
        /// <returns>
        /// ���ϴ� �ڸ��� ��Ʈ���� ��ȯ���ݴϴ�.
        /// </returns>
        public static uint GetOut_InBits(uint targetVar, uint initVar, int shift)  //  ���, �ڸ���, ��ġ
        {
            uint uVar = initVar; // uVar = 1
            uVar = uVar << shift; //   = 1 << 6
            uVar = targetVar & uVar;  //0100 0000
            uVar = uVar >> shift; //   
            return uVar;        // 0
        }


        /// <summary>
        /// ��Ʈ�� �о �־��ִ� �Լ��Դϴ�.
        /// </summary>
        /// <typeparam name="T">
        /// PushValue�� ���� �ڷ����� �־��ݴϴ�.
        /// </typeparam>
        /// <param name="BaseValue">
        /// �з��� �ϴ� ���� �־��ݴϴ�.
        /// </param>
        /// <param name="Power">
        /// ��ŭ �з������� ���� ���� �־��ݴϴ�.
        /// </param>
        /// <param name="Pushvalue">
        /// �о��� ��Ʈ�� ���� �־��ݴϴ�.
        /// </param>
        /// <returns>
        /// �о��ְ� �� �ڿ� ��Ʈ���� ��ȯ���ݴϴ�.
        /// </returns>
        public static uint Pushbit<T>(uint BaseValue, int Power, T Pushvalue)
        {
            BaseValue = BaseValue << Power;
            BaseValue = BaseValue | Convert.ToUInt32(Pushvalue);
            return BaseValue;
        }

        /// <summary>
        /// ��ġ�� �̵���Ű�� ��Ʈ�� ���ؿ��� �Լ��Դϴ�.
        /// </summary>
        /// <param name="src">
        /// ��Ʈ�� ����ϱ� ���� ���� �־��ݴϴ�.
        /// </param>
        /// <param name="start">
        /// ���Ʈ��ŭ ���������� ����Ʈ ��ų���� ���� �����Դϴ�.
        /// </param>
        /// <param name="size">
        /// ����,���������� ��Ʈ�� ����Ʈ ��ų���� ���� �����Դϴ�.
        /// </param>
        /// <returns>
        /// ���ϴ� �ڸ��� ��Ʈ���� ��ȯ���ݴϴ�.
        /// </returns>
        public uint BitSplitter_Right(uint src, int start, int size)  //  ���, �ڸ���, ��ġ
        {
            src = src >> start;
            src = src << 32 - size;
            return src >> 32 - size;
        }

        /// <summary>
        /// ��Ʈ�� ���� �ٲ��ִ� �Լ�
        /// </summary>
        /// <param name="targetVar">
        /// �ٲ��� ��� ��
        /// </param>
        /// <param name="controlVar">
        /// �ٲ��� ��
        /// </param>
        /// <param name="shift">
        /// �ٲ��� ��ġ
        /// </param>
        /// <param name="bit">
        /// �ٲ��� �ڸ���
        /// </param>
        /// <returns></returns>
        public uint SetSettingVar_InBits(uint targetVar, uint controlVar, int shift, int bit)   //  ���, ��, ��ġ, �ڸ���
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

            #region ����
            //0000 0000 0000 0000 0000 0000 1111 0000   //  ��� ��ġ��ŭ �δ�
            //1111 1111 1111 1111 1111 1111 1111 1111   //  4294967295
            //1111 1111 1111 1111 1111 1111 0000 1111   //  uInitVar �� �����        
            //1010 1010 1010 1010 1010 1010 0000 1010   //  ����� ��ġ�� ����      
            //0000 0000 0000 0000 0000 0000 1010 0000   //  �����Ұ��� ��ġ��ŭ �δ�
            //1010 1010 1010 1010 1010 1010 0000 1010   //  ����
            //1010 1010 1010 1010 1010 1010 1010 1010   //  ���
            #endregion

            // ��� ��ġ��ŭ �δ�
            uInitVar = uInitVar << shift;

            //  uInitVar �� �����
            uInitVar = 4294967295 ^ uInitVar;

            // ^  = XOR ����
            uVar = targetVar & uInitVar;

            // �ٲ��� ���� ��ġ��ŭ �δ�
            controlVar = controlVar << shift;

            // | = OR ����
            uVar = uVar | controlVar;
            return uVar;
        }
    }

    /// <summary>
    /// �÷� ���� ���� �Լ��� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class Color_Utils
    {
        /// <summary>
        /// �� ��Ȳ�� ���� �÷������� �̸� �����մϴ�.
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
        /// ����ڵ带 �ް� �÷����� ��ȯ���ִ� �Լ��Դϴ�.
        /// </summary>
        /// <param name="hexadecimalColor">
        /// ����ڵ�
        /// </param>
        /// <returns>
        /// ����ڵ忡 ���� �÷��� ��ȯ
        /// </returns>
        public static Color GetColorByHexadecimal(string hexadecimalColor)
        {
            // SetTextColor ��� �κ� GetColorByHexadecimal()�̰ɷ� ��ü �� Get_TextColorType(textColor) �Ű� ���� ��� ȣ��

            Color _color;
            ColorUtility.TryParseHtmlString(hexadecimalColor, out _color);
            return _color;
        }

        /// <summary>
        /// TextColorType Ÿ�Կ� ���� ����ڵ带 ��ȯ���ִ� �Լ��Դϴ�.
        /// </summary>
        /// <param name="color">
        /// TextColorType�� �־��ݴϴ�.
        /// </param>
        /// <returns>
        /// TextColorType�� ���� ����ڵ尪 ��ȯ
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
        /// ��޿� ���� �÷����� �޾ƿ��� ���� �Լ��Դϴ�.
        /// </summary>
        /// <param name="Rank">
        /// ���
        /// </param>
        /// <returns>
        /// ��޿� ���� enum�� ��ȯ
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
        /// enum���� ���� ������ ��ġ�ؽ�Ʈ�������� ��ȯ�ؼ� ��ȯ���ݴϴ�.
        /// </summary>
        /// <param name="color">
        /// �ٲ��� �÷� ��
        /// </param>
        /// <param name="text">
        /// �ٲ��� ����
        /// </param>
        /// <returns>
        /// �÷� ���� �� ��ġ�ؽ�Ʈ�������� ��ȯ���ݴϴ�.
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
    /// ���� ���� �Լ��� ������ Ŭ���� �Դϴ�.
    /// </summary>
    public class Version_Utils
    {

    }

    /// <summary>
    /// ���� �Լ��� ������ Ŭ���� �Դϴ�.
    /// </summary>
    public class ETC
    {
        #region Exception
        /// <summary>
        /// ���� �÷��� ���߿� Exception ������ ��ġ �ʴ� ������ ������ ������ ���� ���� �Լ��Դϴ�.
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
                stringBuilder.Append("\n Error �߻� : ").Append(e.Message);
                stringBuilder.Append("\n StackTrace : ").Append(e.StackTrace);
                stringBuilder.Append("\n HelpLink : ").Append(e.HelpLink);
                stringBuilder.Append("\n Source : ").Append(e.Source);
                Debug.LogError(stringBuilder.ToString());
            }
            finally
            {
                // ������ �ʿ��� ��쿡 �����մϴ�. 
            }
        }
        #endregion

        /// <summary>
        /// ���� �޸� üũ �Լ�
        /// </summary>
        public static void GetMemory()
        {
            Debug.Log("Cur Memory : " + GC.GetTotalMemory(false));
        }
    }

    /// <summary>
    /// �˰����� �ʿ��� ��쿡 ����ϵ��� �Լ��� ������ Ŭ�����Դϴ�.
    /// </summary>
    public class Algorithm_Utils
    {

    }
}
