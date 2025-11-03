using BorderControl.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public Robot(string id, string model)
        {
            ID = id;
            Model = model;
        }
        public string ID {  get; set; }
        public string Model { get; set; }
    }
}
