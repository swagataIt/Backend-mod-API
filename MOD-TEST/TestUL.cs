using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD_DAL;
using MOD_BAL;
using NUnit;
using NUnit.Framework;
namespace MOD_TEST
{
    [TestFixture]
    public class Class1
    {
        public UL user = new UL();
        [Test]
        public void GetAll()
        {
            UL uL = new UL();
            IList<UserDtl> user = uL.GetAll();
            Assert.IsNotNull(user);

        }
        [Test]
        public void GetById()
        {

            UserDtl user1 = user.GetDetails(5);
            Assert.IsNotNull(user1);
        }

        [Test]
        public void Register()
        {
            UL user = new UL();
            UserDtl user1 = new UserDtl()
            {
                firstName = "Ritikh",
                lastName = "Jaiswal",
                userName = "ritik",
                password = "12345678",
                email = "ritik12@gmail.com",
                contactNumber = 9851324109,
                linkdinUrl = "",
                yearOfExperience = null,
                training = null,
                active = true,
                role = 1,
            };
            user.SignUp(user1);
            UserDtl user2 = user.GetDetails(11);
            Assert.IsNotNull(user2);
        }


        [Test]
        public void Update()
        {
            PaymentDtl user1 = new PaymentDtl()
            {
                remarks = "",
                amount = 6000,
                mentorId = 46,
                mentorName = "Cornel",
                trainingId = 9,
                skillName = "Artifical Intellegience",
                totalAmountToMentor = 5700,
                commision = 400
            };
            user.UpdatePayment(2, user1);
            PaymentDtl user2 = user.GetPaymentDetails(2);
            Assert.IsTrue(user1.amount == user2.amount && user1.mentorName == user2.mentorName);
        }
        



    }
}
