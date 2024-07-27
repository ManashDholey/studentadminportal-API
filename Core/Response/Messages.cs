using Core.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Response
{
    public static class Messages
    {
        public static string TeacherDataNotFound = "Teacher data is not found.";
        public static string TeacherDataUpdate = "Teacher data updated successfully.";
        public static string TeacherDataFound = "Teacher data is found.";
    }
}
