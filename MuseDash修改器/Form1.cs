using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MuseDash修改器
{
    public partial class Form1 : Form
    {
        private string ImageName = "GameAssembly.dll";
        private string ProcessName = "MuseDash";
        private int ProcessId = 0;
        private IntPtr ImageBase;
        private Operation operate;


        public Form1()
        {
            InitializeComponent();
        }


        //初始化函数,用来找到程序pid,以及imagebase
        private bool CheckProcess()
        {
            Process[] processes = Process.GetProcessesByName(ProcessName);
            foreach (var p in processes)
            {
                if (p.ProcessName == ProcessName)
                {
                    ProcessId = p.Id;
                    richTextBox1.Text += "找到游戏进程--" + p.Id + "\r\n";
                    for (int i = 0; i < p.Modules.Count; i++)
                    {
                        if (p.Modules[i].ModuleName.Equals(ImageName))
                        {
                            ImageBase = p.Modules[i].BaseAddress;
                            richTextBox1.Text += "找到游戏模块基址--" + p.Modules[i].BaseAddress + "\r\n";
                            return true;
                        }
                    }

                }
            }
            richTextBox1.Text += "未找到游戏进程--" + ProcessName + ".exe\r\n";
            return false;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (operate.CloseAllEffect() == true)
                {
                    richTextBox1.Text += "关闭所有效果" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "关闭所有效果失败" + "\r\n";
                }
            }
            catch (System.NullReferenceException)
            {
                richTextBox1.Text += "请先点击开始按钮" + "\r\n";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (operate.LockHP(Operation.OPEN) == false)
                {
                    richTextBox1.Text += "开启锁血:操作失败" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "开启锁血" + "\r\n";
                }
            }
            catch (System.NullReferenceException)
            {
                richTextBox1.Text += "请先点击开始按钮" + "\r\n";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (operate.IdolSkill(Operation.OPEN) == true)
                {
                    richTextBox1.Text += "替换技能:开启" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "替换技能:开启失败" + "\r\n";
                }
            }
            catch (System.NullReferenceException)
            {
                richTextBox1.Text += "请先点击开始按钮" + "\r\n";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (operate.IdolSkill(Operation.CLOSE) == true)
                {
                    richTextBox1.Text += "替换技能:关闭" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "替换技能:关闭失败" + "\r\n";
                }
            }
            catch (System.NullReferenceException)
            {
                richTextBox1.Text += "请先点击开始按钮" + "\r\n";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (operate.LockHP(Operation.CLOSE) == false)
                {
                    richTextBox1.Text += "关闭锁血:操作失败" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "关闭锁血" + "\r\n";
                }
            }
            catch (System.NullReferenceException)
            {
                richTextBox1.Text += "请先点击开始按钮" + "\r\n";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (operate.IdolSkill(Operation.OPEN) == true)
                {
                    richTextBox1.Text += "偶像布若:开启10倍经验" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "偶像布若:开启10倍经验失败" + "\r\n";
                }
            }
            catch (System.NullReferenceException)
            {
                richTextBox1.Text += "请先点击开始按钮" + "\r\n";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (operate.IdolSkill(Operation.CLOSE))
                {
                    richTextBox1.Text += "偶像布若:关闭10倍经验" + "\r\n";
                }
                else
                {
                    richTextBox1.Text += "偶像布若:关闭10倍经验失败" + "\r\n";
                }

            }
            catch (System.NullReferenceException)
            {
                richTextBox1.Text += "请先点击开始按钮" + "\r\n";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void button1_begin_click(object sender, EventArgs e)
        {
            if (ProcessId == 0)
            {
                CheckProcess();
            }
            //初始化操作类
            operate = new Operation(ProcessId, ImageBase);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                try
                {
                    if (operate.SetAutoPlay(Operation.CLOSE))
                    {
                        richTextBox1.Text += "自动打击:关闭" + "\r\n";
                    }
                    else
                    {
                        richTextBox1.Text += "自动打击:关闭失败" + "\r\n";
                    }

                }
                catch (System.NullReferenceException)
                {
                    richTextBox1.Text += "请先点击开始按钮" + "\r\n";
                }
            }
            else
            {
                try
                {
                    if (operate.SetAutoPlay(Operation.OPEN))
                    {
                        richTextBox1.Text += "自动打击:开启" + "\r\n";
                    }
                    else
                    {
                        richTextBox1.Text += "自动打击:开启失败" + "\r\n";
                    }

                }
                catch (System.NullReferenceException)
                {
                    richTextBox1.Text += "请先点击开始按钮" + "\r\n";
                }
            }
        }
    }



    public class Operation
    {
        //宏定义
        private const int ACCESS_ALL = 0x1F0FFF;
        public const int OPEN = 1;
        public const int CLOSE = 0;

        //固定偏移基址
        private const int PART_LOCKHP1 = 0x86AE60;
        private const int PART_LOCKHP2 = 0;
                                                        // IdolSkill
        private const int PART_IDOTSKILL = 0x65DD28;    // GameAssembly.dll+65DD28 - C7 40 44 0000C03F     - mov [rax+44],3FC00000
        // SleepSkill
        private const int PART_AUTOPLAY1 = 0x3588650;   // GameAssembly.dll+1B9E7BF - 48 8B 05 72C46901     - mov rax,[GameAssembly.dll+323AC38]
        private const int PART_AUTOPLAY2 = 0xb8;
        private const int PART_AUTOPLAY3 = 0x60;
        private const int PART_AUTOPLAY4 = 0x12;
        private IntPtr AUTOPLAY_ADDR = (IntPtr)0;

        //固定操作大小
        private const int OPERAT_SIZE_LOCK = 3;
        private const int OPERAT_SIZE_IDOLSKILL = 7;
        private const int OPERAT_SIZE_AUTOPLAY = 5;


        private int ProcessId;
        private IntPtr ImageBase;
        private IntPtr ProcessHandle;

        //三个操作基址
        private IntPtr KeepComboAddr;

        //数据区
        private static byte[] LockHPByte_origin = new byte[OPERAT_SIZE_LOCK] { 0x8d, 0x0c, 0x3e };
        private static byte[] LockHPByte_patched = new byte[OPERAT_SIZE_LOCK] { 0x41, 0x8b, 0xc8 };

        private static byte[] IdolSkillByte_origin = new byte[OPERAT_SIZE_IDOLSKILL] { 0xc7, 0x40, 0x44, 0x00, 0x00, 0xc0, 0x3f };
        private static byte[] IdolSkillByte_patched = new byte[OPERAT_SIZE_IDOLSKILL] { 0xc7, 0x40, 0x44, 0x00, 0x00, 0x20, 0x41 };


        public Operation(int processid, IntPtr imagebase)
        {
            ImageBase = imagebase;
            ProcessId = processid;
            ProcessHandle = OpenProcess(ACCESS_ALL, false, processid);

        }
        private bool PreCheck()
        {
            //检查pid和imagebase是否为空,为true有效,为false无效
            if (ImageBase == IntPtr.Zero || ProcessId == 0 || ProcessHandle == IntPtr.Zero)
            {
                return false;
            }
            return true;
        }
        [DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer,
               int nSize, IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer,
            int nSize, IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(IntPtr hObject);



        //主要功能区


        public bool LockHP(int Mode)
        {
            return false;

            bool ret = false;
            IntPtr OperatAddr = ImageBase + PART_LOCKHP1;
            if (PreCheck() == true)
            {
                byte[] nowByte = new byte[OPERAT_SIZE_LOCK];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(nowByte, 0);
                ret = ReadProcessMemory(ProcessHandle, OperatAddr, byteAddress, OPERAT_SIZE_LOCK, IntPtr.Zero);
                if (ret == true)
                {
                    if (Mode == OPEN)
                    {
                        if (CmpBytes(nowByte, LockHPByte_origin, OPERAT_SIZE_LOCK))
                        {
                            IntPtr operatBytes = Marshal.UnsafeAddrOfPinnedArrayElement(LockHPByte_patched, 0);
                            return WriteProcessMemory(ProcessHandle, OperatAddr, operatBytes, OPERAT_SIZE_LOCK, IntPtr.Zero);
                        }
                    }
                    if (Mode == CLOSE)
                    {
                        if (CmpBytes(nowByte, LockHPByte_patched, OPERAT_SIZE_LOCK))
                        {
                            IntPtr operatBytes = Marshal.UnsafeAddrOfPinnedArrayElement(LockHPByte_origin, 0);
                            return WriteProcessMemory(ProcessHandle, OperatAddr, operatBytes, OPERAT_SIZE_LOCK, IntPtr.Zero);
                        }
                    }
                }
            }
            return false;
        }

        public bool IdolSkill(int Mode)
        {
            bool ret = false;
            IntPtr OperatAddr = ImageBase + PART_IDOTSKILL;
            if (PreCheck() == true)
            {
                byte[] nowByte = new byte[OPERAT_SIZE_IDOLSKILL];
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(nowByte, 0);
                ret = ReadProcessMemory(ProcessHandle, OperatAddr, byteAddress, OPERAT_SIZE_IDOLSKILL, IntPtr.Zero);
                if (ret == true)
                {
                    if (Mode == OPEN)
                    {
                        if (CmpBytes(nowByte, IdolSkillByte_origin, OPERAT_SIZE_IDOLSKILL))
                        {
                            IntPtr patchBytes = Marshal.UnsafeAddrOfPinnedArrayElement(IdolSkillByte_patched, 0);
                            return WriteProcessMemory(ProcessHandle, OperatAddr, patchBytes, OPERAT_SIZE_IDOLSKILL, IntPtr.Zero);
                        }
                    }
                    if (Mode == CLOSE)
                    {
                        if (CmpBytes(nowByte, IdolSkillByte_patched, OPERAT_SIZE_IDOLSKILL))
                        {
                            IntPtr patchBytes = Marshal.UnsafeAddrOfPinnedArrayElement(IdolSkillByte_origin, 0);
                            return WriteProcessMemory(ProcessHandle, OperatAddr, patchBytes, OPERAT_SIZE_IDOLSKILL, IntPtr.Zero);
                        }
                    }
                }
            }
            return false;
        }

        public bool CloseAllEffect()
        {
            return IdolSkill(CLOSE) | LockHP(CLOSE) | SetAutoPlay(CLOSE);
        }
        public bool SetAutoPlay(int Mode)
        {
            bool ret = false;
            IntPtr OperatAddr = ImageBase + PART_AUTOPLAY1;
            if (PreCheck() == true)
            {
                if (Mode == OPEN)
                {
                    unsafe
                    {
                        long[] buffer = new long [1];
                        IntPtr addr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                        ret = ReadProcessMemory(ProcessHandle, OperatAddr, addr, sizeof(long), IntPtr.Zero);
                        OperatAddr = (IntPtr)buffer[0] + PART_AUTOPLAY2;
                        ret = ReadProcessMemory(ProcessHandle, OperatAddr, addr, sizeof(long), IntPtr.Zero);
                        OperatAddr = (IntPtr)buffer[0] + PART_AUTOPLAY3;
                        ret = ReadProcessMemory(ProcessHandle, OperatAddr, addr, sizeof(long), IntPtr.Zero);
                        OperatAddr = (IntPtr)buffer[0] + PART_AUTOPLAY4;
                        Byte[] input= new Byte[1];
                        input[0] = (byte)0x1;
                        IntPtr addr2 = Marshal.UnsafeAddrOfPinnedArrayElement(input, 0);
                        ret = WriteProcessMemory(ProcessHandle, OperatAddr, addr2, 1, IntPtr.Zero);
                        return ret;
                    }
                }
                if (Mode == CLOSE)
                {
                    unsafe
                    {
                        long[] buffer = new long[1];
                        IntPtr addr = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                        ret = ReadProcessMemory(ProcessHandle, OperatAddr, addr, sizeof(long), IntPtr.Zero);
                        OperatAddr = (IntPtr)buffer[0] + PART_AUTOPLAY2;
                        ret = ReadProcessMemory(ProcessHandle, OperatAddr, addr, sizeof(long), IntPtr.Zero);
                        OperatAddr = (IntPtr)buffer[0] + PART_AUTOPLAY3;
                        ret = ReadProcessMemory(ProcessHandle, OperatAddr, addr, sizeof(long), IntPtr.Zero);
                        OperatAddr = (IntPtr)buffer[0] + PART_AUTOPLAY4;
                        Byte[] input = new Byte[1];
                        input[0] = (byte)0x0;
                        IntPtr addr2 = Marshal.UnsafeAddrOfPinnedArrayElement(input, 0);
                        ret = WriteProcessMemory(ProcessHandle, OperatAddr, addr2, 1, IntPtr.Zero);
                        return ret;
                    }
                }

            }
            return false;
        }

        //cmp两个字节,返回true为一样,返回false为不一样
        private bool CmpBytes(byte[] a, byte[] b, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        //copy两个字节数据的数据,把数据b复制到数据a,长度为length
        private void CpyBytes(byte[] a, byte[] b, int length)
        {
            for (int i = 0; i < length; i++)
            {
                a[i] = b[i];
            }
        }
    }
}
