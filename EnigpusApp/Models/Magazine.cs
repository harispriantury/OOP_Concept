using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigpusApp.Models
{
    internal class Magazine : Book
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int PublishYear { get; set; }
        public string Publisher { get; set; }

        public Magazine(string code, string title, int publishYear, string publisher)
        {
            Code = code;
            Title = title;
            PublishYear = publishYear;
            Publisher = publisher;
        }

        public override string getTitle()
        {
            return Title;
        }
    }
}
