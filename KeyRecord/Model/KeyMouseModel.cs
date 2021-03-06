﻿//KeyMouseModel
using KeyRecord.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace KeyRecord.Model
{
    public class KeyMouseModel
    {
        private Bitmap categoryIcon;
        private string deviceName;
        private string keyData;
        private int keyCode;
        private int locationX;
        private int locationY;
        private string title;
        private Bitmap programIcon;
        private string className;
        private string processPath;
        private string executeDate;
        private string extendedValue;

        /// <summary>
        /// 分类图标
        /// </summary>
        public Bitmap CategoryIcon
        {
            get
            {
                return categoryIcon;
            }

            set
            {
                categoryIcon = value;
            }
        }

        /// <summary>
        /// 操作的设备名称
        /// </summary>
        public string DeviceName
        {
            get
            {
                return deviceName;
            }

            set
            {
                deviceName = value;
            }
        }

        /// <summary>
        /// 按下了哪个键
        /// </summary>
        public string KeyData
        {
            get
            {
                return keyData;
            }

            set
            {
                keyData = value;
            }
        }

        /// <summary>
        /// 键码
        /// </summary>
        public int KeyCode
        {
            get
            {
                return keyCode;
            }

            set
            {
                keyCode = value;
            }
        }

        /// <summary>
        /// 当前操作x坐标
        /// </summary>
        public int LocationX
        {
            get
            {
                return locationX;
            }

            set
            {
                locationX = value;
            }
        }

        /// <summary>
        /// 当前操作y坐标
        /// </summary>
        public int LocationY
        {
            get
            {
                return locationY;
            }

            set
            {
                locationY = value;
            }
        }

        /// <summary>
        /// 当前操作窗口标题
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        /// <summary>
        /// 程序图标
        /// </summary>
        public Bitmap ProgramIcon
        {
            get
            {
                return programIcon;
            }

            set
            {
                programIcon = value;
            }
        }

        /// <summary>
        /// 当前操作窗口所属类
        /// </summary>
        public string ClassName
        {
            get
            {
                return className;
            }

            set
            {
                className = value;
            }
        }

        /// <summary>
        /// 当前进程路径
        /// </summary>
        public string ProcessPath
        {
            get
            {
                return processPath;
            }

            set
            {
                processPath = value;
            }
        }

        /// <summary>
        /// 当前操作时间
        /// </summary>
        public string ExecuteDate
        {
            get
            {
                return executeDate;
            }

            set
            {
                executeDate = value;
            }
        }

        /// <summary>
        /// 扩展属性
        /// </summary>
        public string ExtendedValue
        {
            get
            {
                return extendedValue;
            }

            set
            {
                extendedValue = value;
            }
        }

        #region 复合属性Value的使用
        /* 1、所有的赋值必须通过方法SetItemValue；
         * 2、共用专有信号量
         */
        //是否需要重新初始化标识。默认：True（需要）
        bool b_ValueFlag = true;
        CSKeyValue cskv_Value;

        /// <summary> 获取资源对象内置参数
        /// 从属性CSValue中解析出对应的内置参数
        /// </summary>
        /// <param name="ItemName">项目名</param>
        /// <returns></returns>
        public string GetItemValue(string ItemName)
        {
            if (string.IsNullOrEmpty(this.ExtendedValue)) { return string.Empty; }
            if (b_ValueFlag)
            {
                cskv_Value = new CSKeyValue();
                cskv_Value.F_Value = '\'';
                cskv_Value.CSInitial(this.ExtendedValue);
                b_ValueFlag = false;
            }
            return cskv_Value.CSGetValue(ItemName);
        }

        /// <summary> 设定资源对象内置参数
        /// 将输入的参数，按规则赋予属性CSValue
        /// </summary>
        /// <param name="ItemName">项目名</param>
        /// <param name="ItemValue">项目值</param>
        /// <returns></returns>
        public int SetItemValue(string ItemName, string ItemValue)
        {
            if (b_ValueFlag)
            {
                cskv_Value = new CSKeyValue();
                cskv_Value.F_Value = '\'';
                cskv_Value.CSInitial(this.ExtendedValue);
                b_ValueFlag = false;
            }
            int i_Result = cskv_Value.CSAdd(ItemName, ItemValue);
            this.ExtendedValue = cskv_Value.ToSerializedString();
            return i_Result;
        }

        #endregion

        //public DataSet AddKeyMouseData()
        //{
        //    string sql = "Insert into KeyMouse (DeviceName, KeyData,LocationX,LocationY,Title,ClassName,ExecuteDate) " +
        //        string.Format("VALUES('{0}', '{1}', {2},{3},'{4}','{5}','{6}'); ", DeviceName, KeyData,LocationX,LocationY,Title,ClassName,ExecuteDate);
        //    return SQLiteHelper.ExecuteDataSet(SQLiteHelper.LocalDbConnectionString, sql.ToString(), CommandType.Text);
        //}
    }
}
