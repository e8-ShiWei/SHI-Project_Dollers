using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dollers.model
{
    public class MainController
    {
        int maxUserID, maxRoomID;
        SortedList<int, User> usersList;
        SortedList<int, Room> roomsList;

        #region 构造方法
        public MainController()
        {
            usersList = new SortedList<int, User>();
            roomsList = new SortedList<int, Room>();
            maxUserID = 0;
            maxRoomID = 0;
        }
        #endregion

        #region 用户管理
        public User createUser(string name)
        {
            User u = new User(maxIDInc(maxUserID), name);
            usersList.Add(u.ID, u);
            return u;
        }
        public void deleteUser(int ID)
        {
            usersList.Remove(ID);
        }
        public int getUserCount()
        {
            return usersList.Count();
        }
        public List<User> getUserList()
        {
            List<User> ulist = new List<User>();
            foreach (KeyValuePair<int, User> item in usersList)
            {
                ulist.Add(item.Value);
            }
            return ulist;
        }
        #endregion

        #region 房间管理
        public Room createRoom(string name, string question, string pwd, int max_count)
        {
            Room m = new Room(maxIDInc(maxRoomID), name, question, pwd, max_count);
            roomsList.Add(m.ID, m);
            return m;
        }
        public Room createRoom(string name, int max_count)
        {
            Room m = new Room(maxIDInc(maxRoomID), name, max_count);
            roomsList.Add(m.ID, m);
            return m;
        }
        public void deleteRoom(int ID)
        {
            roomsList.Remove(ID);
        }
        public int getRoomCount()
        {
            return roomsList.Count();
        }
        public List<Room> getRoomList()
        {
            List<Room> mlist = new List<Room>();
            foreach (KeyValuePair<int, Room> item in roomsList)
            {
                mlist.Add(item.Value);
            }
            return mlist;
        }
        #endregion

        #region 私有方法
        private int maxIDInc(int maxID)
        {
            maxID++;
            if (maxID >= 9999) return 0;
            else return maxID;
        }
        #endregion
    }
}