/* =============================================================================*\
*
* Filename: CommandExecuter.ExeFunc.cs
* Description: 
*
* Version: 1.0
* Created: 9/26/2017 02:06:02(UTC+8:00)
* Compiler: Visual Studio 2017
* 
* Author: zsh2401
* Company: I am free man
*
\* =============================================================================*/
namespace AutumnBox.Basic.Executer
{
    using AutumnBox.Basic.Devices;
    using System;
    partial class CommandExecuter
    {
        /// <summary>
        /// 执行传入的命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OutputData Execute(Command command)
        {
            return ABProcess.RunToExited(command.FileName, command.FullCommand);
        }
        /// <summary>
        /// 执行adb命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OutputData AdbExecute(string command)
        {
            return Execute(new Command(command));
        }
        /// <summary>
        /// 向指定设备执行adb命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OutputData AdbExecute(string devId, string command)
        {
            return Execute(new Command(new DeviceBasicInfo() { Id = devId }, command));
        }
        /// <summary>
        /// 执行fastboot命令
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public OutputData FastbootExecute(string command)
        {
            return Execute(new Command(command, ExeType.Fastboot));
        }
        /// <summary>
        /// 向指定设备执行fastboot命令
        /// </summary>
        /// <param name="devId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public OutputData FastbootExecute(string devId, string command)
        {
            return Execute(new Command(new DeviceBasicInfo() { Id = devId }, command, ExeType.Fastboot));
        }
    }
}