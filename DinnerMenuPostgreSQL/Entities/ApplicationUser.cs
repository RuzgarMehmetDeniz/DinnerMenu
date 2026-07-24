using Microsoft.AspNetCore.Identity;

namespace DinnerMenuPostgreSQL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Müşterinin kendi rezervasyon ve yorumlarını "Hesabım" sayfasında gösterebilmek için
        public List<Reservation> Reservations { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
