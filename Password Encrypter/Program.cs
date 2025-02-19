using System;

namespace Password_Encrypter
{
    internal class Program
    {
        public static Dictionary<int, string> alphabetKeyNum;
        public static Dictionary<string, int> alphabetKeyLetter;

        /// <summary>
        /// Encrypt an inputed word. This is a Caesar cipher.  
        /// </summary>
        /// <param name="word"> Inputed word to encrypt. </param>
        /// <param name="key"> Key that results in a specific encryption. </param>
        /// <returns> encrypted input string. </returns>
        private static string encrypt(string word, int key)
        {
            string encryptedWord = "";
                   
            // Loop length of inputed word.
            foreach (char c in word)
            {
                // Check for upper case.
                if (char.IsUpper(c))
                {
                    int num = alphabetKeyLetter[c.ToString()];
                    int searchNum = num + key;

                    // check overflow.
                    if (searchNum > 26)
                    {
                        searchNum = searchNum - 26;
                    }

                    encryptedWord += alphabetKeyNum[searchNum];
                }
                // Check for space.
                else if (c == ' ')
                {
                    encryptedWord += ' ';
                }
                // its lower case.
                else
                {
                    int num = alphabetKeyLetter[c.ToString().ToUpper()];
                    int searchNum = num + key;

                    // check overflow.
                    if (searchNum > 26)
                    {
                        searchNum = searchNum - 26;
                    }

                    encryptedWord += alphabetKeyNum[searchNum].ToLower();
                }
            }

            return encryptedWord;
        }

        /// <summary>
        /// decrypt inputed word. This is a Caesar cipher. 
        /// </summary>
        /// <param name="word"> Inputed word to decrypt. </param>
        /// <param name="key"> Key that results in specific decryption. </param>
        /// <returns> decrypted input string. </returns>
        private static string decrypt(string word, int key)
        {
            string decryptWord = "";

            foreach (char c in word)
            {
                // Check for upper case.
                if (char.IsUpper(c))
                {
                    int num = alphabetKeyLetter[c.ToString()];
                    int searchNum = num - key;

                    // check overflow.
                    if (searchNum < 1)
                    {
                        searchNum = searchNum + 26;
                    }

                    decryptWord += alphabetKeyNum[searchNum];
                }
                // Check for space.
                else if (c == ' ')
                {
                    decryptWord += ' ';
                }
                // its lower case.
                else
                {
                    int num = alphabetKeyLetter[c.ToString().ToUpper()];
                    int searchNum = num - key;
                    
                    // check overflow.
                    if (searchNum < 1)
                    {
                        searchNum = searchNum + 26;
                    }

                    decryptWord += alphabetKeyNum[searchNum].ToLower();
                }
            }

            return decryptWord;
        }

        static void Main(string[] args)
        {
            alphabetKeyNum = new Dictionary<int, string>()
            {
                { 1, "A" },
                { 2, "B" },
                { 3, "C" },
                { 4, "D" },
                { 5, "E" },
                { 6, "F" },
                { 7, "G" },
                { 8, "H" },
                { 9, "I" },
                { 10, "J" },
                { 11, "K" },
                { 12, "L" },
                { 13, "M" },
                { 14, "N" },
                { 15, "O" },
                { 16, "P" },
                { 17, "Q" },
                { 18, "R" },
                { 19, "S" },
                { 20, "T" },
                { 21, "U" },
                { 22, "V" },
                { 23, "W" },
                { 24, "X" },
                { 25, "Y" },
                { 26, "Z" }
            };

            alphabetKeyLetter = new Dictionary<string, int>()
            {
                { "A", 1 },
                { "B", 2 },
                { "C", 3 },
                { "D", 4 },
                { "E", 5 },
                { "F", 6 },
                { "G", 7 },
                { "H", 8 },
                { "I", 9 },
                { "J", 10 },
                { "K", 11 },
                { "L", 12 },
                { "M", 13 },
                { "N", 14 },
                { "O", 15 },
                { "P", 16 },
                { "Q", 17 },
                { "R", 18 },
                { "S", 19 },
                { "T", 20 },
                { "U", 21 },
                { "V", 22 },
                { "W", 23 },
                { "X", 24 },
                { "Y", 25 },
                { "Z", 26 },
            };

            //----------------------------------------------------------------Read user input.

            Console.WriteLine("Enter 1 if you want to encrypt. 2 if you want to decrypt.");
            int ans = Convert.ToInt32(Console.ReadLine());

            int key;

            // Query if the user wants to encrypt or decrypt.
            if (ans == 1)
            {
                Console.WriteLine("Enter Word to Encrypt...");
                string wordToEncryipt = Console.ReadLine();

                Console.WriteLine("Enter Key number. Remember this number.");
                key = Convert.ToInt32(Console.ReadLine());

                string encriptedWord = encrypt(wordToEncryipt, key);
                Console.WriteLine(encriptedWord);
            }
            else
            {
                Console.WriteLine("Enter Key number.");
                key = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Word to decrypt...");
                string wordToDecrypt = Console.ReadLine();

                string decryptedWord = decrypt(wordToDecrypt, key);
                Console.WriteLine(decryptedWord);
            }                        
        }       
    }
}
