using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment_5.Models
{
    [Serializable()]
    class Level : ISerializable 
    {
        public uint ID { get; set; }
        public string Name { get; set; }
        public uint RoundsCompleted { get; set; }
        public uint RoundsFailed { get; set; }
        public bool LevelMastered { get; set; }

        public Level()
        {
            RoundsCompleted = 0;
            RoundsFailed = 0;
            LevelMastered = false;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", ID);
            info.AddValue("Name", Name);
            info.AddValue("Completed", RoundsCompleted);
        }

        public Level(SerializationInfo info, StreamingContext context)
        {
            ID = (uint)info.GetValue("ID", typeof(uint));
            Name = (string)info.GetValue("Name", typeof(string));
            RoundsCompleted = (uint)info.GetValue("Completed", typeof(uint));
        }
    }
}
