using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAE_Search_Tool_Client.Models.BusinessLogic
{

        public class DataFromDB
        {
            public long IdData { get; set; }

            private string _Path;
            public string Path
            {
                get
                {
                    return _Path;
                }

                set
                {
                    _Path = value;
                }
            }
            public string EingabeText { get; set; }

        }
    }

