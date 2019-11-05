﻿using Masuit.Tools.Strings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Masuit.Tools
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class Extensions
    {
        #region SyncForEach

        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        public static void ForEach(this object[] objs, Action<object> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }

        /// <summary>
        /// 遍历IEnumerable
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        public static void ForEach(this IEnumerable<dynamic> objs, Action<object> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }

        /// <summary>
        /// 遍历集合
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        public static void ForEach(this IList<dynamic> objs, Action<object> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }

        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        public static void ForEach<T>(this T[] objs, Action<T> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }

        /// <summary>
        /// 遍历IEnumerable
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        public static void ForEach<T>(this IEnumerable<T> objs, Action<T> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }

        /// <summary>
        /// 遍历List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        public static void ForEach<T>(this IList<T> objs, Action<T> action)
        {
            foreach (var o in objs)
            {
                action(o);
            }
        }

        /// <summary>
        /// 遍历数组并返回一个新的List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this object[] objs, Func<object, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }

        /// <summary>
        /// 遍历IEnumerable并返回一个新的List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<dynamic> objs, Func<object, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }

        /// <summary>
        /// 遍历List并返回一个新的List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IList<dynamic> objs, Func<object, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }


        /// <summary>
        /// 遍历数组并返回一个新的List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this T[] objs, Func<T, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }

        /// <summary>
        /// 遍历IEnumerable并返回一个新的List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> objs, Func<T, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }

        /// <summary>
        /// 遍历List并返回一个新的List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IList<T> objs, Func<T, T> action)
        {
            foreach (var o in objs)
            {
                yield return action(o);
            }
        }

        #endregion

        #region AsyncForEach

        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        public static async void ForEachAsync(this object[] objs, Action<object> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }

        /// <summary>
        /// 遍历数组
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        public static async void ForEachAsync<T>(this T[] objs, Action<T> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }

        /// <summary>
        /// 遍历IEnumerable
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        public static async void ForEachAsync<T>(this IEnumerable<T> objs, Action<T> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }

        /// <summary>
        /// 遍历List
        /// </summary>
        /// <param name="objs"></param>
        /// <param name="action">回调方法</param>
        /// <typeparam name="T"></typeparam>
        public static async void ForEachAsync<T>(this IList<T> objs, Action<T> action)
        {
            await Task.Run(() =>
            {
                Parallel.ForEach(objs, action);
            });
        }

        #endregion

        #region Map

        /// <summary>
        /// 映射到目标类型(浅克隆)
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型</returns>
        public static TDestination MapTo<TDestination>(this object source) where TDestination : new()
        {
            TDestination dest = new TDestination();
            dest.GetType().GetProperties().ForEach(p =>
            {
                p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(source));
            });
            return dest;
        }

        /// <summary>
        /// 映射到目标类型(浅克隆)
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型</returns>
        public static async Task<TDestination> MapToAsync<TDestination>(this object source) where TDestination : new()
        {
            return await Task.Run(() =>
            {
                TDestination dest = new TDestination();
                dest.GetType().GetProperties().ForEach(p =>
                {
                    p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(source));
                });
                return dest;
            });
        }

        /// <summary>
        /// 映射到目标类型(深克隆)
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型</returns>
        public static TDestination Map<TDestination>(this object source) where TDestination : new() => JsonConvert.DeserializeObject<TDestination>(JsonConvert.SerializeObject(source));

        /// <summary>
        /// 映射到目标类型(深克隆)
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型</returns>
        public static async Task<TDestination> MapAsync<TDestination>(this object source) where TDestination : new() => await Task.Run(() => JsonConvert.DeserializeObject<TDestination>(JsonConvert.SerializeObject(source)));

        /// <summary>
        /// 复制到一个现有对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源对象</param>
        /// <param name="dest">目标对象</param>
        /// <returns></returns>
        public static T CopyTo<T>(this T source, T dest) where T : new()
        {
            dest.GetType().GetProperties().ForEach(p =>
            {
                p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(source));
            });
            return dest;
        }

        /// <summary>
        /// 复制一个新的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<T> CopyAsync<T>(this T source) where T : new() => await Task.Run(() =>
        {
            T dest = new T();
            dest.GetType().GetProperties().ForEach(p =>
            {
                p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(source));
            });
            return dest;
        });

        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static IEnumerable<TDestination> ToList<TDestination>(this object[] source) where TDestination : new()
        {
            foreach (var o in source)
            {
                var dest = new TDestination();
                dest.GetType().GetProperties().ForEach(p =>
                {
                    p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(o));
                });
                yield return dest;
            }
        }

        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static async Task<IEnumerable<TDestination>> ToListAsync<TDestination>(this object[] source) where TDestination : new()
        {
            return await Task.Run(() =>
            {
                IList<TDestination> list = new List<TDestination>();
                foreach (var o in source)
                {
                    var dest = new TDestination();
                    dest.GetType().GetProperties().ForEach(p =>
                    {
                        p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(o));
                    });
                    list.Add(dest);
                }

                return list;
            });
        }

        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static IEnumerable<TDestination> ToList<TDestination>(this IList<dynamic> source) where TDestination : new()
        {
            foreach (var o in source)
            {
                var dest = new TDestination();
                dest.GetType().GetProperties().ForEach(p =>
                {
                    p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(o));
                });
                yield return dest;
            }
        }

        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static async Task<IEnumerable<TDestination>> ToListAsync<TDestination>(this IList<dynamic> source) where TDestination : new()
        {
            return await Task.Run(() =>
            {
                IList<TDestination> list = new List<TDestination>();
                foreach (var o in source)
                {
                    var dest = new TDestination();
                    dest.GetType().GetProperties().ForEach(p =>
                    {
                        p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(o));
                    });
                    list.Add(dest);
                }

                return list;
            });
        }

        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static IEnumerable<TDestination> ToList<TDestination>(this IEnumerable<dynamic> source) where TDestination : new()
        {
            foreach (var o in source)
            {
                var dest = new TDestination();
                dest.GetType().GetProperties().ForEach(p =>
                {
                    p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(o));
                });
                yield return dest;
            }
        }

        /// <summary>
        /// 映射到目标类型的集合
        /// </summary>
        /// <param name="source">源</param>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <returns>目标类型集合</returns>
        public static async Task<IEnumerable<TDestination>> ToListAsync<TDestination>(this IEnumerable<dynamic> source) where TDestination : new()
        {
            return await Task.Run(() =>
            {
                IList<TDestination> list = new List<TDestination>();
                foreach (var o in source)
                {
                    var dest = new TDestination();
                    dest.GetType().GetProperties().ForEach(p =>
                    {
                        p.SetValue(dest, source.GetType().GetProperty(p.Name)?.GetValue(o));
                    });
                    list.Add(dest);
                }

                return list;
            });
        }

        #endregion

        /// <summary>
        /// 转换成json字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToJsonString(this object source) => JsonConvert.SerializeObject(source, new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        /// <summary>
        /// 转换成json字符串
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static async Task<string> ToJsonStringAsync(this object source) => await Task.Run(() => JsonConvert.SerializeObject(source));

        #region 数字互转

        /// <summary>
        /// 字符串转int
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static int ToInt32(this string s)
        {
            Int32.TryParse(s, out int result);
            return result;
        }

        /// <summary>
        /// 字符串转long
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static long ToInt64(this string s)
        {
            Int64.TryParse(s, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>double类型的数据</returns>
        public static double ToDouble(this string s)
        {
            Double.TryParse(s, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static decimal ToDecimal(this string s)
        {
            Decimal.TryParse(s, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转decimal
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>int类型的数字</returns>
        public static decimal ToDecimal(this double s)
        {
            return new decimal(s);
        }

        /// <summary>
        /// 字符串转double
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>double类型的数据</returns>
        public static double ToDouble(this decimal s)
        {
            return (double)s;
        }

        /// <summary>
        /// 将double转换成int
        /// </summary>
        /// <param name="num">double类型</param>
        /// <returns>int类型</returns>
        public static int ToInt32(this double num)
        {
            return (int)Math.Floor(num);
        }

        /// <summary>
        /// 将double转换成int
        /// </summary>
        /// <param name="num">double类型</param>
        /// <returns>int类型</returns>
        public static int ToInt32(this decimal num)
        {
            return (int)Math.Floor(num);
        }

        /// <summary>
        /// 字符串转long类型
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultResult">转换失败的默认值</param>
        /// <returns></returns>
        public static long ToLong(this string str, long defaultResult)
        {
            if (!Int64.TryParse(str, out var result))
            {
                result = defaultResult;
            }
            return result;
        }

        /// <summary>
        /// 将int转换成double
        /// </summary>
        /// <param name="num">int类型</param>
        /// <returns>int类型</returns>
        public static double ToDouble(this int num)
        {
            return num * 1.0;
        }

        /// <summary>
        /// 将int转换成decimal
        /// </summary>
        /// <param name="num">int类型</param>
        /// <returns>int类型</returns>
        public static decimal ToDecimal(this int num)
        {
            return (decimal)(num * 1.0);
        }

        #endregion

        #region 检测字符串中是否包含列表中的关键词

        /// <summary>
        /// 检测字符串中是否包含列表中的关键词
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="keys">关键词列表</param>
        /// <returns></returns>
        public static bool Contains(this string s, IEnumerable<string> keys) => Regex.IsMatch(s.ToLower(), String.Join("|", keys).ToLower());

        #endregion

        #region 匹配Email

        /// <summary>
        /// 匹配Email
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns>
        public static Match MatchEmail(this string s, out bool isMatch)
        {
            Match match = Regex.Match(s, @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            isMatch = match.Success;
            return isMatch ? match : null;
        }

        /// <summary>
        /// 匹配Email
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool MatchEmail(this string s)
        {
            MatchEmail(s, out bool success);
            return success;
        }

        #endregion

        #region 匹配完整的URL

        /// <summary>
        /// 匹配完整格式的URL
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns>
        public static Uri MatchUrl(this string s, out bool isMatch)
        {
            try
            {
                isMatch = true;
                return new Uri(s);
            }
            catch
            {
                isMatch = false;
                return null;
            }
        }

        /// <summary>
        /// 匹配完整格式的URL
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool MatchUrl(this string s)
        {
            MatchUrl(s, out var isMatch);
            return isMatch;
        }

        #endregion

        #region 权威校验身份证号码

        /// <summary>
        /// 根据GB11643-1999标准权威校验中国身份证号码的合法性
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool MatchIdentifyCard(this string s)
        {
            if (s.Length == 18)
            {
                if (Int64.TryParse(s.Remove(17), out var n) == false || n < Math.Pow(10, 16) || Int64.TryParse(s.Replace('x', '0').Replace('X', '0'), out n) == false)
                {
                    return false; //数字验证  
                }

                string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
                if (address.IndexOf(s.Remove(2), StringComparison.Ordinal) == -1)
                {
                    return false; //省份验证  
                }

                string birth = s.Substring(6, 8).Insert(6, "-").Insert(4, "-");
                DateTime time;
                if (!DateTime.TryParse(birth, out time))
                {
                    return false; //生日验证  
                }

                string[] arrVarifyCode = ("1,0,x,9,8,7,6,5,4,3,2").Split(',');
                string[] wi = ("7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2").Split(',');
                char[] ai = s.Remove(17).ToCharArray();
                int sum = 0;
                for (int i = 0; i < 17; i++)
                {
                    sum += wi[i].ToInt32() * ai[i].ToString().ToInt32();
                }

                int y;
                Math.DivRem(sum, 11, out y);
                if (arrVarifyCode[y] != s.Substring(17, 1).ToLower())
                {
                    return false; //校验码验证  
                }

                return true; //符合GB11643-1999标准  
            }

            if (s.Length == 15)
            {
                if (Int64.TryParse(s, out var n) == false || n < Math.Pow(10, 14))
                {
                    return false; //数字验证  
                }

                string address = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
                if (address.IndexOf(s.Remove(2), StringComparison.Ordinal) == -1)
                {
                    return false; //省份验证  
                }

                string birth = s.Substring(6, 6).Insert(4, "-").Insert(2, "-");
                if (DateTime.TryParse(birth, out _) == false)
                {
                    return false; //生日验证  
                }

                return true;
            }

            return false;
        }

        #endregion

        #region 校验IP地址的合法性

        /// <summary>
        /// 校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns>
        public static Match MatchInetAddress(this string s, out bool isMatch)
        {
            Match match;
            if (s.Contains(":"))
            {
                //IPv6
                match = Regex.Match(s, @"^([\da-fA-F]{0,4}:){1,7}[\da-fA-F]{1,4}$");
                isMatch = match.Success;
            }
            else
            {
                //IPv4
                match = Regex.Match(s, @"^(\d+)\.(\d+)\.(\d+)\.(\d+)$");
                isMatch = match.Success;
                foreach (Group m in match.Groups)
                {
                    if (m.Value.ToInt32() < 0 || m.Value.ToInt32() > 255)
                    {
                        isMatch = false;
                        break;
                    }
                }
            }

            return isMatch ? match : null;
        }

        /// <summary>
        /// 校验IP地址的正确性，同时支持IPv4和IPv6
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool MatchInetAddress(this string s)
        {
            MatchInetAddress(s, out bool success);
            return success;
        }

        #endregion

        #region 校验手机号码的正确性

        /// <summary>
        /// 匹配手机号码
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <param name="isMatch">是否匹配成功，若返回true，则会得到一个Match对象，否则为null</param>
        /// <returns>匹配对象</returns>
        public static Match MatchPhoneNumber(this string s, out bool isMatch)
        {
            Match match = Regex.Match(s, @"^((1[3,5,6,8][0-9])|(14[5,7])|(17[0,1,3,6,7,8])|(19[8,9]))\d{8}$");
            isMatch = match.Success;
            return isMatch ? match : null;
        }

        /// <summary>
        /// 匹配手机号码
        /// </summary>
        /// <param name="s">源字符串</param>
        /// <returns>是否匹配成功</returns>
        public static bool MatchPhoneNumber(this string s)
        {
            MatchPhoneNumber(s, out bool success);
            return success;
        }

        #endregion

        /// <summary>
        /// 严格比较两个对象是否是同一对象
        /// </summary>
        /// <param name="_this">自己</param>
        /// <param name="o">需要比较的对象</param>
        /// <returns>是否同一对象</returns>
        public new static bool ReferenceEquals(this object _this, object o) => object.ReferenceEquals(_this, o);

        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s) => String.IsNullOrEmpty(s);

        /// <summary>
        /// 类型直转
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(this IConvertible value)
        {
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// 字符串转时间
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string value)
        {
            DateTime.TryParse(value, out var result);
            return result;
        }

        /// <summary>
        /// 字符串转Guid
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Guid ToGuid(this string s)
        {
            return Guid.Parse(s);
        }

        /// <summary>
        /// 根据正则替换
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regex">正则表达式</param>
        /// <param name="replacement">新内容</param>
        /// <returns></returns>
        public static string Replace(this string input, Regex regex, string replacement)
        {
            return regex.Replace(input, replacement);
        }

        /// <summary>
        /// 生成唯一短字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="chars">可用字符数数量，0-9,a-z,A-Z</param>
        /// <returns></returns>
        public static string CreateShortToken(this string str, byte chars = 36)
        {
            var nf = new NumberFormater(chars);
            return nf.ToString((DateTime.Now.Ticks - 630822816000000000) * 100 + Stopwatch.GetTimestamp() % 100);
        }

        /// <summary>
        /// 十进制转任意进制
        /// </summary>
        /// <param name="num"></param>
        /// <param name="bin">进制</param>
        /// <returns></returns>
        public static string ToBinary(this long num, int bin)
        {
            var nf = new NumberFormater(bin);
            return nf.ToString(num);
        }

        /// <summary>
        /// 十进制转任意进制
        /// </summary>
        /// <param name="num"></param>
        /// <param name="bin">进制</param>
        /// <returns></returns>
        public static string ToBinary(this int num, int bin)
        {
            var nf = new NumberFormater(bin);
            return nf.ToString(num);
        }

        /// <summary>
        /// 按字段去重
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> hash = new HashSet<TKey>();
            return source.Where(p => hash.Add(keySelector(p)));
        }

        /// <summary>
        /// 将小数截断为8位
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static double Digits8(this double num)
        {
            return (long)(num * 1E+8) * 1e-8;
        }

        /// <summary>
        /// 判断IP地址在不在某个IP地址段
        /// </summary>
        /// <param name="input">需要判断的IP地址</param>
        /// <param name="begin">起始地址</param>
        /// <param name="ends">结束地址</param>
        /// <returns></returns>
        public static bool IpAddressInRange(this string input, string begin, string ends)
        {
            uint current = IPToID(input);
            return current >= IPToID(begin) && current <= IPToID(ends);
        }

        /// <summary>
        /// IP地址转换成数字
        /// </summary>
        /// <param name="addr">IP地址</param>
        /// <returns>数字,输入无效IP地址返回0</returns>
        private static uint IPToID(string addr)
        {
            if (!IPAddress.TryParse(addr, out var ip))
            {
                return 0;
            }

            byte[] bInt = ip.GetAddressBytes();
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bInt);
            }

            return BitConverter.ToUInt32(bInt, 0);
        }

        /// <summary>
        /// 判断IP是否是私有地址
        /// </summary>
        /// <param name="myIPAddress"></param>
        /// <returns></returns>
        public static bool IsPrivateIP(this IPAddress myIPAddress)
        {
            if (IPAddress.IsLoopback(myIPAddress)) return true;
            if (myIPAddress.AddressFamily == AddressFamily.InterNetwork)
            {
                byte[] ipBytes = myIPAddress.GetAddressBytes();
                // 10.0.0.0/24 
                if (ipBytes[0] == 10)
                {
                    return true;
                }
                // 169.254.0.0/16
                if (ipBytes[0] == 169 && ipBytes[1] == 254)
                {
                    return true;
                }
                // 172.16.0.0/16
                if (ipBytes[0] == 172 && ipBytes[1] == 16)
                {
                    return true;
                }
                // 192.168.0.0/16
                if (ipBytes[0] == 192 && ipBytes[1] == 168)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 判断IP是否是私有地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsPrivateIP(this string ip)
        {
            if (MatchInetAddress(ip))
            {
                return IsPrivateIP(IPAddress.Parse(ip));
            }
            throw new ArgumentException(ip + " 不是一个合法的ip地址");
        }

        /// <summary>
        /// 判断url是否是外部地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsExternalAddress(this string url)
        {
            var uri = new Uri(url);
            switch (uri.HostNameType)
            {
                case UriHostNameType.Dns:
                    var ipHostEntry = Dns.GetHostEntry(uri.DnsSafeHost);
                    foreach (IPAddress ipAddress in ipHostEntry.AddressList)
                    {
                        if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
                        {
                            if (!ipAddress.IsPrivateIP())
                            {
                                return true;
                            }
                        }
                    }
                    break;

                case UriHostNameType.IPv4:
                    return !IPAddress.Parse(uri.DnsSafeHost).IsPrivateIP();
            }
            return false;
        }

        /// <summary>
        /// 生成真正的随机数
        /// </summary>
        /// <param name="r"></param>
        /// <param name="seed"></param>
        /// <returns></returns>
        public static int StrictNext(this Random r, int seed = Int32.MaxValue)
        {
            return new Random((int)Stopwatch.GetTimestamp()).Next(seed);
        }

        /// <summary>
        /// 产生正态分布的随机数
        /// </summary>
        /// <param name="rand"></param>
        /// <param name="mean">均值</param>
        /// <param name="stdDev">方差</param>
        /// <returns></returns>
        public static double NextGauss(this Random rand, double mean, double stdDev)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            return mean + stdDev * randStdNormal;
        }

        /// <summary>
        /// 将流转换为内存流
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="dispose">保存后是否释放源流</param>
        /// <returns></returns>
        public static MemoryStream SaveAsMemoryStream(this Stream stream, bool dispose = false)
        {
            var ms = new MemoryStream();
            stream.CopyTo(ms);
            try
            {
                return ms;
            }
            finally
            {
                if (dispose)
                {
                    stream.Dispose();
                }
            }
        }
    }
}