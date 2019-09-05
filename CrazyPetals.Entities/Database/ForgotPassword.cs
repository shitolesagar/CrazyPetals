using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrazyPetals.Entities.Database
{
    public class ForgotPassword
    {
        public int Id { get; set; }
        public int OTP { get; set; }
        public string VerificationCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsUsed { get; set; }
        public string AppId { get; set; }
    }
}
