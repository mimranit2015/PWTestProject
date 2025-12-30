using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWTestProject.Models
{
       public class CheckBoxModel
        {
            public bool Desktop { get; set; }
            public bool Documents { get; set; }
            public bool Downloads { get; set; }

            public CheckBoxModel(bool desktop, bool documents, bool downloads)
            {
                Desktop = desktop;
                Documents = documents;
                Downloads = downloads;
            }

        public CheckBoxModel(bool desktop)
        {
            Desktop = desktop;
        }
    }
    }


