﻿using Microsoft.EntityFrameworkCore;
using Model.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DeptDB
    {

        public static long GetNumDepts()
        {
            using (MySQLDBContext context = new MySQLDBContext())
            {
                using (var connexio = context.Database.GetDbConnection()) // <== NOTA IMPORTANT: requereix ==>using Microsoft.EntityFrameworkCore;
                {
                    // Obrir la connexió a la BD
                    connexio.Open();

                    // Crear una consulta SQL
                    using (var consulta = connexio.CreateCommand())
                    {

                        // query SQL
                        consulta.CommandText = @"select count(1) from dept ";
                        return (long)consulta.ExecuteScalar();                        
                    }

                }
            }
        }

        public static List<Dept> GetDepts()
        {
            List<Dept> departaments = new List<Dept>();
            using (MySQLDBContext context = new MySQLDBContext())
            {
                using (var connexio = context.Database.GetDbConnection()) // <== NOTA IMPORTANT: requereix ==>using Microsoft.EntityFrameworkCore;
                {
                    // Obrir la connexió a la BD
                    connexio.Open();

                    // Crear una consulta SQL
                    using (var consulta = connexio.CreateCommand())
                    {

                        // query SQL
                        consulta.CommandText = @"select *  
                                                from dept ";
                        var reader = consulta.ExecuteReader();
                        while (reader.Read()) // per cada Read() avancem una fila en els resultats de la consulta.
                        {
                            int dept_no = reader.GetInt32(reader.GetOrdinal("DEPT_NO"));
                            string dnom = reader.GetString(reader.GetOrdinal("DNOM"));
                            string loc = reader.GetString(reader.GetOrdinal("LOC"));

                            Dept d = new Dept(dept_no, dnom, loc);  
                            departaments.Add(d);
                        }
                    }

                }
            }
            return departaments;

        }

    }
}
