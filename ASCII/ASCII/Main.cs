using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    internal class Main
    {
        class VigenereCipher
        {
            private const int ASCII_MIN = 32;
            private const int ASCII_MAX = 127;
            private const int ASCII_RANGE = ASCII_MAX - ASCII_MIN;

            private char[] alphabet;

            public VigenereCipher()
            {

                alphabet = new char[ASCII_RANGE];
                for (int i = 0; i < ASCII_RANGE; i++)
                {
                    alphabet[i] = (char)(ASCII_MIN + i);
                }
            }

            private string ExtendKey(string key, int length)
            {
                StringBuilder extendedKey = new StringBuilder();
                int keyLength = key.Length;
                for (int i = 0; i < length; i++)
                {
                    extendedKey.Append(key[i % keyLength]);
                }
                return extendedKey.ToString();
            }

            public string Encrypt(string text, string key)
            {
                StringBuilder encryptedText = new StringBuilder();
                string extendedKey = ExtendKey(key, text.Length);
                for (int i = 0; i < text.Length; i++)
                {
                    char currentChar = text[i];
                    int index = Array.IndexOf(alphabet, currentChar);
                    int shift = (int)extendedKey[i] - ASCII_MIN;
                    index = (index + shift) % ASCII_RANGE;
                    encryptedText.Append(alphabet[index]);

                }
                return encryptedText.ToString();
            }

            public string Decrypt(string encryptedText, string key)
            {
                StringBuilder decryptedText = new StringBuilder();
                string extendedKey = ExtendKey(key, encryptedText.Length);
                for (int i = 0; i < encryptedText.Length; i++)
                {
                    char currentChar = encryptedText[i];
                    int index = Array.IndexOf(alphabet, currentChar);
                    int shift = (int)extendedKey[i] - ASCII_MIN;
                    index = (index - shift + ASCII_RANGE) % ASCII_RANGE;
                    decryptedText.Append(alphabet[index]);
                }
                return decryptedText.ToString();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                VigenereCipher cipher = new VigenereCipher();

                Console.Write("Enter the text to encrypt/decrypt: ");
                string text = Console.ReadLine();

                Console.Write("Enter the key: ");
                string key = Console.ReadLine();

                string encryptedText = cipher.Encrypt(text, key);
                string decryptedText = cipher.Decrypt(encryptedText, key);

                Console.WriteLine("Encrypted text: " + encryptedText);
                Console.WriteLine("Decrypted text: " + decryptedText);

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
