using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResearch
{
    public class Human
    {
        public int age { get; set; }
        public int sizeInCM { get; set; }
        public int iq { get; set; }
        public bool hasFamily { get; set; }
        public bool isObese { get; set; }
        public string firstname { get; set; }
        public string familyname { get; set; }
        public string civilstatus { get; set; }
        public string hometown { get; set; }
        public string religion { get; set; }
        public string shoesize, topsize, bottomsize, cupsize;
        public Dictionary<string, string> residence { get; set; }
        public Dictionary<string, object> workplace { get; set; }
        public Dictionary<string, List<string>> interests { get; set; }
        public Dictionary<string, List<string>> hobbies { get; set; }
        public Dictionary<string, string> deseases { get; set; }
        public Dictionary<string, Dictionary<string, string>> contacts { get; set; }
        public Geschlecht gender { get; set; }
        public Sternzeichen starsign { get; set; }
        public Blutgruppe bloodtype { get; set; }
        public Beziehungsstatus relationshipstatus { get; set; }
        public DateTime birthdate { get; set; }

        //Enumerations
        public enum Geschlecht { Male, Female, Other }
        public enum Sternzeichen { Aquarius, Pisces, Aries, Taurus, Gemini, Cancer, Leo, Virgo, Libra, Scorpio, Sagittarius, Capricorn }
        public enum Beziehungsstatus { Single, In_a_relationship, Complicated, Friendzoned}
        public enum Blutgruppe { A, B, AB, O }

        /************************************
         *********** Methods ****************
         ************************************/

        //createInstance
        public Human createInstance() { return this; }
        public Human createInstance(string fi_name, string fa_name)
        {
            Human i = new Human();
            i.firstname = fi_name;
            i.familyname = fa_name;
            return i;
        }

        public Human createInstance(string fi_name, string fa_name, int age)
        {
            Human i = new Human();
            i.firstname = fi_name;
            i.familyname = fa_name;
            i.age = age;
            return i;
        }

        public Human createInstance(string fi_name, string fa_name, int age, Geschlecht gender)
        {
            Human i = new Human();
            i.firstname = fi_name;
            i.familyname = fa_name;
            i.age = age;
            i.gender = gender;
            return i;
        }

        public Human createInstance(string fi_name, string fa_name, int age, Geschlecht gender, int size)
        {
            Human i = new Human();
            i.firstname = fi_name;
            i.familyname = fa_name;
            i.age = age;
            i.gender = gender;
            i.sizeInCM = size;
            return i;
        }

        public Human createInstance(string fi_name, string fa_name, int age, Geschlecht gender, int size, DateTime birthdate)
        {
            Human i = new Human();
            i.firstname = fi_name;
            i.familyname = fa_name;
            i.age = age;
            i.gender = gender;
            i.sizeInCM = size;
            i.birthdate = birthdate;
            return i;
        }

        //Other Methods
        public bool hasDeseases()
        {
            if (!( this.deseases.Count <= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addResidence(string town, string adress)
        {
            residence.Add(town, adress);
        }

        public void addWorkplace(string subject, object objects)
        {
            workplace.Add(subject, objects);
        }

        public void addInterests(string category, List<string> interests)
        {
            this.interests.Add(category, interests);
        }

        public void addHobbies(string category, List<string> hobbies)
        {
            this.hobbies.Add(category, hobbies);
        }

        public void addDesease(string type, string name)
        {
            deseases.Add(type, name);
        }

        public void addContact(string relationship, Dictionary <string, string> name)
        {
            contacts.Add(relationship, name);
        }

        public DateTime newBirthday(int day, int month, int year)
        {
           return new DateTime(day, month, year);
        }
    }
}
