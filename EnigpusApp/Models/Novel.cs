using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnigpusApp.Models
{
    internal class Novel : Book
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int publishYear { get; set; }
        public string writer { get; set; }

        public Novel(string code, string title, string publisher, int publishYear, string writer)
        {
            Code = code;
            Title = title;
            Publisher = publisher;
            this.publishYear = publishYear;
            this.writer = writer;
        }

        public override string getTitle()
        {
            return Title;
        }
    }
}
