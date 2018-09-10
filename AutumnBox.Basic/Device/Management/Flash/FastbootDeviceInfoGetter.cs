﻿/********************************************************************************
** auth： zsh2401@163.com
** date： 2018/1/12 5:13:30
** filename: DeviceInfoGetterInFastboot.cs
** compiler: Visual Studio 2017
** desc： ...
*********************************************************************************/
using AutumnBox.Basic.Executer;
using System.Text.RegularExpressions;

namespace AutumnBox.Basic.Device.Management.Flash
{
    /// <summary>
    /// 获取处在Fastboot状态下的设备的信息
    /// </summary>
    public class FastbootDeviceInfoGetter : DependOnDeviceObject
    {
        private const string resultPattern = @".+:\u0020(?<result>.+)";
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="device"></param>
        public FastbootDeviceInfoGetter(IDevice device) : base(device)
        {
        }

        /// <summary>
        /// 获取Product信息
        /// </summary>
        /// <returns></returns>
        public string GetProduct()
        {
            var text = Device.Fastboot("getvar product").Item1.ToString();
            var match = Regex.Match(text, resultPattern);
            if (match.Success)
            {
                return match.Result("${result}");
            }
            else
            {
                return null;
            }
        }
    }
}