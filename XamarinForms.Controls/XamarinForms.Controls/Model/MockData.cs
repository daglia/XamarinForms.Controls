using System.Collections.Generic;

namespace XamarinForms.Controls.Model
{
    public class MockData
    {
        public MockData()
        {
            this.Kullanicilar = new List<Kullanici>();
            Kullanicilar.Add(new Kullanici()
            {
                Ad = "Kamil",
                Email = "kamil@fidil.com",
                Soyad = "Fidil"
            });
            Kullanicilar.Add(new Kullanici()
            {
                Ad = "Hakkı",
                Email = "hakki@fidil.com",
                Soyad = "Fidil"
            });
            Kullanicilar.Add(new Kullanici()
            {
                Ad = "Kerim",
                Email = "kerim@fidil.com",
                Soyad = "Fidil"
            });
        }
        public List<Kullanici> Kullanicilar { get; set; }
    }
}