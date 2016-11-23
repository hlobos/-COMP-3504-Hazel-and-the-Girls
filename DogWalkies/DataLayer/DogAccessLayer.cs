using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace DogWalkies
{
    class DogAccessLayer
    {
        //Code for singleton design pattern setup
        private static DogAccessLayer data = null;

        public static DogAccessLayer getInstance()
        {
            if (data == null)
                data = new DogAccessLayer();

            return data;
        }

        //Regular class data and methods
        private SQLiteConnection dbConnection = null;

        /*=====================================================================
        * Constructor
        =====================================================================*/
        private DogAccessLayer()
        {
            setUpDB();
        }

        /*=====================================================================
         * Deconstructor (Called when the object is destroyed)
         * closes connection to the database
          =====================================================================*/
        ~DogAccessLayer()
        {
            shutDown();
        }

        /*=====================================================================
        * Deconstructor (Called when the object is destroyed);
         =====================================================================*/
        private void shutDown()
        {
            if (dbConnection != null)
                dbConnection.Close();
        }

        /*=====================================================================
         * Initial setup of tables in the database
         =====================================================================*/
        private void setUpTables()
        {
            dbConnection.CreateTable<Dog>();
        }

        /*=====================================================================
         * Initial connection to the database
         =====================================================================*/
        private void setUpDB()
        {
            //get the path to where the application can store internal data 
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string dbFileName = "AppData.db"; // name we want to give to our db file
            string fullDBPath = System.IO.Path.Combine(folderPath, dbFileName); // properly formate the path for the system we are on

            //if file does not already exist it will be created for us
            dbConnection = new SQLiteConnection(fullDBPath);
            setUpTables(); // this happens very time.
        }

        public void addDog(Dog info)
        {
            dbConnection.Insert(info);
        }

        public Dog getDogByID(int id)
        {
            return dbConnection.Get<Dog>(id);
        }

        public void deleteDogByID(int id)
        {
            dbConnection.Delete<Dog>(id);
        }

        public void updateDogInfo(Dog info)
        {
            dbConnection.Update(info);
        }

        public List<Dog> getAllDogs()
        {
            //gets all elements in the Student table and packages it into a List
            return new List<Dog>(dbConnection.Table<Dog>());
        }


        public List<Dog> getAllDogsOrdered()
        {
            //Same as getAllDogs() and ordered by dog first name
            return new List<Dog>(dbConnection.Table<Dog>().OrderBy(doggo => doggo.FirstName));
        }

    }
}