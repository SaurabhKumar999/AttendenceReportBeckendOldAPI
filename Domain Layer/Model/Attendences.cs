using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Model
{
    
    public class Attendences
    {
        [Key]
        public int EmpId
        {
            get;
            set;
        }
        public string? EmpName
        {
            get;
            set;
        }
        public string? month
        {
            get;
            set;
        }

        public string? Designation
        {
            get;
            set;
        }
        public DateTime? Date
        {
            get;
            set;
        }
     
        public string? Status
        {
            get;
            set;
        }
        public DateTime? LoginTime
        {
            get;
            set;
        }
        public DateTime? LogoutTime
        {
            get;
            set;
        }
        public DateTime? Hours
        {
            get;
            set;
        }
    }
}
    
