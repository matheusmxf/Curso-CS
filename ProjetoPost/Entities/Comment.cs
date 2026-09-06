using System;
using System.Collections.Generic;
using System.Text;

namespace Course.Entities
{
    class Comment
    {
        public string Text { get; set; }
        
#pragma warning disable CS8618
        public Comment()

        {
            
        }

        public Comment(string text)
        { 
            Text = text;
        }
    }
}