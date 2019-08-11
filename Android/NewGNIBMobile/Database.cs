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
    class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "GNIBData.db")))
                {
                    connection.CreateTable<PresetData>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Add or Insert Operation  

        public bool insertIntoTable(PresetData presetdata)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "GNIBData.db")))
                {
                    connection.Insert(presetdata);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("SQLiteEx", ex.Message);
                return false;
            }
        }
        public List<PresetData> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "GNIBData.db")))
                {
                    return connection.Table<PresetData>().ToList();
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("SQLiteEx", ex.Message);
                return null;
            }
        }
        //Edit Operation  

        public bool updateTable(PresetData presetdata)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "GNIBData.db")))
                {
                    connection.Query<PresetData>("UPDATE PresetData set FName=?, SName=?, Email=?,Emailmatch?,FamilyApplicant=?,CurrentPass=?,IrpDate=?,LastIrpNum=?,Cat=?,SubCat=?Where Id=?", presetdata.Fname,
                        presetdata.Sname, presetdata.Email, 
                        presetdata.EmailMatch, presetdata.FamilyApplicant, presetdata.CurrentPass, presetdata.Irp_Date,
                        presetdata.Last_IrpNum, presetdata.Category, presetdata.SubCategory, presetdata.Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Delete Data Operation  

        public bool removeTable(PresetData presetdata)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "GNIBData.db")))
                {
                    connection.Delete(presetdata);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("SQLiteEx", ex.Message);
                return false;
            }
        }
        //Select Operation  

        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "GNIBData.db")))
                {
                    connection.Query<PresetData>("SELECT * FROM PresetData Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                Console.WriteLine("SQLiteEx", ex.Message);
                return false;
            }
        }
    }
}
