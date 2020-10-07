using _03_Badges_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03_Badges_Repository
{
    public class BadgesRepository
    {
        protected static Dictionary<int, DoorNames> _list = new Dictionary<int, DoorNames>();


        public bool AddContentToDictionary(Badges content)
        {
            if (!_list.ContainsKey(12345))
            {
                _list.Add(12345, DoorNames.A1);
            }

            return true;


        }
        public Dictionary<int, DoorNames> GetContent()
        {
            return _list;
        }

        public bool GetContentByID()
        {
            Dictionary<int, DoorNames>.KeyCollection key = _list.Keys;
            foreach (int number in key)
            {
                return true;
            }
            return false;
        }


        public bool DeleteExistingContent(Badges existingContent)
        {
            bool deleteResult = _list.Remove(12345);
            return deleteResult;
        }
    }
}




