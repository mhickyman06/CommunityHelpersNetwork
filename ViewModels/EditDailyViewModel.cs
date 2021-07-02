using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpersNetwork.ViewModels
{
    public class EditDailyView
    {
        public int Id { get; set; }

        [DataType(DataType.Text)]
        public string Body { get; set; }
    }
}
