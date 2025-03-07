﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace NEA_Frontend_2
{
    public interface IEncrypt //Use of interface
    {
        string encrypt(string plaintext); //Encrypts the plaintext and generates a key
        string decrypt(string EncryptedTxt, string key); //Decrypts the encrypted text
        string Hash(string Text); //Returns a hash value of the text
        string Get_Key(); //Returns the key used in the last encryption
    }
    public class Encrypt : IEncrypt
    {
        private static string _key;
 
        public string encrypt(string plaintext)
        {
            _key = Generate_Key(plaintext.Length);
            // Plaintext converted into a binary array
            byte[] BinaryPlaintext = Encoding.ASCII.GetBytes(plaintext);
            // Key converted into binary array
            byte[] BinaryKey = Encoding.ASCII.GetBytes(_key);
            int[] EncryptedText = new int[128];
            // XOR the binary key and binary plaintext
            for (int i = 0; i < BinaryPlaintext.Length; i++)
            {
                EncryptedText[i] = BinaryKey[i] ^ BinaryPlaintext[i];
            }
            string chars = " ";
            int j = 0;
            while (EncryptedText[j] > 0)
            {
                // Convert back into ascii character numbers
                chars += (EncryptedText[j]) + ",";
                j++;
            }
            
            return chars;
        }
        public string decrypt(string EncryptedTxt, string key)
        {
            // Splits the CSV numbers into an array
            string[] split = EncryptedTxt.Split(',');
            // Initialise array for the binary plaintext
            byte[] BinaryPlaintext = new byte[split.Length];

            for (int i = 0; i < split.Length - 1; i++)
            {
                BinaryPlaintext[i] = ToBinary(split[i]);
            }

            byte[] BinaryKey = Encoding.ASCII.GetBytes(key);
            int[] Plaintext = new int[128];
            for (int i = 0; i < BinaryKey.Length; i++)
            {
                Plaintext[i] = BinaryKey[i] ^ BinaryPlaintext[i]; //XOR the binary key and binary plaintext
            }
            string chars = "";
            int j = 0;
            while (Plaintext[j] > 0)
            {
                chars += Convert.ToChar(Plaintext[j]); //Converts from binary to ascii characters
               
                j++;
            }
            Console.WriteLine(chars + " Decrypted");
            return chars;

        }
        private byte ToBinary(string num) // Converts an ascii key to binary
        {

            int AsciiNum = Convert.ToInt32(num);

            string binary = Convert.ToString(AsciiNum, 2);
            if (binary.Length != 8)
            {
                for (int i = 0; i < 8 - binary.Length; i++)
                {
                    binary = "0" + binary;
                }
            }
            byte binaryByte = Convert.ToByte(binary, 2);
            return binaryByte;

        }
        public string Hash(string Text) // Hashes the text 
        {
            byte[] data = Encoding.ASCII.GetBytes(Text);
            data = new SHA256Managed().ComputeHash(data);
            string hashstring = Encoding.ASCII.GetString(data);
            hashstring = hashstring.Substring(hashstring.Length - 15); //Returns the final 15 letters of the string
            return hashstring;

        }
        private string Generate_Key(int len) // Generates a random key with same length as the text
        {
            Random rand = new Random();
            string key = "";
            char[] chars = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            for (int i = 0; i < len; i++)
            {
                key += chars[rand.Next(0,36)];
            }
            return key;
        }
        public string Get_Key()
        {
            if (_key == null)
            {
                return "No key has been generated";
            }
            else
            {
                return _key;
            }
        }
    }
}

