using DVLD_Buisness;
using Microsoft.Win32;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace DVLD.Classes
{

    internal static  class clsGlobal
    {
        public static clsUser CurrentUser;
        static string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        public static string sourceName = "DVLD";
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            string dataToSave = Username + "#//#" + Password;
            string ValueName = "Credential";
            try
            {

                string encyptVal = clsUtil.Encrypt(dataToSave);
                Registry.SetValue(KeyPath, ValueName, encyptVal, RegistryValueKind.String);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                EventLog.WriteEntry(sourceName, $"An error occurred while saving credentials: {ex.Message}", EventLogEntryType.Error);
                return false;
            }

            //try
            //{
            //    //this will get the current project directory folder.
            //    string currentDirectory = System.IO.Directory.GetCurrentDirectory();


            //    // Define the path to the text file where you want to save the data
            //    string filePath = currentDirectory + "\\data.txt";

            //    //incase the username is empty, delete the file
            //    if (Username=="" && File.Exists(filePath)) 
            //    { 
            //         File.Delete(filePath);
            //        return true;

            //    }

            //    // concatonate username and passwrod withe seperator.
            //    string dataToSave = Username + "#//#"+Password ;

            //    // Create a StreamWriter to write to the file
            //    using (StreamWriter writer = new StreamWriter(filePath))
            //    {
            //        // Write the data to the file
            //        writer.WriteLine(dataToSave);
                   
            //      return true;
            //    }
            //}
            //catch (Exception ex)
            //{
            //   MessageBox.Show ($"An error occurred: {ex.Message}");
            //    return false;
            //}

        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {

            string ValueName = "Credential";
            //this will get the stored username and password and will return true if found and false if not found.
            try
            {


                object registryValue = Registry.GetValue(KeyPath, ValueName, null);

                // 2. التحقق من أن القيمة موجودة وليست Null قبل البدء
                if (registryValue == null)
                {
                    return false; // نخرج بهدوء لأن البيانات غير موجودة أصلاً
                }
                string encryptedData = registryValue.ToString();
                string decryptedVal = clsUtil.Decrypt(encryptedData);

                if (decryptedVal != null)
                {
                    string[] result = decryptedVal.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    Username = result[0];
                    Password = result[1];
                    return true;
                }
                else
                {
                    return false;

                }
            ////gets the current project's directory
            //string currentDirectory = System.IO.Directory.GetCurrentDirectory();

            //// Path for the file that contains the credential.
            //string filePath  = currentDirectory + "\\data.txt";

            //// Check if the file exists before attempting to read it
            //if (File.Exists(filePath))
            //{
            //    // Create a StreamReader to read from the file
            //    using (StreamReader reader = new StreamReader(filePath))
            //    {
            //        // Read data line by line until the end of the file
            //        string line;
            //        while ((line = reader.ReadLine()) != null)
            //        {
            //            Console.WriteLine(line); // Output each line of data to the console
            //            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

            //            Username = result[0];
            //            Password = result[1];
            //        }
            //        return true;
            //    }
            //}
            //else
            //{
            //    return false;
            //}
            }
            catch (Exception ex)
            {
                MessageBox.Show ($"An error occurred: {ex.Message}");
                EventLog.WriteEntry(sourceName, $"An error occurred while retrieving credentials: {ex.Message}", EventLogEntryType.Error);
                return false;   
            }

        }
    }
}
