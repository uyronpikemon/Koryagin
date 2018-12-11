using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tryea
{
    class Language
    {
        public int f1(string _str)
        {
            string t = "01234567";
            string alf = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string t0 = "89";
            if(t.Contains(_str))
            {
                return 0;
            }
            else
            {
                if(alf.Contains(_str))
                {
                    Console.WriteLine("БУКВА");
                    return 1;
                }
                else
                {
                    if(t0.Contains(_str))
                    {
                        Console.WriteLine("8 9");
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("ДРУГОЙСИМВОЛ");
                        return 1;
                    }
                }
            }
        }

        public int f2(string _str)
        {
            string t = "0123456789";
            string alf = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

            if (alf.Contains(_str))
            {
                return 0;
            }
            else
            {
                if (t.Contains(_str))
                {
                    Console.WriteLine("ЦИФРА");
                    return 1;
                }
                else
                {
                    Console.WriteLine("ДРУГОЙСИМВОЛ");
                    return 1;
                }
            }
        }

        public int f3(string _str)
        {
            if(f1(_str) == 1 || f2(_str) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int perem(string _str)
        {
            Regex regex = new Regex(@"[A-Za-z]{1}[A-Za-z0-7]*");
            MatchCollection matches = regex.Matches(_str);
            if (matches.Count > 0)
            {
                //foreach (Match match in matches)
                    //Console.WriteLine(match.Value);
                return 0;
            }
            else
            {
                Console.WriteLine("Совпадений не найдено perem");
                return 1;
            }
        }

        public int u(string _str)
        {
            Regex regex = new Regex(@"[0-7]+");
            MatchCollection matches = regex.Matches(_str);
            if (matches.Count > 0)
            {
                //foreach (Match match in matches)
                    //Console.WriteLine(match.Value);
                return 0;
            }
            else
            {
                Console.WriteLine("Совпадений не найдено u");
                return 1;
            }
        }

        public int B4(string _str)
        {
            if(perem(_str) == 1 && u(_str) == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }

    
    class Program
    {
        public List<string> List_Perem = new List<string>();

        double[] Perem_Value;

        int[] deg;

        public int Perem(string _str)
        {

            Regex regex = new Regex(@"^[A-Za-z]{1}[A-Za-z0-7]*$");
            Match match = regex.Match(_str);
            if (match.Success)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        int Uel(string _str)
        {
            Regex regex = new Regex(@"^[0-7]+$");
            Match match = regex.Match(_str);
            if (match.Success)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        double B4(string _str)
        {
            if (_str == "")
            {
                Console.WriteLine("Пустая строка: " + _str);
                return -200000000.123;
            }
            else
            {
                if(Uel(_str) == 0)
                {
                    try
                    {
                        return Convert.ToDouble(_str);
                    }
                    catch
                    {
                        FormatException ex = new FormatException("Kak Tak?");
                        Console.WriteLine(ex.ToString());
                        return -200000000.125;//хз чо жто
                    }
                }
                else
                {
                    if(Perem(_str) == 0)
                    {
                        if (List_Perem.Contains(_str))
                        {
                            if (Perem_Value[List_Perem.IndexOf(_str)] != -21038135135)
                            {
                                return Perem_Value[List_Perem.IndexOf(_str)];
                            }
                            else
                            {
                                Console.WriteLine("Использована переменаня, которое не присвоено значение " + _str);
                                return -200000000.124;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Использована необозначенная ранее переменаня " + _str);
                            return -200000000.124;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Неизвестный текст: " + _str);
                        return -200000000.124;
                    }
                }
            }
        }

        double B3(string _str)
        {
            List<double> res_B3 = new List<double>();
            List<int> tr_B3 = new List<int>();
            List<string> func = new List<string>();

            string sr = "";
            double a;

            Regex regex = new Regex(@"^(sin|cos|abs)([0-7]+|[A-Za-z]{1}[A-Za-z0-7]*)$");
            Match match = regex.Match(_str);
            if (match.Success)
            {
                for (int i = 0; i < _str.Length - 2; i++)
                {
                    sr = sr + _str[i] + _str[i + 1] + _str[i + 2];
                    if (sr == "sin")
                    {
                        func.Add("sin");
                    }
                    if (sr == "cos")
                    {
                        func.Add("cos");
                    }
                    if (sr == "abs")
                    {
                        func.Add("abs");
                    }
                    sr = "";
                }
                
                string[] strs = _str.Split(new string[] { "sin", "cos", "abs" }, StringSplitOptions.RemoveEmptyEntries);
                
                if(strs.Count() > 1 || strs.Count() < 1)
                {
                    return B4(_str);//?
                }
                else
                {
                    if (B4(strs[0]) < -200000000)
                    {
                        return -200000000.127;
                    }
                    else
                    {
                        a = B4(strs[0]);
                        for (int i = func.Count - 1; i >= 0; i--)
                        {
                            if(func[i] == "sin")
                            {
                                a = Math.Sin(a * (Math.PI / 180));
                            }
                            if (func[i] == "cos")
                            {
                                a = Math.Cos(a * (Math.PI / 180));
                            }
                            if (func[i] == "abs")
                            {
                                a = Math.Abs(a);
                            }
                        }
                        return a;
                    }
                }
            }
            else
            {
                if(B4(_str) < -200000000)
                {
                    Console.WriteLine("Неправильно написана функция: " + _str);
                    return -200000000.126;
                }
                else
                {
                    return B4(_str);
                }
            }
        }

        double B2(string _str)
        {
            double a = 0;
            List<double> res_B2 = new List<double>();
            List<int> tr_B2 = new List<int>();

            for (int i = 0; i < _str.Length; i++)
            {
                if (_str[i] == '^')
                {
                    tr_B2.Add(i);
                }
            }

            string[] strs = _str.Split(new char[] { '^' });
            foreach (string s in strs)
            {
                if (s.Contains("sin") || s.Contains("cos") || s.Contains("abs"))
                {
                    if(B3(s) < -200000000)
                    {
                        //Console.WriteLine("B2, sin,cos,abs.Contains: " + s);
                        return -200000000.128;
                    }
                    else
                    {
                        res_B2.Add(B3(s));
                    }
                }
                else
                {
                    if(B4(s) < -200000000)
                    {
                        //Console.WriteLine("B2, !sin,cos,abs.Contains: " + s);
                        return -200000000.129;
                    }
                    else
                    {
                        res_B2.Add(B4(s));
                    }
                }
            }

            if(res_B2.Count > 1)
            {
                a = res_B2[tr_B2.Count];

                for (int i = tr_B2.Count; i > 0; i--)
                {
                    a = Math.Pow(res_B2[i - 1], a);
                }
                return a;
            }
            else
            {
                return res_B2[0];
            }
        }

        double B1(string _str)
        {
            double a = 0;

            List<double> res_B1 = new List<double>();
            List<int> tr_B1 = new List<int>();

            for(int i = 0; i < _str.Length; i++)
            {
                if (_str[i] == '*' || _str[i] == '/')
                {
                    tr_B1.Add(i);
                }
            }

            string[] strs = _str.Split(new char[] { '*', '/' });
            foreach (string s in strs)
            {
                if (s.Contains('^'))
                {
                    if(B2(s) < -200000000)
                    {
                        //Console.WriteLine("B1, ^" + s);
                        return -200000000.130;
                    }
                    else
                    {
                        res_B1.Add(B2(s));
                    }
                }
                else
                {
                    if(s.Contains("sin") || s.Contains("cos") || s.Contains("abs"))
                    {
                        if(B3(s) < -200000000)
                        {
                            //Console.WriteLine("B1, sin,cos,abs.Contains: " + s);
                            return -200000000.131;
                        }
                        else
                        {
                            res_B1.Add(B3(s));
                        }
                    }
                    else
                    {
                        if (B4(s) < -200000000)
                        {
                            //Console.WriteLine("B1, !sin,cos,abs.Contains: " + s);
                            return -200000000.132;
                        }
                        else
                        {
                            res_B1.Add(B4(s));
                        }
                    }
                }
            }

            if(res_B1.Count > 1)
            {
                a = res_B1[0];
                
                for (int i = 0; i < tr_B1.Count; i++)
                {
                    if(_str[tr_B1[i]] == '*')
                    {
                        a = a * res_B1[i + 1];
                    }
                    else
                    {
                        if(_str[tr_B1[i]] == '/')
                        {
                            if(res_B1[i + 1] != 0)
                            {
                                a = a / res_B1[i + 1];
                            }
                            else
                            {
                                Console.WriteLine("ДЕление на 0");
                                return -200000000.137;
                            }
                        }
                    }
                }
                return a;
            }
            else
            {
                return (res_B1[0]);
            }
        }

        double PrCh(string _str)
        {
            List<int> Zn = new List<int>();
            int t = 0;

            for (int i = 0; i < _str.Length; i++)
            {
                if (_str[i] == '+' || _str[i] == '-' || _str[i] == '*' || _str[i] == '/' || _str[i] == '^')
                {
                    Zn.Add(i);
                }
            }

            for(int i = 0; i < Zn.Count - 1; i++)
            {
                if((Zn[i] + 1) == Zn[i + 1])
                {
                    t++;
                }
            }

            if (t > 0)
            {
                Console.WriteLine("Два знака подряд");
                return -200000000.138;
            }
            else
            {
                double a = 0;

                List<double> res_PrCh = new List<double>();
                List<int> tr_PrCh = new List<int>();

                for (int i = 0; i < _str.Length; i++)
                {
                    if (_str[i] == '+' || _str[i] == '-')
                    {
                        tr_PrCh.Add(i);
                    }
                }

                if (tr_PrCh.Count > 0)
                {
                    if (tr_PrCh[0] == 0 && (_str[tr_PrCh[0]] == '-' || _str[tr_PrCh[0]] == '+'))
                    {
                        tr_PrCh.Clear();
                        _str = "0" + _str;

                        for (int i = 0; i < _str.Length; i++)
                        {
                            if (_str[i] == '+' || _str[i] == '-')
                            {
                                tr_PrCh.Add(i);
                            }
                        }
                    }
                }
                
                string[] strs = _str.Split(new char[] { '+', '-' });
                foreach (string s in strs)
                {
                    if (s.Contains('*') || s.Contains('/'))
                    {
                        if (B1(s) < -200000000)
                        {
                            //Console.WriteLine("PrCh, */ : " + s);
                            return -200000000.133;
                        }
                        else
                        {
                            res_PrCh.Add(B1(s));
                        }
                    }
                    else
                    {
                        if (s.Contains('^'))
                        {
                            if (B2(s) < -200000000)
                            {
                                //Console.WriteLine("PrCh, ^ : " + s);
                                return -200000000.134;
                            }
                            else
                            {
                                res_PrCh.Add(B2(s));
                            }
                        }
                        else
                        {
                            if (s.Contains("sin") || s.Contains("cos") || s.Contains("abs"))
                            {
                                if (B3(s) < -200000000)
                                {
                                    //Console.WriteLine("PrCh, sin,cos,abs.Contains : " + s);
                                    return -200000000.135;
                                }
                                else
                                {
                                    res_PrCh.Add(B3(s));
                                }
                            }
                            else
                            {
                                if (B4(s) < -200000000)
                                {
                                    //Console.WriteLine("PrCh, !sin,cos,abs.Contains : " + s);
                                    return -200000000.136;
                                }
                                else
                                {
                                    res_PrCh.Add(B4(s));
                                }
                            }
                        }
                    }
                }

                a = res_PrCh[0];

                for (int i = 0; i < tr_PrCh.Count; i++)
                {
                    if (_str[tr_PrCh[i]] == '+')
                    {
                        a = a + res_PrCh[i + 1];
                    }
                    else
                    {
                        if (_str[tr_PrCh[i]] == '-')
                        {
                            a = a - res_PrCh[i + 1];
                        }
                    }
                }
                return a;
            }
        }
        
        bool Oper(string _str)
        {
            List<string> Opers = new List<string>();
            Perem_Value = new double[List_Perem.Count];

            for (int i = 0; i < Perem_Value.Length; i++)
            {
                Perem_Value[i] = -21038135135;
            }

            Regex regex = new Regex(@"\s*[0-7]+:");
            MatchCollection matches = regex.Matches(_str);
            if (matches.Count > 0)
            {
                for(int i = 0; i < matches.Count; i++)
                {
                    if(matches.Count == i + 1)
                    {
                        Opers.Add(_str.Substring(matches[i].Index, _str.Length - matches[i].Index).Trim());
                    }
                    else
                    {
                        Opers.Add((_str.Substring(matches[i].Index, matches[i + 1].Index - matches[i].Index)).Trim());
                    }
                }
            }
            else
            {
                Console.WriteLine("wat");
                return false;
            }

            for(int i = 0; i < Opers.Count; i++)
            {
                Opers[i] = Opers[i].Replace(" ", "");
                string[] U = Opers[i].Split(new string[] { ":" }, StringSplitOptions.None);
                if(U[0] != "")
                {
                    if(U[1] != "")
                    {
                        string[] P = U[1].Split(new string[] { "=" }, StringSplitOptions.None);
                        if (P[0] != "")
                        {
                            if(Perem(P[0]) == 0)
                            {
                                if(List_Perem.Contains(P[0]))
                                {
                                    if(PrCh(P[1]) > -200000000)
                                    {
                                        Perem_Value[List_Perem.IndexOf(P[0])] = PrCh(P[1]);
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Неизвестная переменная " + P[0]);
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не переменная " + P[0]);
                                return false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пропущена переменная");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пропущена переменная и правая часть");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Пропущена \"Метка\"");
                    return false;
                }
            }
            //for(int i = 0; i < Perem_Value.Length; i++)
            //{
            //    Console.WriteLine(List_Perem[i] + " " + Perem_Value[i].ToString());
            //}
            return true;
        }
        
        bool Last(string _str)
        {
            _str = _str.Replace(" ", "");

            string[] srt = _str.Split(new char[] { ';' }, StringSplitOptions.None);
            foreach (string s in srt)
            {
                if(s != "")
                {
                    if (Perem(s) == 0)
                    {
                        if (List_Perem.Contains(s))
                        {
                            Console.WriteLine("Переменная в \"Последнем\" " + s + " уже была объявлена");
                            return false;
                        }
                        else
                        {
                            List_Perem.Add(s);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не переменная в \"Последнем\": " + s + ":");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Пропущена переменная в \"Последнем\"");
                    return false;
                }
            }
            return true;
        }
        
        bool Zveno(string _str)
        {
            List<string> strs_for_analize = new List<string>();
            List<int> possition_of_F_or_S = new List<int>();

            string[] sw = _str.Split(new string[] { "First", "Second" }, StringSplitOptions.None);
            foreach(string s in sw)
            {
                strs_for_analize.Add(s.Trim());
            }

            for(int i = 0; i < _str.Length - 5; i++)
            {
                if(_str[i] == 'F' && _str[i+1] == 'i' && _str[i+2] == 'r' && _str[i+3] == 's' && _str[i+4] == 't' )
                {
                    possition_of_F_or_S.Add(1);
                }
                if(_str[i] == 'S' && _str[i+1] == 'e' && _str[i+2] == 'c' && _str[i+3] == 'o' && _str[i+4] == 'n' && _str[i+5] == 'd')
                {
                    possition_of_F_or_S.Add(2);
                }
            }

            for (int i = 0; i < possition_of_F_or_S.Count; i++)
            {
                if (possition_of_F_or_S[i] == 1)
                {
                    if(strs_for_analize[i + 1] != "")
                    {
                        strs_for_analize[i + 1] = strs_for_analize[i + 1].Replace(" ", "");
                        string[] r = strs_for_analize[i + 1].Split(',');
                        for (int m = 0; m < r.Length; m++)
                        {
                            if (Uel(r[m]) != 0)
                            {
                                Console.WriteLine("Нецелое число после First " + r[m]);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пустая строка после First");
                        return false;
                    }
                }
                else
                {
                    if(strs_for_analize[i + 1] != "")
                    {
                        string[] r = strs_for_analize[i + 1].Split(new string[] { " " }, StringSplitOptions.None);
                        for (int n = 0; n < r.Length; n++)
                        {
                            if (Perem(r[n]) == 0)
                            {
                                if (List_Perem.Contains(r[n]))
                                {
                                    Console.WriteLine("Переменная перед Second " + r[n] + " уже была объявлена");
                                    return false;
                                }
                                else
                                {
                                    List_Perem.Add(r[n]);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Не переменная после Second: " + r[n]);
                                return false;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Пустая строка после Second");
                        return false;
                    }    
                }
            }
            return true;
        }

        bool Splt(string _str)
        {
            _str = _str.TrimStart().TrimEnd();
            List<int> fs = new List<int>();
            List<string> fss = new List<string>();
            int a = 0; //F\S
            int b = 0; //F\S
            int mat = 0;
            string toZveno = "";
            string toLast = "";
            string toOper = "";

            if (_str.Contains("First") || _str.Contains("Second"))
            {
                a = Math.Min(_str.IndexOf("First"), _str.IndexOf("Second"));
                for (int i = 0; i < a; i++)
                {
                    if (_str[i] != ' ')
                    {
                        b++;
                    }
                }//проверка на то, чтобы между Begin и F\S ничего не было, кроме пробелов
                if (b == 0)
                {
                    Regex regex_if_First_Is_In_Last_Zveno = new Regex(@"\s*[A-Za-z]{1}[A-Za-z0-9]*\s*;\s*");// 3 a2; a3; ...
                    Match match_if_First_Is_In_Last_Zveno = regex_if_First_Is_In_Last_Zveno.Match(_str);
                    Regex regex_if_Second_Is_In_Last_Zveno = new Regex(@"\s+[A-Za-z]{1}[A-Za-z0-9]*\s*;\s*");// a1 a2;a3 ...
                    Match match_if_Second_Is_In_Last_Zveno = regex_if_Second_Is_In_Last_Zveno.Match(_str);

                    if (match_if_First_Is_In_Last_Zveno.Success || match_if_Second_Is_In_Last_Zveno.Success)
                    {
                        if (match_if_First_Is_In_Last_Zveno.Success)
                        {
                            mat = match_if_First_Is_In_Last_Zveno.Index;
                        }
                        else
                        {
                            if (match_if_Second_Is_In_Last_Zveno.Success)
                            {
                                mat = match_if_Second_Is_In_Last_Zveno.Index;
                            }
                            else
                            {
                                Console.WriteLine("Wat");
                                return false;
                            }
                        }
                        toZveno = _str.Remove(mat).TrimEnd();
                        if(Zveno(toZveno))
                        {
                            Regex regex_for_Last = new Regex(@"\s*[0-7]+:");//5:a2=...
                            Match match_for_Last = regex_for_Last.Match(_str);
                            if (match_for_Last.Success)
                            {
                                toLast = _str.Remove(match_for_Last.Index);
                                toLast = toLast.Remove(0, mat).Trim();
                                if (Last(toLast))
                                {
                                    toOper = _str.Remove(0, match_for_Last.Index).Trim();

                                    if(Oper(toOper))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Отсутствует \"Оператор\"");
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Отсутствует \"Последнее\"");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Между Begin и Firts или Second есть что-то, кроме пробелов");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("В строке нет слово Firts и Second");
                return false;
            }
        }

        bool Language(string _sstr)
        {
            string _str = _sstr;
            _str = _str.TrimStart().TrimEnd();
            
            if (_str.Contains("Begin"))
            {
                if (_str.IndexOf("Begin") == 0)
                {
                    if (_str.LastIndexOf("Begin") == 0)
                    {
                        if(_str.Contains("End"))
                        {
                            if (_str.LastIndexOf("End") == _str.Length - 3)
                            {
                                if (_str.IndexOf("End") == _str.Length - 3)
                                {
                                    _str = _str.Remove(0, _str.IndexOf("Begin") + 5); //-Begin
                                    _str = _str.Remove(_str.Length - 3, 3); //-End
                                    
                                    if (Splt(_str))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Слово End встречено два раза");
                                    return false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Слово End не на последнем месте");
                                return false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Не встречено ключoe словo End");
                            return false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Слово Begin встречено два раза");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Слово Begin не на первом месте");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Не встречено ключевое слово Begin");
                return false;
            }
        }

        static void Main(string[] args)
        {

            Program F = new Program();

            string str = "BeginFirst3,8,64,1,2First 3,25 Second a2 a3 i g i3;m4;b 3:2=3*4*sin30 4:a3=3^2End";

            str = "Begin " +
                "First 3,25 Second a234 Second a2 a3 i g First3,7,64,1,2 Second a25 awwq erew q " +
                "i3;m4;b " +
                "3:a2=3*4*sin30 4:a3=3^2 5:i=a2*2 6:g=sincos30 5:a25 = a2*6 " +
                "End";
            
            Console.WriteLine("str: " + str);
            bool lang = F.Language(str);
            if (lang)
            {
                Console.WriteLine("Все верно ");
                for(int i = 0; i < F.List_Perem.Count; i++)
                {
                    if(F.Perem_Value[i] != -21038135135)
                    {
                        Console.WriteLine(F.List_Perem[i] + " = " + F.Perem_Value[i].ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine(lang.ToString());
            }

            Console.ReadKey();
        }
    }
}
