using System;

namespace XamarinForms.Controls.Model
{
    public class Kullanici
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Ad} {Soyad}";
        }
    }
}