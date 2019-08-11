using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace NewGNIBMobile
{
    class PresetData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Last_IrpNum { get; set; }
        public string Irp_Date { get; set; }
        public string Fname { get; set; }
        public string Sname { get; set; }
        public string FamilyApplicant { get; set; }
        public string Email { get; set; }
        public string EmailMatch { get; set; }
        public string CurrentPass { get; set; }

    }
}