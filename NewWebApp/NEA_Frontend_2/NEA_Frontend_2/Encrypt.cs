using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace NEA_Frontend_2
{
    public class Encrypt
    {
        public string encrypt(string plaintext, string key)
        {

            // Plaintext converted into a binary array
            byte[] BinaryPlaintext = Encoding.ASCII.GetBytes(plaintext);
            // Key converted into binary array
            byte[] BinaryKey = Encoding.ASCII.GetBytes(key);
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
                // Convert back into ascii characters
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
            int[] EncryptedText = new int[128];
            for (int i = 0; i < BinaryKey.Length; i++)
            {
                EncryptedText[i] = BinaryKey[i] ^ BinaryPlaintext[i];
            }
            string chars = "";
            int j = 0;
            while (EncryptedText[j] > 0)
            {
                chars += Convert.ToChar(EncryptedText[j]);
                //Console.WriteLine(chars[j]);
                j++;
            }
            Console.WriteLine(chars + " Decrypted");
            return chars;

        }
        private byte ToBinary(string num)
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
            string hash_Text = Encoding.ASCII.GetString(data);
            return hash_Text;
        }
    }
}

