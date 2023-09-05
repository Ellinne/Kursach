using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GallerySite.Models
{
    public class MetaData
    {
        [StringLength(50)]
        [Display(Name = "Name")]        //Имя
        public string LastName;

        [StringLength(50)]
        [Display(Name = "Surname")]     //Фамилия

        public string FirstName;

        [StringLength(50)]
        [Display(Name = "FatherName")] //Отчество

        public string MiddleName;

        [Display(Name = "Enrollment Date")]

        public Nullable<System.DateTime> EnrollmentDate;
    }
}