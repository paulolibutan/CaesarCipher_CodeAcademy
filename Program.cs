using System;

namespace CaesarCipher
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.Write("Enter secret message:   ");
      string inputMsg = Console.ReadLine().ToLower();
      char[] inputArr = inputMsg.ToCharArray();
      string encrypted = String.Join("",Encrypt(inputArr,3));
      Console.WriteLine($"Your encrypted message is: {encrypted}");
      string decrypted = String.Join("",Decrypt(encrypted.ToCharArray(),3));
      Console.WriteLine($"Your decrypted message is: {decrypted}");
    }
    static char[] Encrypt(char[] secretMessage, int key){
        char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        char[] encryptedMessage = new char[secretMessage.Length];
        for (int i = 0; i < secretMessage.Length; i++){
        char letter = secretMessage[i];
          if (Char.IsLetter(letter)){
            int letterPosition = Array.IndexOf(alphabet,letter);
            int newLetterPosition = (letterPosition + key) % 26;
            char encrypted = alphabet[newLetterPosition];
            encryptedMessage[i] = encrypted;
          } else {
          continue;
          }
        }
      return encryptedMessage;
    }
    static char[] Decrypt(char[] encryptedMessage, int key){
        char[] alphabet = new char[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        char[] decryptedMessage = new char[encryptedMessage.Length];
        for (int i = 0; i < encryptedMessage.Length; i++){
          char letter = encryptedMessage[i];
          if (Char.IsLetter(letter)){
              int letterPosition = Array.IndexOf(alphabet,letter);
              int newLetterPosition;
                if ((letterPosition-key) < 0){
                    newLetterPosition = 26 - Math.Abs(letterPosition-key);         
                 }
                 else
                 {
                   newLetterPosition = (letterPosition-key);
                  }
            char decrypted = alphabet[newLetterPosition];
            decryptedMessage[i]= decrypted;
          } else
          {
            continue;
          }
          
        }
        return decryptedMessage;
    }
  }
}