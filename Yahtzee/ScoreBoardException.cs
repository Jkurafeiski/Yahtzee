using System;
using System.Runtime.Serialization;

namespace Yahtzee
{
    public class ScoreBoardException : Exception
    {
        public ScoreBoardException(string message)
        : base(message)
        {
            
        }

        public ScoreBoardException(string message, Exception innerException)
        : base(message, innerException)
        {
            
        }

        public ScoreBoardException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
            
        }
    }
}