﻿using MeetMe.Data.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MeetMe.Data.Models
{
   
    public class User : IdentityUser
    {

                                          
        public bool IsOnline { get; set; }

       
        public DateTime  lastEntryDate { get; set; }
        
        [StringLength(20, ErrorMessage = DataConstants.UserFirstNameMaxLengthErrorMessage)]
        public string FirstName { get; set; }
       
        [StringLength(20, ErrorMessage = DataConstants.UserLastNameMaxLengthErrorMessage)]
        public string LastName { get; set; }
        
        
        public Country Country { get; set; }
        
       
        public City City { get; set; }

        
        public DateTime BirthDay { get; set; }
        
        
        public Sex Sex { get; set; }    
        
       
        public LookingFor LookingFor { get; set; }   
        
       
        [RegularExpression(@"^\d+\.\d{0,2}$",ErrorMessage =DataConstants.UserHeightRangeErrorMessage)]
        [Range(1,2.50)]
        public double Height { get; set; }
      
        [MinLength(1)]
        [MaxLength(500)]
        public int Weight { get; set; } 
       
        
        public EyeColor EyeColor { get; set; }  
        [StringLength(500, ErrorMessage = DataConstants.UserBiographyMaxLengthErrorMessage)]
        public string Biography { get; set; }     
                                                  
      

        public List<Picture> Pictures { get; set; } = new List<Picture>();

        
        public List<Friends> Friends { get; set; } = new List<Friends>();         // Sent Requests

        public List<Friends> Contacts { get; set; } = new List<Friends>();       //Received Requests







         public  List<Messages> Send { get; set; } = new List<Messages>();           //Sent Messages
        public  List<Messages> Received { get; set; } = new List<Messages>();        //Received Messages

       
        

    }










}
