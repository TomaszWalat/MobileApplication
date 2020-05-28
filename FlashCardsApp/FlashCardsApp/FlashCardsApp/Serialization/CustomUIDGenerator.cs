using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

// LongRandom() by Dyppl - https://stackoverflow.com/questions/6651554/random-number-in-long-range-is-this-the-way

namespace FlashCardsApp.Serialization
{
    class CustomUIDGenerator
    {
        private Dictionary<long, object> _UIDTable;
        private Dictionary<object, long> _objectTable;
        private List<object> _allObjects;

        public CustomUIDGenerator(Dictionary<long, object> UIDTable = null, Dictionary<object, long> objectTable = null, List<object> allObjects = null)
        {
            _UIDTable = UIDTable ?? new Dictionary<long, object>();
            _objectTable = objectTable ?? new Dictionary<object, long>();
            _allObjects = allObjects ?? new List<object>();
        }

        public long GetId(object obj)
        {
            long objectID = 0;

            if (!_objectTable.ContainsKey(obj))
            {
                Random rand = new Random();

                objectID = LongRandom(long.MinValue, long.MaxValue, rand);

                Console.WriteLine("New object UID, object: " + obj.GetType().Name + ", UID: " + objectID);

                _UIDTable.Add(objectID, obj);
                _objectTable.Add(obj, objectID);
            }
            else
            {
                objectID = _objectTable[obj];
            }

            return objectID;
        }

        public object GetObject(long id)
        {
            object obj = null;

            if(_UIDTable.ContainsKey(id))
            {
                obj = _UIDTable[id];
            }

            return obj;
        }

        public bool HasId(object obj)
        {
            return _objectTable.ContainsKey(obj);
        }

        public bool HasId(long id)
        {
            return _UIDTable.ContainsKey(id);
        }

        // 3rd party code
        private long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

    }
}
