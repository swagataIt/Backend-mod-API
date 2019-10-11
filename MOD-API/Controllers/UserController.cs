using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MOD_DAL;

namespace MOD_API.Controllers
{
    public class UserController : ApiController
    {
        MOD_BAL.UL userlogic = new MOD_BAL.UL();


        [Route ("api/GetAllData")]
        [HttpGet]
        public IHttpActionResult GettAll()
        {
            var data = userlogic.GetAll();
            return Ok(data);
        }
        [HttpPut]
        [Route("api/EditUserData/{id}")]
        public int EditUserData(int id, UserDtl user)
        {
            return userlogic.EditAllData(id, user);
        }
        [HttpPut]
        [Route("api/EditUserData1/{id}")]
        public int EditUserData1(int id, UserDtl user)
        {
            return userlogic.EditUserData(id, user);
        }

        [Route("api/GetAllPayment")]
        [HttpGet]
        public IHttpActionResult GettAllPay()
        {
            var data = userlogic.GetAllPayment();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/paymentByMentor/{id}")]
        public IHttpActionResult PayementById(int id)
        {
            var data = userlogic.getMentorPayment(id);
            return Ok(data);
        }
        [HttpGet]
        [Route("api/paymentById/{id}")]
        public IHttpActionResult PaymentById(int id)
        {
            var data = userlogic.getPaymentDetailsById(id);
            return Ok(data);
        }
        [HttpGet]
        [Route("api/paymentByMentorId/{id}")]
        public IHttpActionResult PayementByMentorId(int id)
        {
            var data = userlogic.GetPaymentDetails(id);
            return Ok(data);
        }

        [HttpPut]
        [Route("api/paymentEdit/{id}")]
        public int EditPayment(int id, PaymentDtl training)
        {
            return userlogic.UpdatePayment(id, training);
        }

        [Route("api/mentor")]
        [HttpGet]
        public IHttpActionResult MentorOnly()
        {
            var data = userlogic.mentor();
            return Ok(data);
        }

        
        [HttpGet]
        [Route("api/searchTrainer/{name}")]
        public IHttpActionResult SearchTrainer(string name)
        {
            var data = userlogic.Trainer(name);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/userTrainings/{id}")]
        public IHttpActionResult TrainingUser1(int id)
        {
            var data = userlogic.TrainingUser(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/mentorTrainings/{id}")]
        public IHttpActionResult TrainingMentor1(int id)
        {
            var data = userlogic.TrainingMentor(id);
            return Ok(data);
        }

        [HttpGet]
        [Route("api/skillByName/{name}")]
        public IHttpActionResult SkillsByName(string name)
        {
            var data = userlogic.skillByName(name);
            return Ok(data);
        }

        [Route("api/showTech")]
        [HttpGet]
        public IHttpActionResult GettAllTech()
        {
            var data = userlogic.GetAllTech();
            return Ok(data);
        }

        [HttpGet]
        [Route("api/Details/{id}")]
        public UserDtl Details(int id)
        {
            return userlogic.GetDetails(id);
        }

        

        [Route("api/create")]
        [HttpPost]
        public int Create(UserDtl details)
        {
            return userlogic.SignUp(details);
        }

        [Route("api/addtech")]
        [HttpPost]
        public int AddTechnology(SkillDtl details)
        {
            return userlogic.AddTech(details);
        }

        [Route("api/addPayment")]
        [HttpPost]
        public int AddPayment1(PaymentDtl details)
        {
            return userlogic.AddPayment(details);
        }
        [Route("api/addtraining")]
        [HttpPost]
        public int AddTraining1(TrainingDtl details)
        {
            return userlogic.AddTraining(details);
        }

        [Route("api/login")]
        [HttpPost]
        public IHttpActionResult Login(UserDtl userDtl)
        {
            UserDtl result = userlogic.SignIn(userDtl);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/deleteSkills/{id}")]
        public int Delete(int id)
        {
            return userlogic.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("api/trainingDetails/{id}")]
        public TrainingDtl TrainingDetails(int id)
        {
            return userlogic.GetTrainingDetails(id);
        }

        [HttpPut]
        [Route("api/trainingEdit/{id}")]
        public int Edit(int id,TrainingDtl training)
        {
            return userlogic.UpdateTraining(id,training);
        }
    }
}
