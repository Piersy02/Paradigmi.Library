﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Paradigmi.Library.Models.Entities;

namespace Paradigmi.Library.Application.Models.Requests
{
    public class AddBookRequest
    {
        public AddBookRequest(string name, string author, string editor, DateTime publicationDate, HashSet<string> categories)
        {
            Name = name;
            Author = author;
            Editor = editor;
            PublicationDate = publicationDate;
            Categories = categories;
        }

        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Editor { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public HashSet<string> Categories { get; set; } = new HashSet<string>();


    }
}
