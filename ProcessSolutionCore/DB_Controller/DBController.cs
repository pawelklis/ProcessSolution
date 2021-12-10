using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


    public class DBController
    {
        public static dbContext db = new dbContext();

        public static T AddAsync<T>(T o) where T : new()
        {
            return Add<T>(o, true);

        }


        public static T Add<T>(T o, bool async = false) where T : new()
        {
            System.Data.Entity.DbSet dSet = db.Entities.Find(x => x.ElementType == typeof(T));
            dSet.Add(o);
            SaveChanges(async);
            return o;
        }

        public static T AddorUpdateAsync<T>(T o) where T : class, IEntity
        {
            return AddorUpdate<T>(o, true);
        }
        public static T AddorUpdate<T>(T o, bool async = false) where T : class, IEntity
        {
            if (o.Id == 0)
            {
                System.Data.Entity.DbSet dSet = db.Entities.Find(x => x.ElementType == typeof(T));
                dSet.Add(o);
                SaveChanges(async);
                return o;
            }

            T ob = GetObjectById<T>(o.Id);
            if (ob == null)
            {
                System.Data.Entity.DbSet dSet = db.Entities.Find(x => x.ElementType == typeof(T));
                dSet.Add(o);
                SaveChanges(async);
                return o;
            }
            else
            {
                SaveChanges(async);
                return o;
            }
        }

        public static T RemovetObjectByIdAsync<T>(int id, bool async = false) where T : class, IEntity
        {

            RemovetObjectById<T>(id, true);

            return null;
        }
        public static void RemovetObjectById<T>(int id, bool async = false) where T : class, IEntity
        {
            try
            {
                var myClassSet = db.Set(typeof(T));
                System.Data.Entity.DbSet<T> set = myClassSet.Cast<T>();
                T o = set.Single(x => x.Id == id);


                set.Remove(o);
                SaveChanges(async);
            }
            catch (Exception ex)
            {

                //throw ex;
            }
        }


        public static T GetObjectById<T>(int id) where T : class, IEntity
        {
            var myClassSet = db.Set(typeof(T));
            System.Data.Entity.DbSet<T> set = myClassSet.Cast<T>();
            T o = set.Single(x => x.Id == id);
            return o;
        }

        public static T GetObjectByProperty<T>(string value, string propertyname) where T : class, IEntity
        {
            var myClassSet = db.Set(typeof(T));
            System.Data.Entity.DbSet<T> set = myClassSet.Cast<T>();

            System.Reflection.PropertyInfo[] mi = typeof(T).GetProperties();
            T returnObject = null;

            set.ToList().ForEach(o =>
            {
                System.Reflection.PropertyInfo m = mi.Single(x => x.Name.ToLower() == propertyname.ToLower());
                if (((PropertyInfo)m).GetValue(o).ToString().ToLower() == value.ToString().ToLower())
                    returnObject = o;
                return;
            });

            return returnObject;
        }



        private static void SaveChanges(bool async)
        {
            if (async)
                db.SaveChangesAsync();
            else
                db.SaveChanges();
        }

    }
