using OtelProject.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        public List<T> GetListByID(Expression<Func<T, bool>> filter)// List türünde bir ifade kullandığım için geriye bir değer döndürmem gerekir.↓
        {
            return db.Set<T>().Where(filter).ToList(); // filter isimli parametreden gelen değere göre listeleme yapılsın.
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

        public void TUpdate(T p) // Güncelleme işlemi için.
        {
            db.SaveChanges();
        }

        // Silme ve güncelleme işleminden önce silinecek ve güncellenecek olan satırın bilgilerini T Find metodu aracılığıyla tutturacağız.
        public T Find(Expression<Func<T, bool>> where) // Expression, Linq sytax'ına ait bir komuttur.Fonksiyon olarak alınacak bir çıkış değeri belirlenir, çıkış değerimiz; T. T'den sonra çıkış değerinin türü belirlenir, türümüz; bool. Sonrasında ise bir parametre ismi yazılır, parametremiz; where. Where yerine istediğimiz parametreyi yazabiliriz fakat genellikle where kullanılır. 
        {
            return db.Set<T>().FirstOrDefault(where); // Find metodunu gönderdiğimizde bize geri sadece bir tane değer gönderecek, bu değer where'den gelen değer olacak. (Burada göndermiş olduğumuz where parametresi ise ID olacak.) Kısacası; bize, geriye T entity'sine bağlı olarak where şartında göndermiş olduğumuz değerin sadece FirstOrDefault'ta bir değerini gönderecek. Yani sadece ID göndereceğiz ve o ID'ye ait kayıtlar tutulacak gibi. Burada bir şartlı listeleme söz konusu değildir.
        }
    }
}
