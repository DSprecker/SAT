﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SAT.DATA.EF
{
    #region Students Metadata

    public class StudentsMetadata
    {

        //public int StudentId { get; set; }



        [Required(ErrorMessage ="*")]
        [Display(Name ="First Name")]
        [StringLength(20, ErrorMessage = "Value must be 20 characters or less.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        [StringLength(20, ErrorMessage = "Value must be 20 characters or less.")]
        public string LastName { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(15, ErrorMessage = "Value must be 15 characters or less.")]
        public string Major { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(50, ErrorMessage = "Value must be 50 characters or less.")]
        public string Address { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(25, ErrorMessage = "Value must be 25 characters or less.")]
        public string City { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(2, ErrorMessage = "Value must be 2 characters or less.")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(10, ErrorMessage = "Value must be 10 characters or less.")]
        public string ZipCode { get; set; }

        [DisplayFormat(NullDisplayText = "[-N/A-]")]
        [StringLength(13, ErrorMessage = "Value must be 13 characters or less.")]
        public string Phone { get; set; }

        [Required(ErrorMessage= "*Must provide a valid email address")]
        [Display(Name = "Email Address")]
        [StringLength(60, ErrorMessage = "Value must be 60 characters or less.")]
        public string Email { get; set; }

        [Display(Name = "Photo URL")]
        public string PhotoUrl { get; set; }


        //public int SSID { get; set; }
    }


    [MetadataType(typeof(StudentsMetadata))]
    public partial class Students
    {
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            
        }
    }
    #endregion

    #region CoursesMetadata

    public class CoursesMetadata
    {

        //public int CourseId { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Course Name")]
        [StringLength(50, ErrorMessage ="*Value must be 50 characters or less.")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Description")]
        [UIHint("MultilineText")]
        public string CourseDescription { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Credit Hours")]
        public byte Credithours { get; set; }
        
        [StringLength(250, ErrorMessage = "*Value must be 250 characters or less.")]
        public string Curriculum { get; set; }

        [UIHint("MultlineText")]
        public string Notes { get; set; }

        [Display(Name = "Active?")]
        public bool IsActive { get; set; }

    }

    #endregion

    #region ScheduledClassesMetadata
    public class ScheduledClassesMetadata
    {

        [Required(ErrorMessage = "*")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }

        [Required(ErrorMessage = "*")]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public System.DateTime EndDate { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Instructor")]
        [StringLength(40, ErrorMessage = "*Value must be 40 characters or less.")]
        public string InstructorName { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Class Location")]
        [StringLength(20, ErrorMessage = "*Value must be 20 characters or less.")]
        public string Location { get; set; }

        //public int SCSID { get; set; }
    } 
    #endregion

    public class EnrollmentsMetaData
    {

    }
}
