using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Carp.Models
{
    public enum MessageStatus { Noraml, Error }
    public class Message
    {
        public Message(string value)
        {
            Value = value;
        }
        public string Value { get; set; }
        public MessageStatus Status { get; set; }
    }
}
