using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_intro_1.Common.Business.ResponseMessages
{
    public static class ResponseMessages
    {
    
        public static string PersonNotFound="Person Not Found";
        public static string  PersonNotDeleted="Person cannot be deleted due to some assigned tasks";

        public static string  BucketNotFound="Bucket is not Found";
        public static string  BucketNotDeleted="Bucket can not be deleted due some task(s) assigned to it ";
        public static string  BucketAlreadyExist="Bucket called  is already exist please try different title";
        public static string  BucketIsFull = "Bucket is full";
        
        public static string  TaskNotFound="Task is not exist";
        public static string  TaskOrPersonNotFound="Invalid person or task id";
       
       

    }
}
