using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOD_DAL;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MOD_BAL
{
    public class UL
    {
        public modDBEntities db = new modDBEntities();

        public IList<UserDtl> GetAll()
        {
            return db.UserDtls.ToList();
        }
        public int EditAllData(int id, UserDtl userDtl)
        {
            UserDtl user = db.UserDtls.Find(id);
            if (user != null)
            {
                try
                {
                    user.email = userDtl.email;
                    user.userName = userDtl.userName;
                    user.password = userDtl.password;
                    user.firstName = userDtl.firstName;
                    user.lastName = userDtl.lastName;
                    user.contactNumber = userDtl.contactNumber;
                    user.role = userDtl.role;
                    user.linkdinUrl = userDtl.linkdinUrl;
                    user.yearOfExperience = userDtl.yearOfExperience;
                    user.active = userDtl.active;
                    user.training = userDtl.training;
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            return 1;
        }
        public int EditUserData(int id, UserDtl userDtl)
        {
            UserDtl user = db.UserDtls.Find(id);
            if (user != null)
            {
                try
                {
                    user.email = userDtl.email;
                    user.userName = userDtl.userName;
                    user.password = userDtl.password;
                    user.firstName = userDtl.firstName.ToString();
                    user.lastName = userDtl.lastName.ToString();
                    user.contactNumber = userDtl.contactNumber;
                    user.role = userDtl.role;
                    user.active = userDtl.active;
                    
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {

                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                    ve.PropertyName,
                    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                    ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            return 1;
        }
        public IList<PaymentDtl> GetAllPayment()
        {
            return db.PaymentDtls.ToList();
        }

        public PaymentDtl GetPaymentDetails(int id)
        {
            PaymentDtl details = db.PaymentDtls.Find(id);
            return details;
        }

        public int UpdatePayment(int id, PaymentDtl paymentDtl)
        {
            PaymentDtl pay = db.PaymentDtls.Find(id);
            if (pay != null)
            {
                try
                {
                    pay.amount = paymentDtl.amount;
                    pay.mentorId = paymentDtl.mentorId;
                    pay.mentorName = paymentDtl.mentorName;
                    pay.trainingId = paymentDtl.trainingId;
                    pay.skillName = pay.skillName;
                    pay.totalAmountToMentor = paymentDtl.totalAmountToMentor;
                    pay.commision = paymentDtl.commision;
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            return 1;
        }

        public IList<UserDtl> mentor()
        {
            return db.UserDtls.Where(s => s.role == 2).ToList();
        }
        public IList<PaymentDtl> getMentorPayment(int id)
        {
            return db.PaymentDtls.Where(s => s.mentorId == id).ToList();
        }
        public IList<PaymentDtl> getPaymentDetailsById(int id)
        {
            return db.PaymentDtls.Where(s => s.id == id).ToList();
        }
        public IList<SkillDtl> GetAllTech()
        {
            return db.SkillDtls.ToList();
        }

        public UserDtl GetDetails(int id)
        {
            UserDtl details = db.UserDtls.Find(id);
            return details;
        }

        public TrainingDtl GetTrainingDetails(int id)
        {
            TrainingDtl details = db.TrainingDtls.Find(id);
            return details;
        }
        public IList<TrainingDtl> TrainingUser(int id)
        {
            return db.TrainingDtls.Where(s => s.userId == id).ToList();
        }
        public IList<TrainingDtl> TrainingMentor(int id)
        {
            return db.TrainingDtls.Where(s => s.mentorId == id).ToList();
        }
        public IList<UserDtl> Trainer(string name)
        {
            return db.UserDtls.Where(s => s.training == name).ToList(); 
        }
        public IList<SkillDtl> skillByName(string name)
        {
            return db.SkillDtls.Where(s => s.name == name).ToList(); ;
        }
        public int SignUp(UserDtl newEntry)
        {
            int flag = 0;
            UserDtl details = db.UserDtls.SingleOrDefault(x => x.email == newEntry.email);
            if (details != null)
            {
                flag = 0;
            }
            else
            {
                db.UserDtls.Add(newEntry);
                db.SaveChanges();
                flag = 1;
            }
            return flag;
        }
        public UserDtl SignIn(UserDtl loginDtl)
        {
            UserDtl details = db.UserDtls.SingleOrDefault(x => x.email == loginDtl.email && x.password == loginDtl.password);
            return details;
        }
        public int AddTech(SkillDtl newEntry)
        {
            try
            {
                db.SkillDtls.Add(newEntry);
                db.SaveChanges();
                return 1;
            }
            catch (DbEntityValidationException e)
            {

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                ve.PropertyName,
                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        public int AddPayment(PaymentDtl newEntry)
        {
            try
            {
                db.PaymentDtls.Add(newEntry);
                db.SaveChanges();
                return 1;
            }
            catch 
            {

                
                throw;
            }

        }
        public int AddTraining(TrainingDtl newEntry)
        {
            try
            {
                db.TrainingDtls.Add(newEntry);
                db.SaveChanges();
                return 1;
            }
            catch (DbEntityValidationException e)
            {

                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                ve.PropertyName,
                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                ve.ErrorMessage);
                    }
                }
                throw;
            }

        }
        public int DeleteEmployee(int id)
        {
            SkillDtl emp = db.SkillDtls.Find(id);
            db.SkillDtls.Remove(emp);
            db.SaveChanges();
            return 1;
        }


        public int UpdateTraining(int id,TrainingDtl training)
        {
            TrainingDtl emp = db.TrainingDtls.Find(id);
            if (emp!=null)
            {
                try
                {
                    emp.mentorId = training.mentorId;
                    emp.startDate = training.startDate;
                    emp.endDate = training.endDate;
                    emp.timeSlot = training.timeSlot;
                    emp.userId = training.userId;
                    emp.userName = training.userName;
                    emp.progress = training.progress;
                    emp.status = training.status;
                    emp.mentorId = training.mentorId;
                    emp.mentorName = training.mentorName;
                    emp.skillId = training.skillId;
                    emp.skillname = training.skillname;
                    emp.fees = training.fees;
                    emp.requested = training.requested;
                    emp.rejectNotify = training.rejectNotify;
                    emp.paymentStatus = training.paymentStatus;
                    db.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }
            return 1; 
        }

    }
}
