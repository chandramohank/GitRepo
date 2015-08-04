﻿using AngularDemo.Data.Shared_Classes;
using AngularDemo.Entities.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AngularDemo.Data.Repositories
{
    public class EmployeeRepository
    {
        public List<Employee> GetEmployees()
        {
            Employee emp = new Employee();
            var empList = new List<Employee>() { };           
            var strFileName="datasource.txt";          
            var stream = GetEmbeddedResourceStream(strFileName);
            StringBuilder sb = new StringBuilder();
            using (stream)
            {
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        sb.Append(line);
                    }
                }
            }
            empList=JsonConvert.DeserializeObject<List<Employee>>(sb.ToString());           
            return empList;
        }

        private Stream GetEmbeddedResourceStream(string resourceName)
        {
            Assembly assy = Assembly.GetExecutingAssembly();
            string[] res = assy.GetManifestResourceNames();
            //Stream strm = assy.GetManifestResourceStream(resourceName);
            for (int i = 0; i < res.Length; i++)
            {
                if (res[i].ToLower().IndexOf(resourceName.ToLower()) != -1)
                {
                    return assy.GetManifestResourceStream(res[i]);
                }
            }
            return Stream.Null;
        }
    }
}
