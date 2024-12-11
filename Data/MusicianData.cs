using CrazyMusicians.Models;

namespace CrazyMusicians.Data
{
    public class MusicianData
    {
        // Sanal veri tabanı
        public static List<Musician> musicians = new List<Musician>()
        {
            new Musician { Id = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunFact = "Her zaman yanlış nota çalar, ama çok eğlenceli" },
            new Musician { Id = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunFact = "Şarkıları yanlış anlaşılır ama çok popüler" },
            new Musician { Id = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist", FunFact = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli" },
            new Musician { Id = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi", FunFact = "Nota üretirken sürekli sürprizler hazırlar" },
            new Musician { Id = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı", FunFact = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir" },
            new Musician { Id = 6, Name = "Elif Armoni", Profession = "Armoni Ustası", FunFact = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır" },
            new Musician { Id = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı", FunFact = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir" },
            new Musician { Id = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı", FunFact = "Rezonans konusunda uzman, ama bazen çok gürültü çıkarır" },
            new Musician { Id = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı", FunFact = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç" },
            new Musician { Id = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı", FunFact = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır" }
        };
    }
}
