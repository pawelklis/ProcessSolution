
using Microsoft.EntityFrameworkCore;
using ProcessWeb;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


public class AppDBContext : DbContext
{


    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        string mySqlConnectionStr = "Server=localhost;Database=blazcor;Uid=root;Pwd=mayday1";
        options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
   

    }


    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
    {
        Entities.Add(tblEmployee);
        Entities.Add(employeedetails);

       
    }


    public List<object> Entities = new List<object>();


    public DbSet<Employee> tblEmployee { get; set; }

    public DbSet<EmployeeDetails> employeedetails { get; set; }
}



public class EmployeeDataAccessLayer
{
    AppDBContext db = new AppDBContext(new DbContextOptions<AppDBContext>());            //To Get all employees details     
    public IEnumerable<Employee> GetAllEmployees()
    {
        try
        {
            return db.tblEmployee.Include("Details").ToList();
        }
        catch
        {
            throw;
        }
    }

    public IEnumerable<T>  GetAllObject<T>(string[] include) where T:class
    {
        if (include == null)
            include = new string[0];

        switch (include.Length) 
        {
            case 0:
                return db.Set<T>();                
            case 1:
                return db.Set<T>().Include(include[0]);                
            case 2:
                return db.Set<T>().Include(include[0]).Include(include[1]);
            case 3:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]);
            case 4:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]).Include(include[3]);
            case 5:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]).Include(include[3]).Include(include[4]);
            case 6:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]).Include(include[3]).Include(include[4]).Include(include[5]);
            case 7:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]).Include(include[3]).Include(include[4]).Include(include[5]).Include(include[6]);
            case 8:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]).Include(include[3]).Include(include[4]).Include(include[5]).Include(include[6]).Include(include[7]);
            case 9:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]).Include(include[3]).Include(include[4]).Include(include[5]).Include(include[6]).Include(include[7]).Include(include[8]);
            case 10:
                return db.Set<T>().Include(include[0]).Include(include[1]).Include(include[2]).Include(include[3]).Include(include[4]).Include(include[5]).Include(include[6]).Include(include[7]).Include(include[8]).Include(include[9]);
        }

        
            return  db.Set<T>();
        
    }

  


    //To Add new employee record     
    //public void AddEmployee(Employee employee)
    //{
    //    try
    //    {
    //        db.tblEmployee.Add(employee);

    //        employee.Details.ForEach(x =>
    //        {
    //            db.Entry(x).State = EntityState.Modified;
    //        });

    //        db.SaveChanges();
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}
    //To Update the records of a particluar employee    



    private void SetObjectDBState(object o, EntityState state = EntityState.Modified)
    {
        PropertyInfo[] pi = o.GetType().GetProperties();
        int id = 0;

        foreach (var p in pi)
        {
            if (p.Name.ToLower() == "id" || p.Name.ToLower() == "employeeid")
            {
                id = int.Parse(p.GetValue(o).ToString());
            }
        }

        EntityState stateOfObject = EntityState.Modified;
        if (id == 0)
            stateOfObject = EntityState.Added;

        if(state != EntityState.Modified)
        {
            stateOfObject = state;
        }

        foreach (var p in pi)
        {
            if (p.GetValue(o) != null)
            {
                try
                {
                  if (p.PropertyType.IsGenericType)
                        {
                            if (classIs.IsGenericList(p.GetValue(o)))
                            {
                                var l = p.GetValue(o) as IEnumerable;

                    
                   
                                foreach (var oo in l)
                                {
                                    SetObjectDBState(oo);
                                }
                            }
                            else
                            {
                                SetObjectDBState(p.GetValue(o));
                            }

                        }
                        else
                        {
                            if (!p.PropertyType.IsValueType && p.PropertyType!=typeof(string))
                                SetObjectDBState(p.GetValue(o));
                            else
                                db.Entry(o).State = stateOfObject;
                        }
                }
                catch (Exception)
                {

                    throw;
                }
            }

      
        }
    }

    public void UpdateObject<T>(T o) where T : class
    {

        try
        {

            SetObjectDBState(o);
            db.SaveChanges();
        }
        catch
        {
            throw;
        }

    }

    //public void UpdateEmployee(Employee employee)
    //{
    //    try
    //    {

    //        db.Entry(employee).State = EntityState.Modified;

    //        foreach (var ed in employee.Details)
    //        {
    //            if (ed.Id != 0)
    //                db.Entry(ed).State = EntityState.Modified;
    //            else
    //                db.Entry(ed).State = EntityState.Added;
    //        }


    //        db.SaveChanges();
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}
    //Get the details of a particular employee   
    public Employee GetEmployeeData(int id)
    {
        try
        {
            Employee employee = db.tblEmployee.Find(id);
            return employee;
        }
        catch
        {
            throw;
        }
    }
    //To Delete the record of a particular employee  

    public void RemovetObject<T>(object o, bool async = false) where T : class
    {

        try
        {
            var myClassSet = db.Set<T>();

            myClassSet.Remove((T)o);
            db.SaveChanges();
        }
        catch (Exception ex)
        {

            //throw ex;
        }


    }
    //public void DeleteEmployee(int id)
    //{
    //    try
    //    {
    //        Employee emp = db.tblEmployee.Find(id);
    //        db.tblEmployee.Remove(emp);
    //        db.SaveChanges();
    //    }
    //    catch
    //    {
    //        throw;
    //    }
    //}


    //public void DeleteEmployeeDetail(Employee em, int id)
    //{

    //    EmployeeDetails ed = em.Details.Single(x => x.Id == id);
    //    em.Details.Remove(ed);
    //    db.SaveChanges();


    //}
}


public static class classIs
{
    public static bool IsGenericList(this object o)
    {
        var oType = o.GetType();
        return (oType.IsGenericType && (oType.GetGenericTypeDefinition() == typeof(List<>)));
    }
}

//using BlazorCrud.Shared.Models;
//using Microsoft.EntityFrameworkCore; 
//using System;
//using System.Collections.Generic; 
//using System.Linq;
//using System.Threading.Tasks;  
//  namespace BlazorCrud.Server.DataAccess 
//{
//    public class EmployeeContext : DbContext 
//    { 
//        public virtual DbSet<Employee> tblEmployee { get; set; } 
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
//        { 
//            if (!optionsBuilder.IsConfigured) 
//            {
//                optionsBuilder.UseSqlServer(@"Put Your Connection string here"); 
//            }
//        }
//    }
//}