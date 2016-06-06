using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlgorithmsDemo.Models
{
    public class DataModel
    {
        //input models
        public double FiboInput { get; set; }
        public double PrimeInput { get; set; }
        public string[] StringInput { get; set; }

        //output models
        public List<string> NFibonacciNumbers { get; set; }        
        public List<string> PrimeNumbersLessThanN { get; set; }
        public List<string> SortedStrings { get; set; }
    }
}