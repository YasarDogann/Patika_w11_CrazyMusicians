using CrazyMusicians.Models;
using CrazyMusicians.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansControllers : ControllerBase
    {

        // Tüm müzisyenleri çeken endpoint
        [HttpGet] // GET : api/musicians
        public IEnumerable<Musician> GetAllMusicians()
        {
            return MusicianData.musicians;
        }


        // Detay alma işlemi ama ROute belirliyoruz. İd'ye göre getiricez
        [HttpGet("{id:int:min(1)}")] // GET: api/musicians/{id}
        public ActionResult<Musician> GetMusicianById(int id)
        {
            var musician = MusicianData.musicians.FirstOrDefault(x => x.Id == id);
            if (musician is null)
            {
                return NotFound($"{id} no'lu müzisyen bulunamadı");
            }
            return Ok(musician);
        }

        /*
        // Müzisyen kardeşlerimizi Adlarına göre de alalım
        [HttpGet("musician/{name:alpha}")]
        public ActionResult<IEnumerable<Musician>> GetMusicianByName(string name) // ALTTAKİ SEARCH İLE BURADAKİ NAME AYNI PRATİK İÇİN YAPILDI
        {
            // Name içeren müzisyenleri filtrele büyük küçük harf duyarlılığı ypk
            var musician = MusicianData.musicians
                .Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!musician.Any()) // muzisyen içinde herhangi birşey !yoksa
            {
                return NotFound($"{name} adlı müzisyen bulunamadı");
            }
            return Ok(musician);
        }
        */

        //isimle arama yap GET: api/musicians/search?name=Ali
        [HttpGet("search")]
        public ActionResult<IEnumerable<Musician>> SearchMusicians([FromQuery] string name)
        {
            var results = MusicianData.musicians.Where(m => m.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

            if (!results.Any())
            {
                return NotFound($"{name} adlı müzisyen bulunamadı");
            }
            return Ok(results);
        }


        // Yeni Müzisyen ekleme : POST: api/musicians
        [HttpPost]
        public ActionResult AddMusician([FromBody] MusicianDto musicianDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // hatalı giriş varsa döndürür
            }

            // MusicianDto'dan musician modeline dönüş 
            var musician = new Musician
            {
                Id = MusicianData.musicians.Max(x => x.Id) + 1,
                Name = musicianDto.Name,
                Profession = musicianDto.Profession,
                FunFact = musicianDto.FunFact,
            };

            // yeni müzisyeni veri listesine ekleioyrız
            MusicianData.musicians.Add(musician);

            //başarıyla oluşturulduğunu belirtmek için 201 created döndürür
            return CreatedAtAction(nameof(GetMusicianById), new { id = musician.Id }, musician);
        }


        //Müzisyeni Güncelleme PUT: api/musicians/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateMusician(int id, [FromBody] Musician updatedMusician)
        {
            var musician = MusicianData.musicians.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound($"Muzisyen bulunmadı");
            }

            musician.Name = updatedMusician.Name;
            musician.Profession = updatedMusician.Profession;
            musician.FunFact = updatedMusician.FunFact;

            return NoContent();
        }


        // Müsizyeni Kısmen güncelleme PATCH: api/musicians/{id}
        [HttpPatch("{id}")]
        public ActionResult PartiallyUpdateMusician(int id, [FromBody] Musician partialUpdate)
        {
            var result = MusicianData.musicians.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return NotFound($"{id} no'lu müzisyen bulunamadı");
            }

            if (!string.IsNullOrWhiteSpace(partialUpdate.Name)) //MEALİ: yani diyorki; Eğer kullanıcının yazdığı isim Boş değilse kaydet
            {
                result.Name = partialUpdate.Name;
            }

            if (!string.IsNullOrWhiteSpace(partialUpdate.Profession))
            {
                result.Profession = partialUpdate.Profession;
            }

            if (!string.IsNullOrWhiteSpace(partialUpdate.FunFact))
            {
                result.FunFact = partialUpdate.FunFact;
            }
            // Başarıyla güncellenince 204 No Content döner
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMusician(int id)
        {
            var musician = MusicianData.musicians.FirstOrDefault(m => m.Id == id);

            if (musician == null)
            {
                return NotFound($"{id} no'lu müzisyen bulunamadı");
            }
            MusicianData.musicians.Remove(musician);
            return NoContent();
        }
    }
}
