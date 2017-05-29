using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BibleSortVerses
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadLine();


            ////string functions

            //string firstname;
            //string lastname;

            //firstname = "Winston Henry";
            //lastname = "Haybittle";


            //Console.WriteLine(firstname.Clone());
            //// Make String Clone
            //Console.WriteLine(firstname.CompareTo(lastname));
            ////Compare two string value and returns 0 for true and

            // Console.WriteLine(firstname.Contains("ton")); //Check whether specified value exists or not in string

            //  Console.WriteLine(firstname.EndsWith("n")); //Check whether specified value is the last character of string
            //            Console.WriteLine(firstname.Equals(lastname));
            ////Compare two string and returns true and false


            //Console.WriteLine(firstname.GetHashCode());
            ////Returns HashCode of String

            //Console.WriteLine(firstname.GetType());
            ////Returns type of string

            //Console.WriteLine(firstname.GetTypeCode());
            ////Returns type of string

            //Console.WriteLine(firstname.IndexOf("s")); //Returns the first index position of specified value

            //Console.WriteLine(firstname.ToLower());
            ////Covert string into lower case

            //Console.WriteLine(firstname.ToUpper());
            ////Convert string into Upper case

            //Console.WriteLine(firstname.Insert(0, "Hello")); //Insert substring into string

            //Console.WriteLine(firstname.IsNormalized());
            ////Check Whether string is in Unicode normalization

            //Console.WriteLine(firstname.LastIndexOf("n")); //Returns the last index position of specified value

            //Console.WriteLine(firstname.Length);
            ////Returns the Length of String

            //Console.WriteLine(firstname.Remove(5));
            ////Deletes all the characters from beginning to specified index.

            //Console.WriteLine(firstname.Replace('i', 'y')); // Replace the character

            //string[] split = firstname.Split(new char[] { 'n' }); //Split the string based on specified value


            //Console.WriteLine(split[0]);
            //Console.WriteLine(split[1]);
            //Console.WriteLine(split[2]);

            //Console.WriteLine(firstname.StartsWith("W")); //Check whether first character of string is same as specified value

            //Console.WriteLine(firstname.Substring( 2, 5));
            ////Returns substring

            //Console.WriteLine(firstname.ToCharArray());
            ////Converts an string into char array.

            //Console.WriteLine(firstname.Trim());
            ////It removes starting and ending white spaces from



            //end of string functions
            Program p = new Program();
            p.DoExtractions();
        }


        protected void DoExtractions()
        {
            //label:

            //Console.WriteLine("\n\tMenu");
            //Console.WriteLine("\nPress 1 for add");
            //Console.WriteLine("Press 2 for subtraction");
            //Console.WriteLine("Press 3 for multiplication");
            //Console.WriteLine("Press 4 for Division");
            string connString = @"Server = LAPDOG; Database = BibleTest; Trusted_Connection = True;";
            string sql = @"select Verse from bibleVerse";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                        Console.WriteLine(row[col]);
                    
                    //mine gonna split string on colon : then check string from beginning for a space or/and a alphabetic or non-numeric character, here goes
                    //char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                    //string text = "one\ttwo three:four,five six seven";
                    //System.Console.WriteLine("Original text: '{0}'", text);
                    char[] delimiterChars = { ':', ' ' };
                    string text = "one: three: four five: six: seven";
                    
                   

                    string[] words = text.Split(delimiterChars);
                    System.Console.WriteLine("{0} Split after Colon:", words.Length);
                    foreach (string s in words)
                    {
                        System.Console.WriteLine(s);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            finally
            {
                Console.Beep();
                string EndMsg = "Thanks, Program Ran Successfully";
                EndMsg = Console.ReadLine();
                conn.Close();
            }
        }
    }
}
