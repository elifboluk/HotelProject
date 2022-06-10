using OtelProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// T değeri: ben bu classı kullanırken dışarıdan bir parametre (entity) göndereceğim bu entity de benim tablom olacak. Repository içerisinde gönderilecek olan parametrelerde genelde T ismiyle adlandırılır. Fakat bir şartım (where T: class, new()) var; bu T değeri bir class'ın aldığı bütün özellikleri alabilmeli ve new'lenebilmeli.
namespace OtelProject.Repositories
{
    public class Repository<T> where T: class, new()
    {
        DbOtelEntities db = new DbOtelEntities(); //Entities çağırıldı.
        // Sırasıyla metodlarımızı çağıralım.
        public List<T> GetAll() 
        {
            return db.Set<T>().ToList(); // Set dışarıdan parametre göndereceğimiz anlamına gelir. Bu yapı sayesinde dışarıdan istediğimiz tabloyu buraya getireceğiz ve GetAll metoduyla bu tablonun içeriğini çağıracağız.
        }

        public void TAdd(T p) // T türünde bir p parametresi aldık. Buraya hangi entity'i gönderirsek o entity'e göre işlem gerçekleştirilmesini istiyoruz.
        { 
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p)
        {
            db.Set<T>().Remove(p); // Remove parametreden gelen değeri kaldırmak için kullanılır.
            db.SaveChanges();
        }
        public T TGet(int id) // ID'ye göre bulma işlemi için T türünde TGet methodu oluşturduk. ind id ile şart olarak bir id getirilmesi gerektiğini koyduk.
        {
            return db.Set<T>().Find(id); // Dışarıdan gönderdiğim id'ye göre bulma işlemi gerçekleştir.
        }

        public void TUpdate() // Güncelleme işlemi için.
        {
            db.SaveChanges();
        }
    }
}
