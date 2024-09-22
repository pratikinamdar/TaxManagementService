using Microsoft.AspNetCore.Mvc;
using TaxManagement.Models;

namespace TaxManagement.Controllers
{
    public class UserController:ControllerBase
    {

        private TaxDb db;
        public UserController(IConfiguration config)
        {
             db = new TaxDb (config.GetConnectionString("connstr"));
        }

        [HttpPost("Users", Name = "PostUser")]

        public void PostUser(UserParams user)
        {
            UserProfile u = new UserProfile() { Name = user.Name, Contact = user.Contact, Single = user.Single, Income = user.Income };

            db.UserProfile.Add(u);
            db.SaveChanges();
        }

        [HttpGet("Users", Name="GetUser")]

        public IEnumerable<UserProfile> GetUserProfiles() 
        {
            var userProfiles = (from u in db.UserProfile
                                select u).ToList();
            return userProfiles;
        }


        [HttpGet("Users/{ProfileId}", Name = "GetUserById")]
        public UserProfile GetUserById(int ProfileId)
        {
            var u = (from x in db.UserProfile
                    where x.ProfileId == ProfileId
                     select x).First();
            return u;
        }

        [HttpGet("CalculateTax/{ProfileId}/{Year}", Name = "TaxCalc")]

       public UserTax TaxCalc(TaxCalInput Tax)
        {
            var u = (from x in db.UserProfile
                    where x.ProfileId == Tax.ProfileId
                    select x).First();
            float taxc = 0;
            if (u.Single == true)
            {
                taxc = (u.Income * 30) / 100;
            }
            else
            {
                taxc = (u.Income * 20) / 100;
            }

            UserTax ut = new UserTax() { Name = u.Name, Single = u.Single, Contact = u.Contact, Income = u.Income, Tax = taxc };

            TaxHistory th = new TaxHistory() { ProfileId = u.ProfileId, Income=u.Income, TaxPaid=taxc, Year = Tax.Year };
            db.TaxHistory.Add(th);
            db.SaveChanges();
            return ut;
        }

        [HttpGet("TaxHistory/{ProfileId}", Name = "GetUserTaxHistory")]

        public IEnumerable<TaxHistory> GetUserTaxHistory(int ProfileId)
        {
            var th = (from t in db.TaxHistory
                     where t.ProfileId == ProfileId
                     select t).ToList();
            return th;
        }

    }
}
